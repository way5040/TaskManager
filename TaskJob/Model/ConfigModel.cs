using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskJob.Model
{
    public class ConfigModel
    {
        public List<TaskConfig> taskConfigs { get; set; }
    }
    public class TaskConfig {
        public int Interval { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskBz { get; set; }
        public string State { get; set; }
        public string Method { get; set; }
        public string Parameter { get; set; }
        public string Url { get; set; }
    }
}
