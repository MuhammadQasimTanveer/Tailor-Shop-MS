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

namespace Tailor_Shop_Management_System
{
    public partial class SuitDetail : Form
    {
        public SuitDetail()
        {
            InitializeComponent();
        }

        DBLayer db = new DBLayer();
        SettersandGetters bll = new SettersandGetters();


        public void RefreshCounts()
        {
            label2.Text = db.PendingCountsuits("Pending");
            label4.Text = db.ReadyCountsuits("Ready");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SuitDetail_Load(object sender, EventArgs e)
        {
            DataTable dt1 = db.Pending();
            dataGridView1.DataSource = dt1;

            DataTable dt2 = db.Ready();
            dataGridView2.DataSource = dt2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a valid ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id;
                if (int.TryParse(textBox1.Text.Trim(), out id) == true)
                {
                    bll.PendingID = id;

                    if (db.DoesCustomerExistWithStatus(id, "Pending") == false)
                    {
                        MessageBox.Show("Unable to move customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Clear();
                        return;
                    }

                    bool success = db.MoveToReady(bll.PendingID);
                    if (success == true)
                    {
                        MessageBox.Show("Customer moved to the Ready list.");

                        DataTable dt1 = db.Pending();
                        dataGridView1.DataSource = dt1;
                        DataTable dt2 = db.Ready();
                        dataGridView2.DataSource = dt2;

                        RefreshCounts();

                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Unable to move customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numeric ID only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                }
            }
        }
   

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter an ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id;
                if (int.TryParse(textBox2.Text.Trim(), out id) == true)
                {
                    bll.ReadyID = id;

                    if (db.DoesCustomerExistWithStatus(id, "Ready") == false)
                    {
                        MessageBox.Show("Unable to move customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox2.Clear();
                        return;
                    }

                    bool success = db.MoveToPending(bll.ReadyID);
                    if (success == true)
                    {

                        MessageBox.Show("Customer moved to the Pending list.");

                        DataTable dt2 = db.Ready();
                        dataGridView2.DataSource = dt2;

                        DataTable dt1 = db.Pending();
                        dataGridView1.DataSource = dt1;

                        RefreshCounts();

                        textBox2.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Unable to move customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numeric ID only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Clear();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        
        }

        private void SuitDetail_Activated(object sender, EventArgs e)
        {
            label2.Text = db.PendingCountsuits("Pending");
            label4.Text = db.ReadyCountsuits("Ready");
        }
    }
}