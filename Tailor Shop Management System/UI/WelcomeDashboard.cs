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

namespace Tailor_Shop_Management_System.UI
{
    public partial class WelcomeDashboard : Form
    {
        public WelcomeDashboard()
        {
            InitializeComponent();
        }

        DBLayer db = new DBLayer();
        SettersandGetters bll = new SettersandGetters();

        private void WelcomeDashboard_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        public void DisplayingCounts()
        {
            label7.Text = db.TotalCustomers();
            label8.Text = db.PendingCountsuits("Pending");
            label9.Text = db.ReadyCountsuits("Ready");
            label10.Text = db.DeliveredCountsuits("Delivered");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
