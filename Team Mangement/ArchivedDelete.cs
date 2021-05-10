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
    public partial class ArchivedDelete : Form
    {
        public static event Action DeleteFromArchieve;
        public static event Action UNArchieveTask;
        public ArchivedDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (DeleteFromArchieve != null)
                DeleteFromArchieve();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            if (UNArchieveTask != null)
                UNArchieveTask();
        }
    }
}
