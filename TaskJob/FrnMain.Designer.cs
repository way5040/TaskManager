namespace TaskJob
{
    partial class FrnMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrnMain));
            this.TaskListView = new System.Windows.Forms.ListView();
            this.TaskId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Method = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ApiUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cycle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskBz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddTask = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.添加任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskTimer = new System.Windows.Forms.Timer(this.components);
            this.cmsTask = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RunTask = new System.Windows.Forms.ToolStripMenuItem();
            this.StopTask = new System.Windows.Forms.ToolStripMenuItem();
            this.SetTask = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTask = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveTask = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.AddTask.SuspendLayout();
            this.cmsTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskListView
            // 
            this.TaskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TaskId,
            this.TaskName,
            this.Method,
            this.ApiUrl,
            this.State,
            this.cycle,
            this.TaskBz});
            this.TaskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskListView.FullRowSelect = true;
            this.TaskListView.Location = new System.Drawing.Point(0, 25);
            this.TaskListView.Name = "TaskListView";
            this.TaskListView.Size = new System.Drawing.Size(997, 517);
            this.TaskListView.TabIndex = 0;
            this.TaskListView.UseCompatibleStateImageBehavior = false;
            this.TaskListView.View = System.Windows.Forms.View.Details;
            this.TaskListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TaskListView_MouseClick);
            // 
            // TaskId
            // 
            this.TaskId.Text = "任务Id";
            this.TaskId.Width = 48;
            // 
            // TaskName
            // 
            this.TaskName.Text = "任务名";
            this.TaskName.Width = 131;
            // 
            // Method
            // 
            this.Method.Text = "请求方式";
            this.Method.Width = 82;
            // 
            // ApiUrl
            // 
            this.ApiUrl.Text = "请求API地址";
            this.ApiUrl.Width = 176;
            // 
            // State
            // 
            this.State.Text = "当前状态";
            this.State.Width = 73;
            // 
            // cycle
            // 
            this.cycle.Text = "频率";
            this.cycle.Width = 74;
            // 
            // TaskBz
            // 
            this.TaskBz.Text = "任务备注";
            this.TaskBz.Width = 339;
            // 
            // AddTask
            // 
            this.AddTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.AddTask.Location = new System.Drawing.Point(0, 0);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(997, 25);
            this.AddTask.TabIndex = 1;
            this.AddTask.Text = "添加任务";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加任务ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton1.Text = "文件";
            // 
            // 添加任务ToolStripMenuItem
            // 
            this.添加任务ToolStripMenuItem.Name = "添加任务ToolStripMenuItem";
            this.添加任务ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加任务ToolStripMenuItem.Text = "添加任务";
            this.添加任务ToolStripMenuItem.Click += new System.EventHandler(this.添加任务ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // TaskTimer
            // 
            this.TaskTimer.Enabled = true;
            this.TaskTimer.Interval = 1000;
            this.TaskTimer.Tick += new System.EventHandler(this.TaskTimer_Tick);
            // 
            // cmsTask
            // 
            this.cmsTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunTask,
            this.StopTask,
            this.SetTask,
            this.EditTask,
            this.RemoveTask});
            this.cmsTask.Name = "cmsTask";
            this.cmsTask.Size = new System.Drawing.Size(149, 114);
            // 
            // RunTask
            // 
            this.RunTask.Name = "RunTask";
            this.RunTask.Size = new System.Drawing.Size(148, 22);
            this.RunTask.Text = "运行任务";
            this.RunTask.Click += new System.EventHandler(this.RunTask_Click);
            // 
            // StopTask
            // 
            this.StopTask.Name = "StopTask";
            this.StopTask.Size = new System.Drawing.Size(148, 22);
            this.StopTask.Text = "暂停任务";
            this.StopTask.Click += new System.EventHandler(this.StopTask_Click);
            // 
            // SetTask
            // 
            this.SetTask.Name = "SetTask";
            this.SetTask.Size = new System.Drawing.Size(148, 22);
            this.SetTask.Text = "继续任务";
            this.SetTask.Click += new System.EventHandler(this.SetTask_Click);
            // 
            // EditTask
            // 
            this.EditTask.Name = "EditTask";
            this.EditTask.Size = new System.Drawing.Size(148, 22);
            this.EditTask.Text = "修改任务配置";
            this.EditTask.Click += new System.EventHandler(this.EditTask_Click);
            // 
            // RemoveTask
            // 
            this.RemoveTask.Name = "RemoveTask";
            this.RemoveTask.Size = new System.Drawing.Size(148, 22);
            this.RemoveTask.Text = "删除任务";
            this.RemoveTask.Click += new System.EventHandler(this.RemoveTask_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(662, 192);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 16);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // FrnMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 542);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.TaskListView);
            this.Controls.Add(this.AddTask);
            this.Name = "FrnMain";
            this.Text = "任务调配";
            this.Load += new System.EventHandler(this.FrnMain_Load);
            this.AddTask.ResumeLayout(false);
            this.AddTask.PerformLayout();
            this.cmsTask.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TaskListView;
        private System.Windows.Forms.ColumnHeader TaskId;
        private System.Windows.Forms.ColumnHeader TaskName;
        private System.Windows.Forms.ColumnHeader TaskBz;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader cycle;
        private System.Windows.Forms.ToolStrip AddTask;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 添加任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.Timer TaskTimer;
        private System.Windows.Forms.ContextMenuStrip cmsTask;
        private System.Windows.Forms.ToolStripMenuItem RemoveTask;
        private System.Windows.Forms.ToolStripMenuItem RunTask;
        private System.Windows.Forms.ToolStripMenuItem StopTask;
        private System.Windows.Forms.ToolStripMenuItem EditTask;
        private System.Windows.Forms.ColumnHeader Method;
        private System.Windows.Forms.ColumnHeader ApiUrl;
        private System.Windows.Forms.ToolStripMenuItem SetTask;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

