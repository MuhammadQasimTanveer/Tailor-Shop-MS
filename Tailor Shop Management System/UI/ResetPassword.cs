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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tailor_Shop_Management_System.UI
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if ((textBox1.Text.Trim() == String.Empty) || (textBox2.Text.Trim() == String.Empty))
            {
                MessageBox.Show("Please enter Password", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            char[] notAllowedStartChars = { ' ', '-', '+', '=', '_', '.', ',', '/', '\\', '@', '#', '$', '%', '^', '&', '*',
                                '(', ')', '!', '`', '~', ':', ';', '"', '\'', '<', '>', '|', '?' };

            if (notAllowedStartChars.Contains(textBox1.Text[0]) || notAllowedStartChars.Contains(textBox2.Text[0]))
            {
                MessageBox.Show("Password cannot start with special characters like !, @, #, etc.", "Invalid Start", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (notAllowedStartChars.Contains(textBox1.Text[0]) || notAllowedStartChars.Contains(textBox2.Text[0]))
            {
                MessageBox.Show("Password cannot start with special characters like -, +, =, etc.", "Invalid Start", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Passwords do not match!", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DBLayer db = new DBLayer();
            bool updated = db.UpdatePassword(textBox1.Text);
            if (updated)
            {
                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                LoginForm login = new LoginForm();
                login.Show();
            }
            else
            {
                MessageBox.Show("Password update failed. Please try again.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = '\0'; // show password
            }
            else
            {
                textBox1.PasswordChar = '*'; // hide password
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.None;

            // Disable control box (no default minimize/maximize/close)
            this.ControlBox = false;

            // Manual start and full screen
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopMost = true;

            button2.Location = new Point(this.Width - button2.Width - 10, 10);

            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);

            int x = (this.ClientSize.Width - panel3.Width) / 2;
            int y = (this.ClientSize.Height - panel3.Height) / 2;
            panel3.Location = new Point(x, y);

            LoginForm loginForm = new LoginForm();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.PasswordChar = '\0'; // show password
            }
            else
            {
                textBox2.PasswordChar = '*'; // hide password
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,

          Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
          Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
          Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
          Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid);
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel2.ClientRectangle,

            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
            Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();    //in ResetPassword_Load 
            this.Close();
            loginForm.Show();
        }
    }
}
