using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskJob.Model;

namespace TaskJob
{
    public class Job
    {
        public static void TaskJob(int TaskId, CancellationToken token, ManualResetEvent resetEvent) {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                // 初始化为true时执行WaitOne不阻塞
                resetEvent.WaitOne();

                 //任务的业务逻辑

                var config = Constants.config.taskConfigs.FirstOrDefault(e=>e.TaskId== TaskId);
                File.AppendAllText($"files/{config.TaskName}.txt", $"{config.TaskBz}\r\n");
                Thread.Sleep(config.Interval*1000);

            }
        }
    }
}
