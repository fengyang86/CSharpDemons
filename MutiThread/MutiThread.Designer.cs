namespace MutiThread
{
    partial class MutiThread
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
            this.ThreadPool = new System.Windows.Forms.Button();
            this.TaskFun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ThreadFun = new System.Windows.Forms.Button();
            this.AsyncDelegate = new System.Windows.Forms.Button();
            this.InterlockedUse = new System.Windows.Forms.Button();
            this.LockUse = new System.Windows.Forms.Button();
            this.MonitorUse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ThreadPool
            // 
            this.ThreadPool.Location = new System.Drawing.Point(50, 136);
            this.ThreadPool.Name = "ThreadPool";
            this.ThreadPool.Size = new System.Drawing.Size(125, 39);
            this.ThreadPool.TabIndex = 0;
            this.ThreadPool.Text = "Thread线程池";
            this.ThreadPool.UseVisualStyleBackColor = true;
            this.ThreadPool.Click += new System.EventHandler(this.ThreadPool_Click);
            // 
            // TaskFun
            // 
            this.TaskFun.Location = new System.Drawing.Point(51, 181);
            this.TaskFun.Name = "TaskFun";
            this.TaskFun.Size = new System.Drawing.Size(125, 36);
            this.TaskFun.TabIndex = 1;
            this.TaskFun.Text = "Task";
            this.TaskFun.UseVisualStyleBackColor = true;
            this.TaskFun.Click += new System.EventHandler(this.TaskFun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(142, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "多线程Demon";
            // 
            // ThreadFun
            // 
            this.ThreadFun.Location = new System.Drawing.Point(51, 89);
            this.ThreadFun.Name = "ThreadFun";
            this.ThreadFun.Size = new System.Drawing.Size(124, 41);
            this.ThreadFun.TabIndex = 3;
            this.ThreadFun.Text = "Thread函数";
            this.ThreadFun.UseVisualStyleBackColor = true;
            this.ThreadFun.Click += new System.EventHandler(this.ThreadFun_Click);
            // 
            // AsyncDelegate
            // 
            this.AsyncDelegate.Location = new System.Drawing.Point(50, 223);
            this.AsyncDelegate.Name = "AsyncDelegate";
            this.AsyncDelegate.Size = new System.Drawing.Size(122, 41);
            this.AsyncDelegate.TabIndex = 4;
            this.AsyncDelegate.Text = "委托异步执行";
            this.AsyncDelegate.UseVisualStyleBackColor = true;
            this.AsyncDelegate.Click += new System.EventHandler(this.AsyncDelegate_Click);
            // 
            // InterlockedUse
            // 
            this.InterlockedUse.Location = new System.Drawing.Point(204, 89);
            this.InterlockedUse.Name = "InterlockedUse";
            this.InterlockedUse.Size = new System.Drawing.Size(124, 41);
            this.InterlockedUse.TabIndex = 5;
            this.InterlockedUse.Text = "Inerlocked示范";
            this.InterlockedUse.UseVisualStyleBackColor = true;
            this.InterlockedUse.Click += new System.EventHandler(this.InterlockedUse_Click);
            // 
            // LockUse
            // 
            this.LockUse.Location = new System.Drawing.Point(204, 134);
            this.LockUse.Name = "LockUse";
            this.LockUse.Size = new System.Drawing.Size(124, 41);
            this.LockUse.TabIndex = 6;
            this.LockUse.Text = "lock关键字使用";
            this.LockUse.UseVisualStyleBackColor = true;
            this.LockUse.Click += new System.EventHandler(this.LockUse_Click);
            // 
            // MonitorUse
            // 
            this.MonitorUse.Location = new System.Drawing.Point(204, 181);
            this.MonitorUse.Name = "MonitorUse";
            this.MonitorUse.Size = new System.Drawing.Size(124, 41);
            this.MonitorUse.TabIndex = 7;
            this.MonitorUse.Text = "Monitor类锁定资源";
            this.MonitorUse.UseVisualStyleBackColor = true;
            this.MonitorUse.Click += new System.EventHandler(this.MonitorUse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 336);
            this.Controls.Add(this.MonitorUse);
            this.Controls.Add(this.LockUse);
            this.Controls.Add(this.InterlockedUse);
            this.Controls.Add(this.AsyncDelegate);
            this.Controls.Add(this.ThreadFun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TaskFun);
            this.Controls.Add(this.ThreadPool);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ThreadPool;
        private System.Windows.Forms.Button TaskFun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ThreadFun;
        private System.Windows.Forms.Button AsyncDelegate;
        private System.Windows.Forms.Button InterlockedUse;
        private System.Windows.Forms.Button LockUse;
        private System.Windows.Forms.Button MonitorUse;
    }
}

