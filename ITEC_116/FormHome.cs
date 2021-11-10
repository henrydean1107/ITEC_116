using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ITEC_116
{
    public partial class FormHome : Form
    {

        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        List<Panel> listPanel = new List<Panel>();

        public FormHome()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 54);
            panelSide.Controls.Add(leftBorderBtn);
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aF_DatabaseDataExpenses.expenses_table' table. You can move, or remove it, as needed.
            this.expenses_tableTableAdapter.Fill(this.aF_DatabaseDataExpenses.expenses_table);
            // TODO: This line of code loads data into the 'aF_DatabaseDataSet2.accounts_payable_table' table. You can move, or remove it, as needed.
            this.accounts_payable_tableTableAdapter1.Fill(this.aF_DatabaseDataSet2.accounts_payable_table);
            // TODO: This line of code loads data into the 'aF_DatabaseDataSet1.accounts_payable_table' table. You can move, or remove it, as needed.
            this.accounts_payable_tableTableAdapter.Fill(this.aF_DatabaseDataSet1.accounts_payable_table);
            // TODO: This line of code loads data into the 'aF_DatabaseDataSet.accounts_receivable_table' table. You can move, or remove it, as needed.
            this.accounts_receivable_tableTableAdapter.Fill(this.aF_DatabaseDataSet.accounts_receivable_table);
            //Load Panels
            listPanel.Add(panelDashboard);
            listPanel.Add(panelAccountsPayableData);
            listPanel.Add(panelAccountsReceivableData);
            listPanel.Add(panelExpensesList);
            listPanel.Add(panelIncomeStatementList);
            listPanel[0].BringToFront();
            //Load Username
            lblUsername.Text = FormLogin.username;
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(38, 147, 220);
            public static Color color2 = Color.FromArgb(249, 88, 155);
            public static Color color3 = Color.FromArgb(252, 110, 50);
            public static Color color4 = Color.FromArgb(133, 194, 100);
            public static Color color5 = Color.FromArgb(246, 175, 91);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(84, 94, 116);
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left Border Button Color
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(51, 57, 70);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            listPanel[0].BringToFront();
        }

        private void btnAccountsPayableData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            listPanel[1].BringToFront();
        }

        private void btnAccountsReceivableData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            listPanel[2].BringToFront();
        }

        private void btnExpensesList_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            listPanel[3].BringToFront();
        }

        private void btnIncomeStatementList_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            listPanel[4].BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            this.Close();
            login.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Draggable Function

        bool mouseDown;
        private Point offset;
        private void mouseDown_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPosition = PointToScreen(e.Location);
                Location = new Point(currentScreenPosition.X - offset.X, currentScreenPosition.Y - offset.Y);
            }
        }

        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

    }
}
