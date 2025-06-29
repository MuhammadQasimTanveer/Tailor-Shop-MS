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
    public partial class LogoutSuccess : Form
    {
        public LogoutSuccess()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            loginform.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); // This will close the entire application
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LogoutSuccess_Load(object sender, EventArgs e)
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
            this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
            this.panel3.Paint += new PaintEventHandler(this.panel3_Paint);

            int x = (this.ClientSize.Width - panel4.Width) / 2;
            int y = (this.ClientSize.Height - panel4.Height) / 2;
            panel4.Location = new Point(x, y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,

           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid);
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
            ControlPaint.DrawBorder(e.Graphics, panel3.ClientRectangle,

           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid,
           Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid);
        }
    }
}
