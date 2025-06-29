using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tailor_Shop_Management_System.Database_Layer;
using Tailor_Shop_Management_System.Settersandgetters;
using static System.Net.Mime.MediaTypeNames;

namespace Tailor_Shop_Management_System.UI
{
    public partial class PrintBill : Form
    {
        public PrintBill()
        {
            InitializeComponent();
        }


        DBLayer db = new DBLayer();
        SettersandGetters bll = new SettersandGetters();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private int originalButton1Y;
        private int originalTextBox5Y;
        private int originalButton2Y;
        private int originalButton3Y;

        private void ClearDynamicControlsFromPanel(Panel panel)
        {
            for (int i = panel.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = panel.Controls[i];
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "dynamic")
                {
                    panel.Controls.RemoveAt(i);
                    ctrl.Dispose(); // optional, good for memory
                }
            }
        }

        private void PrintBill_Load(object sender, EventArgs e)
        {
            DataTable dt1 = db.Ready();
            dataGridView1.DataSource = dt1;

            DataTable dt2 = db.Delivered();
            dataGridView2.DataSource = dt2;

            //store original buttons positions
            originalButton1Y = button1.Location.Y;
            originalTextBox5Y = textBox5.Location.Y;
            originalButton2Y = button2.Location.Y;
            originalButton3Y = button3.Location.Y;
        }


