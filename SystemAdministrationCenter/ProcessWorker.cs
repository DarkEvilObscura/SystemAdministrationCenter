using System;
using System.ComponentModel;
using System.Diagnostics;

namespace SystemAdministrationCenter
{
    public class ProcessWorker
    {
        BackgroundWorker _backgroundWorker = new BackgroundWorker();
        Process _process = new Process();
                
        object _task;
        public object CurrentObject
        {
            get { return _task; }
            private set { _task = value; }
        }

        public bool Running { get; private set; } = false;
        //public bool Exited { get; private set; } = false;

        public ProcessWorker(TaskErstellenBearbeiten task)
        {
            this.CurrentObject = task;
        }

        public void StartWorker()
        {
            this.Running = !this.Running;
            //Exited = false;
            this._backgroundWorker.DoWork += BackgroundWorker_DoWork;
            this._backgroundWorker.RunWorkerAsync(_task);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TaskErstellenBearbeiten task = (TaskErstellenBearbeiten)e.Argument;
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = task.TaskExecution[0].Value,
                Arguments = task.TaskExecution[1].Value,
                CreateNoWindow = task.NoWindow,
                WindowStyle = task.WindowStyle
            };

            this._process.StartInfo = processStartInfo;
            this._process.EnableRaisingEvents = true;
            this._process.Exited += Process_Exited;
            this._process.Start();
            this._process.WaitForExit();
        }

        public void KillProcess()
        {
            this._process.Kill();
            this._backgroundWorker.CancelAsync();
            this._backgroundWorker.Dispose();
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            this.Running = !this.Running;
        }
    }
}
