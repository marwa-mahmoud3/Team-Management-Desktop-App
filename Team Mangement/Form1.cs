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
    public partial class Home_Page : Form
    {
        public Home_Page()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Register Register = new Register();
            Register.Show();
        }
        private void GoToHomePAge(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
