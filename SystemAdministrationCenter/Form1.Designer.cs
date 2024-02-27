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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabPage_Printer = new System.Windows.Forms.TabPage();
            this.listView_Printer = new System.Windows.Forms.ListView();
            this.imageList_Printer = new System.Windows.Forms.ImageList(this.components);
            this.tabPage_SystemInformation = new System.Windows.Forms.TabPage();
            this.groupBox_Mainboard = new System.Windows.Forms.GroupBox();
            this.label_MainboardModel = new System.Windows.Forms.Label();
            this.label_MainboardVendor = new System.Windows.Forms.Label();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.timer_Execution = new System.Windows.Forms.Timer(this.components);
            this.timer_CPUMemory = new System.Windows.Forms.Timer(this.components);
            this.groupBoxMemory = new System.Windows.Forms.GroupBox();
            this.label_MemoryAvailable = new System.Windows.Forms.Label();
            this.label_MemoryUsage = new System.Windows.Forms.Label();
            this.groupBox_OS = new System.Windows.Forms.GroupBox();
            this.label_OSName = new System.Windows.Forms.Label();
            this.groupBox_CPU = new System.Windows.Forms.GroupBox();
            this.progressBar_CPU = new System.Windows.Forms.ProgressBar();
            this.label_CPUUsage = new System.Windows.Forms.Label();
            this.timer_CheckRunningProcesses = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Tasks.SuspendLayout();
            this.tabPage_Printer.SuspendLayout();
            this.tabPage_SystemInformation.SuspendLayout();
            this.groupBox_Mainboard.SuspendLayout();
            this.groupBoxMemory.SuspendLayout();
            this.groupBox_OS.SuspendLayout();
            this.groupBox_CPU.SuspendLayout();
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
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
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
            this.tabControl1.Controls.Add(this.tabPage_Printer);
            this.tabControl1.Controls.Add(this.tabPage_SystemInformation);
            this.tabControl1.Location = new System.Drawing.Point(12, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(594, 250);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_Tasks
            // 
            this.tabPage_Tasks.Controls.Add(this.listView_Tasks);
            this.tabPage_Tasks.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Tasks.Name = "tabPage_Tasks";
            this.tabPage_Tasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Tasks.Size = new System.Drawing.Size(586, 224);
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
            this.listView_Tasks.Size = new System.Drawing.Size(586, 224);
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
            this.contextMenuStrip_LVTasks.Name = "contextMenuStrip_LVTasks";
            this.contextMenuStrip_LVTasks.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_LVTasks.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_LVTasks_Opening);
            // 
            // tabPage_Printer
            // 
            this.tabPage_Printer.Controls.Add(this.listView_Printer);
            this.tabPage_Printer.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Printer.Name = "tabPage_Printer";
            this.tabPage_Printer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Printer.Size = new System.Drawing.Size(586, 224);
            this.tabPage_Printer.TabIndex = 1;
            this.tabPage_Printer.Text = "Drucker";
            this.tabPage_Printer.UseVisualStyleBackColor = true;
            // 
            // listView_Printer
            // 
            this.listView_Printer.HideSelection = false;
            this.listView_Printer.LargeImageList = this.imageList_Printer;
            this.listView_Printer.Location = new System.Drawing.Point(0, 0);
            this.listView_Printer.Name = "listView_Printer";
            this.listView_Printer.Size = new System.Drawing.Size(586, 224);
            this.listView_Printer.TabIndex = 0;
            this.listView_Printer.UseCompatibleStateImageBehavior = false;
            // 
            // imageList_Printer
            // 
            this.imageList_Printer.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Printer.ImageStream")));
            this.imageList_Printer.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Printer.Images.SetKeyName(0, "default");
            this.imageList_Printer.Images.SetKeyName(1, "normal");
            // 
            // tabPage_SystemInformation
            // 
            this.tabPage_SystemInformation.Controls.Add(this.groupBox_CPU);
            this.tabPage_SystemInformation.Controls.Add(this.groupBox_OS);
            this.tabPage_SystemInformation.Controls.Add(this.groupBoxMemory);
            this.tabPage_SystemInformation.Controls.Add(this.groupBox_Mainboard);
            this.tabPage_SystemInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SystemInformation.Name = "tabPage_SystemInformation";
            this.tabPage_SystemInformation.Size = new System.Drawing.Size(586, 224);
            this.tabPage_SystemInformation.TabIndex = 2;
            this.tabPage_SystemInformation.Text = "Systeminformationen";
            this.tabPage_SystemInformation.UseVisualStyleBackColor = true;
            // 
            // groupBox_Mainboard
            // 
            this.groupBox_Mainboard.Controls.Add(this.label_MainboardModel);
            this.groupBox_Mainboard.Controls.Add(this.label_MainboardVendor);
            this.groupBox_Mainboard.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Mainboard.Name = "groupBox_Mainboard";
            this.groupBox_Mainboard.Size = new System.Drawing.Size(226, 58);
            this.groupBox_Mainboard.TabIndex = 0;
            this.groupBox_Mainboard.TabStop = false;
            this.groupBox_Mainboard.Text = "Mainboard";
            // 
            // label_MainboardModel
            // 
            this.label_MainboardModel.AutoSize = true;
            this.label_MainboardModel.Location = new System.Drawing.Point(17, 42);
            this.label_MainboardModel.Name = "label_MainboardModel";
            this.label_MainboardModel.Size = new System.Drawing.Size(36, 13);
            this.label_MainboardModel.TabIndex = 1;
            this.label_MainboardModel.Text = "Model";
            // 
            // label_MainboardVendor
            // 
            this.label_MainboardVendor.AutoSize = true;
            this.label_MainboardVendor.Location = new System.Drawing.Point(17, 19);
            this.label_MainboardVendor.Name = "label_MainboardVendor";
            this.label_MainboardVendor.Size = new System.Drawing.Size(41, 13);
            this.label_MainboardVendor.TabIndex = 0;
            this.label_MainboardVendor.Text = "Vendor";
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
            // timer_CPUMemory
            // 
            this.timer_CPUMemory.Enabled = true;
            this.timer_CPUMemory.Interval = 1000;
            this.timer_CPUMemory.Tick += new System.EventHandler(this.timer_CPUMemory_Tick);
            // 
            // groupBoxMemory
            // 
            this.groupBoxMemory.Controls.Add(this.label_MemoryAvailable);
            this.groupBoxMemory.Controls.Add(this.label_MemoryUsage);
            this.groupBoxMemory.Location = new System.Drawing.Point(322, 3);
            this.groupBoxMemory.Name = "groupBoxMemory";
            this.groupBoxMemory.Size = new System.Drawing.Size(261, 72);
            this.groupBoxMemory.TabIndex = 4;
            this.groupBoxMemory.TabStop = false;
            this.groupBoxMemory.Text = "Arbeitsspeicher";
            // 
            // label_MemoryAvailable
            // 
            this.label_MemoryAvailable.AutoSize = true;
            this.label_MemoryAvailable.Location = new System.Drawing.Point(6, 50);
            this.label_MemoryAvailable.Name = "label_MemoryAvailable";
            this.label_MemoryAvailable.Size = new System.Drawing.Size(87, 13);
            this.label_MemoryAvailable.TabIndex = 5;
            this.label_MemoryAvailable.Text = "MemoryAvailable";
            // 
            // label_MemoryUsage
            // 
            this.label_MemoryUsage.AutoSize = true;
            this.label_MemoryUsage.Location = new System.Drawing.Point(6, 23);
            this.label_MemoryUsage.Name = "label_MemoryUsage";
            this.label_MemoryUsage.Size = new System.Drawing.Size(75, 13);
            this.label_MemoryUsage.TabIndex = 4;
            this.label_MemoryUsage.Text = "MemoryUsage";
            // 
            // groupBox_OS
            // 
            this.groupBox_OS.Controls.Add(this.label_OSName);
            this.groupBox_OS.Location = new System.Drawing.Point(3, 67);
            this.groupBox_OS.Name = "groupBox_OS";
            this.groupBox_OS.Size = new System.Drawing.Size(226, 44);
            this.groupBox_OS.TabIndex = 6;
            this.groupBox_OS.TabStop = false;
            this.groupBox_OS.Text = "Betriebsystem";
            // 
            // label_OSName
            // 
            this.label_OSName.AutoSize = true;
            this.label_OSName.Location = new System.Drawing.Point(2, 21);
            this.label_OSName.Name = "label_OSName";
            this.label_OSName.Size = new System.Drawing.Size(50, 13);
            this.label_OSName.TabIndex = 0;
            this.label_OSName.Text = "OSName";
            // 
            // groupBox_CPU
            // 
            this.groupBox_CPU.Controls.Add(this.progressBar_CPU);
            this.groupBox_CPU.Controls.Add(this.label_CPUUsage);
            this.groupBox_CPU.Location = new System.Drawing.Point(322, 178);
            this.groupBox_CPU.Name = "groupBox_CPU";
            this.groupBox_CPU.Size = new System.Drawing.Size(261, 43);
            this.groupBox_CPU.TabIndex = 7;
            this.groupBox_CPU.TabStop = false;
            this.groupBox_CPU.Text = "CPU-Auslastung";
            // 
            // progressBar_CPU
            // 
            this.progressBar_CPU.Location = new System.Drawing.Point(6, 20);
            this.progressBar_CPU.Name = "progressBar_CPU";
            this.progressBar_CPU.Size = new System.Drawing.Size(209, 17);
            this.progressBar_CPU.Step = 1;
            this.progressBar_CPU.TabIndex = 7;
            // 
            // label_CPUUsage
            // 
            this.label_CPUUsage.AutoSize = true;
            this.label_CPUUsage.Location = new System.Drawing.Point(221, 22);
            this.label_CPUUsage.Name = "label_CPUUsage";
            this.label_CPUUsage.Size = new System.Drawing.Size(37, 13);
            this.label_CPUUsage.TabIndex = 6;
            this.label_CPUUsage.Text = "CPUU";
            // 
            // timer_CheckRunningProcesses
            // 
            this.timer_CheckRunningProcesses.Enabled = true;
            this.timer_CheckRunningProcesses.Interval = 1125;
            this.timer_CheckRunningProcesses.Tick += new System.EventHandler(this.timer_CheckRunningProcesses_Tick);
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
            this.tabPage_Printer.ResumeLayout(false);
            this.tabPage_SystemInformation.ResumeLayout(false);
            this.groupBox_Mainboard.ResumeLayout(false);
            this.groupBox_Mainboard.PerformLayout();
            this.groupBoxMemory.ResumeLayout(false);
            this.groupBoxMemory.PerformLayout();
            this.groupBox_OS.ResumeLayout(false);
            this.groupBox_OS.PerformLayout();
            this.groupBox_CPU.ResumeLayout(false);
            this.groupBox_CPU.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage_Printer;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.ListView listView_Tasks;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_Condition;
        private System.Windows.Forms.ColumnHeader columnHeader_Execution;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_LVTasks;
        private System.Windows.Forms.ColumnHeader columnHeader_Status;
        private System.Windows.Forms.Timer timer_Execution;
        private System.Windows.Forms.ListView listView_Printer;
        private System.Windows.Forms.ImageList imageList_Printer;
        private System.Windows.Forms.TabPage tabPage_SystemInformation;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_Mainboard;
        private System.Windows.Forms.Label label_MainboardVendor;
        private System.Windows.Forms.Label label_MainboardModel;
        private System.Windows.Forms.Timer timer_CPUMemory;
        private System.Windows.Forms.GroupBox groupBoxMemory;
        private System.Windows.Forms.Label label_MemoryAvailable;
        private System.Windows.Forms.Label label_MemoryUsage;
        private System.Windows.Forms.GroupBox groupBox_OS;
        private System.Windows.Forms.Label label_OSName;
        private System.Windows.Forms.GroupBox groupBox_CPU;
        private System.Windows.Forms.ProgressBar progressBar_CPU;
        private System.Windows.Forms.Label label_CPUUsage;
        private System.Windows.Forms.Timer timer_CheckRunningProcesses;
    }
}

