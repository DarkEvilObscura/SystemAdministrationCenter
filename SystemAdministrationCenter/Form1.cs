using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemAdministrationCenter
{
    public partial class Form1 : Form
    {
        private const int CB_SETCUEBANNER = 0x1703;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        //Beinhaltet eine Liste von Schlüssel-Werte-Paaren für die ListView:
        //TKey: taskID, TValue: ListViewItem
        List<KeyValuePair<int, ListViewItem>> listLVItems = new List<KeyValuePair<int, ListViewItem>>();

        //Beinhaltet die Liste von den erstellen Tasks
        List<TaskErstellenBearbeiten> listTasks = new List<TaskErstellenBearbeiten>();

        //Beinhaltet eine Liste von Schlüssel-Werte-Paaren, für die Ausführung von Tasks:
        //TKey: taskID, TValue: Hintergrund-Thread mit dem ausgeführten Prozess
        List<KeyValuePair<int, ProcessWorker>> listProcess = new List<KeyValuePair<int, ProcessWorker>>();

        const int LV_LONGEST_ITEM = -1;
        const int LV_WIDTH_AUTOSIZE = -2;

        const int LV_COLUMN_STATUS = 3;

        static TaskErstellenBearbeiten task;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_Time.Text = DateTime.Now.ToString();
        }

        void Init()
        {
            toolStripStatusLabel_UserNameComputerName.Text = string.Format("{0} ({1})", Environment.UserName, Environment.MachineName);
            toolStripStatusLabel_Time.Text = DateTime.Now.ToString();

            UpdateListViewColumnWidth();
            SystemInformation.Run();
        }

        ListViewItem CreateNewListViewItem(TaskErstellenBearbeiten task)
        {
            ListViewItem lvItem = new ListViewItem(task.TaskName);
            if (task.TaskCondition.ToString() == "Uhrzeit")
            {
                lvItem.SubItems.Add(string.Format("{0} ({1})", task.TaskCondition.ToString(), task.TaskConditionTime.ToShortTimeString()));
            }
            else
            {
                lvItem.SubItems.Add(task.TaskCondition.ToString());
            }
            lvItem.SubItems.Add(string.Format("\"{0}\" {1}", task.TaskExecution[0].Value, task.TaskExecution[1].Value));
            lvItem.SubItems.Add("Noch nicht ausgeführt");

            return lvItem;
        }

        void UpdateListViewItemStatus(int listViewIndex, TaskErstellenBearbeiten.StatusTyp status)
        {
            this.listTasks[listViewIndex].StatusText = status;
            this.listLVItems[listViewIndex].Value.SubItems[LV_COLUMN_STATUS].Text = GetStatusText(status);
        }

        void UpdateListViewColumnWidth()
        {
            int width = (listView_Tasks.Width / 4) - 1;

            columnHeader_Name.Width = width;
            columnHeader_Condition.Width = width;
            columnHeader_Execution.Width = width;
            columnHeader_Status.Width = width;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            tabControl1.Width = this.Width - 40;
            tabControl1.Height = this.Height - 133;

            listView_Tasks.Width = tabControl1.Width;
            listView_Tasks.Height = tabControl1.Height;

            UpdateListViewColumnWidth();
        }

        private void timer_Execution_Tick(object sender, EventArgs e)
        {
            CheckToRun();
        }

        private void timer_CheckRunningProcesses_Tick(object sender, EventArgs e)
        {
            CheckRunningProcess();
        }

        //Überprüft, welche Tasks ausgeführt werden müssen
        void CheckToRun()
        {
            if (listTasks.Count > 0)
            {
                if(!timer_CheckRunningProcesses.Enabled)
                {
                    timer_CheckRunningProcesses.Enabled = true;
                    timer_CheckRunningProcesses.Start();
                }
                foreach (TaskErstellenBearbeiten item in listTasks)
                {
                    if (item.TaskCondition == TaskErstellenBearbeiten.Condition.Uhrzeit &&
                       item.TaskConditionTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() &&
                       item.StatusText == TaskErstellenBearbeiten.StatusTyp.NochNichtAusgefuehrt)
                    {
                        Run(item);
                    }
                }
            }
            else
            {
                if (timer_CheckRunningProcesses.Enabled)
                {
                    timer_CheckRunningProcesses.Enabled = false;
                    timer_CheckRunningProcesses.Stop();
                }
            }
        }

        //Prüft die laufenden Tasks
        void CheckRunningProcess()
        {
            int index;
            foreach (KeyValuePair<int, ProcessWorker> item in this.listProcess)
            {
                task = this.listTasks.Find(x => x.ID == item.Key);
                if (task.StatusText == TaskErstellenBearbeiten.StatusTyp.Beendet)
                {
                    if (item.Value.Running && item.Value.PID > 0)
                    {
                        task.StatusText = TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt;

                        index = this.listLVItems.Find(x => x.Key == task.ID).Value.Index;
                        UpdateListViewItemStatus(index, TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt);
                    }
                }

                if (task.StatusText == TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt)
                {   
                    if(!item.Value.Running && item.Value.PID == 0)
                    {
                        task.StatusText = TaskErstellenBearbeiten.StatusTyp.Beendet;

                        index = this.listLVItems.Find(x => x.Key == task.ID).Value.Index;
                        UpdateListViewItemStatus(index, TaskErstellenBearbeiten.StatusTyp.Beendet);
                    }
                }

                //if (!item.Value.Running)
                //{
                //    //listIDs.Add(item.Key);
                //    task = (TaskErstellenBearbeiten)item.Value.CurrentObject;
                //    index = listLVItems.FindIndex(x => x.Key == task.ID);
                //    UpdateListViewItemStatus(index, TaskErstellenBearbeiten.StatusTyp.Beendet);
                //}
            }
        }

        //Task wird ausgeführt
        void Run(TaskErstellenBearbeiten task)
        {
            ProcessWorker processWorker = new ProcessWorker(task);
            this.listProcess.Add(new KeyValuePair<int, ProcessWorker>(task.ID, processWorker));
            task.StatusText = TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt;
            UpdateListViewItemStatus(listLVItems.FindIndex(x => x.Key == task.ID), TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt);

            processWorker.StartWorker();
        }

        //Beendet den Task
        void Kill(int taskID)
        {
            TaskErstellenBearbeiten task = listTasks.Find(x => x.ID == taskID);
            KeyValuePair<int, ProcessWorker> item = this.listProcess.Find(x => x.Key == taskID);
            item.Value.KillProcess();
            task.StatusText = TaskErstellenBearbeiten.StatusTyp.Beendet;
            UpdateListViewItemStatus(listLVItems.FindIndex(x => x.Key == taskID), TaskErstellenBearbeiten.StatusTyp.Beendet);
        }

        string GetStatusText(TaskErstellenBearbeiten.StatusTyp status)
        {
            switch (status)
            {
                case TaskErstellenBearbeiten.StatusTyp.NochNichtAusgefuehrt:
                    return "Noch nicht ausgeführt";
                case TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt:
                    return "Wird ausgeführt";
                case TaskErstellenBearbeiten.StatusTyp.Beendet:
                    return "Beendet";
            }

            return string.Empty;
        }

        #region ContextMenu

        private void contextMenuStrip_LVTasks_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)sender;
            int selectedIndex = -1;

            contextMenuStrip.Items.Clear();

            if (listView_Tasks.SelectedItems.Count > 0)
            {
                selectedIndex = listView_Tasks.SelectedIndices[0];

                //Wenn ein Element im ListView ausgewählt wurde
                switch (listTasks[selectedIndex].StatusText)
                {
                    case TaskErstellenBearbeiten.StatusTyp.NochNichtAusgefuehrt:
                    case TaskErstellenBearbeiten.StatusTyp.Beendet:
                        AddContextMenuItem(contextMenuStrip, "TaskStart", "Task starten", toolStripMenuItem_TaskStart_Click);
                        break;
                    case TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt:
                        AddContextMenuItem(contextMenuStrip, "TaskKill", "Task beenden", toolStripMenuItem_TaskKill_Click);
                        break;
                }
                AddContextSeparator(contextMenuStrip);
                AddContextMenuItem(contextMenuStrip, "TaskBearbeiten", "Task bearbeiten", toolStripMenuItem_TaskBearbeiten_Click);
                AddContextMenuItem(contextMenuStrip, "TaskLoeschen", "Task löschen", toolStripMenuItem_TaskLoeschen_Click);

                //contextMenuStrip.Items.Find("TaskBearbeiten", true)[0].Enabled = false; //listTasks[selectedIndex].StatusText == TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt;
                //contextMenuStrip.Items.Find("TaskLoeschen", true)[0].Enabled = listTasks[selectedIndex].StatusText == TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt;
            }

            if (contextMenuStrip.Items.Count == 0)
            {
                AddContextMenuItem(contextMenuStrip, "TaskErstellen", "Neuen Task erstellen", toolStripMenuItem_NeuenTask_Click);
            }

            e.Cancel = false;
        }

        void AddContextMenuItem(ContextMenuStrip contextMenuStrip, string name, string text, EventHandler clickEventHandler)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = string.Concat("toolStripMenuItem_", name, "_Click");
            toolStripMenuItem.Text = text;
            toolStripMenuItem.Click += clickEventHandler;
            contextMenuStrip.Items.Add(toolStripMenuItem);
        }

        void AddContextSeparator(ContextMenuStrip contextMenuStrip)
        {
            ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
            toolStripSeparator.Name = "toolStripSeparator";
            contextMenuStrip.Items.Add(toolStripSeparator);
        }

        private void toolStripMenuItem_NeuenTask_Click(object sender, EventArgs e)
        {
            Form_TaskErstellenBearbeiten form = new Form_TaskErstellenBearbeiten();
            TaskErstellenBearbeiten task;
            DialogResult dialog = form.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                task = form.Task;
                ListViewItem lvItem = CreateNewListViewItem(task);
                listView_Tasks.Items.Add(lvItem);
                UpdateListViewColumnWidth();

                this.listLVItems.Add(new KeyValuePair<int, ListViewItem>(task.ID, lvItem));
                this.listTasks.Add(task);
            }
        }

        void toolStripMenuItem_TaskStart_Click(object sender, EventArgs e)
        {
            int selectedIndex = listView_Tasks.SelectedIndices[0];
            Run(listTasks[selectedIndex]);
        }

        void toolStripMenuItem_TaskKill_Click(object sender, EventArgs e)
        {
            int selectedIndex = listView_Tasks.SelectedIndices[0];
            Kill(listLVItems[selectedIndex].Key);
        }

        private void toolStripMenuItem_TaskBearbeiten_Click(object sender, EventArgs e)
        {
            int index = listView_Tasks.SelectedIndices[0]; //Angeklickte Item
            TaskErstellenBearbeiten task = this.listTasks[index];
            Form_TaskErstellenBearbeiten form = new Form_TaskErstellenBearbeiten(task);
            DialogResult dialog = form.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                task = form.Task;
                ListViewItem listViewItem = CreateNewListViewItem(task);
                this.listTasks[index] = task;
                this.listLVItems[index] = new KeyValuePair<int, ListViewItem>(index, listViewItem);
                this.listView_Tasks.Items[index] = listViewItem;
            }
        }

        void toolStripMenuItem_TaskLoeschen_Click(object sender, EventArgs e)
        {
            int index = listView_Tasks.SelectedIndices[0]; //Angeklickte Item
            int taskID = listTasks[index].ID;
            KeyValuePair<int, ProcessWorker> item = this.listProcess.Find(x => x.Key == taskID);
            if (!item.Value.Running)
            {
                listLVItems.RemoveAt(index); //.Remove(listLVItems.Find(x => x.Key == taskID));
                listView_Tasks.Items[index].Remove();
                listTasks.Remove(listTasks.Find(x => x.ID == taskID));
            }
            else
            {
                MessageBox.Show("Der laufende Task kann nicht gelöscht werden.\nWarten Sie bis dieser abgeschlossen ist oder beenden Sie den Task manuell", "Task löschen nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion //ContextMenu

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                //Tasks
                case 0:
                    timer_CPUMemory.Stop();
                    break;
                //Drucker
                case 1:
                    timer_CPUMemory.Stop();
                    FillLVPrinter();
                    break;
                case 2:
                    //Systeminformationen
                    label_MainboardVendor.Text = SystemInformation.MainboardVendor;
                    label_MainboardModel.Text = SystemInformation.MainboardModel;
                    label_OSName.Text = string.Format("{0} {1} ({2})", SystemInformation.OSName, SystemInformation.OSVersion, SystemInformation.OSArchitecture);
                    timer_CPUMemory.Start();
                    break;
            }
        }

        void FillLVPrinter()
        {
            listView_Printer.Items.Clear();
            listView_Printer.LargeImageList = imageList_Printer;

            ListViewItem printerItem;

            //TKey: Druckername, TValue: Standarddrucker ?
            foreach (KeyValuePair<string, bool> item in Printer.ListPrinter)
            {
                printerItem = new ListViewItem();
                printerItem.Text = item.Key;
                printerItem.ImageIndex = (!item.Value) ? 1 : 0;

                listView_Printer.Items.Add(printerItem);
            }
        }

        private void timer_CPUMemory_Tick(object sender, EventArgs e)
        {
            int cpuUsage = SystemInformation.GetCPUUsage();
            int freeMem = SystemInformation.GetFreeMemory();
            int availMemTot = SystemInformation.MemoryTotal;
            int usedMemory = availMemTot - freeMem;

            label_CPUUsage.Text = string.Format("{0} %", cpuUsage.ToString());
            label_MemoryUsage.Text = string.Format("{0} MB/{1} MB ({2} %) in Verwendung", usedMemory, availMemTot, (usedMemory * 100 / availMemTot));
            label_MemoryAvailable.Text = string.Format("{0} MB/{1} MB ({2} %) Freier Speicher", freeMem, availMemTot, (freeMem * 100 / availMemTot));

            progressBar_CPU.Value = cpuUsage;
        }
    }
}
