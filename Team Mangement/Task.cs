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
    public partial class Task : Form
    {
        public static event Action<string, string, string, string, string> AddSubTaskInArchiveAfterRemove;
        public static event Action<string> AddsubTaskinChecklist;
        public static event Action<string, string, string, string, string,string> FinsihedTask;
        public static event Action<string, string, string, string, string> AddSubTaskInArcheiveAfterFinsih;
        public static event Action<string> AddMemberinCreateTask;
        public Task()
        {
            InitializeComponent();
            CreateTask.Alltasks += addtask;
            Subtask.Allsubtasks += addsubtask;
            CheckedTask.removeSubTask += CheckedTask_removeSubTask1;
            CheckEssentialTask.removeTask += CheckEssentialTask_removeTask;
            archive.FromUnAricheivedSubTaskToList += Archive_FromUnAricheivedSubTaskToList;
            archive.FromUnAricheivedTaskToList += Archive_FromUnAricheivedTaskToList;
            CheckEssentialTask.removeFinishedTask += CheckEssentialTask_removeFinishedTask;
            CheckedTask.FinshedSubTask += FinsihedSubTask;
            InviteTeamMember.TeamName += InviteTeamMember_TeamName;
            Team_Member.TeamMember += AssignMember;

        }
        private void AssignMember(string obj)
        {
            checkedListBox1.Items.Add(obj);
        }
        private void InviteTeamMember_TeamName(string obj)
        {
            label1.Text = obj;
        }

        private void FinsihedSubTask()
        {
            AddSubTaskInArcheiveAfterFinsih(listView2.SelectedItems[0].SubItems[0].Text, listView2.SelectedItems[0].SubItems[1].Text,
                listView2.SelectedItems[0].SubItems[2].Text, listView2.SelectedItems[0].SubItems[3].Text,
                listView2.SelectedItems[0].SubItems[4].Text);
            
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                listView2.Items.Remove(item);
            }
        }
        private void CheckEssentialTask_removeFinishedTask()
        {
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            FinsihedTask(listView1.SelectedItems[0].SubItems[0].Text,
                listView1.SelectedItems[0].SubItems[1].Text,
                listView1.SelectedItems[0].SubItems[2].Text,
                listView1.SelectedItems[0].SubItems[3].Text,
                listView1.SelectedItems[0].SubItems[4].Text,
                listView1.SelectedItems[0].SubItems[5].Text);
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
            int index = 0;
            foreach (ListViewItem item in listView2.Items)
            {
                if (id == listView2.Items[index].SubItems[0].Text)
                {
                    SubTasks arcieveSubTasks = new SubTasks(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text);
                    SubTasks.ListOfArchievesubtasks.Add(arcieveSubTasks);
                    if (AddSubTaskInArchiveAfterRemove != null)
                        AddSubTaskInArchiveAfterRemove(arcieveSubTasks.IDSubTask, arcieveSubTasks._SubTaskName, arcieveSubTasks._SubTask_Priority, arcieveSubTasks._StartDate, arcieveSubTasks._EndDate);
                    listView2.Items.Remove(item);
                }
                else
                    index++;
                if (index == listView2.Items.Count)
                    break;
            }
        }

        private void Archive_FromUnAricheivedTaskToList(string arg1, string arg2, string arg3, string arg4, string arg5, string arg6)
        {
            ListViewItem items = listView1.Items.Add(arg1);
            items.SubItems.Add(arg2);
            items.SubItems.Add(arg3);
            items.SubItems.Add(arg4);
            items.SubItems.Add(arg5);
            items.SubItems.Add(arg6);
        }

        private void Archive_FromUnAricheivedSubTaskToList(string arg1, string arg2, string arg3, string arg4, string arg5)
        {
            ListViewItem items = listView2.Items.Add(arg1);
            items.SubItems.Add(arg2);
            items.SubItems.Add(arg3);
            items.SubItems.Add(arg4);
            items.SubItems.Add(arg5);
        }

        private void CheckEssentialTask_removeTask()
        {
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
            int index = 0;
            foreach (ListViewItem item in listView2.Items)
            {
                if (id == listView2.Items[index].SubItems[0].Text)
                {
                    SubTasks arcieveSubTasks = new SubTasks(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text);
                    SubTasks.ListOfArchievesubtasks.Add(arcieveSubTasks);
                    if(AddSubTaskInArchiveAfterRemove != null)
                        AddSubTaskInArchiveAfterRemove(arcieveSubTasks.IDSubTask, arcieveSubTasks._SubTaskName, arcieveSubTasks._SubTask_Priority, arcieveSubTasks._StartDate, arcieveSubTasks._EndDate);
                    listView2.Items.Remove(item);
                }
                else
                    index++;
                if (index == listView2.Items.Count)
                    break;
            }
        }

        private void CheckedTask_removeSubTask1()
        {
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                listView2.Items.Remove(item);
            }
        }      
        private void button1_Click(object sender, EventArgs e)
        {
            CreateTask createTask = new CreateTask();
            foreach (string item in checkedListBox1.Items)
            {
                if (AddMemberinCreateTask != null)
                    AddMemberinCreateTask(item);
            }
               
            createTask.Show();
        }
        private void addtask(string id,string taskName,string categoryName ,string Priority ,string startData,string endData)
        {
            ListViewItem items = listView1.Items.Add(id);
            items.SubItems.Add(taskName);
            items.SubItems.Add(categoryName);
            items.SubItems.Add(Priority);
            items.SubItems.Add(startData);
            items.SubItems.Add(endData);
        }
        private void addsubtask(string id,string taskName, string Priority, string startData, string endData)
        {
            ListViewItem items = listView2.Items.Add(id);
            items.SubItems.Add(taskName);
            items.SubItems.Add(Priority);
            items.SubItems.Add(startData);
            items.SubItems.Add(endData);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Create_Team team = new Create_Team();
            team.Show();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                CheckEssentialTask checkessentialtask = new CheckEssentialTask();
                checkessentialtask.ID = listView1.SelectedItems[0].SubItems[0].Text;
                checkessentialtask.taskName = listView1.SelectedItems[0].SubItems[1].Text;
                checkessentialtask.categoryname = listView1.SelectedItems[0].SubItems[2].Text;
                checkessentialtask.Priority = listView1.SelectedItems[0].SubItems[3].Text;
                checkessentialtask.startDate = listView1.SelectedItems[0].SubItems[4].Text;
                checkessentialtask.endData = listView1.SelectedItems[0].SubItems[5].Text;
                if (AddsubTaskinChecklist != null)
                {
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        if (listView2.Items[i].SubItems[0].Text == listView1.SelectedItems[0].SubItems[0].Text)
                            AddsubTaskinChecklist(listView2.Items[i].SubItems[1].Text);
                    }
                }

                checkessentialtask.Show();
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                CheckedTask checkedtask = new CheckedTask();
                checkedtask.Id = listView2.SelectedItems[0].SubItems[0].Text;
                checkedtask.subtaskname = listView2.SelectedItems[0].SubItems[1].Text;
                checkedtask.Priority = listView2.SelectedItems[0].SubItems[2].Text;
                checkedtask.startDate = listView2.SelectedItems[0].SubItems[3].Text;
                checkedtask.endData = listView2.SelectedItems[0].SubItems[4].Text;
                checkedtask.Show();
            }
        }
    }
}
