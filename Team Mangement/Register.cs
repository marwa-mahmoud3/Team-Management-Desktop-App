using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Team_Mangement
{
    public partial class Register : Form
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader datatable;
        public Register()
        {
            InitializeComponent();         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 4)
                label7.Visible = true;
            else
            {
                label7.Visible = false;
            }
            if (textBox2.Text.Contains("@gmail.com") || textBox2.Text.Contains("@yahoo.com"))
                label5.Visible = false;
            else
            {
                label5.Visible = true;
            }
            if (textBox3.Text.Length > 5)
                label6.Visible = false;
            else
            {
                label6.Visible = true;
            }
            if (label6.Visible == false && label7.Visible == false && label5.Visible == false)
            {
                sqlCommand = new SqlCommand($"select * from users where userName ='{textBox1.Text}'" ,sqlConnection);
                datatable = sqlCommand.ExecuteReader();
                if(datatable.Read())
                {
                    datatable.Close();
                    MessageBox.Show("User Name is Using try another ");
                }
                else
                {
                    datatable.Close();
                    sqlCommand = new SqlCommand($" insert into users values ('{textBox1.Text}','{textBox3.Text}')", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Your Account is Created");
                    this.Close();
                    Create_Team team = new Create_Team();
                    team.Show();
                }
                User AddNewUser = new User(textBox1.Text,textBox3.Text);
                SampleData.Users.Add(AddNewUser);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {
             sqlConnection = new SqlConnection(@"Data Source=DESKTOP-60R5JD3;Initial Catalog=Team Managment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();
        }
    }
}
