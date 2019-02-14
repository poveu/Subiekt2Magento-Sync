using InsERT;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiekt2Magento_Sync
{
    public partial class MainForm : Form
    {
        const int tab1_childrenColumnId = 3;
        const int tab1_similarColumnId = 4;

        int tab1_statusColumnId;
        int tab2_statusColumnId;

        SqlConnection subConnection;

        static string subServer;
        static string subDatabase;
        static string subUid;
        static string subUpwd;

        static bool replace;
        static string mageUrl;
        static string mageToken;

        static string subiektLinked;
        static string subiektSimilar;
        static string subiektLinkedCode;
        static string subiektSimilarCode;

        static string subUser;
        static string subUserPass;

        DataTable attributesTable;
        Dictionary<string, Dictionary<string, string>> attributeKeys;

        public MainForm()
        {
            InitializeComponent();
        }

        async void LoadSettings()
        {
            subServer = Settings.Default.sql_server;
            subDatabase = Settings.Default.sql_database;
            subUid = Settings.Default.sql_username;
            subUpwd = Settings.Default.sql_password?.DecryptString();
            replace = Settings.Default.replace;
            subUser = Settings.Default.subiekt_user;
            subUserPass = Settings.Default.subiekt_password?.DecryptString();
            subiektLinked = Settings.Default.subiekt_linked;
            subiektSimilar = Settings.Default.subiekt_similar;
            subiektLinkedCode = Settings.Default.subiekt_linked_code;
            subiektSimilarCode = Settings.Default.subiekt_similar_code;

            mageUrl = Settings.Default.api_url;
            mageToken = Settings.Default.api_token?.DecryptString();

            switch (tabControl.SelectedIndex)
            {
                case 0:
                default:
                    await LoadProducts();
                    break;
                case 1:
                    await LoadProductsInfo();
                    break;
            }
        }

        async Task<bool> SaveProducts(int rowIndex)
        {
            DataGridView list = dataGridViewLinks;

            using (subConnection = new SqlConnection(@"Data source=" + subServer + ";database=" + subDatabase + ";User id=" + subUid + ";Password=" + subUpwd + ";"))
            {
                using (SqlCommand komendaSQL = subConnection.CreateCommand())
                {
                    try
                    {
                        Log(new LogType("Łączenie z serwerem Subiekta...", 0));
                        await subConnection.OpenAsync();

                        DataGridViewRow row = list.Rows[rowIndex];
                        string sku = row.Cells[0].Value.ToString();

                        Log(new LogType(String.Format("Zapisywanie danych towaru {0}... ", sku), 0));

                        komendaSQL.CommandText = @"
					        UPDATE pw_Dane
					        SET
                                " + subiektLinkedCode + @" = '" + row.Cells[tab1_childrenColumnId].Value + @"',
                                " + subiektSimilarCode + @" = '" + row.Cells[tab1_similarColumnId].Value + @"'
					        WHERE pwd_IdObiektu = (
						        SELECT tw_Id
						        FROM tw__Towar
						        WHERE tw_Symbol = '" + sku + @"'
					        )
					        ";

                        int resultCount = await komendaSQL.ExecuteNonQueryAsync();

                        if (resultCount > 0)
                            row.Cells[tab1_statusColumnId].Value = "Zapisano zmiany";
                        else
                            row.Cells[tab1_statusColumnId].Value = "Nie udało się zapisać";

                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        Log(new LogType(String.Format("Nie udało się wczytać listy towarów z Subiekta. Treść błędu: {0}", e.Message), 2));
                        return false;
                    }
                }

                return true;
            }
        }

        async Task<bool> LoadProducts()
        {
            DataGridView list = dataGridViewLinks;
            list.Columns.Clear();
            list.DataSource = null;
            list.DoubleBuffered(true);

            string commandText = @"
					SELECT
						tw_Symbol AS 'Symbol',
						tw_Nazwa AS 'Nazwa',
						grt_Nazwa AS 'Grupa',
						" + subiektLinkedCode + @" AS 'Powiązane',
                        " + subiektSimilarCode + @" AS 'Podobne'
					FROM tw__Towar
					JOIN pw_Dane
						ON pwd_IdObiektu = tw_Id
					JOIN sl_GrupaTw
						ON tw_IdGrupa = grt_Id
					WHERE
                        tw_SklepInternet = 1
                        AND tw_Zablokowany = 0
                    GROUP BY
                        tw_Symbol, tw_Nazwa, grt_Nazwa, " + subiektLinkedCode + @", " + subiektSimilarCode + @"
					ORDER BY
                        CASE WHEN (" + subiektSimilarCode + @" = '' OR " + subiektSimilarCode + @" IS NULL) THEN " + subiektLinkedCode + @" ELSE " + subiektSimilarCode + @" END DESC, tw_Symbol
					";

            DataTable dataTable = null;
            dataTable = await SubiektCall(commandText);

            if (dataTable != null)
            {
                comboBoxLinksFilterGroup.Items.Clear();
                comboBoxLinksFilterGroup.Items.Add("(dowolna grupa)");

                foreach (DataRow row in dataTable.Rows)
                {
                    string groupName = row["Grupa"].ToString();
                    if (!comboBoxLinksFilterGroup.Items.Contains(groupName))
                        comboBoxLinksFilterGroup.Items.Add(groupName);
                }

                comboBoxLinksFilterGroup.SelectedIndex = 0;

                list.DataSource = dataTable;

                DataGridViewTextBoxColumn statusCol = new DataGridViewTextBoxColumn();
                statusCol.HeaderText = "Status";
                statusCol.ReadOnly = true;
                statusCol.Name = "Status";
                statusCol.MinimumWidth = 150;

                tab1_statusColumnId = list.Columns.Count;
                list.Columns.Insert(tab1_statusColumnId, statusCol);

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Width = 50;
                chk.HeaderText = "Prześlij";
                chk.ReadOnly = false;
                chk.Name = "Prześlij";

                list.Columns.Insert(list.ColumnCount, chk);

                list.Columns[0].ReadOnly = true;
                list.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                list.Columns[1].ReadOnly = true;
                list.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                list.Columns[2].ReadOnly = true;
                list.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                list.Columns[tab1_childrenColumnId].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                list.Columns[tab1_childrenColumnId].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                list.Columns[tab1_childrenColumnId].MinimumWidth = 200;
                list.Columns[tab1_childrenColumnId].ReadOnly = false;
                ((DataGridViewTextBoxColumn)list.Columns[tab1_childrenColumnId]).MaxInputLength = 255;

                list.Columns[tab1_similarColumnId].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                list.Columns[tab1_similarColumnId].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                list.Columns[tab1_similarColumnId].MinimumWidth = 200;
                list.Columns[tab1_similarColumnId].ReadOnly = false;
                ((DataGridViewTextBoxColumn)list.Columns[tab1_similarColumnId]).MaxInputLength = 255;

                list.Columns[tab1_statusColumnId].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                buttonSendLinks.Enabled = true;

                Log(new LogType("Wczytano listę towarów", 1), true);
                return true;

            }

            return false;

        }

        void DataGridViewLinksKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                DataGridViewCell currentCell = dataGridViewLinks.CurrentCell;
                if ((currentCell != null) && ((currentCell.ColumnIndex != tab1_childrenColumnId) || (dataGridViewLinks.SelectedCells.Count > 1)))
                {
                    DataGridViewCell firstSelected = dataGridViewLinks.Rows[dataGridViewLinks.SelectedCells[0].RowIndex].Cells[dataGridViewLinks.Columns.Count - 1];
                    bool select = (firstSelected.Value != null && (bool)firstSelected.Value) ? false : true;

                    foreach (DataGridViewRow row in dataGridViewLinks.SelectedRows)
                    {
                        row.Cells[dataGridViewLinks.ColumnCount - 1].Value = select;
                    }
                    e.Handled = true;
                }
            }

            if ((e.KeyData == (Keys.Control | Keys.C)))
            {
                CopyFullData();
            }
        }

        async void ButtonSendLinks_Click(object sender, EventArgs e)
        {
            buttonSendLinks.Enabled = false;
            string result = await SaveLinks();

            Log((result != null && result == "true") ?
                new LogType(String.Format("Zakończono przetwarzanie powiązań towarów"), 1)
                : new LogType(String.Format("Wystąpił błąd w trakcie wysyłania powiązań towarów na serwer sklepu. Treść błędu: {0}", result), 2));
            buttonSendLinks.Enabled = true;
        }

        public class LogType
        {
            string message;
            int status;

            public LogType(string message, int status)
            {
                this.message = message;
                this.status = status;
            }

            public string getMessage()
            {
                return message;
            }

            public int getStatus()
            {
                return status;
            }
        }

        async Task<string> SaveLinks()
        {
            string parentSKU;
            string childrenSKUs;
            string similarSKUs;

            Log(new LogType("Rozpoczynanie procesu zapisywania powiązań...", 0));

            progressBarLinks.Maximum = dataGridViewLinks.Rows.Count;
            progressBarLinks.Value = 0;

            foreach (DataGridViewRow row in dataGridViewLinks.Rows)
            {
                if (Convert.ToBoolean(row.Cells[dataGridViewLinks.ColumnCount - 1].Value))
                {
                    parentSKU = row.Cells[0].Value.ToString().Trim();
                    childrenSKUs = row.Cells[tab1_childrenColumnId].Value.ToString().Trim();
                    similarSKUs = row.Cells[tab1_similarColumnId].Value.ToString().Trim();

                    string[] newChildren = childrenSKUs.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] newSimilar = similarSKUs.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if ((newChildren.Length == 0) && (newSimilar.Length == 0))
                    {
                        Log(new LogType(String.Format("Nie podano żadnych powiązań dla {0}. Pomijam.", parentSKU), 0));
                        row.Cells[tab1_statusColumnId].Value = "Pominięto";
                        continue;
                    }

                    row.Cells[tab1_statusColumnId].Value = "Przetwarzam...";
                    Log(new LogType(String.Format("Przetwarzanie danych dla {0}...", parentSKU), 0));

                    if (newChildren.Length != 0)
                    {
                        await MagentoLink(parentSKU, newChildren, "related", row);
                    }

                    if (newSimilar.Length != 0)
                    {
                        await MagentoLink(parentSKU, newSimilar, "upsell", row);
                    }
                }
                progressBarLinks.PerformStep();
            }
            return "true";
        }

        async Task<bool> MagentoLink(string parentSKU, string[] children, string linkType, DataGridViewRow row)
        {
            List<Dictionary<string, string>> currentArray = new List<Dictionary<string, string>>();
            IProgress<LogType> statusHandler = new Progress<LogType>(message =>
            {
                Log(message);
            });

            switch (linkType)
            {
                case "related":
                    row.Cells[tab1_statusColumnId].Value = "Wczytuję aktualnie powiązane...";
                    Log(new LogType(String.Format("Sprawdzanie aktualnych powiązań dla towaru {0}...", parentSKU), 0));
                    break;
                case "upsell":
                    row.Cells[tab1_statusColumnId].Value = "Wczytuję aktualnie podobne...";
                    Log(new LogType(String.Format("Sprawdzanie aktualnych podobnych dla towaru {0}...", parentSKU), 0));
                    break;
            }

            try
            {
                string alreadyLinked = await MagentoCall(statusHandler, "products/" + parentSKU + "/links/" + linkType);

                if (alreadyLinked != null)
                {
                    currentArray = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(alreadyLinked);

                    foreach (string child in children)
                    {
                        if (!currentArray.Any(v => v.Values.Contains(child.Trim())))
                        {
                            Dictionary<string, string> product = new Dictionary<string, string>();

                            product.Add("sku", parentSKU);
                            product.Add("link_type", linkType);
                            product.Add("linked_product_sku", child.Trim());

                            currentArray.Add(product);
                        }
                    }

                    Log(new LogType(String.Format("Docelowa ilość towarów do powiązania z {0}: {1}", parentSKU, currentArray.Count), 0));
                    Log(new LogType(String.Format("Przetwarzanie listy towarów do powiązania z {0}...", parentSKU), 0));
                    row.Cells[tab1_statusColumnId].Value = "Przetwarzam powiązania...";

                    Dictionary<string, List<Dictionary<string, string>>> newArray = new Dictionary<string, List<Dictionary<string, string>>>();
                    newArray.Add("items", currentArray);

                    try
                    {
                        string json = JsonConvert.SerializeObject(newArray, Formatting.Indented);
                        row.Cells[tab1_statusColumnId].Value = "Wysyłam na serwer...";
                        string postingResponse = await MagentoCall(statusHandler, "products/" + parentSKU + "/links", json);
                        if (postingResponse != null && postingResponse == "true")
                        {
                            Log(new LogType(String.Format("Pomyślnie przesłano nowe powiązania dla {0}", parentSKU), 1));
                            row.Cells[tab1_statusColumnId].Value = "Przesłano pomyślnie";
                            CellStyle(row.Cells[tab1_statusColumnId], "Przesłano pomyślnie", "#e0ffec");
                        }
                        else
                        {
                            Log(new LogType(String.Format("Nie udało się przesłać nowych powiązań dla {0}. Treść błędu: {1}", parentSKU, postingResponse), 2));
                            CellStyle(row.Cells[tab1_statusColumnId], "Błąd", "#ffe0e0");
                            return false;
                        }

                    }
                    catch (Exception e)
                    {
                        Log(new LogType(String.Format("Wystąpił błąd podczas przetwarzania listy . Treść błędu: {0}", e.Message), 2));
                        CellStyle(row.Cells[tab1_statusColumnId], "Błąd", "#ffe0e0");
                        return false;
                    }
                }
                else
                {
                    Log(new LogType(String.Format("Na serwerze sklepu brak towaru o symbolu {0}", parentSKU), 2));
                    CellStyle(row.Cells[tab1_statusColumnId], "Nie istnieje w sklepie", "#ffe0e0");
                    return false;
                }

            }
            catch (Exception e)
            {
                Log(new LogType(String.Format("Wystąpił błąd podczas odbierania z serwera danych dla towaru o symbolu {0}. Treść błędu: {1}", parentSKU, e.Message), 2));
                CellStyle(row.Cells[tab1_statusColumnId], "Błąd", "#ffe0e0");
                return false;
            }
            return true;
        }

        void CellStyle(DataGridViewCell cell, string status, string color)
        {
            cell.Value = status;
            cell.Style.BackColor = ColorTranslator.FromHtml(color);
        }

        public async Task<string> MagentoCall(IProgress<LogType> status, string url, string content = null, bool put = false)
        {
            status?.Report(new LogType((content != null) ? "Wysyłanie danych na serwer..." : "Odbieranie danych z serwera...", 0));

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + mageToken);
                client.DefaultRequestHeaders.Add("max-age", "0");
                CacheControlHeaderValue cacheControl = new CacheControlHeaderValue();
                cacheControl.NoCache = true;
                client.DefaultRequestHeaders.CacheControl = cacheControl;
                try
                {
                    HttpResponseMessage response = (content != null) ?
                        (put) ? await client.PutAsync(mageUrl + url, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false)
                            : await client.PostAsync(mageUrl + url, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false)
                        : await client.GetAsync(mageUrl + url).ConfigureAwait(false);

                    using (response)
                    {
                        using (HttpContent responseContent = response.Content)
                        {
                            string responseString = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

                            try
                            {
                                response.EnsureSuccessStatusCode();
                            }
                            catch (HttpRequestException exception)
                            {
                                status?.Report(new LogType(String.Format("Wystąpił błąd podczas wysyłania danych na serwer." + Environment.NewLine + "Treść błędu: {0}" + Environment.NewLine + "Odpowiedź serwera: {1}", exception.Message, responseString), 2));
                                return null;
                            }

                            return responseString;
                        }
                    }
                }
                catch (Exception e)
                {
                    if (content != null)
                        status?.Report(new LogType(String.Format("Wystąpił błąd podczas wysyłania danych na serwer. Treść błędu: {0}", e.Message), 2));
                    return null;
                }
            }
        }

        void Log(LogType data, bool oneLine = false)
        {
            string message = data.getMessage();
            string prefix;
            Color newColor;

            RichTextBox control;

            switch (tabControl.SelectedIndex)
            {
                case 0:
                default:
                    control = richTextBoxLinksStatus;
                    break;
                case 1:
                    control = richTextBoxAttributesStatus;
                    break;
            }

            switch (data.getStatus())
            {
                case 0:
                default:
                    newColor = Color.Black;
                    prefix = "INFO";
                    break;
                case 1:
                    newColor = Color.DarkGreen;
                    prefix = "SUKCES";
                    break;
                case 2:
                    newColor = Color.DarkRed;
                    prefix = "BŁĄD";
                    break;

            }

            int lastLine = control.Lines.Length - 1;

            if (oneLine)
            {
                int s1 = control.GetFirstCharIndexFromLine(lastLine);
                int s2 = control.TextLength;

                control.Select(s1, s2 - s1);
                control.SelectedText = String.Format("[{0}] [{1}] {2}", DateTime.Now.ToString("hh:mm:ss"), prefix, message);
            }
            else
            {
                string lastLineValue = control.Lines[lastLine];
                string newText = String.Format("[{0}] [{1}] {2}", DateTime.Now.ToString("hh:mm:ss"), prefix, message);

                control.SelectionStart = control.TextLength;
                control.SelectionLength = 0;
                if (lastLineValue != newText)
                    control.AppendText(Environment.NewLine + newText);
            }

            lastLine = control.Lines.Length - 1;

            int firstChar = control.GetFirstCharIndexFromLine(lastLine);
            int length = control.TextLength;
            control.Select(firstChar, length - firstChar);
            control.SelectionColor = newColor;

            control.DeselectAll();
            control.ScrollToCaret();
        }

        void ToolStripSelectAll_Click(object sender, EventArgs e)
        {
            int lastColumn = dataGridViewLinks.ColumnCount - 1;
            for (int i = 0; i < dataGridViewLinks.RowCount; i++)
            {
                dataGridViewLinks.Rows[i].Cells[lastColumn].Value = true;
            }
            dataGridViewLinks.Refresh();
        }
        void OdznaczWybraneToolStripMenuItemClick(object sender, EventArgs e)
        {

        }
        void ToolStripToggleSelected_Click(object sender, EventArgs e)
        {
            int lastColumn = dataGridViewLinks.ColumnCount - 1;
            if (dataGridViewLinks.SelectedCells.Count > 0)
            {
                DataGridViewCell firstSelected = dataGridViewLinks.Rows[dataGridViewLinks.SelectedCells[0].RowIndex].Cells[dataGridViewLinks.Columns.Count - 1];
                bool select = (firstSelected.Value != null && (bool)firstSelected.Value) ? false : true;
                foreach (DataGridViewRow row in dataGridViewLinks.SelectedRows)
                {
                    row.Cells[lastColumn].Value = select;
                }
                dataGridViewLinks.Refresh();
            }
        }
        void ToolStripUnselectAll_Click(object sender, EventArgs e)
        {
            int lastColumn = dataGridViewLinks.ColumnCount - 1;
            for (int i = 0; i < dataGridViewLinks.RowCount; i++)
            {
                dataGridViewLinks.Rows[i].Cells[lastColumn].Value = false;
            }
            dataGridViewLinks.Refresh();
        }
        void DataGridViewLinksCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewLinks.BeginEdit(true);
        }
        void ToolStripCopySelected_Click(object sender, EventArgs e)
        {
            CopyFullData();
        }

        void CopyFullData()
        {

            if (dataGridViewLinks.Rows.Count > 0)
            {
                var newline = System.Environment.NewLine;
                var tab = "\t";
                var clipboard_string = new StringBuilder();

                foreach (DataGridViewRow row in dataGridViewLinks.SelectedRows)
                {
                    int cellsCount = row.Cells.Count - 1; //bez ostatniej kolumny z CheckBoxem
                    for (int i = 0; i < cellsCount; i++)
                    {
                        if (i == (cellsCount - 1))
                            clipboard_string.Append(row.Cells[i].Value + newline);
                        else
                        {
                            if (row.Cells[i].Value.ToString() != "")
                                clipboard_string.Append(row.Cells[i].Value + tab);
                        }
                    }
                }
                Clipboard.SetText(clipboard_string.ToString());
            }
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        void ButtonLinksSettings_Click(object sender, EventArgs e)
        {
            if (Program.settingsForm == null)
                Program.settingsForm = new SettingsForm();
            Program.settingsForm.ShowDialog(this);
            LoadSettings();
        }

        bool Sfera()
        {
            try
            {
                GTClass insert = new GTClass();

                var produkt = insert.Produkt;
                insert.Serwer = subServer;
                insert.Baza = subDatabase;
                insert.Autentykacja = AutentykacjaEnum.gtaAutentykacjaMieszana;
                insert.Uzytkownik = subUid;
                insert.UzytkownikHaslo = subUpwd;
                insert.Operator = subUser;
                insert.OperatorHaslo = subUserPass;

                Log(new LogType("Loguję do Sfery...", 0));

                Subiekt subiekt = (Subiekt)insert.Uruchom((Int32)UruchomDopasujEnum.gtaUruchomDopasuj | (Int32)UruchomDopasujEnum.gtaUruchomDopasujOperatora, (Int32)UruchomEnum.gtaUruchomWTle);

                Log(new LogType("Wczytuję listę towarów oznaczonych jako \"Do sklepu internetowego\"...", 0));

                TowaryKolekcja list = subiekt.TowaryManager.OtworzKolekcje("tw_SklepInternet=1 AND NOT EXISTS (SELECT * FROM pw_Dane WHERE pwd_Id = tw_Id)");

                Log(new LogType("Ustawiam pola własne dla towarów...", 0));

                int i = 1;

                foreach (Towar towar in list)
                {
                    Log(new LogType(String.Format("Ustawiam pola własne dla towarów ({0}/{1})...", i, list.Liczba), 0), true);
                    towar.PoleWlasne[subiektLinked] = "";
                    towar.PoleWlasne[subiektSimilar] = "";
                    towar.Zapisz();
                    i++;
                }

                Log(new LogType("Zakończono ustawianie parametru własnego dla towarów oznaczonych jako \"Do sklepu internetowego\". Możesz teraz wczytać listę towarów za pomocą przycisku [Pobierz listę towarów z Subiekta].", 1));
                return true;
            }
            catch (Exception e)
            {
                switch (e.HResult)
                {
                    case unchecked((int)0x8004132B):
                        Log(new LogType("Nie udało się uruchomić instancji Subiekta w tle za pomocą Sfery. Sprawdź w ustawieniach, czy podane są prawidłowe dane logowania do Subiekta.", 2));
                        break;
                    default:
                        Log(new LogType(String.Format("Wystąpił błąd podczas ustawiania parametrów własnych. Treśc błędu: {0}", e.Message), 2));
                        break;
                }

                return false;
            }
        }

        void FilterList()
        {
            DataGridView list;
            ComboBox group;
            TextBox name;

            switch (tabControl.SelectedIndex)
            {
                case 0:
                default:
                    list = dataGridViewLinks;
                    group = comboBoxLinksFilterGroup;
                    name = textBoxLinksFilterName;
                    break;
                case 1:
                    list = dataGridViewProducts;
                    group = comboBoxAttributesFilterGroup;
                    name = textBoxAttributesFilterName;
                    break;
            }

            if (list.Rows.Count > 0)
            {
                if (group.SelectedIndex > 0)
                    (list.DataSource as DataTable).DefaultView.RowFilter = string.Format("Grupa = '{0}' AND (Nazwa LIKE '%{1}%' OR Symbol LIKE '%{1}%')", group.SelectedItem, name.Text);
                else
                    (list.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nazwa LIKE '%{0}%' OR Symbol LIKE '%{0}%'", name.Text);
            }
        }


        void TextBoxLinksFilterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterList();
        }

        void DataGridViewLinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridViewLinks.ColumnCount - 1) && (dataGridViewLinks.Rows.Count > 0))
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridViewLinks.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bool selected = Convert.ToBoolean(cell.Value);
                dataGridViewLinks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !selected;
            }
        }

        void ButtonLinksFilter_Click(object sender, EventArgs e)
        {
            FilterList();
        }
        void ComboBoxLinksFilterGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterList();
        }
        void DataGridViewLinks_DataSourceChanged(object sender, EventArgs e)
        {
            if (dataGridViewLinks.Rows.Count > 0)
            {
                textBoxLinksFilterName.Enabled = true;
                comboBoxLinksFilterGroup.Enabled = true;
                buttonLinksFilter.Enabled = true;
            }
            else
            {
                textBoxLinksFilterName.Enabled = false;
                comboBoxLinksFilterGroup.Enabled = false;
                buttonLinksFilter.Enabled = false;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private async void DataGridViewLinksCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool result = await SaveProducts(e.RowIndex);
            if (result)
                Log(new LogType("Zaktualizowano towar w bazie", 1));
            else
                Log(new LogType("Nie zaktualizowano żadnego rekordu", 0));
        }


        private void ToolStripCopySku_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dataGridViewLinks.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void DataGridViewLinksCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            foreach (DataGridViewRow x in dataGridViewLinks.Rows)
            {
                x.MinimumHeight = 25;
            }
        }

        async Task<bool> LoadProductsInfo()
        {
            if (attributesTable != null)
            {
                attributesTable.Dispose();
                attributesTable = null;
            }
            string commandText = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Poveu_Cechy' AND xtype='U')
	                    CREATE TABLE Poveu_Cechy (
		                    c_Id INT NOT NULL,
		                    c_Nazwa VARCHAR(255) NOT NULL,
		                    PRIMARY KEY (c_Id)
	                    );
	
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Poveu_CechyWGrupach' AND xtype='U')
	                    CREATE TABLE Poveu_CechyWGrupach (	
		                    cwg_Id INT NOT NULL,
		                    cwg_IdGrupy INT NOT NULL,
		                    cwg_IdCechy INT NOT NULL,
		                    PRIMARY KEY (cwg_Id)
	                    );
	
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Poveu_WartosciCech' AND xtype='U')
	                    CREATE TABLE Poveu_WartosciCech (
		                    wc_Id INT NOT NULL,
		                    wc_IdProduktu INT NOT NULL,
		                    wc_IdCechy INT NOT NULL,
		                    wc_Wartosc VARCHAR(MAX) NOT NULL,
		                    PRIMARY KEY (wc_Id)
	                    );

                    SELECT
	                    tw_Symbol AS 'Symbol',
	                    tw_Nazwa AS 'Nazwa',
	                    grt_Nazwa AS 'Grupa',
	                    CAST((
		                    SELECT
		                      COUNT(wc_Id)
		                    FROM Poveu_WartosciCech
		                    WHERE
		                      wc_IdProduktu = Towar.tw_Id
	                    ) AS VARCHAR) + '/' +
							  CAST((
		                    SELECT
		                      COUNT(cwg_Id)
		                    FROM Poveu_CechyWGrupach
		                    WHERE
		                      cwg_IdGrupy = Towar.tw_IdGrupa
	                    ) AS varchar) AS 'Przypisano cech'
                    FROM tw__Towar Towar
                    JOIN sl_GrupaTw
                       ON grt_Id = tw_IdGrupa
                    WHERE
                       tw_SklepInternet = 1
                       AND tw_Zablokowany = 0
                    ORDER BY
                       tw_Symbol;
					";

            using (DataTable dataTable = await SubiektCall(commandText))
            {

                DataGridView list = dataGridViewProducts;

                list.Columns.Clear();
                list.DataSource = null;
                list.DoubleBuffered(true);

                comboBoxAttributesFilterGroup.Items.Clear();
                comboBoxAttributesFilterGroup.Items.Add("(dowolna grupa)");

                if (dataTable != null)
                {

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string groupName = row["Grupa"].ToString();
                        if (!comboBoxAttributesFilterGroup.Items.Contains(groupName))
                            comboBoxAttributesFilterGroup.Items.Add(groupName);
                    }

                    comboBoxAttributesFilterGroup.SelectedIndex = 0;

                    if (dataTable != null)
                        list.DataSource = dataTable;

                    list.Columns[0].ReadOnly = true;
                    list.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    list.Columns[1].ReadOnly = true;
                    list.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    list.Columns[1].MinimumWidth = 200;

                    list.Columns[2].ReadOnly = true;
                    list.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    list.Columns[3].ReadOnly = true;
                    list.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    DataGridViewTextBoxColumn statusCol = new DataGridViewTextBoxColumn();
                    statusCol.HeaderText = "Status";
                    statusCol.ReadOnly = true;
                    statusCol.Name = "Status";
                    statusCol.MinimumWidth = 150;

                    tab2_statusColumnId = list.Columns.Count;
                    list.Columns.Insert(tab2_statusColumnId, statusCol);

                    buttonSendAttributes.Enabled = true;

                    Log(new LogType("Wczytano listę towarów", 1), true);
                    return true;
                }
                return false;
            }
        }

        async Task<DataTable> LoadProductAttributes(string sku, bool returnOnly = false)
        {
            string commandText = @"
					SELECT
	                    c_Nazwa AS 'Cecha',
	                    wc_Wartosc AS 'Wartość'
                    FROM
	                    Poveu_CechyWGrupach
                    LEFT JOIN Poveu_Cechy
	                    ON c_Id = cwg_IdCechy
                    LEFT JOIN tw__Towar
	                    ON tw_Symbol = '" + sku + @"'
                    LEFT JOIN Poveu_WartosciCech
	                    ON (wc_IdCechy = c_Id AND wc_IdProduktu = tw_Id)
                    WHERE
	                    cwg_IdGrupy = tw_IdGrupa
                    ORDER BY Cecha
					";
            DataTable dataTable;

            dataTable = await SubiektCall(commandText);

            if (!returnOnly)
            {
                DataGridView list = dataGridViewAttributes;
                list.Columns.Clear();
                list.DataSource = null;
                list.DoubleBuffered(true);

                if (dataTable != null)
                {
                    list.DataSource = dataTable;
                    list.Columns[0].ReadOnly = true;
                    list.Columns[1].ReadOnly = false;
                    list.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    list.Columns[1].MinimumWidth = 200;
                    list.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
                }
            }

            Log(new LogType("Wczytano atrybuty towaru o symbolu " + sku, 1), true);
            return dataTable;
        }

        async Task<DataTable> SubiektCall(string commandText, bool quiet = false)
        {
            using (subConnection = new SqlConnection(@"Data source=" + subServer + ";database=" + subDatabase + ";User id=" + subUid + ";Password=" + subUpwd + ";"))
            {
                using (SqlCommand komendaSQL = subConnection.CreateCommand())
                {
                    if (!quiet) Log(new LogType("Wczytywanie danych z bazy...", 0));
                    komendaSQL.CommandText = commandText;

                    DataTable dataTable = new DataTable();
                    using (var sqlDataAdapter = new SqlDataAdapter(komendaSQL))
                    {
                        try
                        {
                            await subConnection.OpenAsync();
                            await Task.Run(() => sqlDataAdapter.Fill(dataTable));
                            return dataTable;
                        }
                        catch (Exception e)
                        {
                            if (!quiet) Log(new LogType(String.Format("Nie udało się połączyć z bazą Subiekta. Treść błędu: {0}", e.Message), 2));
                            return null;
                        }
                    }
                }
            }
        }

        private void ComboBoxAttributesFilterGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterList();
        }

        private void TextBoxAttributesFilterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterList();
        }

        private void ButtonAttributesFilter_Click(object sender, EventArgs e)
        {
            FilterList();
        }

        private void DataGridViewProducts_DataSourceChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.Rows.Count > 0)
            {
                textBoxAttributesFilterName.Enabled = true;
                comboBoxAttributesFilterGroup.Enabled = true;
                buttonAttributesFilter.Enabled = true;
            }
            else
            {
                textBoxAttributesFilterName.Enabled = false;
                comboBoxAttributesFilterGroup.Enabled = false;
                buttonAttributesFilter.Enabled = false;
            }
        }

        async Task PrepareAttributes()
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                string sku = dataGridViewProducts.SelectedRows[0].Cells[0].Value.ToString();
                await LoadProductAttributes(sku);
            }
        }

        private async void DataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            await PrepareAttributes();
        }

        private void DataGridViewAttributes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAttributes.BeginEdit(true);
        }

        async Task<bool> SaveProductAttributes(int rowIndex)
        {
            DataGridView list = dataGridViewAttributes;
            DataGridViewRow row = list.Rows[rowIndex];
            string sku = dataGridViewProducts.SelectedRows[0].Cells[0].Value.ToString();

            using (subConnection = new SqlConnection(@"Data source=" + subServer + ";database=" + subDatabase + ";User id=" + subUid + ";Password=" + subUpwd + ";"))
            {
                //jesli tekst pusty to usun wartosc z bazy
                using (SqlCommand komendaSQL = subConnection.CreateCommand())
                {
                    try
                    {
                        string attributeValue = row.Cells[1].Value.ToString().Trim();

                        if (attributeValue.Length == 0)
                        {
                            komendaSQL.CommandText = @"
                                DELETE FROM Poveu_WartosciCech
                                WHERE
                                wc_IdCechy = (
		                            SELECT c_Id
		                            FROM Poveu_Cechy
		                            WHERE c_Nazwa = '" + row.Cells[0].Value + @"'
	                            )
	                            AND
	                            wc_IdProduktu = (
		                            SELECT tw_Id
		                            FROM tw__Towar
		                            WHERE tw_Symbol = '" + sku + @"'
	                            )
                            ";
                        }
                        else
                        {

                            komendaSQL.CommandText = @"
                                UPDATE Poveu_WartosciCech
                                SET
	                                wc_Wartosc = '" + attributeValue + @"'
                                WHERE
	                                wc_IdCechy = (
		                                SELECT c_Id
		                                FROM Poveu_Cechy
		                                WHERE c_Nazwa = '" + row.Cells[0].Value + @"'
	                                )
	                                AND
	                                wc_IdProduktu = (
		                                SELECT tw_Id
		                                FROM tw__Towar
		                                WHERE tw_Symbol = '" + sku + @"'
	                                )
	
                                IF @@ROWCOUNT = 0
	                                INSERT INTO Poveu_WartosciCech
	                                (wc_Id, wc_IdProduktu, wc_IdCechy, wc_Wartosc)
	                                VALUES (
		                                (SELECT ISNULL(MAX(wc_Id) + 1, 1) FROM Poveu_WartosciCech),
		                                (SELECT tw_Id FROM tw__Towar WHERE tw_Symbol = '" + sku + @"'),
		                                (SELECT c_Id FROM Poveu_Cechy WHERE c_Nazwa = '" + row.Cells[0].Value + @"'),
		                                '" + attributeValue + @"'
	                                )
					        ";

                        }

                        await subConnection.OpenAsync();
                        int resultCount = await komendaSQL.ExecuteNonQueryAsync();

                        if (resultCount > 0)
                            return true;

                        return false;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        Log(new LogType(String.Format("Nie udało się wczytać listy towarów z Subiekta. Treść błędu: {0}", e.Message), 2));
                        return false;
                    }
                }
            }
        }

        private async void DataGridViewAttributes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool result = await SaveProductAttributes(e.RowIndex);
            if (result)
                Log(new LogType("Zaktualizowano atrybut w bazie", 1));
            else
                Log(new LogType("Nie zaktualizowano żadnego rekordu", 0));
        }

        private async void DataGridViewAttributes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewAttributes.CurrentCell.ColumnIndex == 1)
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.Multiline = false;
                    autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    await AddAutoCompleteItems(DataCollection, dataGridViewAttributes.SelectedRows[0]);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
        }

        async Task AddAutoCompleteItems(AutoCompleteStringCollection col, DataGridViewRow gridRow)
        {
            string commandText = @"
					SELECT DISTINCT
	                    wc_Wartosc
                    FROM Poveu_WartosciCech
                    JOIN Poveu_Cechy
	                    ON wc_IdCechy = c_Id
                    WHERE
	                    c_Nazwa = '" + gridRow.Cells[0].Value + @"'
					";

            DataTable dataTable;
            dataTable = await SubiektCall(commandText, true);
            foreach (DataRow row in dataTable.Rows)
            {
                col.Add(row[0].ToString());
            }
        }

        private async void ToolStripAddAttribute_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                string groupName = dataGridViewProducts.SelectedRows[0].Cells[2].Value.ToString();

                if (attributesTable == null)
                {
                    progressBarAttributes.Value = progressBarAttributes.Maximum / 2;
                    Log(new LogType("Wczytuję listę atrybutów...", 0));
                    attributesTable = new DataTable();
                    attributesTable.Columns.Add("c_Nazwa");

                    string requestUrl = "products/attributes?searchCriteria[filter_groups][0][filters][0][field]=frontend_input&searchCriteria[filter_groups][0][filters][0][condition_type]=in&searchCriteria[filter_groups][0][filters][0][value]=multiselect,select";
                    string loadedAttributes = await MagentoCall(null, requestUrl);

                    if (loadedAttributes != null)
                    {
                        JObject data = JObject.Parse(loadedAttributes);
                        JArray items = (JArray)data["items"];

                        foreach (JObject item in items)
                        {
                            JToken value;
                            if (item.TryGetValue("attribute_code", out value))
                            {
                                string finalValue = (string)value;
                                attributesTable.NewRow();
                                attributesTable.Rows.Add(finalValue);
                            }
                        }
                        Log(new LogType("Wczytano listę atrybutów", 1), true);
                    }

                    progressBarAttributes.Value = progressBarAttributes.Maximum;
                }

                DialogInput dialogInput = (dataGridViewProducts.SelectedRows.Count == 1) ? new DialogInput(String.Format("Wpisz lub wybierz kod nowego atrybutu dla grupy {0}:", groupName), attributesTable) : new DialogInput("Podaj kod nowego atrybutu dla grupy:", attributesTable);
                if (dialogInput.ShowDialog(this) == DialogResult.OK)
                {
                    string value = dialogInput.Value.Trim();

                    if (value != "")
                    {
                        string commandText = @"
                            IF NOT EXISTS(SELECT * FROM Poveu_Cechy WHERE c_Nazwa = '" + value.Trim() + @"')
	                            INSERT INTO Poveu_Cechy
		                            (c_Id, c_Nazwa)
	                            VALUES (
		                            (SELECT ISNULL(MAX(c_Id) + 1, 1) FROM Poveu_Cechy),
		                            '" + value.Trim() + @"'
		                            );
                            IF NOT EXISTS(SELECT * FROM Poveu_CechyWGrupach WHERE cwg_IdCechy = (SELECT c_Id FROM Poveu_Cechy WHERE c_Nazwa = '" + value.Trim() + @"') AND cwg_IdGrupy = (SELECT grt_Id FROM sl_GrupaTw WHERE grt_Nazwa = '" + groupName.Trim() + @"'))
	                            INSERT INTO Poveu_CechyWGrupach
		                            (cwg_Id, cwg_IdGrupy, cwg_IdCechy)
	                            VALUES (
		                            (SELECT ISNULL(MAX(cwg_Id) + 1, 1) FROM Poveu_CechyWGrupach),
		                            (SELECT grt_Id FROM sl_GrupaTw WHERE grt_Nazwa = '" + groupName.Trim() + @"'),
		                            (SELECT c_Id FROM Poveu_Cechy WHERE c_Nazwa = '" + value.Trim() + @"')
	                            );
					        ";

                        DataTable dataTable;
                        dataTable = await SubiektCall(commandText);

                        if (dataTable != null)
                        {
                            Log(new LogType("Zapisano nowy atrybut", 1));
                            await PrepareAttributes();
                        }
                    }
                }
                dialogInput.Dispose();
            }
        }

        private async void ToolStripRefreshProducts_Click(object sender, EventArgs e)
        {
            await LoadProductsInfo();
        }

        private async void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                default:
                    if (dataGridViewLinks.Rows.Count == 0)
                    {
                        bool result = await LoadProducts();
                    }
                    break;
                case 1:
                    if (dataGridViewProducts.Rows.Count == 0)
                    {
                        await LoadProductsInfo();
                    }
                    break;
            }
        }

        private async void ToolStripRefreshAttributes_Click(object sender, EventArgs e)
        {
            await PrepareAttributes();
        }

        private void ButtonAttributesSettings_Click(object sender, EventArgs e)
        {
            if (Program.settingsForm == null)
                Program.settingsForm = new SettingsForm();
            Program.settingsForm.ShowDialog(this);
            LoadSettings();
        }

        private async void ToolStripRefreshLinks_Click(object sender, EventArgs e)
        {
            await LoadProducts();
        }

        private void DataGridViewAttributes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
                PutData(sender as DataGridView, Clipboard.GetText(), true);
        }

        async void PutData(DataGridView list, string data, bool save = false)
        {
            if (list.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = list.SelectedRows[0];
                selectedRow.Cells[1].Value = data.Trim();

                if (save)
                {
                    bool result = await SaveProductAttributes(selectedRow.Index);
                    if (result)
                        Log(new LogType("Zaktualizowano atrybut w bazie", 1));
                    else
                        Log(new LogType("Nie zaktualizowano żadnego rekordu", 0));
                }
                
            }
        }

        async Task<bool> AddNewAttributeValue(IProgress<LogType> statusHandler, string attrCode, string attrValue)
        {
            Log(new LogType(String.Format("Dodawanie nowej wartości ({0}) dla atrybutu {1}", attrValue, attrCode), 0));
            Dictionary<string, Dictionary<string, string>> newArray = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> dataPair = new Dictionary<string, string>();
            dataPair.Add("label", attrValue);

            newArray.Add("option", dataPair);

            string json = JsonConvert.SerializeObject(newArray, Formatting.Indented);

            string addingValueResult = await MagentoCall(statusHandler, "products/attributes/" + attrCode + "/options", json);
            
            if (addingValueResult != null && addingValueResult == "true")
                return true;

            return false;
        }

        async Task<string> GetAttributeValueIndex(IProgress<LogType> statusHandler, string attrCode, string attrValue)
        {
            string foundValue = null;

            if (attributeKeys.ContainsKey(attrCode) && attributeKeys[attrCode].ContainsKey(attrValue))
            {
                foundValue = attributeKeys[attrCode][attrValue];
            }
            else
            {
                List<Dictionary<string, string>> currentArray = new List<Dictionary<string, string>>();
                string possibleValues = await MagentoCall(statusHandler, "products/attributes/" + attrCode + "/options");

                if (possibleValues != null)
                {
                    currentArray = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(possibleValues);

                    foreach (Dictionary<string, string> currentValue in currentArray)
                    {
                        string label = currentValue["label"];

                        if (label == attrValue)
                        {
                            foundValue = currentValue["value"];
                            break;
                        }
                    }
                }
                if (foundValue != null)
                {
                    if (attributeKeys.ContainsKey(attrCode))
                        attributeKeys[attrCode].Add(attrValue, foundValue);
                    else
                        attributeKeys.Add(attrCode, new Dictionary<string, string>() { { attrValue, foundValue } });
                }
            }

            return foundValue;
        }

        async Task<string> SetNewAttributeValues(IProgress<LogType> statusHandler, Dictionary<string, List<string>> attrData, string sku)
        {

            Log(new LogType(String.Format("Przypisywanie wartości atrybutów dla {0}", sku), 0));
            List<Dictionary<string, string>> listOfCustomAttributes = new List<Dictionary<string, string>>();

            try
            {
                foreach (KeyValuePair<string, List<string>> attr in attrData)
                {
                    Dictionary<string, string> customAttributesPair = new Dictionary<string, string>();
                    string attrCode = attr.Key;
                    string attrValue = (attr.Value != null) ? string.Join(",", attr.Value) : null;

                    if (!customAttributesPair.ContainsValue(attrCode))
                    {
                        customAttributesPair.Add("attribute_code", attrCode);
                        customAttributesPair.Add("value", attrValue);

                        listOfCustomAttributes.Add(customAttributesPair);
                    }
                }

                if (listOfCustomAttributes.Count > 0)
                {
                    bool productExists = await CheckProduct(sku);
                    if (productExists)
                    {
                        string json = JsonConvert.SerializeObject(new { product = new { sku = sku, custom_attributes = listOfCustomAttributes } }, Formatting.Indented);
                        string addingValueResult = await MagentoCall(statusHandler, "products/" + sku, json, true);

                        if (addingValueResult != null && addingValueResult.Contains(sku))
                            return "Zaktualizowano";
                    }
                    else
                    {
                        Log(new LogType(String.Format("Produkt o symbolu {0} nie istnieje w bazie sklepu", sku), 2));
                        return "Nie istnieje w sklepie";
                    }
                }
                else
                {
                    return "Pominięto";
                }

                return "Błąd";
            }
            catch (Exception e)
            {
                Log(new LogType(String.Format("Wystąpił błąd podczas przypisywania atrybutów dla {0}. Treść błędu: {1}", sku, e.Message), 0));
                return "Błąd";
            }

        }

        async Task<bool> CheckProduct(string sku)
        {
            string productResult = await MagentoCall(null, "products/" + sku);
            return (productResult != null);
        }

        async Task<bool> PrepareNewAttributes()
        {
            IProgress<LogType> statusHandler = new Progress<LogType>(message =>
            {
                Log(message);
            });

            Log(new LogType("Rozpoczynanie procesu wysyłania atrybutów towarów...", 0));

            //(dataGridViewProducts.DataSource as DataTable).DefaultView.RowFilter = "Nazwa LIKE '%'";

            progressBarAttributes.Maximum = dataGridViewProducts.Rows.Count;
            progressBarAttributes.Value = 0;

            foreach (DataGridViewRow listRow in dataGridViewProducts.Rows)
            {
                bool errors = false;
                string sku = listRow.Cells[0].Value.ToString().Trim();

                DataTable attributes = await LoadProductAttributes(sku, true);

                listRow.Cells[tab2_statusColumnId].Value = "Przetwarzam...";
                Log(new LogType(String.Format("Sprawdzanie wartości atrybutów dla {0}...", sku), 0));

                Dictionary<string, List<string>> listOfAttributes = new Dictionary<string, List<string>>();

                foreach (DataRow attribute in attributes.Rows)
                {
                    string attrCode = attribute[0].ToString();
                    string attrValue = attribute[1].ToString();

                    if (attrValue.Length == 0)
                    {
                        listOfAttributes.Add(attrCode, null);
                    }
                    else
                    {
                        string[] attrValues = attrValue.Split('|');
                        List<string> valuesList = new List<string>();

                        string keyIndex = null;

                        if (attributeKeys == null)
                            attributeKeys = new Dictionary<string, Dictionary<string, string>>();

                        foreach (string splittedValue in attrValues)
                        {
                            List<string> values = new List<string> { splittedValue };

                            Regex regex = new Regex(@"^\b([0-9]+)\b-\b([0-9]+)\b$");
                            var match = regex.Match(splittedValue);
                            if (match.Success)
                            {
                                values.Add(match.Groups[1].Value);
                                values.Add(match.Groups[2].Value);
                            }

                            foreach (string value in values)
                            {

                                Log(new LogType(String.Format("Sprawdzanie wartości \"{0}\" dla atrybutu {1}...", value, attrCode), 0));
                                keyIndex = await GetAttributeValueIndex(statusHandler, attrCode, value);

                                if (keyIndex != null)
                                {
                                    if (!valuesList.Contains(keyIndex))
                                        valuesList.Add(keyIndex);
                                }
                                else
                                {
                                    bool addedCorrectly = await AddNewAttributeValue(statusHandler, attrCode, value);
                                    if (addedCorrectly)
                                    {
                                        keyIndex = await GetAttributeValueIndex(statusHandler, attrCode, value);
                                        if (!valuesList.Contains(keyIndex))
                                            valuesList.Add(keyIndex);
                                    }
                                    else
                                    {
                                        listRow.Cells[tab2_statusColumnId].Value = "Wystąpiły błędy";
                                        errors = true;
                                    }
                                }
                            }  
                        }

                        if (valuesList != null)
                        {
                            listOfAttributes.Add(attrCode, valuesList);
                        }
                    }
                }


                string linkingResult = await SetNewAttributeValues(statusHandler, listOfAttributes, sku);
                if (!errors) listRow.Cells[tab2_statusColumnId].Value = linkingResult;

                progressBarAttributes.PerformStep();
            }

            return true;
        }

        private async void ButtonSendAttributes_Click(object sender, EventArgs e)
        {
            buttonSendAttributes.Enabled = false;
            textBoxAttributesFilterName.Enabled = false;
            comboBoxAttributesFilterGroup.Enabled = false;
            buttonAttributesFilter.Enabled = false;
            contextMenuStripAttributes.Enabled = false;
            contextMenuStripProducts.Enabled = false;

            bool result = await PrepareNewAttributes();

            Log((result == true) ?
                new LogType(String.Format("Zakończono synchronizację atrybutów towarów"), 1)
                : new LogType(String.Format("Wystąpił błąd w trakcie wysyłania atrybutów towarów na serwer sklepu."), 2));

            buttonSendAttributes.Enabled = true;
            textBoxAttributesFilterName.Enabled = true;
            comboBoxAttributesFilterGroup.Enabled = true;
            buttonAttributesFilter.Enabled = true;
            contextMenuStripAttributes.Enabled = true;
            contextMenuStripProducts.Enabled = true;
        }

        private void toolStripSfera_Click(object sender, EventArgs e)
        {
            Sfera();
        }

        private void dataGridViewAttributes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!dataGridViewAttributes.Rows[dataGridViewAttributes.CurrentCell.RowIndex].Cells[1].IsInEditMode
                && char.IsLetterOrDigit(e.KeyChar))
            {
                dataGridViewAttributes.CurrentCell = dataGridViewAttributes[1, dataGridViewAttributes.CurrentCell.RowIndex];
                dataGridViewAttributes.Rows[dataGridViewAttributes.CurrentCell.RowIndex].Cells[1].Value = e.KeyChar.ToString();

                PutData(sender as DataGridView, (e.KeyChar).ToString(), false);
                dataGridViewAttributes.BeginEdit(true);

                TextBox controlCell = (TextBox)dataGridViewAttributes.EditingControl;
                controlCell.SelectionStart = controlCell.Text.Length;
                controlCell.SelectionLength = 0;
            }
               
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}