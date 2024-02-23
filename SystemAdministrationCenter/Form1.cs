﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        SystemInformation systemInformation = new SystemInformation();

        List<KeyValuePair<int, ListViewItem>> listLVItems = new List<KeyValuePair<int, ListViewItem>>();
        List<TaskErstellenBearbeiten> listTasks = new List<TaskErstellenBearbeiten>();
        List<KeyValuePair<int, ProcessWorker>> listProcess = new List<KeyValuePair<int, ProcessWorker>>();

        const int LV_LONGEST_ITEM = -1;
        const int LV_WIDTH_AUTOSIZE = -2;

        const int LV_COLUMN_STATUS = 3;

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
            this.systemInformation.ComputerName = Environment.MachineName;
            this.systemInformation.UserName = Environment.UserName;
            
            int width = (listView_Tasks.Width / 4) - 1;
            columnHeader_Name.Width = width;
            columnHeader_Condition.Width = width;
            columnHeader_Execution.Width = width;
            columnHeader_Status.Width = width;

            //SendMessage(this.toolStripComboBox_Action.Control.Handle, CB_SETCUEBANNER, 0, "Task-Aktion");
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

        private void toolStripMenuItem_TaskBearbeiten_Click(object sender, EventArgs e)
        {
            int index = listView_Tasks.SelectedIndices[0]; //Angeklickte Item
            TaskErstellenBearbeiten task = this.listTasks[index];
            Form_TaskErstellenBearbeiten form = new Form_TaskErstellenBearbeiten(task);
            DialogResult dialog = form.ShowDialog();
            if(dialog == DialogResult.OK)
            {
                task = form.Task;
                ListViewItem listViewItem = CreateNewListViewItem(task);
                this.listTasks[index] = task;
                this.listLVItems[index] = new KeyValuePair<int, ListViewItem>(index, listViewItem);
                listView_Tasks.Items[index] = listViewItem;
            }
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

        void CheckToRun()
        {
            if (listTasks.Count > 0)
            {
                foreach (TaskErstellenBearbeiten item in listTasks)
                {
                    if (item.TaskCondition == TaskErstellenBearbeiten.Condition.Uhrzeit &&
                       item.TaskConditionTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() &&
                       item.StatusText == TaskErstellenBearbeiten.StatusTyp.NochNichtAusgefuehrt)
                    {
                        ProcessWorker processWorker = new ProcessWorker(item);
                        processWorker.StartWorker();
                        this.listProcess.Add(new KeyValuePair<int, ProcessWorker>(item.ID, processWorker));
                        UpdateListViewItemStatus(listLVItems.FindIndex(x => x.Key == item.ID), TaskErstellenBearbeiten.StatusTyp.WirdAusgefuehrt);
                    }
                }

                CheckRunningProcess();
            }
        }

        void CheckRunningProcess()
        {
            TaskErstellenBearbeiten task;
            int index = 0;
            foreach (KeyValuePair<int, ProcessWorker> item in this.listProcess)
            {
                if (item.Value.Exited)
                {
                    task = (TaskErstellenBearbeiten)item.Value.CurrentObject;
                    index = listLVItems.FindIndex(x => x.Key == task.ID);
                    UpdateListViewItemStatus(index, TaskErstellenBearbeiten.StatusTyp.Beendet);
                }
            }
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

        private void contextMenuStrip_LVTasks_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)sender;
            int selectedIndex = -1;
            try
            {
                selectedIndex = listView_Tasks.SelectedIndices[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                bool enabled = (listView_Tasks.Items.Count > 0);
                toolStripMenuItem_TaskBearbeiten.Enabled = enabled;
                toolStripMenuItem_TaskLoeschen.Enabled = enabled;
            }

            //Wenn ein Element im ListView ausgewählt wurde
            if(selectedIndex > -1)
            {
                contextMenuStrip.Items.Clear();
                AddContextMenuItem(contextMenuStrip, "TaskStart", "Task starten", blub);
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = "toolStripMenuItem_Blub";
                toolStripMenuItem.Text = "Blub";
                toolStripMenuItem.Click += new EventHandler(blub);
                contextMenuStrip.Items.Add(toolStripMenuItem);
            }
        }

        void blub(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip_LVTasks_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)sender;
            RemoveContextMenuItem(contextMenuStrip, "toolStripMenuItem_Blub");
            //try
            //{
            //    contextMenuStrip.Items.Remove(contextMenuStrip.Items.Find("toolStripMenuItem_Blub", true)[0]);
            //}
            //catch (IndexOutOfRangeException) { }
        }

        void AddContextMenuItem(ContextMenuStrip contextMenuStrip, string name, string text, EventHandler clickEventHandler)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = string.Concat("toolStripMenuItem_", name);
            toolStripMenuItem.Text = text;
            toolStripMenuItem.Click += clickEventHandler;
            contextMenuStrip.Items.Add(toolStripMenuItem);
        }

        void RemoveContextMenuItem(ContextMenuStrip contextMenuStrip, string name)
        {
            name = string.Concat("toolStripMenuItem_", name);
            try
            {
                contextMenuStrip.Items.Remove(contextMenuStrip.Items.Find(name, true)[0]);
            }
            catch (IndexOutOfRangeException) { }
        }
    }
}