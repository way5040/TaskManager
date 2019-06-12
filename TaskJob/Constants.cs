using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskJob.Model;

namespace TaskJob
{
   public class Constants
    {
        public static ConfigModel config { get; set; }
        public static string ConfigFile = "Config.ini";
        public static List<Task> tasks = new List<Task>();
        public static List<TaskDetaile> taskDetailes = new List<TaskDetaile>();
    }
    public class TaskDetaile
    {
        public CancellationTokenSource TokenSource { get; set; }
        public ManualResetEvent ResetEvent { get; set; }
        public  int TaskId { get; set; }
        public  int TaskConfigId { get; set; }
    }

}
