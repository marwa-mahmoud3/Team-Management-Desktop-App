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

namespace Team_Mangement
{
    public partial class Login : Form
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            this.Close();
            register.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlCommand = new SqlCommand($"select * from Users where userName='{textBox1.Text}' and userPassword='{textBox2.Text}'",sqlConnection);
            dr = sqlCommand.ExecuteReader();
            if(dr.Read())
            {
                dr.Close();
                this.Close();
                Create_Team team = new Create_Team();
                team.Show();
            }
            else
            {
                dr.Close();
                MessageBox.Show("No Account avialable , Register First");
            }           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=DESKTOP-60R5JD3;Initial Catalog=Team Managment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();
        }
    }
}
