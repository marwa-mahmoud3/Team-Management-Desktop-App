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
    public partial class ArchieveAndDelete : Form
    {
        public static event Action DeleteSubTaskFromArchieve;
        public static event Action UNArchieveSubTask;
        public ArchieveAndDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (DeleteSubTaskFromArchieve != null)
                DeleteSubTaskFromArchieve();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            if (UNArchieveSubTask != null)
                UNArchieveSubTask();
        }
    }
}
