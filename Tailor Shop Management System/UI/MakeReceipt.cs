using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tailor_Shop_Management_System.Database_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tailor_Shop_Management_System.UI
{
    public partial class MakeReceipt : Form
    {
        public MakeReceipt()
        {
            InitializeComponent();
        }

        DBLayer db = new DBLayer();

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool state = false;

            int suits;

            //if (int.TryParse(textBox7.Text.Trim(), out int id) == false)
            //{

            //    textBox7.Clear();
            //    textBox8.Clear();
            //    textBox9.Clear();
            //    textBox10.Clear();
            //    textBox11.Clear();
            //    textBox12.Clear();
            //    textBox13.Clear();
            //    textBox14.Clear();
            //    textBox15.Clear();
            //    textBox16.Clear();
            //    textBox17.Clear();
            //    textBox1.Clear();
            //    MessageBox.Show("Please enter a valid pending Customer ID.");
            //    textBox6.Clear();
            //    return;
            //}
            //if (int.TryParse(textBox7.Text, out int  id) == true)
            //{
            //    if (id <= 0)
            //    {
            //        MessageBox.Show("ID must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    //else if ()
            //    //{

            //    //}
            //}
            //else
            //{
            //    MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (Regex.IsMatch(textBox8.Text.Trim(), @"^[a-zA-Z\s]+$") == false)
            {
                MessageBox.Show("Name must contain only letters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Regex.IsMatch(textBox9.Text.Trim(), @"^\d{10,11}$") == false)
            {
                MessageBox.Show("Contact must be 10 or 11-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] measurementFields = {
                           textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text,
                           textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text
                                   };

            foreach (string value in measurementFields)
            {
                if (!Regex.IsMatch(value.Trim(), @"^\d+(\.\d+)?\s*[a-zA-Z]*$"))
                {
                    MessageBox.Show("Please enter valid measurement values like 32, 32cm, or 7 inch.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (int.TryParse(textBox1.Text, out suits) == true)
            {
                if (suits <= 0)
                {
                    MessageBox.Show("Number of suits must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric number of suits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            state = true;

            if (state == true)
            {
                int id = Convert.ToInt32(textBox7.Text);
                string fullname = textBox8.Text;
                string contact = textBox9.Text;
                string c_length = textBox10.Text;
                string bazo = textBox11.Text;
                string tera = textBox12.Text;
                string ban = textBox13.Text;
                string upper_waist = textBox14.Text;
                string waist = textBox15.Text;
                string shalwar = textBox16.Text;
                string pancha = textBox17.Text;
                int Noofsuit = Convert.ToInt32(textBox1.Text);

                bool success = db.UpdatePendingCustomer(id, fullname, contact, c_length, bazo,
                                                        tera, ban, upper_waist, waist, shalwar, pancha, Noofsuit);

                if (success == true)
                {
                    MessageBox.Show("Customer record updated successfully.");

                    DataTable dt = db.Pending();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No pending customer found with this ID.");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Trim() == String.Empty || textBox8.Text.Trim() == String.Empty ||
              textBox9.Text.Trim() == String.Empty || textBox10.Text.Trim() == String.Empty ||
              textBox11.Text.Trim() == String.Empty || textBox12.Text.Trim() == String.Empty ||
              textBox13.Text.Trim() == String.Empty || textBox14.Text.Trim() == String.Empty ||
              textBox15.Text.Trim() == String.Empty || textBox16.Text.Trim() == String.Empty ||
              textBox17.Text.Trim() == String.Empty || textBox1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Incomplete Data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                printPreviewDialog1.Document = printDocument1;

                // Dynamically adjust height based on content (example: 20 lines)
                int lineCount = 20; // Adjust based on actual content rows
                int lineHeight = 22;
                int extraPadding = 40;
                int calculatedHeight = (lineCount * lineHeight) + extraPadding;

                // Set custom paper size (width 330, dynamic height)
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("MakeReceipts", 330, calculatedHeight);
                printPreviewDialog1.Document = printDocument1;

                printPreviewDialog1.StartPosition = FormStartPosition.CenterScreen;
                printPreviewDialog1.UseAntiAlias = true; // optional but cleaner
                printPreviewDialog1.ShowDialog(this); // or ShowDialog(null)
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text.Trim(), out int id) == false)
            {
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox1.Clear();
                MessageBox.Show("Please enter a valid pending Customer ID.");
                textBox6.Clear();
                return;
            }

            DataTable dt = db.GetPendingCustomerById(id);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                textBox7.Text = row["Id"].ToString();
                textBox8.Text = row["Fullname"].ToString();
                textBox9.Text = row["Contact"].ToString();
                textBox10.Text = row["C_Length"].ToString();
                textBox11.Text = row["Bazo"].ToString();
                textBox12.Text = row["Tera"].ToString();
                textBox13.Text = row["Ban"].ToString();
                textBox14.Text = row["Upper_waist"].ToString();
                textBox15.Text = row["Waist"].ToString();
                textBox16.Text = row["Shalwar"].ToString();
                textBox17.Text = row["Pancha"].ToString();
                textBox1.Text = row["Noofsuit"].ToString();
            }
            else
            {
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox1.Clear();
                MessageBox.Show("No pending customer found with this ID.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MakeReceipt_Load(object sender, EventArgs e)
        {
            DataTable dt = db.Pending();
            dataGridView1.DataSource = dt;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int startX = 10;
            int currentY = 20;
            int lineHeight = 22;

            // Header
            e.Graphics.DrawString("SA GOLDEN STITCH & FABRICS", new Font("Times New Roman", 13, FontStyle.Bold), Brushes.Red, new Point(startX, currentY));
            currentY += lineHeight;
            e.Graphics.DrawString("0311-5235343", new Font("Century", 10), Brushes.Black, new Point(startX, currentY));
            currentY += lineHeight + 10;

            // Customer Info Section
            e.Graphics.DrawString("Customer Info:", new Font("Georgia", 11, FontStyle.Underline), Brushes.DarkSlateGray, new Point(startX, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("ID:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox7.Text, new Font("Century", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Name:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox8.Text, new Font("Century", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Contact:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox9.Text, new Font("Century", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight + 10;

            // Measurement Section
            e.Graphics.DrawString("Shirt Measurements:", new Font("Georgia", 11, FontStyle.Underline), Brushes.DarkSlateGray, new Point(startX, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Length:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox10.Text, new Font("Century", 10), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Bazo:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox11.Text, new Font("Century", 10), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Tera:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox12.Text, new Font("Century", 10), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Ban:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox13.Text, new Font("Century", 10), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight + 10;

            // Shalwar Section
            e.Graphics.DrawString("Shalwar Measurements:", new Font("Georgia", 11, FontStyle.Underline), Brushes.DarkSlateGray, new Point(startX, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Upper Waist:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox14.Text, new Font("Century", 10), Brushes.Blue, new Point(startX + 100, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Waist:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox15.Text, new Font("Century", 10), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Shalwar:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox16.Text, new Font("Century", 10), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("NoofSuit:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox1.Text, new Font("Century", 10), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Pancha:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox17.Text, new Font("Century", 10), Brushes.Blue, new Point(startX + 80, currentY));
            currentY += lineHeight + 15;

            // Footer
            e.Graphics.DrawString("Tailored with care. Thank you for choosing us!", new Font("Century", 10, FontStyle.Italic), Brushes.DarkGreen, new Point(startX, currentY));

            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
