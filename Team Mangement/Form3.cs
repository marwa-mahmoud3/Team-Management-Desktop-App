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
    public partial class Team_Member : Form
    {
        public static Action<string> AddTeamMember;
        public static Action<string> TeamMember;
        public Team_Member()
        {
            InitializeComponent();
        }
        InviteTeamMember team = new InviteTeamMember();
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (AddTeamMember != null)
                AddTeamMember(textBox1.Text);
            if (TeamMember != null)
                TeamMember(textBox1.Text);
             textBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            team.ShowDialog();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Create_Team team1 = new Create_Team();
            team1.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                button1.Enabled = true;
        }
    }
}
