using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskJob.Helper;
using TaskJob.Model;

namespace TaskJob
{
    public partial class frmEditTask : Form
    {
        private bool IsAdd;
        public frmEditTask()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 0;
            IsAdd = true;
        }
        public frmEditTask(TaskConfig taskConfig)
        {
            InitializeComponent();
            txtTaskId.Text = taskConfig.TaskId.ToString();
            txtTaskName.Text = taskConfig.TaskName;
            txtTaskInterval.Text = taskConfig.Interval.ToString();
            txtConfigBz.Text = taskConfig.TaskBz;
            txtparameter.Text = taskConfig.Parameter;
            txtUrl.Text = taskConfig.Url;
            labState.Text = taskConfig.State;
            cmbType.SelectedIndex = taskConfig.Method == "Post" || taskConfig.Method ==null ? 0:1;
            IsAdd = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TaskConfig taskConfig = new TaskConfig();
            if (!int.TryParse(txtTaskId.Text, out int Id))
            {
                MessageBox.Show("任务编码必须是数字");
                return;
            }
            if (!int.TryParse(txtTaskInterval.Text, out int Interval))
            {
                MessageBox.Show("任务频率必须是数字");
                return;
            }
            var config = Constants.config.taskConfigs.FirstOrDefault(n => n.TaskId.ToString() == txtTaskId.Text);
            taskConfig.Interval = Interval;
            taskConfig.TaskId = Id;
            taskConfig.TaskName = txtTaskName.Text;
            taskConfig.TaskBz = txtConfigBz.Text;
            taskConfig.Url = txtUrl.Text;
            taskConfig.Method = cmbType.SelectedIndex == 0 ? "Post" : "Get";
            taskConfig.Parameter = txtparameter.Text;
            if (IsAdd)
            {
                if (Constants.config.taskConfigs.FirstOrDefault(n => n.TaskId.ToString() == txtTaskId.Text) != null)
                {
                    MessageBox.Show("任务ID已存在");
                    return;
                }
                taskConfig.AddConfig();
            }
            else
            {
                Constants.config.taskConfigs.Remove(config);
                taskConfig.State = labState.Text;
                taskConfig.AddConfig();
            }

            Constants.config.SaveConfig();

            this.Close();
        }

        private void frmEditTask_Load(object sender, EventArgs e)
        {

        }
    }
}
