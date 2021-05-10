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
    public partial class archive : Form
    {
        public static event Action<string, string, string, string, string, string> FromUnAricheivedTaskToList;
        public static event Action<string, string, string, string, string> FromUnAricheivedSubTaskToList;
        public archive()
        {
            InitializeComponent();
            CheckedTask.AddSubTaskInArchive += CheckedTask_AddTaskInArchive;
            CheckEssentialTask.AddTaskInArchive += CheckEssentialTask_AddTaskInArchive;
            Task.AddSubTaskInArchiveAfterRemove += Task_AddSubTaskInArchiveAfterRemove;
            ArchivedDelete.DeleteFromArchieve += ArchivedDelete_DeleteFromArchieve;
            ArchieveAndDelete.DeleteSubTaskFromArchieve += ArchieveAndDelete_DeleteSubTaskFromArchieve;
            ArchivedDelete.UNArchieveTask += ArchivedDelete_UNArchieveTask;
            ArchieveAndDelete.UNArchieveSubTask += ArchieveAndDelete_UNArchieveSubTask;
            Task.FinsihedTask += CheckEssentialTask_AddTaskInArchive;
            Task.AddSubTaskInArcheiveAfterFinsih += Task_AddSubTaskInArcheiveAfterFinsih;
        }

        private void Task_AddSubTaskInArcheiveAfterFinsih(string arg1, string arg2, string arg3, string arg4, string arg5)
        {
            int number = dataGridView1.Rows.Add();
            dataGridView1.Rows[number].Cells[0].Value = arg1;
            dataGridView1.Rows[number].Cells[1].Value = arg2;
            dataGridView1.Rows[number].Cells[2].Value = arg3;
            dataGridView1.Rows[number].Cells[3].Value = arg4;
            dataGridView1.Rows[number].Cells[4].Value = arg5;
        }

        private void ArchieveAndDelete_UNArchieveSubTask()
        {
            if (FromUnAricheivedSubTaskToList != null)
                FromUnAricheivedSubTaskToList(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                    dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                     dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                     dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                     dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void ArchivedDelete_UNArchieveTask()
        {
            if (FromUnAricheivedTaskToList != null)
                FromUnAricheivedTaskToList(dataGridView2.SelectedRows[0].Cells[0].Value.ToString(), dataGridView2.SelectedRows[0].Cells[1].Value.ToString(),
                     dataGridView2.SelectedRows[0].Cells[2].Value.ToString(), dataGridView2.SelectedRows[0].Cells[3].Value.ToString(), dataGridView2.SelectedRows[0].Cells[4].Value.ToString(),
                     dataGridView2.SelectedRows[0].Cells[4].Value.ToString());
            string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
            for(int i =0;i <dataGridView1.Rows.Count;)
            {
                if (dataGridView1.Rows.Count >= 0)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == id)
                    {
                        if (FromUnAricheivedSubTaskToList != null)
                            FromUnAricheivedSubTaskToList(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(),
                                dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString());
                        dataGridView1.Rows.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void ArchieveAndDelete_DeleteSubTaskFromArchieve()
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void ArchivedDelete_DeleteFromArchieve()
        {
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }

        private void Task_AddSubTaskInArchiveAfterRemove(string arg1, string arg2, string arg3, string arg4, string arg5)
        {
            int number = dataGridView1.Rows.Add();
            dataGridView1.Rows[number].Cells[0].Value = arg1;
            dataGridView1.Rows[number].Cells[1].Value = arg2;
            dataGridView1.Rows[number].Cells[2].Value = arg3;
            dataGridView1.Rows[number].Cells[3].Value = arg4;
            dataGridView1.Rows[number].Cells[4].Value = arg5;
        }

        private void CheckEssentialTask_AddTaskInArchive(string arg1, string arg2, string arg3, string arg4, string arg5, string arg6)
        {
            int number = dataGridView2.Rows.Add();
            dataGridView2.Rows[number].Cells[0].Value = arg1;
            dataGridView2.Rows[number].Cells[1].Value = arg2;
            dataGridView2.Rows[number].Cells[2].Value = arg3;
            dataGridView2.Rows[number].Cells[3].Value = arg4;
            dataGridView2.Rows[number].Cells[4].Value = arg5;
            dataGridView2.Rows[number].Cells[5].Value = arg6;

        }       
        public void CheckedTask_AddTaskInArchive(string arg1, string arg2, string arg3, string arg4, string arg5)
        {
            int number = dataGridView1.Rows.Add();
            dataGridView1.Rows[number].Cells[0].Value = arg1;
            dataGridView1.Rows[number].Cells[1].Value = arg2;
            dataGridView1.Rows[number].Cells[2].Value = arg3;
            dataGridView1.Rows[number].Cells[3].Value = arg4;
            dataGridView1.Rows[number].Cells[4].Value = arg5;
        }
       
        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ArchivedDelete archivedDelete = new ArchivedDelete();
            archivedDelete.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ArchieveAndDelete archivedDelete = new ArchieveAndDelete();
            archivedDelete.Show();
        }


    }
}
