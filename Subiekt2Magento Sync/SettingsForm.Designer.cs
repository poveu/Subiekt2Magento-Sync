namespace Subiekt2Magento_Sync
{
	partial class SettingsForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox comboBoxServerDatabase;
		private System.Windows.Forms.TextBox textBoxServerUser;
		private System.Windows.Forms.Label labelServerUser;
		private System.Windows.Forms.Label labelServer;
		private System.Windows.Forms.Label labelServerDatabase;
		private System.Windows.Forms.GroupBox groupBoxServer;
		private System.Windows.Forms.Label labelServerPassword;
		private System.Windows.Forms.TextBox textBoxServerPassword;
		private System.Windows.Forms.ComboBox comboBoxServer;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.GroupBox groupBoxApi;
		private System.Windows.Forms.Label labelApiToken;
		private System.Windows.Forms.TextBox textBoxApiToken;
		private System.Windows.Forms.Label labelApiUrl;
		private System.Windows.Forms.TextBox textBoxApiUrl;
		private System.Windows.Forms.GroupBox groupBoxOperator;
		private System.Windows.Forms.Label labelOperatorPassword;
		private System.Windows.Forms.TextBox textBoxOperatorPassword;
		private System.Windows.Forms.Label labelOperatorName;
		private System.Windows.Forms.GroupBox groupBoxLinks;
		private System.Windows.Forms.Label labelLinkedProducts;

		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.labelServerPassword = new System.Windows.Forms.Label();
            this.textBoxServerPassword = new System.Windows.Forms.TextBox();
            this.labelServerDatabase = new System.Windows.Forms.Label();
            this.comboBoxServerDatabase = new System.Windows.Forms.ComboBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelServerUser = new System.Windows.Forms.Label();
            this.textBoxServerUser = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxApi = new System.Windows.Forms.GroupBox();
            this.buttonApiTest = new System.Windows.Forms.Button();
            this.labelApiToken = new System.Windows.Forms.Label();
            this.textBoxApiToken = new System.Windows.Forms.TextBox();
            this.labelApiUrl = new System.Windows.Forms.Label();
            this.textBoxApiUrl = new System.Windows.Forms.TextBox();
            this.groupBoxOperator = new System.Windows.Forms.GroupBox();
            this.comboBoxOperatorName = new System.Windows.Forms.ComboBox();
            this.labelOperatorPassword = new System.Windows.Forms.Label();
            this.textBoxOperatorPassword = new System.Windows.Forms.TextBox();
            this.labelOperatorName = new System.Windows.Forms.Label();
            this.groupBoxLinks = new System.Windows.Forms.GroupBox();
            this.comboBoxSimilarProducts = new System.Windows.Forms.ComboBox();
            this.labelSimilarProducts = new System.Windows.Forms.Label();
            this.comboBoxLinkedProducts = new System.Windows.Forms.ComboBox();
            this.labelLinkedProducts = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxServer.SuspendLayout();
            this.groupBoxApi.SuspendLayout();
            this.groupBoxOperator.SuspendLayout();
            this.groupBoxLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxServer.Controls.Add(this.comboBoxServer);
            this.groupBoxServer.Controls.Add(this.labelServerPassword);
            this.groupBoxServer.Controls.Add(this.textBoxServerPassword);
            this.groupBoxServer.Controls.Add(this.labelServerDatabase);
            this.groupBoxServer.Controls.Add(this.comboBoxServerDatabase);
            this.groupBoxServer.Controls.Add(this.labelServer);
            this.groupBoxServer.Controls.Add(this.labelServerUser);
            this.groupBoxServer.Controls.Add(this.textBoxServerUser);
            this.groupBoxServer.Location = new System.Drawing.Point(12, 12);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(466, 129);
            this.groupBoxServer.TabIndex = 0;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Dane bazy danych Subiekta";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(190, 18);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(270, 21);
            this.comboBoxServer.TabIndex = 0;
            this.comboBoxServer.SelectedIndexChanged += new System.EventHandler(this.ComboBoxServer_SelectedIndexChanged);
            this.comboBoxServer.TextChanged += new System.EventHandler(this.comboBoxServer_TextChanged);
            this.comboBoxServer.Leave += new System.EventHandler(this.ComboBoxServer_Leave);
            // 
            // labelServerPassword
            // 
            this.labelServerPassword.Location = new System.Drawing.Point(6, 74);
            this.labelServerPassword.Name = "labelServerPassword";
            this.labelServerPassword.Size = new System.Drawing.Size(111, 23);
            this.labelServerPassword.TabIndex = 17;
            this.labelServerPassword.Text = "Hasło serwera:";
            // 
            // textBoxServerPassword
            // 
            this.textBoxServerPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerPassword.Location = new System.Drawing.Point(190, 71);
            this.textBoxServerPassword.Name = "textBoxServerPassword";
            this.textBoxServerPassword.PasswordChar = '*';
            this.textBoxServerPassword.Size = new System.Drawing.Size(270, 20);
            this.textBoxServerPassword.TabIndex = 2;
            this.textBoxServerPassword.TextChanged += new System.EventHandler(this.TextBoxServerPassword_TextChanged);
            // 
            // labelServerDatabase
            // 
            this.labelServerDatabase.Location = new System.Drawing.Point(6, 100);
            this.labelServerDatabase.Name = "labelServerDatabase";
            this.labelServerDatabase.Size = new System.Drawing.Size(123, 23);
            this.labelServerDatabase.TabIndex = 15;
            this.labelServerDatabase.Text = "Baza danych Subiekta:";
            // 
            // comboBoxServerDatabase
            // 
            this.comboBoxServerDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxServerDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxServerDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxServerDatabase.FormattingEnabled = true;
            this.comboBoxServerDatabase.Location = new System.Drawing.Point(190, 97);
            this.comboBoxServerDatabase.Name = "comboBoxServerDatabase";
            this.comboBoxServerDatabase.Size = new System.Drawing.Size(270, 21);
            this.comboBoxServerDatabase.TabIndex = 3;
            this.comboBoxServerDatabase.SelectedIndexChanged += new System.EventHandler(this.ComboBoxServerDatabase_SelectedIndexChanged);
            this.comboBoxServerDatabase.Leave += new System.EventHandler(this.comboBoxServerDatabase_Leave);
            // 
            // labelServer
            // 
            this.labelServer.Location = new System.Drawing.Point(6, 22);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(111, 23);
            this.labelServer.TabIndex = 13;
            this.labelServer.Text = "Serwer:";
            // 
            // labelServerUser
            // 
            this.labelServerUser.Location = new System.Drawing.Point(6, 48);
            this.labelServerUser.Name = "labelServerUser";
            this.labelServerUser.Size = new System.Drawing.Size(111, 23);
            this.labelServerUser.TabIndex = 10;
            this.labelServerUser.Text = "Użytkownik serwera:";
            // 
            // textBoxServerUser
            // 
            this.textBoxServerUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerUser.Location = new System.Drawing.Point(190, 45);
            this.textBoxServerUser.Name = "textBoxServerUser";
            this.textBoxServerUser.Size = new System.Drawing.Size(270, 20);
            this.textBoxServerUser.TabIndex = 1;
            this.textBoxServerUser.TextChanged += new System.EventHandler(this.TextBoxServerUser_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(12, 428);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(466, 39);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Zapisz ustawienia";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // groupBoxApi
            // 
            this.groupBoxApi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxApi.Controls.Add(this.buttonApiTest);
            this.groupBoxApi.Controls.Add(this.labelApiToken);
            this.groupBoxApi.Controls.Add(this.textBoxApiToken);
            this.groupBoxApi.Controls.Add(this.labelApiUrl);
            this.groupBoxApi.Controls.Add(this.textBoxApiUrl);
            this.groupBoxApi.Location = new System.Drawing.Point(12, 229);
            this.groupBoxApi.Name = "groupBoxApi";
            this.groupBoxApi.Size = new System.Drawing.Size(466, 103);
            this.groupBoxApi.TabIndex = 2;
            this.groupBoxApi.TabStop = false;
            this.groupBoxApi.Text = "Dane Magento API";
            // 
            // buttonApiTest
            // 
            this.buttonApiTest.Location = new System.Drawing.Point(190, 71);
            this.buttonApiTest.Name = "buttonApiTest";
            this.buttonApiTest.Size = new System.Drawing.Size(270, 23);
            this.buttonApiTest.TabIndex = 2;
            this.buttonApiTest.Text = "Przetestuj połączenie";
            this.buttonApiTest.UseVisualStyleBackColor = true;
            this.buttonApiTest.Click += new System.EventHandler(this.ButtonApiTest_Click);
            // 
            // labelApiToken
            // 
            this.labelApiToken.Location = new System.Drawing.Point(6, 48);
            this.labelApiToken.Name = "labelApiToken";
            this.labelApiToken.Size = new System.Drawing.Size(111, 23);
            this.labelApiToken.TabIndex = 21;
            this.labelApiToken.Text = "Token dostępu:";
            // 
            // textBoxApiToken
            // 
            this.textBoxApiToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApiToken.Location = new System.Drawing.Point(190, 45);
            this.textBoxApiToken.Name = "textBoxApiToken";
            this.textBoxApiToken.Size = new System.Drawing.Size(270, 20);
            this.textBoxApiToken.TabIndex = 1;
            // 
            // labelApiUrl
            // 
            this.labelApiUrl.Location = new System.Drawing.Point(6, 22);
            this.labelApiUrl.Name = "labelApiUrl";
            this.labelApiUrl.Size = new System.Drawing.Size(111, 23);
            this.labelApiUrl.TabIndex = 20;
            this.labelApiUrl.Text = "Adres API:";
            // 
            // textBoxApiUrl
            // 
            this.textBoxApiUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApiUrl.Location = new System.Drawing.Point(190, 19);
            this.textBoxApiUrl.Name = "textBoxApiUrl";
            this.textBoxApiUrl.Size = new System.Drawing.Size(270, 20);
            this.textBoxApiUrl.TabIndex = 0;
            // 
            // groupBoxOperator
            // 
            this.groupBoxOperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOperator.Controls.Add(this.comboBoxOperatorName);
            this.groupBoxOperator.Controls.Add(this.labelOperatorPassword);
            this.groupBoxOperator.Controls.Add(this.textBoxOperatorPassword);
            this.groupBoxOperator.Controls.Add(this.labelOperatorName);
            this.groupBoxOperator.Enabled = false;
            this.groupBoxOperator.Location = new System.Drawing.Point(12, 147);
            this.groupBoxOperator.Name = "groupBoxOperator";
            this.groupBoxOperator.Size = new System.Drawing.Size(466, 76);
            this.groupBoxOperator.TabIndex = 1;
            this.groupBoxOperator.TabStop = false;
            this.groupBoxOperator.Text = "Dane użytkownika Subiekta";
            // 
            // comboBoxOperatorName
            // 
            this.comboBoxOperatorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOperatorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperatorName.FormattingEnabled = true;
            this.comboBoxOperatorName.Location = new System.Drawing.Point(190, 18);
            this.comboBoxOperatorName.Name = "comboBoxOperatorName";
            this.comboBoxOperatorName.Size = new System.Drawing.Size(270, 21);
            this.comboBoxOperatorName.TabIndex = 0;
            this.comboBoxOperatorName.DropDown += new System.EventHandler(this.ComboBoxOperatorName_DropDown);
            // 
            // labelOperatorPassword
            // 
            this.labelOperatorPassword.Location = new System.Drawing.Point(6, 48);
            this.labelOperatorPassword.Name = "labelOperatorPassword";
            this.labelOperatorPassword.Size = new System.Drawing.Size(111, 23);
            this.labelOperatorPassword.TabIndex = 21;
            this.labelOperatorPassword.Text = "Hasło pracownika:";
            // 
            // textBoxOperatorPassword
            // 
            this.textBoxOperatorPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOperatorPassword.Location = new System.Drawing.Point(190, 45);
            this.textBoxOperatorPassword.Name = "textBoxOperatorPassword";
            this.textBoxOperatorPassword.PasswordChar = '*';
            this.textBoxOperatorPassword.Size = new System.Drawing.Size(270, 20);
            this.textBoxOperatorPassword.TabIndex = 1;
            // 
            // labelOperatorName
            // 
            this.labelOperatorName.Location = new System.Drawing.Point(6, 22);
            this.labelOperatorName.Name = "labelOperatorName";
            this.labelOperatorName.Size = new System.Drawing.Size(149, 23);
            this.labelOperatorName.TabIndex = 20;
            this.labelOperatorName.Text = "Pracownik:";
            // 
            // groupBoxLinks
            // 
            this.groupBoxLinks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLinks.Controls.Add(this.comboBoxSimilarProducts);
            this.groupBoxLinks.Controls.Add(this.labelSimilarProducts);
            this.groupBoxLinks.Controls.Add(this.comboBoxLinkedProducts);
            this.groupBoxLinks.Controls.Add(this.labelLinkedProducts);
            this.groupBoxLinks.Location = new System.Drawing.Point(12, 338);
            this.groupBoxLinks.Name = "groupBoxLinks";
            this.groupBoxLinks.Size = new System.Drawing.Size(466, 80);
            this.groupBoxLinks.TabIndex = 3;
            this.groupBoxLinks.TabStop = false;
            this.groupBoxLinks.Text = "Dodatkowe ustawienia";
            // 
            // comboBoxSimilarProducts
            // 
            this.comboBoxSimilarProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSimilarProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSimilarProducts.FormattingEnabled = true;
            this.comboBoxSimilarProducts.Location = new System.Drawing.Point(190, 45);
            this.comboBoxSimilarProducts.Name = "comboBoxSimilarProducts";
            this.comboBoxSimilarProducts.Size = new System.Drawing.Size(270, 21);
            this.comboBoxSimilarProducts.TabIndex = 1;
            this.comboBoxSimilarProducts.DropDown += new System.EventHandler(this.ComboBoxSimilarProducts_DropDown);
            // 
            // labelSimilarProducts
            // 
            this.labelSimilarProducts.Location = new System.Drawing.Point(6, 49);
            this.labelSimilarProducts.Name = "labelSimilarProducts";
            this.labelSimilarProducts.Size = new System.Drawing.Size(178, 17);
            this.labelSimilarProducts.TabIndex = 24;
            this.labelSimilarProducts.Text = "Pole własne podobnych towarów:";
            // 
            // comboBoxLinkedProducts
            // 
            this.comboBoxLinkedProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLinkedProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLinkedProducts.FormattingEnabled = true;
            this.comboBoxLinkedProducts.Location = new System.Drawing.Point(190, 18);
            this.comboBoxLinkedProducts.Name = "comboBoxLinkedProducts";
            this.comboBoxLinkedProducts.Size = new System.Drawing.Size(270, 21);
            this.comboBoxLinkedProducts.TabIndex = 0;
            this.comboBoxLinkedProducts.DropDown += new System.EventHandler(this.ComboBoxLinkedProducts_DropDown);
            // 
            // labelLinkedProducts
            // 
            this.labelLinkedProducts.Location = new System.Drawing.Point(6, 22);
            this.labelLinkedProducts.Name = "labelLinkedProducts";
            this.labelLinkedProducts.Size = new System.Drawing.Size(178, 17);
            this.labelLinkedProducts.TabIndex = 22;
            this.labelLinkedProducts.Text = "Pole własne powiązanych towarów:";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(485, 479);
            this.Controls.Add(this.groupBoxLinks);
            this.Controls.Add(this.groupBoxOperator);
            this.Controls.Add(this.groupBoxApi);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ustawienia";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            this.groupBoxApi.ResumeLayout(false);
            this.groupBoxApi.PerformLayout();
            this.groupBoxOperator.ResumeLayout(false);
            this.groupBoxOperator.PerformLayout();
            this.groupBoxLinks.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.ComboBox comboBoxLinkedProducts;
        private System.Windows.Forms.ComboBox comboBoxOperatorName;
        private System.Windows.Forms.ComboBox comboBoxSimilarProducts;
        private System.Windows.Forms.Label labelSimilarProducts;
        private System.Windows.Forms.Button buttonApiTest;
        private System.Windows.Forms.Timer timer1;
    }
}