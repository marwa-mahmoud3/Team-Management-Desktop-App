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
    public partial class Subtask : Form
    {
        public static event Action<string, string, string, string,string> Allsubtasks;
        public Subtask()
        {
            InitializeComponent();
        }
        public static int counter;
        public void Ay7aga(int a)
        {
            counter = a;
        }
        public void AssignMember(string Member)
        {
            checkedListBox1.Items.Add(Member);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    listBox1.Items.Add(file);
                }
            }
        }
        public List<SubTasks> subtasks = new List<SubTasks>();
        private void button4_Click(object sender, EventArgs e)
        {
            SubTasks subtasks;
            if (radioButton1.Checked)
            {
                subtasks = new SubTasks(counter.ToString(), textBox1.Text, radioButton1.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                SubTasks.ListOfsubTasks.Add(subtasks);
                Allsubtasks(subtasks.IDSubTask,subtasks._SubTaskName, subtasks._SubTask_Priority, subtasks._StartDate, subtasks._EndDate);
            }
            else if (radioButton2.Checked)
            {
                subtasks = new SubTasks(counter.ToString(), textBox1.Text, radioButton2.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                SubTasks.ListOfsubTasks.Add(subtasks);
                Allsubtasks(subtasks.IDSubTask,subtasks._SubTaskName, subtasks._SubTask_Priority, subtasks._StartDate, subtasks._EndDate);
            }
            else if (radioButton3.Checked)
            {
                subtasks = new SubTasks(counter.ToString(), textBox1.Text, radioButton3.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                SubTasks.ListOfsubTasks.Add(subtasks);
                Allsubtasks(subtasks.IDSubTask,subtasks._SubTaskName, subtasks._SubTask_Priority, subtasks._StartDate, subtasks._EndDate);
            }
            List<object> task = new List<object>();
            foreach (object item in checkedListBox1.CheckedItems)
            {
                task.Add(item.ToString());
            }
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubTasks subtasks;
            if (radioButton1.Checked)
            {
                subtasks = new SubTasks(counter.ToString(), textBox1.Text, radioButton1.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                SubTasks.ListOfsubTasks.Add(subtasks);
                Allsubtasks(subtasks.IDSubTask,subtasks._SubTaskName, subtasks._SubTask_Priority, subtasks._StartDate, subtasks._EndDate);
            }
            else if (radioButton2.Checked)
            {
                subtasks = new SubTasks(counter.ToString(), textBox1.Text, radioButton2.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                SubTasks.ListOfsubTasks.Add(subtasks);
                Allsubtasks(subtasks.IDSubTask,subtasks._SubTaskName, subtasks._SubTask_Priority, subtasks._StartDate, subtasks._EndDate);
            }
            else if (radioButton3.Checked)
            {
                subtasks = new SubTasks(counter.ToString(), textBox1.Text, radioButton3.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                SubTasks.ListOfsubTasks.Add(subtasks);
                Allsubtasks(subtasks.IDSubTask,subtasks._SubTaskName, subtasks._SubTask_Priority, subtasks._StartDate, subtasks._EndDate);
            }
            List<object> task = new List<object>();
            foreach (object item in checkedListBox1.Items)
            {
                task.Add(item.ToString());
            }
            Subtask newsubtask = new Subtask();
            foreach(string item in checkedListBox1.Items)
            {
                newsubtask.AssignMember(item);
            }
            newsubtask.Show();           
            this.Close();            
        }

    }
}

