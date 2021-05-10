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
    public partial class CheckedTask : Form
    {
        public static event Action<string, string, string, string,string> AddSubTaskInArchive;
        public static event Action removeSubTask;
        public static event Action FinshedSubTask;
        public string Id
        {
            set
            {
                label2.Text = value;
            }
        }
        public string subtaskname
        {
            set
            {
                label4.Text = value;
            }
        }
        public string Priority
        {
            set
            {
                label6.Text = value;
            }
        }
        public string startDate
        {
            set
            {
                label8.Text = value;
            }
        }
        public string endData
        {
            set
            {
                label10.Text = value;
            }
        }
        public CheckedTask()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {         
            SubTasks arcieveSubTasks = new SubTasks(label2.Text,label4.Text, label6.Text, label8.Text, label10.Text);
            SubTasks.ListOfArchievesubtasks.Add(arcieveSubTasks);
            AddSubTaskInArchive(arcieveSubTasks.IDSubTask, arcieveSubTasks._SubTaskName, arcieveSubTasks._SubTask_Priority, arcieveSubTasks._StartDate, arcieveSubTasks._EndDate);
            if (removeSubTask != null)
                removeSubTask();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (FinshedSubTask != null)
                FinshedSubTask();
            this.Close();
        }

        
    }
}
