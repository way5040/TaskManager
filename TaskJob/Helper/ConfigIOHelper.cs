using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskJob.Model;

namespace TaskJob.Helper
{
    public static class ConfigIOHelper
    {
        /// <summary>
        /// 保存当前配置
        /// </summary>
        /// <param name="config"></param>
        public static void SaveConfig(this ConfigModel config) {
            File.Delete(Constants.ConfigFile);
            File.AppendAllText(Constants.ConfigFile, JsonConvert.SerializeObject(config));
        }
        /// <summary>
        /// 读取配置
        /// </summary>
        public static void ReadConfig()
        {
            if (File.Exists(Constants.ConfigFile))
                Constants.config = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(Constants.ConfigFile));
        }
        /// <summary>
        /// 添加任务配置
        /// </summary>
        public static void AddConfig(this TaskConfig config)
        {
            Constants.config.taskConfigs.Add(config);
            Constants.config.SaveConfig();
        }
        /// <summary>
        /// 删除任务配置
        /// </summary>
        public static void RemoveConfig(this string Id)
        {
            var config = Constants.config.taskConfigs.FirstOrDefault(e => e.TaskId.ToString() == Id);
            Constants.config.taskConfigs.Remove(config);
            Constants.config.SaveConfig();
        }
        /// <summary>
        /// 更新任务配置
        /// </summary>
        public static void UpdateConfig(this TaskConfig config)
        {
            Constants.config.taskConfigs.ForEach(e =>
            {
                e = config;
            });
            Constants.config.SaveConfig();
        }
    }
}
