using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tailor_Shop_Management_System.Settersandgetters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Tailor_Shop_Management_System.Database_Layer
{
    class DBLayer
    {
        //myconnstring fetches the database connection from app.configuration
        static string myconnstring = ConfigurationManager.ConnectionStrings["TMSConnection"].ConnectionString;

        //this method accepts object bll

        //for adding customers in addcustomer form
        public bool Insert(SettersandGetters bll)
        {
            bool issuccess = false;

            //initializes the connection.
            SqlConnection conn = new SqlConnection(myconnstring);

            //We can also initializes the connection directly
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-U9RBE0T\\SQLEXPRESS01;Initial Catalog=TMS;Integrated Security=True;");

            try
            {
                //This query inserts customer details into the AddCustomers table.
                //string qu = "insert into AddCustomers (id,Fullname)values('" + textBox1.Text + "','" + textBox2.Text + "')";
              
                string qu = "Insert Into AddCustomers(Id,Fullname,Contact,C_Length,Bazo,Tera,Ban,Upper_waist,Waist,Shalwar,Pancha,Noofsuit)" +
                    " values(@Id,@Fullname,@Contact,@C_Length,@Bazo,@Tera,@Ban,@Upper_waist,@Waist,@Shalwar,@Pancha,@Noofsuit)";

                //prepares the SQL command
                SqlCommand cmd = new SqlCommand(qu,conn);

                //assigning user-entered values to SQL parameters

                cmd.Parameters.AddWithValue("@Id",bll.Id);
                cmd.Parameters.AddWithValue("@Fullname",bll.Fullname);
                cmd.Parameters.AddWithValue("@Contact",bll.Contact);
                cmd.Parameters.AddWithValue("@C_Length",bll.C_Length);
                cmd.Parameters.AddWithValue("@Bazo",bll.Bazo);
                cmd.Parameters.AddWithValue("@Tera",bll.Tera);
                cmd.Parameters.AddWithValue("@Ban",bll.Ban);
                cmd.Parameters.AddWithValue("@Upper_waist",bll.Upper_waist);
                cmd.Parameters.AddWithValue("@Waist",bll.Waist);
                cmd.Parameters.AddWithValue("@Shalwar",bll.Shalwar);
                cmd.Parameters.AddWithValue("@Pancha",bll.Pancha);
                cmd.Parameters.AddWithValue("@Noofsuit", bll.Noofsuit);

                //Opens the SQL connection
                conn.Open();

                //SQL Query is executed
                int rows = cmd.ExecuteNonQuery();

                if(rows>0)
                {
                    issuccess = true;
                }
                else
                {
                    issuccess = false;
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            finally
            {
                //Closes the SQL connection.
                conn.Close();
            }

            return issuccess;
        }

        //for viewing customers in viewcustomer form
        public DataTable Select()
        {

            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string qu = "SELECT * FROM AddCustomers";

                //prepares the SQL command
                SqlCommand cmd = new SqlCommand(qu, conn);

                //Temporary holds the data coming from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Opens the SQL connection
                conn.Open();
                cmd.ExecuteNonQuery();
                //fill the data that is in data-adapter into Datatable
                adapter.Fill(dt);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }

            return dt;
        }

        //for search customer by ID in viewcustomer form
        public DataTable SearchById(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string query = "SELECT * FROM AddCustomers WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search ID Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //for search customer by name in viewcustomer form
        public DataTable SearchByName(string name)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string query = "SELECT * FROM AddCustomers WHERE Fullname LIKE @name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", "%" + name + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Name Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        //for showing Name,id,suit in datagrid view in make receipt form
        public DataTable NameandIdandSuit()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string qu = "SELECT Id,Fullname,Noofsuit FROM AddCustomers";
                SqlCommand cmd = new SqlCommand(qu, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                cmd.ExecuteNonQuery();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable Pending()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT Id, Fullname, Noofsuit FROM AddCustomers WHERE Status = @Status";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", "Pending");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                cmd.ExecuteNonQuery();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Status Fetch Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable Ready()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT Id, Fullname, Noofsuit FROM AddCustomers WHERE Status = @Status";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", "Ready");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                cmd.ExecuteNonQuery();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Status Fetch Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable Delivered()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT Id, Fullname, Noofsuit FROM AddCustomers WHERE Status = @Status";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", "Delivered");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                cmd.ExecuteNonQuery();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Status Fetch Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool MoveToReady(int id)
        {
            return UpdateStatus(id, "Ready");
        }

        public bool MoveToPending(int id)
        {
            return UpdateStatus(id, "Pending");
        }

        public bool MarkDelivered(int id)
        {
            return UpdateStatus(id, "Delivered");
        }

        private bool UpdateStatus(int id, string status)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "UPDATE AddCustomers SET Status = @Status WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }

                else { isSuccess = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Status Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public string PendingCountsuits(string status)
        {
            string count = "0";
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT COUNT(*) FROM AddCustomers WHERE Status = @Status";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", "Pending");
                conn.Open();
                count = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Count Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public string ReadyCountsuits(string status)
        {
            string count = "0";
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT COUNT(*) FROM AddCustomers WHERE Status = @Status";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", "Ready");
                conn.Open();
                count = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Count Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public string DeliveredCountsuits(string status)
        {
            string count = "0";
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT COUNT(*) FROM AddCustomers WHERE Status = @Status";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", "Delivered");
                conn.Open();
                count = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Count Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public string TotalCustomers()
        {
            string count = "0";
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT COUNT(*) FROM AddCustomers";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                count = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Count Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }


        //for login form
        public bool LoginCheck(SettersandGetters user)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string query = "SELECT COUNT(*) FROM Admin WHERE UserName = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    isSuccess = true;
                }
                else { isSuccess = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        //for updating password in login form
        public bool UpdatePassword(string newPassword)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string query = "UPDATE Admin SET Password = @Password WHERE UserName = 'Qasimtanvir'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Password", newPassword);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else { isSuccess = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Password Reset Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        public bool DoesCustomerExistWithStatus(int id, string status)
        {
            bool exists = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT COUNT(*) FROM AddCustomers WHERE Id = @Id AND Status = @Status";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Status", status);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    exists = true;
                }
                else { exists = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return exists;
        }

        //for search pendingcustomer by id in Makereceipt form
        public DataTable GetPendingCustomerById(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT * FROM AddCustomers WHERE Id = @Id AND Status = 'Pending'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //for updating pendingcustomer in Makereceipt form

        public bool UpdatePendingCustomer(int id, string fullname, string contact, string c_length, string bazo,
                                  string tera, string ban, string upper_waist, string waist,
                                  string shalwar, string pancha, int Noofsuit )
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string query = @"UPDATE AddCustomers 
                         SET Fullname = @Fullname, Contact = @Contact, C_Length = @C_Length, 
                             Bazo = @Bazo, Tera = @Tera, Ban = @Ban, Upper_waist = @Upper_waist,
                             Waist = @Waist, Shalwar = @Shalwar, Pancha = @Pancha, Noofsuit = @Noofsuit
                         WHERE Id = @Id AND Status = 'Pending'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Fullname", fullname);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@C_Length", c_length);
                cmd.Parameters.AddWithValue("@Bazo", bazo);
                cmd.Parameters.AddWithValue("@Tera", tera);
                cmd.Parameters.AddWithValue("@Ban", ban);
                cmd.Parameters.AddWithValue("@Upper_waist", upper_waist);
                cmd.Parameters.AddWithValue("@Waist", waist);
                cmd.Parameters.AddWithValue("@Shalwar", shalwar);
                cmd.Parameters.AddWithValue("@Pancha", pancha);
                cmd.Parameters.AddWithValue("@Noofsuit", Noofsuit);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else { isSuccess = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }


        //for search readycustomer by id in PrintBill form
        public DataTable GetReadyCustomerById(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string query = "SELECT * FROM AddCustomers WHERE Id = @Id AND Status = 'Ready'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

    }
}