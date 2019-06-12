using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskJob.Helper;
using TaskJob.Model;

namespace TaskJob
{
    public partial class FrnMain : Form
    {
        public FrnMain()
        {
            InitializeComponent();
        }

        private void 添加任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTask frmEditTask = new frmEditTask();
            frmEditTask.ShowDialog();
        }

        private void FrnMain_Load(object sender, EventArgs e)
        {
            //读取配置
            ConfigIOHelper.ReadConfig();
            Constants.config.taskConfigs.ForEach(n=> {
                n.State = "";
            });
        }


        /// <summary>
        /// 设置ListView的列表值
        /// </summary>
        private void SetListView() {

            #region 任务添加Action
            Action<TaskConfig> addTask = (e) => {
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;
                ManualResetEvent resetEvent = new ManualResetEvent(true);
                Task task = new Task(() => Job.TaskJob(e.TaskId, token,resetEvent), token);
                Constants.tasks.Add(task);
                Constants.taskDetailes.Add(new TaskDetaile() { TaskId = task.Id, TaskConfigId = e.TaskId, TokenSource= tokenSource , ResetEvent = resetEvent });
            };
            #endregion

            #region 任务移除Action
   
            #endregion

            #region 多余任务删除逻辑块 
            var configs = Constants.config.taskConfigs;
            foreach (ListViewItem item in TaskListView.Items)
            {
                var config = configs.FirstOrDefault(e => e.TaskId.ToString() == item.SubItems[0].Text);
                if (config == null) {
                    item.Remove();
                }

            }
            #endregion

            #region 任务缺少逻辑块
            configs.ForEach(e => {
                ListViewItem item = new ListViewItem();
                item.Text = e.TaskId.ToString();
                item.SubItems.Add(e.TaskName.ToString());
                item.SubItems.Add(e.Method);
                item.SubItems.Add(e.Url);
                item.SubItems.Add(e.State?.ToString());
                item.SubItems.Add(e.Interval.ToString());
                item.SubItems.Add(e.TaskBz.ToString());
                if (TaskListView.Items.Cast<ListViewItem>().FirstOrDefault(n => n.Text.Equals(item.Text)) == null)
                {
                    TaskListView.Items.Add(item);
                    addTask.Invoke(e);
                }
                else
                {
                    var items = TaskListView.Items;
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].Text == e.TaskId.ToString())
                        {
                            if (items[i].SubItems[1].Text != e.TaskName || items[i].SubItems[2].Text != (e.Method == null ? "" : e.Method) || items[i].SubItems[3].Text != (e.Url == null ? "" : e.Url) || items[i].SubItems[6].Text != e.TaskBz || items[i].SubItems[4].Text != (e.State == null ? "" : e.State) || items[i].SubItems[5].Text != e.Interval.ToString())
                            {
                                TaskListView.Items.Remove(items[i]);
                                TaskListView.Items.Add(item);
                            }
                        }
                    }
                }

            });
            #endregion
        }

        private void TaskTimer_Tick(object sender, EventArgs e)
        {
            SetListView();
            GetTasksState();
        }

        /// <summary>
        /// 获取任务的状态
        /// </summary>
        private void GetTasksState()
        {
            Constants.config.taskConfigs.ForEach(e=> {
                var detaile = Constants.taskDetailes.FirstOrDefault(n=>n.TaskConfigId==e.TaskId);
                var task = Constants.tasks.FirstOrDefault(n => n.Id == detaile.TaskId);
                //e.State = task.Status.ToString();
            });
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //-------右键菜单操作逻辑----------------------------------------------------------------------
        private void TaskListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Right")
            {
                cmsTask.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }
        #region
        #region 通用逻辑封装
        Action<ListViewItem,string, EnumHelper.RightButtonType> RightMenuAction = (item,str, type) => {
            if (item != null)
            {
                var config = Constants.config.taskConfigs.FirstOrDefault(n => n.TaskId.ToString() == item.Text);
                if (config != null)
                {
                    var detaile = Constants.taskDetailes.FirstOrDefault(n => n.TaskConfigId == config.TaskId);
                    if (detaile != null)
                    {
                        var task = Constants.tasks.FirstOrDefault(n => n.Id == detaile.TaskId);
                        if (task != null)
                        {
                            switch (type)
                            {
                                case EnumHelper.RightButtonType.Runing:
                                    if (task.Status.ToString()=="Running")
                                        detaile.ResetEvent.Set();
                                    else
                                        task.Start();
                                    break;
                                case EnumHelper.RightButtonType.Stop:
                                    detaile.ResetEvent.Reset();
                                    break;
                                case EnumHelper.RightButtonType.Set:
                                    detaile.ResetEvent.Set();
                                    break;
                                case EnumHelper.RightButtonType.Cancel:
                                    detaile.TokenSource.Cancel();
                                    config.TaskId.ToString().RemoveConfig();
                                    break;
                                default:
                                    break;
                            }
                            if (type!= EnumHelper.RightButtonType.Cancel)
                            {
                                config.State = str;
                                config.UpdateConfig();
                            }
                            else
                            {
                                removeTask.Invoke(config);
                                config.TaskId.ToString().RemoveConfig();
                            }
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("操作失败");
        };
        #endregion
       static  Action<TaskConfig> removeTask = (e) => {
            var taskDetaile = Constants.taskDetailes.FirstOrDefault(n => n.TaskConfigId == e.TaskId);
            Task task = Constants.tasks.FirstOrDefault(n => n.Id == taskDetaile.TaskId);
            taskDetaile.TokenSource.Cancel(true);
            Constants.tasks.Remove(task);
            Constants.taskDetailes.Remove(taskDetaile);
            task = null;
        };
        #region  启动某任务
        /// <summary>
        /// 启动某任务
        /// </summary>

        private void RunTask_Click(object sender, EventArgs e)
        {
           var item= TaskListView.SelectedItems.Count > 0 ? TaskListView.SelectedItems[0] : null;
            RightMenuAction.Invoke(item,"运行中", EnumHelper.RightButtonType.Runing);
        }
        #endregion
        //暂停某任务
        private void StopTask_Click(object sender, EventArgs e)
        {
            var item = TaskListView.SelectedItems.Count > 0 ? TaskListView.SelectedItems[0] : null;
            RightMenuAction.Invoke(item, "已暂停", EnumHelper.RightButtonType.Stop);
        }
        //继续某任务
        private void SetTask_Click(object sender, EventArgs e)
        {
            var item = TaskListView.SelectedItems.Count > 0 ? TaskListView.SelectedItems[0] : null;
            RightMenuAction.Invoke(item, "运行中", EnumHelper.RightButtonType.Set);
        }
        //删除某任务
        private void RemoveTask_Click(object sender, EventArgs e)
        {
            var item = TaskListView.SelectedItems.Count > 0 ? TaskListView.SelectedItems[0] : null;
            RightMenuAction.Invoke(item, "已取消", EnumHelper.RightButtonType.Cancel);
        }
        //编辑某任务配置
        private void EditTask_Click(object sender, EventArgs e)
        {
            var item = TaskListView.SelectedItems.Count > 0 ? TaskListView.SelectedItems[0] : null;
            if (item==null)
            {
                //frmEditTask frmEditTask = new frmEditTask();
                //frmEditTask.ShowDialog();
            }
            else
            {
                var config = Constants.config.taskConfigs.FirstOrDefault(n=>n.TaskId.ToString().Equals(item.Text));
                if (config!=null)
                {
                    frmEditTask frmEditTask = new frmEditTask(config);
                    frmEditTask.ShowDialog();
                }
         
            }
         
        }



        #endregion


    }
}
