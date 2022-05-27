using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Contacts.contactClasses
{
    class contactClass
    {
        public int contact_id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public string contact_no { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=contact");

        public DataTable Select()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=contact");
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM contact_tbl";
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool Insert(contactClass c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=contact");
            
            try
            {
                string sql = "INSERT INTO contact_tbl (f_name,l_name,contact_no,email,address) VALUES(@f_name,@l_name,@contact_no,@email,@address)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@f_name", c.f_name);
                cmd.Parameters.AddWithValue("@l_name", c.l_name);
                cmd.Parameters.AddWithValue("@contact_no", c.contact_no);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@address", c.address);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            
            return isSuccess;
        }
        
        public bool Update(contactClass c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=contact");

            try
            {
                string sql = "UPDATE contact_tbl SET f_name=@f_name,l_name=@l_name,contact_no=@contact_no,email=@email,address=@address WHERE contact_id=@contact_id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@contact_id", c.contact_id);
                cmd.Parameters.AddWithValue("@f_name", c.f_name);
                cmd.Parameters.AddWithValue("@l_name", c.l_name);
                cmd.Parameters.AddWithValue("@contact_no", c.contact_no);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@address", c.address);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        public bool Delete(contactClass c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=contact");

            try
            {
                string sql = "DELETE FROM contact_tbl WHERE contact_id=@contact_id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@contact_id", c.contact_id);
                
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
