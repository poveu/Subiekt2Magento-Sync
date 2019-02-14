using Microsoft.Win32;
using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiekt2Magento_Sync
{

    public partial class SettingsForm : Form
    {
        bool overrideServer = true;
        SqlCommand sqlCommand;

        public SettingsForm()
        {

            InitializeComponent();

            LoadAsync();

            if (string.IsNullOrEmpty(comboBoxServerDatabase.Text))
            {
                comboBoxServerDatabase.Select();
            }

            if ((string.IsNullOrEmpty(comboBoxServer.Text)) || (comboBoxServer.Text == Program.INFO_LOADING))
            {
                comboBoxServer.Select();
            }

            if (string.IsNullOrEmpty(textBoxServerPassword.Text))
            {
                textBoxServerPassword.Select();
            }

            if (string.IsNullOrEmpty(textBoxServerUser.Text))
            {
                textBoxServerUser.Select();
            } else
            if (string.IsNullOrEmpty(textBoxServerPassword.Text))
            {
                textBoxServerPassword.Select();
            }

        }

        async void LoadAsync()
        {
            await LoadServerList();
        }

        async Task LoadServerList()
        {
            if (overrideServer)
            {
                comboBoxServer.Text = Program.INFO_LOADING;

                try
                {

                    var registryViewArray = new[] { RegistryView.Registry32, RegistryView.Registry64 };
                    foreach (var registryView in registryViewArray)
                    {
                        using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                        using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server"))
                        {
                            var instances = (key == null) ? null : (string[])key.GetValue("InstalledInstances");
                            if (instances != null)
                            {
                                foreach (var element in instances)
                                {
                                    if (element == "MSSQLSERVER")
                                    {
                                        comboBoxServer.Items.Add(System.Environment.MachineName);
                                    }
                                    else
                                    {
                                        comboBoxServer.Items.Add(System.Environment.MachineName + @"\" + element);
                                    }
                                }
                            }
                        }
                    }

                    await Task.Run(() =>
                    {
                        using (DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources())
                        {
                            if (table.Rows.Count > 0)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        if (!comboBoxServer.Items.Contains(row[0] + "\\" + row[1]))
                                            comboBoxServer.Items.Add(row[0] + "\\" + row[1]);
                                    }));
                                }
                            }
                        }

                    });

                    if (comboBoxServer.Items.Count > 0)
                    {
                        if (overrideServer)
                        {
                            comboBoxServer.SelectedIndex = 0;
                            ValidateSQL();
                        }
                    }
                    else if (overrideServer)
                        comboBoxServer.Text = Program.INFO_BRAK_SERWEROW;

                }
                catch (Exception e)
                {
                    MessageBox.Show("Wystąpił błąd podczas wczytywania listy serwerów:\n" + e.Message);
                }
            }
        }

        async void ButtonSave_Click(object sender, EventArgs e)
        {
            if (await SaveSettings())
            {
                if (Program.mainForm == null)
                    Program.mainForm = new MainForm();
                Program.mainForm.Show();
                Hide();
            }
        }

        bool LoadSettings()
        {
            bool overrideServer = true;
            try
            {

                if (!string.IsNullOrEmpty(Settings.Default.sql_server.Trim()))
                {
                    comboBoxServer.Items.Clear();
                    comboBoxServer.Text = Settings.Default.sql_server?.Trim();
                    overrideServer = false;
                }

                textBoxServerUser.Text = Settings.Default.sql_username?.Trim();
                textBoxServerPassword.Text = Settings.Default.sql_password?.DecryptString();
                
                if (!string.IsNullOrEmpty(Settings.Default.sql_database.Trim()))
                {
                    comboBoxServerDatabase.Items.Clear();
                    comboBoxServerDatabase.Text = Settings.Default.sql_database?.Trim();
                }

                textBoxApiUrl.Text = Settings.Default.api_url?.Trim();
                textBoxApiToken.Text = Settings.Default.api_token?.DecryptString();
                
                if (!string.IsNullOrEmpty(Settings.Default.subiekt_user.Trim()))
                {
                    comboBoxOperatorName.Items.Clear();
                    comboBoxOperatorName.Items.Add(Settings.Default.subiekt_user?.Trim());
                    comboBoxOperatorName.SelectedItem = Settings.Default.subiekt_user?.Trim();
                }

                textBoxOperatorPassword.Text = Settings.Default.subiekt_password?.DecryptString();

                if (!string.IsNullOrEmpty(Settings.Default.subiekt_linked) && !string.IsNullOrEmpty(Settings.Default.subiekt_linked_code))
                {
                    comboBoxLinkedProducts.Items.Clear();
                    comboBoxLinkedProducts.Items.Add(new ComboBoxItem(Settings.Default.subiekt_linked?.Trim(), Settings.Default.subiekt_linked_code?.Trim()));
                    comboBoxLinkedProducts.SelectedIndex = 0;
                }

                if (!string.IsNullOrEmpty(Settings.Default.subiekt_similar) && !string.IsNullOrEmpty(Settings.Default.subiekt_similar_code))
                {
                    comboBoxSimilarProducts.Items.Clear();
                    comboBoxSimilarProducts.Items.Add(new ComboBoxItem(Settings.Default.subiekt_similar?.Trim(), Settings.Default.subiekt_similar_code?.Trim()));
                    comboBoxSimilarProducts.SelectedIndex = 0;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania ustawień:\n" + e.Message + e.StackTrace);
            }

            return overrideServer;
        }



        async Task<bool> SaveSettings()
        {
            try
            {
                string apiUrl = textBoxApiUrl.Text;
                if (apiUrl != "")
                {
                    apiUrl = apiUrl.Trim();
                    char lastChar = apiUrl[apiUrl.Length - 1];
                    if (lastChar != '/')
                        apiUrl += "/";
                }

                Settings.Default.sql_server = comboBoxServer.Text?.Trim();
                Settings.Default.sql_username = textBoxServerUser.Text?.Trim();
                Settings.Default.sql_password = textBoxServerPassword.Text?.Trim().EncryptString();
                Settings.Default.sql_database = comboBoxServerDatabase.Text?.Trim();

                Settings.Default.api_url = apiUrl;
                Settings.Default.api_token = textBoxApiToken.Text?.Trim().EncryptString();

                Settings.Default.subiekt_user = comboBoxOperatorName.Text?.Trim();
                Settings.Default.subiekt_password = textBoxOperatorPassword.Text?.Trim().EncryptString();
                Settings.Default.subiekt_linked = comboBoxLinkedProducts.Text?.Trim();
                Settings.Default.subiekt_similar = comboBoxSimilarProducts.Text?.Trim();

                ComboBoxItem linkedItem = (ComboBoxItem)comboBoxLinkedProducts.SelectedItem;
                ComboBoxItem similarItem = (ComboBoxItem)comboBoxSimilarProducts.SelectedItem;
                string hiddenLinked = linkedItem?.HiddenValue;
                string hiddenSimilar = similarItem?.HiddenValue;

                Settings.Default.subiekt_linked_code = hiddenLinked?.Trim();
                Settings.Default.subiekt_similar_code = hiddenSimilar?.Trim();

                Settings.Default.replace = false;
                Settings.Default.Save();

            }
            catch (Exception e)
            {
                MessageBox.Show("Wystąpił błąd podczas zapisywania ustawień:\n" + e.Message);
            }
            if (!await DatabaseCorrect())
            {
                MessageBox.Show("W podanej bazie nie znaleziono odpowiednich danych.\nUpewnij się, że wybrano prawidłową bazę danych (Subiekt GT).");
                return false;
            }
            if (!Program.dataProvided(new String[] { comboBoxServer.Text, textBoxServerUser.Text, comboBoxServerDatabase.Text, textBoxApiUrl.Text, textBoxApiToken.Text, comboBoxLinkedProducts.Text, comboBoxSimilarProducts.Text }))
            {
                MessageBox.Show("Pomyślnie zapisano ustawienia.\nAby uruchomić aplikację uzupełnij wszystkie wymagane pola.");
                return false;
            }
            return true;
        }

        async Task<bool> DatabaseCorrect()
        {
            if (Program.dataProvided(new String[] { comboBoxServer.Text, textBoxServerUser.Text, comboBoxServerDatabase.Text }))
            {

                using (SqlConnection polaczenie = new SqlConnection(@"Data source=" + comboBoxServer.Text + ";database=" + comboBoxServerDatabase.Text + ";User id=" + textBoxServerUser.Text + ";Password=" + textBoxServerPassword.Text + ";Connection Timeout=2"))
                {
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                    }

                    using (sqlCommand = polaczenie.CreateCommand())
                    {
                        try
                        {
                            sqlCommand.CommandTimeout = 5;
                            await polaczenie.OpenAsync();
                            sqlCommand.CommandText = "SELECT COUNT(*) FROM tw__Towar";
                            Int32 count = (Int32)sqlCommand.ExecuteScalar();
                            return (count > 0);
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }
            else
                return false;
        }

        void ErrorHandler(bool error = true)
        {
            if (error)
            {
                textBoxServerUser.BackColor = System.Drawing.Color.LightCoral;
                textBoxServerPassword.BackColor = System.Drawing.Color.LightCoral;
                groupBoxOperator.Enabled = false;
                comboBoxServerDatabase.Text = "";
                comboBoxServerDatabase.Items.Clear();
            } else
            {
                textBoxServerUser.BackColor = System.Drawing.SystemColors.Window;
                textBoxServerPassword.BackColor = System.Drawing.SystemColors.Window;
                groupBoxOperator.Enabled = true;
            }
        }

        async Task LoginToDatabase(bool comboBoxServerDatabaseWasDroppedDown = false)
        {
            try
            {
                DataTable data = await SubiektRequest("SELECT name FROM master.sys.databases", true);
                comboBoxServerDatabase.Items.Clear();

                if (data != null)
                {

                    foreach (DataRow dataRow in data.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            comboBoxServerDatabase.Items.Add(item);
                        }
                    }

                    ErrorHandler(false);
                    if (comboBoxServerDatabaseWasDroppedDown) comboBoxServerDatabase.DroppedDown = true;

                } else
                {
                    ErrorHandler();
                }
            }
            catch (Exception e)
            {
                ErrorHandler();
            }
        }

        async void GetAvailableAttributes(ComboBox box)
        {
            try
            {
                DataTable data = await SubiektRequest("SELECT pwp_Nazwa, pwp_Pole FROM pw_Pole WHERE pwp_Typ = 3 AND pwp_TypObiektu = -14");
                box.Items.Clear();

                foreach (DataRow dataRow in data.Rows)
                {
                    string fieldName = dataRow.Field<String>("pwp_Nazwa");
                    string fieldCode = dataRow.Field<String>("pwp_Pole");
                    box.Items.Add(new ComboBoxItem(fieldName, fieldCode));
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Wystąpił błąd:\n" + e.Message);
                box.Text = "";
                box.Items.Clear();
            }

        }

        public class ComboBoxItem
        {
           string displayValue;

            public ComboBoxItem(string d, string h)
                {
                    displayValue = d;
                    HiddenValue = h;
                }

            public string HiddenValue { get; }

            public override string ToString()
            {
                return displayValue;
            }
        }

    async void GetSubiektUsers()
        {
            try
            {
                DataTable data = await SubiektRequest("SELECT uz_Nazwisko + ' ' + uz_Imie FROM pd_Uzytkownik");
                comboBoxOperatorName.Items.Clear();

                if (data == null)
                {
                    throw new Exception("W podanej bazie danych nie odnaleziono żadnych pracowników.");
                } else
                {
                    foreach (DataRow dataRow in data.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            comboBoxOperatorName.Items.Add(item);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Wystąpił błąd:\n" + e.Message);
                comboBoxOperatorName.Text = "";
                comboBoxOperatorName.Items.Clear();
            }
        }

        async Task<DataTable> SubiektRequest(string command, bool noDatabase = false)
        {
            String[] data = (noDatabase) ?
                new String[] { comboBoxServer.Text, textBoxServerUser.Text, textBoxServerPassword.Text }
                : new String[] { comboBoxServer.Text, textBoxServerUser.Text, textBoxServerPassword.Text, comboBoxServerDatabase.Text };

            if (Program.dataProvided(data))
            {
                string connectionString;

                connectionString = (noDatabase) ?
                    @"Data source=" + comboBoxServer.Text + "; User id=" + textBoxServerUser.Text + "; Password=" + textBoxServerPassword.Text + ";Connection Timeout=2"
                    : @"Data source=" + comboBoxServer.Text + "; Database=" + comboBoxServerDatabase.Text + "; User id=" + textBoxServerUser.Text + "; Password=" + textBoxServerPassword.Text + ";Connection Timeout=3";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel(); 
                    }

                    using (sqlCommand = connection.CreateCommand())
                    {
                        try
                        {
                            sqlCommand.CommandTimeout = 5;
                            await connection.OpenAsync();
                            sqlCommand.CommandText = command;
                            var adapter = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);
                            var dataset = new DataSet();
                            await Task.Run(() => adapter.Fill(dataset));
                            DataTable dt_result = dataset.Tables[0];
                            return dt_result;
                        }
                        catch (SqlException sqle)
                        {
                            ErrorHandler();
                            return null;
                        }
                    }
                }
            }
            return null;
        }


        void ValidateSQL()
        {
            if ((textBoxServerUser.Text != "") && (comboBoxServer.Text != Program.INFO_LOADING) && (comboBoxServer.Text != Program.INFO_BRAK_SERWEROW))
            {
                timer1.Stop();
                timer1.Start();
            }
        }

        void TextBoxServerPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateSQL();
        }
        void TextBoxServerUser_TextChanged(object sender, EventArgs e)
        {
            ValidateSQL();
        }

        private void ComboBoxLinkedProducts_DropDown(object sender, EventArgs e)
        {
            GetAvailableAttributes(sender as ComboBox);
        }

        private void ComboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text != "")
            {
                overrideServer = false;
                ValidateSQL();
            }
        }

        private void ComboBoxOperatorName_DropDown(object sender, EventArgs e)
        {
            GetSubiektUsers();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            overrideServer = LoadSettings();
        }

        private void ComboBoxSimilarProducts_DropDown(object sender, EventArgs e)
        {
            GetAvailableAttributes(sender as ComboBox);
        }

        private void ComboBoxServer_Leave(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text != "") ValidateSQL();
        }

        private async void ComboBoxServerDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!await DatabaseCorrect())
            {
                MessageBox.Show("W podanej bazie nie znaleziono odpowiednich danych.\nUpewnij się, że wybrano prawidłową bazę danych (Subiekt GT).");
                comboBoxServerDatabase.Text = "";
            }
        }

        public async Task<bool> MagentoTest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + textBoxApiToken.Text);
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(textBoxApiUrl.Text + url).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        using (HttpContent responseContent = response.Content)
                        {
                            await responseContent.ReadAsStringAsync().ConfigureAwait(false);
                            return true;
                        }
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Wystąpił błąd: "+ e.Message);
                    return false;
                }
            }
        }

        private async void ButtonApiTest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxApiUrl.Text) && !string.IsNullOrEmpty(textBoxApiToken.Text))
            {
                string currentText = buttonApiTest.Text;
                buttonApiTest.Text = "Łączę...";
                bool testResponse = await Task.Run(() => MagentoTest("products/attributes/types"));
                if (testResponse)
                    MessageBox.Show("Udało się połączyć z Magento.");
                buttonApiTest.Text = currentText;
            } else
                MessageBox.Show("Podaj dane Rest API Magento 2");
            
        }

        private async void comboBoxServerDatabase_Leave(object sender, EventArgs e)
        {
            if ((comboBoxServerDatabase.Text != "") && (!await DatabaseCorrect()))
            {
                MessageBox.Show("W podanej bazie nie znaleziono odpowiednich danych.\nUpewnij się, że wybrano prawidłową bazę danych (Subiekt GT).");
                comboBoxServerDatabase.Text = "";
            }
        }

        private void comboBoxServer_TextChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text != "")
            {
                overrideServer = false;
                ValidateSQL();
            } else
            {
                ErrorHandler();
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            await LoginToDatabase(comboBoxServerDatabase.DroppedDown);
        }
    }

}
