using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tailor_Shop_Management_System.UI
{
    public partial class LogoutForm : Form
    {
        public LogoutForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//////logout button
        {

            this.DialogResult = DialogResult.OK;

            // Close MainDashboard completely
            Form mainDashboard = Application.OpenForms["MainDashboard"];
            if (mainDashboard != null)
            {
                mainDashboard.Close();  // Fully close dashboard
            }

            // Show logout success screen
            LogoutSuccess logoutsuccess = new LogoutSuccess();
            logoutsuccess.Show();

            // Close this logout form

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)////////backbutton
        {

            this.DialogResult = DialogResult.Cancel;

            // Re-show MainDashboard
            Form mainDashboard = Application.OpenForms["MainDashboard"];

            if (mainDashboard != null)
            {
                // Show the main dashboard again
                mainDashboard.Show();
            }

            // Close the current logout confirmation form

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LogoutForm_Load(object sender, EventArgs e)
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

            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
           
            int x = (this.ClientSize.Width - panel1.Width) / 2;
            int y = (this.ClientSize.Height - panel1.Height) / 2;
            panel1.Location = new Point(x, y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,

           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid);
        }
    }
}
