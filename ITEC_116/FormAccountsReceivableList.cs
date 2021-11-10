using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITEC_116
{
    public partial class FormAccountsReceivableList : Form
    {
        public FormAccountsReceivableList()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FormHome home = new FormHome();
            this.Close();
            home.Show();
        }

        private void AccountsReceivableList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aF_AccountsReceivable.accounts_receivable_table' table. You can move, or remove it, as needed.
            this.accounts_receivable_tableTableAdapter.Fill(this.aF_AccountsReceivable.accounts_receivable_table);

        }
    }
}
