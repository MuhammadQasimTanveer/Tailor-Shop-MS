using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tailor_Shop_Management_System.Database_Layer;
using Tailor_Shop_Management_System.Settersandgetters;
using Tailor_Shop_Management_System.UI;
//using System.Runtime.InteropServices;

namespace Tailor_Shop_Management_System
{
    public partial class LoginForm : Form
    {

        //[DllImport("user32.dll")]
        //private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //private const int SW_MINIMIZE = 6;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Trim() == String.Empty) || (textBox2.Text.Trim() == String.Empty))
            {
                MessageBox.Show("Please enter all fields.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop login here
            }

            else
            {
                char[] notAllowedStartChars = { ' ', '-', '+', '=', '_', '.', ',', '/', '\\', '@', '#', '$', '%', '^', '&', '*',
                                '(', ')', '!', '`', '~', ':', ';', '"', '\'', '<', '>', '|', '?' };

                if (notAllowedStartChars.Contains(textBox2.Text[0]))
                {
                    MessageBox.Show("Password cannot start with special characters like !, @, #, etc.", "Invalid Start", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            SettersandGetters user = new SettersandGetters();
            user.Username = textBox1.Text.Trim();
            user.Password = textBox2.Text.Trim();

            DBLayer db = new DBLayer();
            bool loginSuccess = db.LoginCheck(user);

            if (loginSuccess)
            {
                this.Hide(); // Hide login form
                MainDashboard main = new MainDashboard();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
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

            button2.Location = new Point(this.Width - button2.Width - 10, 10);

            textBox2.PasswordChar = '*'; // ensure default is hidden
            this.panel3.Paint += new PaintEventHandler(this.panel3_Paint);
            this.panel4.Paint += new PaintEventHandler(this.panel4_Paint);

            int x = (this.ClientSize.Width - panel5.Width) / 2;
            int y = (this.ClientSize.Height - panel5.Height) / 2;
            panel5.Location = new Point(x, y);
        }
  
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               textBox2.PasswordChar = '\0'; // show password
            }
            else
            {
               textBox2.PasswordChar = '*'; // hide password
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword Reset = new ResetPassword();
            Reset.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
              ControlPaint.DrawBorder(e.Graphics, panel4.ClientRectangle,

            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
               ControlPaint.DrawBorder(e.Graphics, panel3.ClientRectangle,

            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid);
        }

        //private void button2_Click(object sender, EventArgs e)
        //{

        //}

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
