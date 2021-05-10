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
    public partial class InviteTeamMember : Form
    {
        public static event Action<string>TeamName;
        
        public InviteTeamMember()
        {
            InitializeComponent();
            Create_Team.TeamNameAndType += Create_Team_TeamNameAndType;
            Team_Member.AddTeamMember += AddTeamMemberIncombox;          
        }
        private void AddTeamMemberIncombox(string arg1)
        {
            comboBox2.Items.Add(arg1);
        }
        private void Create_Team_TeamNameAndType(string arg1, string arg2)
        {
            textBox1.Text = arg1;
            comboBox1.SelectedItem = arg2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Team_Member team = new Team_Member();
            team.Show();
            this.Close();
        }
        Task task = new Task();      
        private void button2_Click(object sender, EventArgs e)
        {
            if (TeamName != null)
                TeamName(textBox1.Text);
            this.Close();
            archive archive = new archive();
            archive.Show();
            task.Show();     
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            Create_Team team = new Create_Team();
            team.Show();
            this.Close();
        }

        
    }
}
