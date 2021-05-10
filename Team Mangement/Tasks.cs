using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Mangement
{
    public  class Tasks
    {
        public List<SubTasks> _subtasks;
        public string IDTask { get; set; }
        public string _TaskName { get; set; }
        public string _StartDate { get; set; }
        public string _EndDate { get; set; }
        public List<object> _Employee = new List<object>();
        public string _Category_Name { get; set; }
        public string _Task_Priority { get; set; }
        public Tasks(){}
        public static List<Tasks> ListOftasks = new List<Tasks>();
        public static List<Tasks> ListOfArchievetasks = new List<Tasks>();

        public Tasks(string idTask,string taskName, string categoryName, string taskPriority, string startDate, string endDate)// List<object> taskss//,List<SubTasks> subTasks)
        { 
            _TaskName = taskName;
            _StartDate = startDate;
            _EndDate = endDate;
            _Category_Name = categoryName;
            _Task_Priority = taskPriority;
            IDTask = idTask;
        }
    }
}