        //total price button
        private void button1_Click(object sender, EventArgs e)
        {
            int total = 0;
            int discount = 0;
            int TotalPrice = 0;

            // Loop through all controls in panel
            foreach (Control control in panel1.Controls)
            {
                if (control is TextBox txt && txt.Name.StartsWith("txtSuit"))
                {
                    if (int.TryParse(txt.Text.Trim(), out int price) == true && txt.Text !=String.Empty)
                    {
                        if (price >= 0)
                        {
                            total += price;
                        }
                        else
                        {
                            MessageBox.Show("Suit prices must be positive.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter valid suit price (digits only).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (control is TextBox txtDiscount && txtDiscount.Name.StartsWith("txtDiscount"))
                {
                    if (int.TryParse(txtDiscount.Text.Trim(), out discount) == true && txtDiscount.Text != String.Empty)
                    {
                        if (discount < 0)
                        {
                            MessageBox.Show("Discount must be a positive number.", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if (discount >= total)
                        {
                            MessageBox.Show("Discount must be less than total price.", "Discount Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            TotalPrice = total - discount;
                        }
                    }

                    else if (txtDiscount.Text == String.Empty)
                    {
                        discount = 0;
                        txtDiscount.Text = discount.ToString();
                        TotalPrice = total;
                    }

                    else
                    {
                        MessageBox.Show("Discount must be valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            textBox5.Text = TotalPrice.ToString();
        }

        //print button
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() != String.Empty)
            {
                if (dateTimePicker1.Value.Date >= DateTime.Now.Date)
                {
                    //ReturnDate must be equal or greater than todayDate
                    int calculatedHeight = CalculateDynamicPrintHeight();
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("PrintBill", 330, calculatedHeight);
                    printPreviewDialog1.Document = printDocument1;

                    printPreviewDialog1.StartPosition = FormStartPosition.CenterScreen;
                    printPreviewDialog1.UseAntiAlias = true; // optional but cleaner
                    printPreviewDialog1.ShowDialog(this); // or ShowDialog(null)

                    /*
                    //if you use printbill form outside the panel(as separate form)
                    printPreviewDialog1.Document = printDocument1;
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("PrintBill", 330, calculatedHeight);
                    printPreviewDialog1.ShowDialog(); */
                }
                else
                {
                    MessageBox.Show("Invalid date entered. Try again.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.AutoScroll = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;

            ClearDynamicControlsFromPanel(panel1);

            //set the buttons to original postions;
            button1.Location = new Point(button1.Location.X, originalButton1Y);
            textBox5.Location = new Point(textBox5.Location.X, originalTextBox5Y);
            button2.Location = new Point(button2.Location.X, originalButton2Y);
            button3.Location = new Point(button3.Location.X, originalButton3Y);
        }


        //serach button
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.AutoScroll = false;

            ClearDynamicControlsFromPanel(panel1);

            // Reset button positions
            button1.Location = new Point(button1.Location.X, originalButton1Y);
            textBox5.Location = new Point(textBox5.Location.X, originalTextBox5Y);
            button2.Location = new Point(button2.Location.X, originalButton2Y);
            button3.Location = new Point(button3.Location.X, originalButton3Y);

            if (int.TryParse(textBox6.Text.Trim(), out int id) == false)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Enter a valid Ready Customer ID.");
                textBox6.Clear();
                return;
            }

            DataTable dt = db.GetReadyCustomerById(id);

            if (dt.Rows.Count > 0)
            {
                panel1.AutoScroll = true;
                DataRow row = dt.Rows[0];
                textBox3.Text = row["Id"].ToString();
                textBox2.Text = row["Fullname"].ToString();
                textBox1.Text = row["Noofsuit"].ToString();

                int Noofsuit = Convert.ToInt32(textBox1.Text);
                GenerateSuitPriceInputs(Noofsuit);
            }
            else
            {
                MessageBox.Show("No Ready customer found with this ID.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                dateTimePicker1.Value = DateTime.Now;
            }
        }


        private void GenerateSuitPriceInputs(int Noofsuit)
        {
            int spacing = 29;
            int startX = 42;      // Starting X position
            int startY = 171;     // Starting Y position (after 4 labels)

            for (int i = 1; i <= Noofsuit; i++)
            {
                Label lbl = new Label();
                lbl.Text = $"Suit {i} Price:";
                lbl.Font = new Font("Times New Roman", 10);
                lbl.Location = new Point(startX, startY);
                lbl.Size = new Size(91, 17);

                lbl.Tag = "dynamic";
                panel1.Controls.Add(lbl);

                TextBox txt = new TextBox();
                txt.Name = $"txtSuit{i}";
                txt.Font = new Font("Microsoft Sans Serif", 8);
                txt.Location = new Point(startX + 116, startY); // Textbox position
                txt.Size = new Size(91, 20);

                txt.Tag = "dynamic";
                panel1.Controls.Add(txt);

                startY += spacing; // Move down for next controls
            }

            Label lblDiscount = new Label();
            lblDiscount.Text = "Discount:";
            lblDiscount.Font = new Font("Times New Roman", 10);
            lblDiscount.Location = new Point(startX, startY);
            lblDiscount.Size = new Size(91, 17);

            lblDiscount.Tag = "dynamic";
            panel1.Controls.Add(lblDiscount);

            TextBox txtDiscount = new TextBox();
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Font = new Font("Microsoft Sans Serif", 8);
            txtDiscount.Location = new Point(startX + 118, startY);
            txtDiscount.Size = new Size(91, 20);

            txtDiscount.Tag = "dynamic";
            panel1.Controls.Add(txtDiscount);

            //store original buttons position to temporary variables
            int button1OriginalY = button1.Location.Y;
            int textBox5OriginalY = textBox5.Location.Y;
            int button2OriginalY = button2.Location.Y;
            int button3OriginalY = button3.Location.Y;


            for (int i = 1; i <= Noofsuit; i++)
            {
                //the postion of temporary variables
                button1OriginalY += 30;
                textBox5OriginalY += 30;
                button1.Location = new Point(button1.Location.X, button1OriginalY);
                textBox5.Location = new Point(textBox5.Location.X, textBox5OriginalY);
            }
            button2.Location = new Point(button2.Location.X, button1OriginalY + 46);
            button3.Location = new Point(button3.Location.X, button1OriginalY + 46);
        }

        private int CalculateDynamicPrintHeight()
        {
            int baseLines = 9; // header + customer info
            int dynamicLines = 0;

            foreach (Control control in panel1.Controls)
            {
                if (control is TextBox txt && (txt.Name.StartsWith("txtSuit") || txt.Name.StartsWith("txtDiscount")))
                {
                    dynamicLines++;
                }
            }
            int footerLines = 2; // Total Price + Thank You
            int totalLines = baseLines + dynamicLines + footerLines;
            int lineHeight = 22;
            int padding = 40;

            return (totalLines * lineHeight) + padding;
        }

        //printdocument
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int startX = 10;
            int currentY = 20;
            int lineHeight = 22;

            // Header
            e.Graphics.DrawString("SA GOLDEN STITCH & FABRICS", new Font("Stencil", 13), Brushes.Red, new Point(startX, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("0311-5235343", new Font("Century", 10), Brushes.Black, new Point(startX, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Century", 10), Brushes.LightGreen, new Point(startX, currentY));
            currentY += lineHeight + 10;

            // Customer Info
            e.Graphics.DrawString("Customer Info:", new Font("Georgia", 11, FontStyle.Underline), Brushes.DarkSlateGray, new Point(startX, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Customer ID:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox3.Text, new Font("Century", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 110, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Name:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox2.Text, new Font("Century", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 110, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Return Date:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(dateTimePicker1.Text, new Font("Century", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 110, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Total Suits:", new Font("Century", 10), Brushes.Gray, new Point(startX, currentY));
            e.Graphics.DrawString(textBox1.Text, new Font("Century", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 110, currentY));
            currentY += lineHeight;

            e.Graphics.DrawString("Suit Prices:", new Font("Century", 10, FontStyle.Underline), Brushes.DarkSlateBlue, new Point(startX, currentY));
            currentY += lineHeight;

            foreach (Control control in panel1.Controls)
            {
                if (control is TextBox txt && txt.Name.StartsWith("txtSuit"))
                {
                    string suitLabel = txt.Name.Replace("txtSuit", "Suit ");
                    e.Graphics.DrawString(suitLabel + ":", new Font("Century", 10), Brushes.Black, new Point(startX, currentY));
                    e.Graphics.DrawString(txt.Text, new Font("Century", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 120, currentY));
                    currentY += lineHeight;
                }

                if (control is TextBox txtDiscount && txtDiscount.Name.StartsWith("txtDiscount"))
                {
                    string suitLabel = txtDiscount.Name.Replace("txtDiscount", "Discount");
                    e.Graphics.DrawString(suitLabel + ":", new Font("Century", 10), Brushes.Black, new Point(startX, currentY));
                    e.Graphics.DrawString(txtDiscount.Text, new Font("Century", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 120, currentY));
                    currentY += lineHeight;
                }
            }

            e.Graphics.DrawString("Total Price:", new Font("Century", 10), Brushes.Black, new Point(startX, currentY));
            e.Graphics.DrawString(textBox5.Text, new Font("Century", 10, FontStyle.Bold), Brushes.DarkGreen, new Point(startX + 120, currentY));
            currentY += lineHeight + 10;

            // Footer
            e.Graphics.DrawString("Thank you for shopping with us!", new Font("Century", 11, FontStyle.Italic), Brushes.DarkGreen, new Point(startX, currentY));

            if (int.TryParse(textBox3.Text, out int customerId))
            {
                bool result = db.MarkDelivered(Convert.ToInt32(textBox3.Text));

                if (result == true)
                {
                    MessageBox.Show("Delivery status updated successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to mark as Delivered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DataTable dt1 = db.Ready();
            dataGridView1.DataSource = dt1;

            DataTable dt2 = db.Delivered();
            dataGridView2.DataSource = dt2;


            panel1.AutoScroll = false;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;

            //set the buttons to original postions;
            button1.Location = new Point(button1.Location.X, originalButton1Y);
            textBox5.Location = new Point(textBox5.Location.X, originalTextBox5Y);
            button2.Location = new Point(button2.Location.X, originalButton2Y);
            button3.Location = new Point(button3.Location.X, originalButton3Y);

            ClearDynamicControlsFromPanel(panel1);
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
