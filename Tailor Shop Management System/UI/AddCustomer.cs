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
using System.Data.SqlClient;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Tailor_Shop_Management_System
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        SettersandGetters bll = new SettersandGetters();
        DBLayer db = new DBLayer();

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ClearAllFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool state = false;
            int id, suits;
            if (textBox1.Text.Trim() == String.Empty || textBox2.Text.Trim() == String.Empty ||
                textBox3.Text.Trim() == String.Empty || textBox4.Text.Trim() == String.Empty ||
                textBox5.Text.Trim() == String.Empty || textBox6.Text.Trim() == String.Empty ||
                textBox7.Text.Trim() == String.Empty || textBox8.Text.Trim() == String.Empty ||
                textBox9.Text.Trim() == String.Empty || textBox10.Text.Trim() == String.Empty ||
                textBox11.Text.Trim() == String.Empty || textBox12.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please fill all the fields before submitting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                if (int.TryParse(textBox1.Text, out id) == true)
                {
                    if (id <= 0)
                    {
                        MessageBox.Show("ID must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Regex.IsMatch(textBox2.Text.Trim(), @"^[a-zA-Z\s]+$") == false)
                {
                    MessageBox.Show("Fullname must contain only letters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Regex.IsMatch(textBox3.Text.Trim(), @"^\d{10,11}$") == false)
                {
                    MessageBox.Show("Contact must be 10 or 11-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] measurementFields = { 
                           textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text,
                           textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text
                                   };

                foreach (string value in measurementFields)
                {
                    if (!Regex.IsMatch(value.Trim(), @"^\d+(\.\d+)?\s*[a-zA-Z]*$"))
                    {
                        MessageBox.Show("Please enter valid measurement values like 32, 32cm, or 7 inch.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (int.TryParse(textBox12.Text, out suits) == true)
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
            }


            if(state==true)
            {
                //setter function is used automatically to set the values of these text-boxes using its object
                bll.Id = int.Parse(textBox1.Text);
                bll.Fullname = textBox2.Text;
                bll.Contact = textBox3.Text;
                bll.C_Length = textBox4.Text;
                bll.Bazo = textBox5.Text;
                bll.Tera = textBox6.Text;
                bll.Ban = textBox7.Text;
                bll.Upper_waist = textBox8.Text;
                bll.Waist = textBox9.Text;
                bll.Shalwar = textBox10.Text;
                bll.Pancha = textBox11.Text;
                bll.Noofsuit = int.Parse(textBox12.Text);


                //this object (containing all information) is passed as argument to insert method
                bool success = db.Insert(bll);
                if (success == true)
                {
                    MessageBox.Show("New Customer Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllFields();
                }
                else
                {
                    MessageBox.Show("Failed to add this customer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
