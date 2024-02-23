namespace SystemAdministrationCenter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_UserNameComputerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Tasks = new System.Windows.Forms.TabPage();
            this.listView_Tasks = new System.Windows.Forms.ListView();
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Condition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Execution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_LVTasks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_NeuenTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.timer_Execution = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Tasks.SuspendLayout();
            this.contextMenuStrip_LVTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_UserNameComputerName,
            this.toolStripStatusLabel_Time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 298);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(618, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_UserNameComputerName
            // 
            this.toolStripStatusLabel_UserNameComputerName.Name = "toolStripStatusLabel_UserNameComputerName";
            this.toolStripStatusLabel_UserNameComputerName.Size = new System.Drawing.Size(603, 17);
            this.toolStripStatusLabel_UserNameComputerName.Spring = true;
            this.toolStripStatusLabel_UserNameComputerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_Time
            // 
            this.toolStripStatusLabel_Time.Name = "toolStripStatusLabel_Time";
            this.toolStripStatusLabel_Time.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Tasks);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(594, 226);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage_Tasks
            // 
            this.tabPage_Tasks.Controls.Add(this.listView_Tasks);
            this.tabPage_Tasks.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Tasks.Name = "tabPage_Tasks";
            this.tabPage_Tasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Tasks.Size = new System.Drawing.Size(586, 200);
            this.tabPage_Tasks.TabIndex = 0;
            this.tabPage_Tasks.Text = "Tasks";
            this.tabPage_Tasks.UseVisualStyleBackColor = true;
            // 
            // listView_Tasks
            // 
            this.listView_Tasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Name,
            this.columnHeader_Condition,
            this.columnHeader_Execution,
            this.columnHeader_Status});
            this.listView_Tasks.ContextMenuStrip = this.contextMenuStrip_LVTasks;
            this.listView_Tasks.FullRowSelect = true;
            this.listView_Tasks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Tasks.HideSelection = false;
            this.listView_Tasks.Location = new System.Drawing.Point(0, 0);
            this.listView_Tasks.MultiSelect = false;
            this.listView_Tasks.Name = "listView_Tasks";
            this.listView_Tasks.ShowItemToolTips = true;
            this.listView_Tasks.Size = new System.Drawing.Size(586, 200);
            this.listView_Tasks.TabIndex = 0;
            this.listView_Tasks.UseCompatibleStateImageBehavior = false;
            this.listView_Tasks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_Name
            // 
            this.columnHeader_Name.Text = "Name";
            // 
            // columnHeader_Condition
            // 
            this.columnHeader_Condition.Text = "Bedingung";
            // 
            // columnHeader_Execution
            // 
            this.columnHeader_Execution.Text = "Ausführung";
            // 
            // columnHeader_Status
            // 
            this.columnHeader_Status.Text = "Status";
            // 
            // contextMenuStrip_LVTasks
            // 
            this.contextMenuStrip_LVTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_NeuenTask});
            this.contextMenuStrip_LVTasks.Name = "contextMenuStrip_LVTasks";
            this.contextMenuStrip_LVTasks.Size = new System.Drawing.Size(182, 48);
            this.contextMenuStrip_LVTasks.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip_LVTasks_Closing);
            this.contextMenuStrip_LVTasks.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_LVTasks_Opening);
            // 
            // toolStripMenuItem_NeuenTask
            // 
            this.toolStripMenuItem_NeuenTask.Name = "toolStripMenuItem_NeuenTask";
            this.toolStripMenuItem_NeuenTask.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem_NeuenTask.Text = "Neuen Task erstellen";
            this.toolStripMenuItem_NeuenTask.Click += new System.EventHandler(this.toolStripMenuItem_NeuenTask_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(586, 200);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // timer_Execution
            // 
            this.timer_Execution.Enabled = true;
            this.timer_Execution.Interval = 1000;
            this.timer_Execution.Tick += new System.EventHandler(this.timer_Execution_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 320);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SystemAdministrationCenter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Tasks.ResumeLayout(false);
            this.contextMenuStrip_LVTasks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_UserNameComputerName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Time;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Tasks;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.ListView listView_Tasks;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_Condition;
        private System.Windows.Forms.ColumnHeader columnHeader_Execution;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_LVTasks;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_NeuenTask;
        private System.Windows.Forms.ColumnHeader columnHeader_Status;
        private System.Windows.Forms.Timer timer_Execution;
    }
}

