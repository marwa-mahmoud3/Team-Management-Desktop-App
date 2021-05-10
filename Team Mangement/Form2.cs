using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_Mangement
{
    public partial class Create_Team : Form
    {
        public event EventHandler GoToHomePAge;

        public static event Action<string, string> TeamNameAndType;
        public Create_Team()
        {
            InitializeComponent();
        }
        Team_Member teamMemeber = new Team_Member();

        private void button1_Click(object sender, EventArgs e)
        {
            if (TeamNameAndType != null)
                TeamNameAndType(textBox1.Text, comboBox1.SelectedItem.ToString());
            //teamMemeber.NameTeam = textBox1.Text;
            //teamMemeber.TeamCategory = comboBox1.SelectedItem;
            teamMemeber.Show();
            this.Close();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 3 || textBox1.Text.Length == 0)
                label9.Visible = true;
            else
                label9.Visible = false;
           
            if (label10.Visible == false && label9.Visible == false)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null )
                label10.Visible = true;
            else
                label10.Visible = false;

            if (label10.Visible == false && label9.Visible == false)
                button1.Enabled = true;
            else
                button1.Enabled = false;

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (GoToHomePAge != null)
                GoToHomePAge(this, e);
            this.Close();
        }
    }
}
