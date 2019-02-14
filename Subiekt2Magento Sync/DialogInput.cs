using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiekt2Magento_Sync
{
    public partial class DialogInput : Form
    {

        public string Value { get; set; }

        public DialogInput(string infoText, DataTable loadTable)
        {
            InitializeComponent();
            Width = infoText.Length*8;
            labelInput.Text = infoText;
            if (loadTable != null)
            {
                comboBoxInput.Items.Clear();
                comboBoxInput.DataSource = loadTable.DefaultView;
                comboBoxInput.DisplayMember = "c_Nazwa";
                comboBoxInput.SelectedIndex = -1;

                comboBoxInput.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxInput.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void Result()
        {
            Value = comboBoxInput.Text;
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result();
        }

        private void DialogInput_Activated(object sender, EventArgs e)
        {
            comboBoxInput.Focus();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Result();
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }

        private void DialogInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }
    }
}
