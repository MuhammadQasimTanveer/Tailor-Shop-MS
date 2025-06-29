using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tailor_Shop_Management_System.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tailor_Shop_Management_System
{
    public partial class MainDashboard : Form
    {
        Button activeButton = null;
        Button lastActiveButton = null;

        private void SetActiveNav(Button clickedBtn)
        {
            if (clickedBtn != button6)
                lastActiveButton = clickedBtn;

            //Reset previous active
            if (activeButton != null)
            {
                activeButton.BackColor = Color.Tan;
                activeButton.ForeColor = Color.FromArgb(60, 50, 30);
            }

            // Set new active
            activeButton = clickedBtn;
            activeButton.BackColor = Color.FromArgb(195, 150, 110);  // Highlight color
            activeButton.ForeColor = Color.FromArgb(255, 215, 100);
        }

        public MainDashboard()
        {
            InitializeComponent();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;  // 1 second
            timer1.Start();
            timer1_Tick(null, null);

            this.FormBorderStyle = FormBorderStyle.None;

            // 2. Disable maximize, allow minimize
            this.ControlBox = false;

            // 3. Start manually and position at top-left
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            // 4. Full screen including taskbar area
            this.Bounds = Screen.PrimaryScreen.Bounds;

            // 5. Always on top (for login, splash etc.)
            this.TopMost = true;

            this.ShowInTaskbar = true;

            panel2.Controls.Clear(); // Remove old controls
            WelcomeDashboard welcome = new WelcomeDashboard();
            welcome.TopLevel = false;
            panel2.Controls.Add(welcome);
            welcome.StartPosition = FormStartPosition.Manual;
            welcome.Location = new Point(
                (panel2.Width - welcome.Width) / 2,
                (panel2.Height - welcome.Height) / 2
            );
            welcome.Show();
            welcome.DisplayingCounts();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //12 hours format with AM/PM
            label3.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveNav(button1);
            this.ActiveControl = null;
            try
            {
                panel2.Controls.Clear(); // Remove old controls
                SuitDetail suit = new SuitDetail();
                suit.TopLevel = false;
                panel2.Controls.Add(suit);
                suit.StartPosition = FormStartPosition.Manual;
                suit.Location = new Point(
                    (panel2.Width - suit.Width) / 2,
                    (panel2.Height - suit.Height) / 2
                );
                suit.Show();
                suit.RefreshCounts();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveNav(button2);
            this.ActiveControl = null;
            try
            {
                panel2.Controls.Clear(); // Remove old controls
                ViewCustomer viewcus = new ViewCustomer();
                viewcus.TopLevel = false;
                panel2.Controls.Add(viewcus);
                viewcus.StartPosition = FormStartPosition.Manual;
                viewcus.Location = new Point(
                    (panel2.Width - viewcus.Width) / 2,
                    (panel2.Height - viewcus.Height) / 2
                );
                viewcus.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveNav(button3);
           this.ActiveControl = null;
            try
            {
                panel2.Controls.Clear(); // Remove old controls
                AddCustomer addcus = new AddCustomer();
                addcus.TopLevel = false;
                panel2.Controls.Add(addcus);
                addcus.StartPosition = FormStartPosition.Manual;
                addcus.Location = new Point(
                    (panel2.Width - addcus.Width) / 2,
                    (panel2.Height - addcus.Height) / 2
                );
                addcus.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetActiveNav(button4);
            this.ActiveControl = null;
            try
            {
                panel2.Controls.Clear(); // Remove old controls
                MakeReceipt make = new MakeReceipt();
                make.TopLevel = false;
                panel2.Controls.Add(make);
                make.StartPosition = FormStartPosition.Manual;
                make.Location = new Point(
                    (panel2.Width - make.Width) / 2,
                    (panel2.Height - make.Height) / 2
                );
                make.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        //public enum DialogResult
        //{
        //    None = 0,
        //    OK = 1,
        //    Cancel = 2,
        //    Abort = 3,
        //    Retry = 4,
        //    Ignore = 5,
        //    Yes = 6,
        //    No = 7
        //}

        private void button6_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            SetActiveNav(button6);
            try
            {
                LogoutForm logout = new LogoutForm();
                //logout.Show();
                //this.Hide();
                // Use DialogResult to wait for user action
                var result = logout.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    // User canceled logout, go back to last selected nav
                    if (lastActiveButton != null)
                        SetActiveNav(lastActiveButton);
                }
                else if (result == DialogResult.OK)
                {
                    this.Hide(); // Proceed to logout
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            SetActiveNav(button7);
            try
            {
                panel2.Controls.Clear(); // Remove old controls
                PrintBill printbill = new PrintBill();
                printbill.TopLevel = false;
                panel2.Controls.Add(printbill);
                printbill.StartPosition = FormStartPosition.Manual;
                printbill.Location = new Point(
                    (panel2.Width - printbill.Width) / 2,
                    (panel2.Height - printbill.Height) / 2
                );
                printbill.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
