using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Team_Mangement
{
    public partial class CreateTask : Form
    {
        public static int count = 0;
        public static event Action<string,string, string, string, string, string> Alltasks;
        public string newCategories
        {
            set
            {
                newCategories = value;
            }
        }
        //XmlSerializer xmlSerializer;
        
        public CreateTask()
        {
            InitializeComponent();
            Team_Member.TeamMember += AssignMember;
            Task.AddMemberinCreateTask += Task_AddMemberinCreateTask;
            //filetasks = new List<Tasks>();
            //xmlSerializer = new XmlSerializer(typeof(List<Tasks>));
        }

        private void Task_AddMemberinCreateTask(string obj)
        {
            checkedListBox1.Items.Add(obj);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void AssignMember(string Member)
        {
            checkedListBox1.Items.Add(Member);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Add(textBox2.Text);
            textBox2.Text = " ";
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
        public static void ButtonClicked()
        {
            count++;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ButtonClicked();
            Tasks tasks;
            if (radioButton1.Checked)
            {
                tasks = new Tasks(count.ToString(),task_name.Text, comboBox2.SelectedItem.ToString(), radioButton1.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                Tasks.ListOftasks.Add(tasks);
                Alltasks(tasks.IDTask,tasks._TaskName, tasks._Category_Name, tasks._Task_Priority, tasks._StartDate, tasks._EndDate);
            }
            else if (radioButton2.Checked)
            {               
                tasks = new Tasks(count.ToString(), task_name.Text, comboBox2.SelectedItem.ToString(), radioButton2.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                Tasks.ListOftasks.Add(tasks);
                Alltasks(tasks.IDTask,tasks._TaskName, tasks._Category_Name, tasks._Task_Priority, tasks._StartDate, tasks._EndDate);
            }
            else if (radioButton3.Checked)
            {
                tasks = new Tasks(count.ToString(), task_name.Text, comboBox2.SelectedItem.ToString(), radioButton3.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                Tasks.ListOftasks.Add(tasks);
                Alltasks(tasks.IDTask,tasks._TaskName, tasks._Category_Name, tasks._Task_Priority, tasks._StartDate, tasks._EndDate);
            }
            List<object> task = new List<object>();
            foreach (object item in checkedListBox1.CheckedItems)
            {
                task.Add(item.ToString());
            }
            this.Close();
            this.Controls.Clear();
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            //System.IO.FileStream fileStream = new FileStream("D:\\My projects\\Team Managment\\TeamManagement.Xml", FileMode.Create,FileAccess.Write);
            //Tasks createTask = new Tasks();
            //createTask._TaskName = textBox1.Text;
            //createTask._StartDate = StartDate.Value;
            //createTask._EndDate = EndDate.Value;
            //createTask._Category_Name = comboBox2.SelectedItem.ToString();
            //createTask._Task_Priority = groupBox1.Text;
            //filetasks.Add(createTask);
            //xmlSerializer.Serialize(fileStream, filetasks);
            ButtonClicked();
            Tasks tasks;
            if (radioButton1.Checked)
            {
                tasks = new Tasks(count.ToString(), task_name.Text, comboBox2.SelectedItem.ToString(), radioButton1.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                Tasks.ListOftasks.Add(tasks);
                Alltasks(tasks.IDTask,tasks._TaskName, tasks._Category_Name, tasks._Task_Priority, tasks._StartDate, tasks._EndDate);
            }
            else if (radioButton2.Checked)
            {
                tasks = new Tasks(count.ToString(), task_name.Text, comboBox2.SelectedItem.ToString(), radioButton2.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                Tasks.ListOftasks.Add(tasks);
                Alltasks(tasks.IDTask,tasks._TaskName, tasks._Category_Name, tasks._Task_Priority, tasks._StartDate, tasks._EndDate);
            }
            else if (radioButton3.Checked)
            {
                tasks = new Tasks(count.ToString(), task_name.Text, comboBox2.SelectedItem.ToString(), radioButton3.Text, StartDate.Value.ToString(), EndDate.Value.ToString());
                Tasks.ListOftasks.Add(tasks);
                Alltasks(tasks.IDTask,tasks._TaskName, tasks._Category_Name, tasks._Task_Priority, tasks._StartDate, tasks._EndDate);
            }
            List<object> task = new List<object>();
            foreach (object item in checkedListBox1.CheckedItems)
            {
                task.Add(item.ToString());
            }
            Subtask subtask = new Subtask();
            this.Close();
            foreach(string item in checkedListBox1.CheckedItems)
            {
                subtask.AssignMember(item);
            }
            subtask.Ay7aga(count);
            subtask.Show();           
            //this.Controls.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex > -1 && task_name.Text.Length >0)
            {
                button5.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please Enter Task Name & Category First");
            }

        }
    }
}
