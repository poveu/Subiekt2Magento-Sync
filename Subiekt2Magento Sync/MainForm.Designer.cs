namespace Subiekt2Magento_Sync
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dataGridViewLinks;
		private System.Windows.Forms.Button buttonSendLinks;
		private System.Windows.Forms.RichTextBox richTextBoxLinksStatus;
		private System.Windows.Forms.TableLayoutPanel tableLinksButtons;
		private System.Windows.Forms.Button buttonLinksSettings;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripLinks;
		private System.Windows.Forms.ToolStripMenuItem toolStripToggleSelected;
		private System.Windows.Forms.ToolStripMenuItem toolStripSelectAll;
		private System.Windows.Forms.ToolStripMenuItem toolStripUnselectAll;
		private System.Windows.Forms.ToolStripMenuItem toolStripCopySelected;
		private System.Windows.Forms.Label labelLinksFilter;
		private System.Windows.Forms.TextBox textBoxLinksFilterName;
		private System.Windows.Forms.Button buttonLinksFilter;
		private System.Windows.Forms.ComboBox comboBoxLinksFilterGroup;
		private System.Windows.Forms.Label labelLinksFilterGroup;
		private System.Windows.Forms.Label labelLinksFilterName;

		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
			
		}
		
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridViewLinks = new System.Windows.Forms.DataGridView();
            this.contextMenuStripLinks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripToggleSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCopySelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCopySku = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripRefreshLinks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSfera = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSendLinks = new System.Windows.Forms.Button();
            this.richTextBoxLinksStatus = new System.Windows.Forms.RichTextBox();
            this.tableLinksButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLinksSettings = new System.Windows.Forms.Button();
            this.textBoxLinksFilterName = new System.Windows.Forms.TextBox();
            this.labelLinksFilter = new System.Windows.Forms.Label();
            this.buttonLinksFilter = new System.Windows.Forms.Button();
            this.comboBoxLinksFilterGroup = new System.Windows.Forms.ComboBox();
            this.labelLinksFilterGroup = new System.Windows.Forms.Label();
            this.labelLinksFilterName = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLinks = new System.Windows.Forms.TabPage();
            this.progressBarLinks = new System.Windows.Forms.ProgressBar();
            this.tabPageAttributes = new System.Windows.Forms.TabPage();
            this.progressBarAttributes = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanelAttributes = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewAttributes = new System.Windows.Forms.DataGridView();
            this.contextMenuStripAttributes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripAddAttribute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripRefreshAttributes = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.contextMenuStripProducts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripRefreshProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tableAttributesButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSendAttributes = new System.Windows.Forms.Button();
            this.buttonAttributesSettings = new System.Windows.Forms.Button();
            this.labelAttributesFilter = new System.Windows.Forms.Label();
            this.labelAttributesFilterName = new System.Windows.Forms.Label();
            this.richTextBoxAttributesStatus = new System.Windows.Forms.RichTextBox();
            this.labelAttributesFilterGroup = new System.Windows.Forms.Label();
            this.comboBoxAttributesFilterGroup = new System.Windows.Forms.ComboBox();
            this.textBoxAttributesFilterName = new System.Windows.Forms.TextBox();
            this.buttonAttributesFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLinks)).BeginInit();
            this.contextMenuStripLinks.SuspendLayout();
            this.tableLinksButtons.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageLinks.SuspendLayout();
            this.tabPageAttributes.SuspendLayout();
            this.tableLayoutPanelAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).BeginInit();
            this.contextMenuStripAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.contextMenuStripProducts.SuspendLayout();
            this.tableAttributesButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLinks
            // 
            this.dataGridViewLinks.AllowUserToAddRows = false;
            this.dataGridViewLinks.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.dataGridViewLinks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLinks.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewLinks.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(229)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLinks.ContextMenuStrip = this.contextMenuStripLinks;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLinks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewLinks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.dataGridViewLinks.Location = new System.Drawing.Point(6, 33);
            this.dataGridViewLinks.MinimumSize = new System.Drawing.Size(0, 25);
            this.dataGridViewLinks.Name = "dataGridViewLinks";
            this.dataGridViewLinks.RowHeadersWidth = 20;
            this.dataGridViewLinks.RowTemplate.Height = 25;
            this.dataGridViewLinks.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLinks.Size = new System.Drawing.Size(1419, 434);
            this.dataGridViewLinks.TabIndex = 0;
            this.dataGridViewLinks.DataSourceChanged += new System.EventHandler(this.DataGridViewLinks_DataSourceChanged);
            this.dataGridViewLinks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewLinks_CellClick);
            this.dataGridViewLinks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewLinksCellDoubleClick);
            this.dataGridViewLinks.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewLinksCellEndEdit);
            this.dataGridViewLinks.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewLinksCellPainting);
            this.dataGridViewLinks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewLinksKeyDown);
            // 
            // contextMenuStripLinks
            // 
            this.contextMenuStripLinks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSelectAll,
            this.toolStripUnselectAll,
            this.toolStripToggleSelected,
            this.toolStripCopySelected,
            this.toolStripCopySku,
            this.toolStripRefreshLinks,
            this.toolStripSfera});
            this.contextMenuStripLinks.Name = "contextMenuStrip1";
            this.contextMenuStripLinks.Size = new System.Drawing.Size(247, 158);
            // 
            // toolStripSelectAll
            // 
            this.toolStripSelectAll.Name = "toolStripSelectAll";
            this.toolStripSelectAll.Size = new System.Drawing.Size(246, 22);
            this.toolStripSelectAll.Text = "Zaznacz wszystko";
            this.toolStripSelectAll.Click += new System.EventHandler(this.ToolStripSelectAll_Click);
            // 
            // toolStripUnselectAll
            // 
            this.toolStripUnselectAll.Name = "toolStripUnselectAll";
            this.toolStripUnselectAll.Size = new System.Drawing.Size(246, 22);
            this.toolStripUnselectAll.Text = "Odznacz wszystko";
            this.toolStripUnselectAll.Click += new System.EventHandler(this.ToolStripUnselectAll_Click);
            // 
            // toolStripToggleSelected
            // 
            this.toolStripToggleSelected.Name = "toolStripToggleSelected";
            this.toolStripToggleSelected.Size = new System.Drawing.Size(246, 22);
            this.toolStripToggleSelected.Text = "Zaznacz/odznacz wybrane";
            this.toolStripToggleSelected.Click += new System.EventHandler(this.ToolStripToggleSelected_Click);
            // 
            // toolStripCopySelected
            // 
            this.toolStripCopySelected.Name = "toolStripCopySelected";
            this.toolStripCopySelected.Size = new System.Drawing.Size(246, 22);
            this.toolStripCopySelected.Text = "Kopiuj wybrane wiersze";
            this.toolStripCopySelected.Click += new System.EventHandler(this.ToolStripCopySelected_Click);
            // 
            // toolStripCopySku
            // 
            this.toolStripCopySku.Name = "toolStripCopySku";
            this.toolStripCopySku.Size = new System.Drawing.Size(246, 22);
            this.toolStripCopySku.Text = "Kopiuj symbol";
            this.toolStripCopySku.Click += new System.EventHandler(this.ToolStripCopySku_Click);
            // 
            // toolStripRefreshLinks
            // 
            this.toolStripRefreshLinks.Name = "toolStripRefreshLinks";
            this.toolStripRefreshLinks.Size = new System.Drawing.Size(246, 22);
            this.toolStripRefreshLinks.Text = "Odśwież listę";
            this.toolStripRefreshLinks.Click += new System.EventHandler(this.ToolStripRefreshLinks_Click);
            // 
            // toolStripSfera
            // 
            this.toolStripSfera.Name = "toolStripSfera";
            this.toolStripSfera.Size = new System.Drawing.Size(246, 22);
            this.toolStripSfera.Text = "Przypisz brakujące towary (Sfera)";
            this.toolStripSfera.Click += new System.EventHandler(this.toolStripSfera_Click);
            // 
            // buttonSendLinks
            // 
            this.buttonSendLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendLinks.Enabled = false;
            this.buttonSendLinks.Location = new System.Drawing.Point(0, 3);
            this.buttonSendLinks.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.buttonSendLinks.Name = "buttonSendLinks";
            this.buttonSendLinks.Size = new System.Drawing.Size(706, 42);
            this.buttonSendLinks.TabIndex = 4;
            this.buttonSendLinks.Text = "Wyślij dane powiązań do sklepu";
            this.buttonSendLinks.UseVisualStyleBackColor = true;
            this.buttonSendLinks.Click += new System.EventHandler(this.ButtonSendLinks_Click);
            // 
            // richTextBoxLinksStatus
            // 
            this.richTextBoxLinksStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLinksStatus.Location = new System.Drawing.Point(6, 473);
            this.richTextBoxLinksStatus.Name = "richTextBoxLinksStatus";
            this.richTextBoxLinksStatus.ReadOnly = true;
            this.richTextBoxLinksStatus.Size = new System.Drawing.Size(1419, 117);
            this.richTextBoxLinksStatus.TabIndex = 5;
            this.richTextBoxLinksStatus.Text = "Tutaj przypiszesz towarom powiązania do innych towarów.";
            this.richTextBoxLinksStatus.WordWrap = false;
            // 
            // tableLinksButtons
            // 
            this.tableLinksButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLinksButtons.ColumnCount = 2;
            this.tableLinksButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLinksButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLinksButtons.Controls.Add(this.buttonSendLinks, 0, 0);
            this.tableLinksButtons.Controls.Add(this.buttonLinksSettings, 1, 0);
            this.tableLinksButtons.Location = new System.Drawing.Point(6, 622);
            this.tableLinksButtons.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLinksButtons.Name = "tableLinksButtons";
            this.tableLinksButtons.RowCount = 1;
            this.tableLinksButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLinksButtons.Size = new System.Drawing.Size(1419, 48);
            this.tableLinksButtons.TabIndex = 6;
            // 
            // buttonLinksSettings
            // 
            this.buttonLinksSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLinksSettings.Location = new System.Drawing.Point(712, 3);
            this.buttonLinksSettings.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.buttonLinksSettings.Name = "buttonLinksSettings";
            this.buttonLinksSettings.Size = new System.Drawing.Size(707, 42);
            this.buttonLinksSettings.TabIndex = 5;
            this.buttonLinksSettings.Text = "Ustawienia aplikacji";
            this.buttonLinksSettings.UseVisualStyleBackColor = true;
            this.buttonLinksSettings.Click += new System.EventHandler(this.ButtonLinksSettings_Click);
            // 
            // textBoxLinksFilterName
            // 
            this.textBoxLinksFilterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLinksFilterName.Enabled = false;
            this.textBoxLinksFilterName.Location = new System.Drawing.Point(427, 6);
            this.textBoxLinksFilterName.Name = "textBoxLinksFilterName";
            this.textBoxLinksFilterName.Size = new System.Drawing.Size(920, 20);
            this.textBoxLinksFilterName.TabIndex = 8;
            this.textBoxLinksFilterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxLinksFilterName_KeyDown);
            // 
            // labelLinksFilter
            // 
            this.labelLinksFilter.Location = new System.Drawing.Point(6, 8);
            this.labelLinksFilter.Name = "labelLinksFilter";
            this.labelLinksFilter.Size = new System.Drawing.Size(67, 20);
            this.labelLinksFilter.TabIndex = 9;
            this.labelLinksFilter.Text = "Filtruj wyniki:";
            // 
            // buttonLinksFilter
            // 
            this.buttonLinksFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLinksFilter.Enabled = false;
            this.buttonLinksFilter.Location = new System.Drawing.Point(1353, 6);
            this.buttonLinksFilter.Name = "buttonLinksFilter";
            this.buttonLinksFilter.Size = new System.Drawing.Size(72, 21);
            this.buttonLinksFilter.TabIndex = 10;
            this.buttonLinksFilter.Text = "Filtruj";
            this.buttonLinksFilter.UseVisualStyleBackColor = true;
            this.buttonLinksFilter.Click += new System.EventHandler(this.ButtonLinksFilter_Click);
            // 
            // comboBoxLinksFilterGroup
            // 
            this.comboBoxLinksFilterGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLinksFilterGroup.Enabled = false;
            this.comboBoxLinksFilterGroup.Location = new System.Drawing.Point(133, 6);
            this.comboBoxLinksFilterGroup.Name = "comboBoxLinksFilterGroup";
            this.comboBoxLinksFilterGroup.Size = new System.Drawing.Size(171, 21);
            this.comboBoxLinksFilterGroup.Sorted = true;
            this.comboBoxLinksFilterGroup.TabIndex = 11;
            this.comboBoxLinksFilterGroup.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLinksFilterGroup_SelectedIndexChanged);
            // 
            // labelLinksFilterGroup
            // 
            this.labelLinksFilterGroup.Location = new System.Drawing.Point(89, 8);
            this.labelLinksFilterGroup.Name = "labelLinksFilterGroup";
            this.labelLinksFilterGroup.Size = new System.Drawing.Size(42, 20);
            this.labelLinksFilterGroup.TabIndex = 12;
            this.labelLinksFilterGroup.Text = "Grupa:";
            // 
            // labelLinksFilterName
            // 
            this.labelLinksFilterName.Location = new System.Drawing.Point(330, 8);
            this.labelLinksFilterName.Name = "labelLinksFilterName";
            this.labelLinksFilterName.Size = new System.Drawing.Size(97, 20);
            this.labelLinksFilterName.TabIndex = 13;
            this.labelLinksFilterName.Text = "Nazwa lub symbol:";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageLinks);
            this.tabControl.Controls.Add(this.tabPageAttributes);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1439, 702);
            this.tabControl.TabIndex = 14;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPageLinks
            // 
            this.tabPageLinks.Controls.Add(this.progressBarLinks);
            this.tabPageLinks.Controls.Add(this.labelLinksFilter);
            this.tabPageLinks.Controls.Add(this.dataGridViewLinks);
            this.tabPageLinks.Controls.Add(this.labelLinksFilterName);
            this.tabPageLinks.Controls.Add(this.richTextBoxLinksStatus);
            this.tabPageLinks.Controls.Add(this.labelLinksFilterGroup);
            this.tabPageLinks.Controls.Add(this.tableLinksButtons);
            this.tabPageLinks.Controls.Add(this.comboBoxLinksFilterGroup);
            this.tabPageLinks.Controls.Add(this.textBoxLinksFilterName);
            this.tabPageLinks.Controls.Add(this.buttonLinksFilter);
            this.tabPageLinks.Location = new System.Drawing.Point(4, 22);
            this.tabPageLinks.Name = "tabPageLinks";
            this.tabPageLinks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLinks.Size = new System.Drawing.Size(1431, 676);
            this.tabPageLinks.TabIndex = 0;
            this.tabPageLinks.Text = "Powiązane produkty";
            this.tabPageLinks.UseVisualStyleBackColor = true;
            // 
            // progressBarLinks
            // 
            this.progressBarLinks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarLinks.Location = new System.Drawing.Point(6, 596);
            this.progressBarLinks.Name = "progressBarLinks";
            this.progressBarLinks.Size = new System.Drawing.Size(1419, 23);
            this.progressBarLinks.Step = 1;
            this.progressBarLinks.TabIndex = 25;
            // 
            // tabPageAttributes
            // 
            this.tabPageAttributes.Controls.Add(this.progressBarAttributes);
            this.tabPageAttributes.Controls.Add(this.tableLayoutPanelAttributes);
            this.tabPageAttributes.Controls.Add(this.tableAttributesButtons);
            this.tabPageAttributes.Controls.Add(this.labelAttributesFilter);
            this.tabPageAttributes.Controls.Add(this.labelAttributesFilterName);
            this.tabPageAttributes.Controls.Add(this.richTextBoxAttributesStatus);
            this.tabPageAttributes.Controls.Add(this.labelAttributesFilterGroup);
            this.tabPageAttributes.Controls.Add(this.comboBoxAttributesFilterGroup);
            this.tabPageAttributes.Controls.Add(this.textBoxAttributesFilterName);
            this.tabPageAttributes.Controls.Add(this.buttonAttributesFilter);
            this.tabPageAttributes.Location = new System.Drawing.Point(4, 22);
            this.tabPageAttributes.Name = "tabPageAttributes";
            this.tabPageAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAttributes.Size = new System.Drawing.Size(1431, 676);
            this.tabPageAttributes.TabIndex = 1;
            this.tabPageAttributes.Text = "Atrybuty produktów";
            this.tabPageAttributes.UseVisualStyleBackColor = true;
            // 
            // progressBarAttributes
            // 
            this.progressBarAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarAttributes.Location = new System.Drawing.Point(6, 596);
            this.progressBarAttributes.Name = "progressBarAttributes";
            this.progressBarAttributes.Size = new System.Drawing.Size(1419, 23);
            this.progressBarAttributes.Step = 1;
            this.progressBarAttributes.TabIndex = 24;
            // 
            // tableLayoutPanelAttributes
            // 
            this.tableLayoutPanelAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelAttributes.ColumnCount = 2;
            this.tableLayoutPanelAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelAttributes.Controls.Add(this.dataGridViewAttributes, 1, 0);
            this.tableLayoutPanelAttributes.Controls.Add(this.dataGridViewProducts, 0, 0);
            this.tableLayoutPanelAttributes.Location = new System.Drawing.Point(6, 33);
            this.tableLayoutPanelAttributes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tableLayoutPanelAttributes.Name = "tableLayoutPanelAttributes";
            this.tableLayoutPanelAttributes.RowCount = 1;
            this.tableLayoutPanelAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAttributes.Size = new System.Drawing.Size(1419, 434);
            this.tableLayoutPanelAttributes.TabIndex = 23;
            // 
            // dataGridViewAttributes
            // 
            this.dataGridViewAttributes.AllowUserToAddRows = false;
            this.dataGridViewAttributes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.dataGridViewAttributes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAttributes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewAttributes.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewAttributes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(229)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttributes.ContextMenuStrip = this.contextMenuStripAttributes;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAttributes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewAttributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAttributes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.dataGridViewAttributes.Location = new System.Drawing.Point(995, 0);
            this.dataGridViewAttributes.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dataGridViewAttributes.MinimumSize = new System.Drawing.Size(0, 25);
            this.dataGridViewAttributes.MultiSelect = false;
            this.dataGridViewAttributes.Name = "dataGridViewAttributes";
            this.dataGridViewAttributes.RowHeadersWidth = 20;
            this.dataGridViewAttributes.RowTemplate.Height = 25;
            this.dataGridViewAttributes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAttributes.Size = new System.Drawing.Size(424, 434);
            this.dataGridViewAttributes.TabIndex = 15;
            this.dataGridViewAttributes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAttributes_CellDoubleClick);
            this.dataGridViewAttributes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAttributes_CellEndEdit);
            this.dataGridViewAttributes.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewAttributes_EditingControlShowing);
            this.dataGridViewAttributes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewAttributes_KeyDown);
            this.dataGridViewAttributes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewAttributes_KeyPress);
            // 
            // contextMenuStripAttributes
            // 
            this.contextMenuStripAttributes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddAttribute,
            this.toolStripRefreshAttributes});
            this.contextMenuStripAttributes.Name = "contextMenuStrip2";
            this.contextMenuStripAttributes.Size = new System.Drawing.Size(300, 48);
            // 
            // toolStripAddAttribute
            // 
            this.toolStripAddAttribute.Name = "toolStripAddAttribute";
            this.toolStripAddAttribute.Size = new System.Drawing.Size(299, 22);
            this.toolStripAddAttribute.Text = "Dodaj atrybut do grupy wybranego towaru";
            this.toolStripAddAttribute.Click += new System.EventHandler(this.ToolStripAddAttribute_Click);
            // 
            // toolStripRefreshAttributes
            // 
            this.toolStripRefreshAttributes.Name = "toolStripRefreshAttributes";
            this.toolStripRefreshAttributes.Size = new System.Drawing.Size(299, 22);
            this.toolStripRefreshAttributes.Text = "Odśwież listę";
            this.toolStripRefreshAttributes.Click += new System.EventHandler(this.ToolStripRefreshAttributes_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.dataGridViewProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProducts.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewProducts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(229)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.ContextMenuStrip = this.contextMenuStripProducts;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProducts.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.dataGridViewProducts.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProducts.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.dataGridViewProducts.MinimumSize = new System.Drawing.Size(0, 25);
            this.dataGridViewProducts.MultiSelect = false;
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 20;
            this.dataGridViewProducts.RowTemplate.Height = 25;
            this.dataGridViewProducts.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(991, 434);
            this.dataGridViewProducts.TabIndex = 14;
            this.dataGridViewProducts.DataSourceChanged += new System.EventHandler(this.DataGridViewProducts_DataSourceChanged);
            this.dataGridViewProducts.SelectionChanged += new System.EventHandler(this.DataGridViewProducts_SelectionChanged);
            // 
            // contextMenuStripProducts
            // 
            this.contextMenuStripProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRefreshProducts});
            this.contextMenuStripProducts.Name = "contextMenuStrip3";
            this.contextMenuStripProducts.Size = new System.Drawing.Size(143, 26);
            // 
            // toolStripRefreshProducts
            // 
            this.toolStripRefreshProducts.Name = "toolStripRefreshProducts";
            this.toolStripRefreshProducts.Size = new System.Drawing.Size(142, 22);
            this.toolStripRefreshProducts.Text = "Odśwież listę";
            this.toolStripRefreshProducts.Click += new System.EventHandler(this.ToolStripRefreshProducts_Click);
            // 
            // tableAttributesButtons
            // 
            this.tableAttributesButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableAttributesButtons.ColumnCount = 2;
            this.tableAttributesButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableAttributesButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableAttributesButtons.Controls.Add(this.buttonSendAttributes, 0, 0);
            this.tableAttributesButtons.Controls.Add(this.buttonAttributesSettings, 1, 0);
            this.tableAttributesButtons.Location = new System.Drawing.Point(6, 622);
            this.tableAttributesButtons.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableAttributesButtons.Name = "tableAttributesButtons";
            this.tableAttributesButtons.RowCount = 1;
            this.tableAttributesButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAttributesButtons.Size = new System.Drawing.Size(1419, 48);
            this.tableAttributesButtons.TabIndex = 22;
            // 
            // buttonSendAttributes
            // 
            this.buttonSendAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendAttributes.Enabled = false;
            this.buttonSendAttributes.Location = new System.Drawing.Point(0, 3);
            this.buttonSendAttributes.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.buttonSendAttributes.Name = "buttonSendAttributes";
            this.buttonSendAttributes.Size = new System.Drawing.Size(706, 42);
            this.buttonSendAttributes.TabIndex = 4;
            this.buttonSendAttributes.Text = "Wyślij atrybuty towarów do sklepu";
            this.buttonSendAttributes.UseVisualStyleBackColor = true;
            this.buttonSendAttributes.Click += new System.EventHandler(this.ButtonSendAttributes_Click);
            // 
            // buttonAttributesSettings
            // 
            this.buttonAttributesSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAttributesSettings.Location = new System.Drawing.Point(712, 3);
            this.buttonAttributesSettings.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.buttonAttributesSettings.Name = "buttonAttributesSettings";
            this.buttonAttributesSettings.Size = new System.Drawing.Size(707, 42);
            this.buttonAttributesSettings.TabIndex = 5;
            this.buttonAttributesSettings.Text = "Ustawienia aplikacji";
            this.buttonAttributesSettings.UseVisualStyleBackColor = true;
            this.buttonAttributesSettings.Click += new System.EventHandler(this.ButtonAttributesSettings_Click);
            // 
            // labelAttributesFilter
            // 
            this.labelAttributesFilter.Location = new System.Drawing.Point(6, 8);
            this.labelAttributesFilter.Name = "labelAttributesFilter";
            this.labelAttributesFilter.Size = new System.Drawing.Size(67, 20);
            this.labelAttributesFilter.TabIndex = 17;
            this.labelAttributesFilter.Text = "Filtruj wyniki:";
            // 
            // labelAttributesFilterName
            // 
            this.labelAttributesFilterName.Location = new System.Drawing.Point(330, 8);
            this.labelAttributesFilterName.Name = "labelAttributesFilterName";
            this.labelAttributesFilterName.Size = new System.Drawing.Size(97, 20);
            this.labelAttributesFilterName.TabIndex = 21;
            this.labelAttributesFilterName.Text = "Nazwa lub symbol:";
            // 
            // richTextBoxAttributesStatus
            // 
            this.richTextBoxAttributesStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAttributesStatus.Location = new System.Drawing.Point(6, 473);
            this.richTextBoxAttributesStatus.Name = "richTextBoxAttributesStatus";
            this.richTextBoxAttributesStatus.ReadOnly = true;
            this.richTextBoxAttributesStatus.Size = new System.Drawing.Size(1419, 117);
            this.richTextBoxAttributesStatus.TabIndex = 15;
            this.richTextBoxAttributesStatus.Text = "Tutaj przypiszesz lub dodasz nowe atrybuty do produktów, zapisując je w dodatkowy" +
    "ch tabelach w bazie danych.";
            this.richTextBoxAttributesStatus.WordWrap = false;
            // 
            // labelAttributesFilterGroup
            // 
            this.labelAttributesFilterGroup.Location = new System.Drawing.Point(89, 8);
            this.labelAttributesFilterGroup.Name = "labelAttributesFilterGroup";
            this.labelAttributesFilterGroup.Size = new System.Drawing.Size(42, 20);
            this.labelAttributesFilterGroup.TabIndex = 20;
            this.labelAttributesFilterGroup.Text = "Grupa:";
            // 
            // comboBoxAttributesFilterGroup
            // 
            this.comboBoxAttributesFilterGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttributesFilterGroup.Enabled = false;
            this.comboBoxAttributesFilterGroup.Location = new System.Drawing.Point(133, 6);
            this.comboBoxAttributesFilterGroup.Name = "comboBoxAttributesFilterGroup";
            this.comboBoxAttributesFilterGroup.Size = new System.Drawing.Size(171, 21);
            this.comboBoxAttributesFilterGroup.Sorted = true;
            this.comboBoxAttributesFilterGroup.TabIndex = 19;
            this.comboBoxAttributesFilterGroup.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAttributesFilterGroup_SelectedIndexChanged);
            // 
            // textBoxAttributesFilterName
            // 
            this.textBoxAttributesFilterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAttributesFilterName.Enabled = false;
            this.textBoxAttributesFilterName.Location = new System.Drawing.Point(427, 6);
            this.textBoxAttributesFilterName.Name = "textBoxAttributesFilterName";
            this.textBoxAttributesFilterName.Size = new System.Drawing.Size(920, 20);
            this.textBoxAttributesFilterName.TabIndex = 16;
            this.textBoxAttributesFilterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxAttributesFilterName_KeyDown);
            // 
            // buttonAttributesFilter
            // 
            this.buttonAttributesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAttributesFilter.Enabled = false;
            this.buttonAttributesFilter.Location = new System.Drawing.Point(1353, 6);
            this.buttonAttributesFilter.Name = "buttonAttributesFilter";
            this.buttonAttributesFilter.Size = new System.Drawing.Size(72, 21);
            this.buttonAttributesFilter.TabIndex = 18;
            this.buttonAttributesFilter.Text = "Filtruj";
            this.buttonAttributesFilter.UseVisualStyleBackColor = true;
            this.buttonAttributesFilter.Click += new System.EventHandler(this.ButtonAttributesFilter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 726);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subiekt2Magento Sync";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLinks)).EndInit();
            this.contextMenuStripLinks.ResumeLayout(false);
            this.tableLinksButtons.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageLinks.ResumeLayout(false);
            this.tabPageLinks.PerformLayout();
            this.tabPageAttributes.ResumeLayout(false);
            this.tabPageAttributes.PerformLayout();
            this.tableLayoutPanelAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).EndInit();
            this.contextMenuStripAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.contextMenuStripProducts.ResumeLayout(false);
            this.tableAttributesButtons.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.ToolStripMenuItem toolStripCopySku;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLinks;
        private System.Windows.Forms.TabPage tabPageAttributes;
        private System.Windows.Forms.Label labelAttributesFilter;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Label labelAttributesFilterName;
        private System.Windows.Forms.RichTextBox richTextBoxAttributesStatus;
        private System.Windows.Forms.Label labelAttributesFilterGroup;
        private System.Windows.Forms.ComboBox comboBoxAttributesFilterGroup;
        private System.Windows.Forms.TextBox textBoxAttributesFilterName;
        private System.Windows.Forms.Button buttonAttributesFilter;
        private System.Windows.Forms.TableLayoutPanel tableAttributesButtons;
        private System.Windows.Forms.Button buttonAttributesSettings;
        private System.Windows.Forms.Button buttonSendAttributes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAttributes;
        private System.Windows.Forms.DataGridView dataGridViewAttributes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAttributes;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddAttribute;
        private System.Windows.Forms.ToolStripMenuItem toolStripRefreshAttributes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProducts;
        private System.Windows.Forms.ToolStripMenuItem toolStripRefreshProducts;
        private System.Windows.Forms.ToolStripMenuItem toolStripRefreshLinks;
        private System.Windows.Forms.ProgressBar progressBarLinks;
        private System.Windows.Forms.ProgressBar progressBarAttributes;
        private System.Windows.Forms.ToolStripMenuItem toolStripSfera;
    }
}

