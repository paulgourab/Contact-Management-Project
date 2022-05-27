using Contacts.contactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Contacts
{
    public partial class Contact : Form
    {
        public Contact()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            c.f_name = textBoxFname.Text;
            c.l_name = textBoxLname.Text;
            c.contact_no = textBoxCon.Text;
            c.email = textBoxEmail.Text;
            c.address = textBoxAddress.Text;

            bool success = c.Insert(c);
            if(success== true)
            {
                MessageBox.Show("New Contact Successfully Inserted");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to add new Contact, Please Try Again");
            }

            DataTable dt = c.Select();
            dataGridViewCon.DataSource = dt;
        }

        private void Contact_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dataGridViewCon.DataSource = dt;
        }

        public void Clear()
        {
            textBoxFname.Text = "";
            textBoxLname.Text = "";
            textBoxCon.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            textBoxConID.Text = "";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            c.contact_id = int.Parse(textBoxConID.Text);
            c.f_name = textBoxFname.Text;
            c.l_name = textBoxLname.Text;
            c.contact_no = textBoxCon.Text;
            c.email = textBoxEmail.Text;
            c.address = textBoxAddress.Text;

            bool success = c.Update(c);
            if(success==true)
            {
                MessageBox.Show("Contact has been successfelly updated");
                DataTable dt = c.Select();
                dataGridViewCon.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Update data");
            }
        }

        private void dataGridViewCon_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBoxConID.Text = dataGridViewCon.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxFname.Text = dataGridViewCon.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxLname.Text = dataGridViewCon.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxCon.Text = dataGridViewCon.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxEmail.Text = dataGridViewCon.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxAddress.Text = dataGridViewCon.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            c.contact_id = int.Parse(textBoxConID.Text);
            
            bool success = c.Delete(c);
            if(success == true)
            {
                MessageBox.Show("Data Successfully deleted");
                
                DataTable dt = c.Select();
                dataGridViewCon.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to delete data");
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=contact");
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM contact_tbl WHERE f_name LIKE '%"+keyword+"%' OR l_name LIKE '%"+keyword+"%' OR address LIKE'%"+keyword+"%'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewCon.DataSource = dt;
        }

        private void Contact_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
