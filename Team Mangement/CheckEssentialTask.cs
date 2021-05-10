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
    public partial class CheckEssentialTask : Form
    {
        public static event Action<string ,string, string, string, string, string> AddTaskInArchive;
        public static event Action removeTask;
        public static event Action removeFinishedTask;
        public string taskName
        {
            set
            {
                task_name.Text = value;
            }
        }
        public string ID
        {
            set
            {
                label4.Text = value;
            }
        }
        public string categoryname
        {
            set
            {
                category_name.Text = value;
            }
        }
        public string Priority
        {
            set
            {
                task_priority.Text = value;
            }
        }
        public string startDate
        {
            set
            {
                start_data.Text = value;
            }
        }
        public string endData
        {
            set
            {
                end_data.Text = value;
            }
        }
        public CheckEssentialTask()
        {
            InitializeComponent();
            Task.AddsubTaskinChecklist += Task_AddsubTaskinChecklist;
        }

        private void Task_AddsubTaskinChecklist(string obj)
        {
            checkedListBox1.Items.Add(obj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tasks arcieveTask = new Tasks(label4.Text, task_name.Text, category_name.Text, task_priority.Text,start_data.Text,end_data.Text) ;
            Tasks.ListOfArchievetasks.Add(arcieveTask);
            AddTaskInArchive(arcieveTask.IDTask, arcieveTask._TaskName, arcieveTask._Category_Name, arcieveTask._Task_Priority, arcieveTask._StartDate, arcieveTask._EndDate);          
            if (removeTask != null)
                removeTask();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int totalcount = checkedListBox1.Items.Count, count = 0;
            foreach (var item in checkedListBox1.CheckedItems)
            {
                count++;
            }
            if (totalcount != count)
               checkBox1.Checked =false;
            else
            {
                if (removeFinishedTask != null)
                    removeFinishedTask();
                this.Close();
            }
        }
    }
}
