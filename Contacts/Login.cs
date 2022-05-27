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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string user = textBoxUsername.Text;
            string pass = textBoxPassword.Text;

            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=contact");
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT count(*) FROM login WHERE username='" + textBoxUsername.Text + "' and password='" + textBoxPassword.Text + "'", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Contact openContact = new Contact();
                openContact.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter right data");
            }
        }
    }
}
