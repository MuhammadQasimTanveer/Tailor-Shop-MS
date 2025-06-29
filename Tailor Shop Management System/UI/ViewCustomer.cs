using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tailor_Shop_Management_System.Database_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tailor_Shop_Management_System
{
    public partial class ViewCustomer : Form
    {
        public ViewCustomer()
        {
            InitializeComponent();
        }


        DBLayer db = new DBLayer();
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            DataTable dt = db.Select();
            dataGridView1.DataSource = dt;
            MessageBox.Show("Total No.of Customers: " + dt.Rows.Count);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.Trim();

            if ((keyword == String.Empty))
            {
                // Show all customers
                dataGridView1.DataSource = db.Select();
                return;
            }

            // Check for valid input
            if (keyword.All(char.IsDigit))
            {
                DataTable dt = db.SearchById(Convert.ToInt32(keyword));
                dataGridView1.DataSource = dt;
            }
            else if (keyword.All(char.IsLetter))
            {
                DataTable dt = db.SearchByName(keyword);
                dataGridView1.DataSource = dt;
            }
            else
            {
                //dataGridView1.DataSource = new DataTable(); // shows only headers
                DataTable dt = db.Select(); // Assuming this returns full table
                DataTable emptyTable = dt.Clone(); // Just structure, no rows
                dataGridView1.DataSource = emptyTable;
            }
        }
    }
}
