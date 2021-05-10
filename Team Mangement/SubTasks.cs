using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Mangement
{
    public class SubTasks
    {
        public string IDSubTask { get; set; }
        public string _SubTaskName { get; set; }
        public string _StartDate { get; set; }
        public string _EndDate { get; set; }
        public string _SubTask_Priority { get; set; }
        public static List<SubTasks> ListOfsubTasks = new List<SubTasks>();
        public static List<SubTasks> ListOfArchievesubtasks = new List<SubTasks>();
        public SubTasks(string idsubTask,string subtaskName, string taskPriority, string startDate, string endDate)
        {
            _SubTaskName = subtaskName;
            _StartDate = startDate;
            _EndDate = endDate;
            _SubTask_Priority = taskPriority;
            IDSubTask = idsubTask;
        }
    }
}
