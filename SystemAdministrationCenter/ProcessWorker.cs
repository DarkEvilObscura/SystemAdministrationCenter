using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SystemAdministrationCenter
{
    public class ProcessWorker
    {
        Thread _thread;
        BackgroundWorker _backgroundWorker = new BackgroundWorker();

        Process _process = new Process();
                
        //object _task;
        //public object CurrentObject
        //{
        //    get { return _task; }
        //    private set { _task = value; }
        //}

        TaskErstellenBearbeiten task;

        public bool ProcessResponding { get; private set; }
        public int ProcessCPUUsage { get; private set; }
        public long ProcessMemoryUsage { get; private set; }

        public int PID { get; private set; }

        public bool Running { get; private set; } = false;

        public ProcessWorker(TaskErstellenBearbeiten task)
        {
            this.task = task;
        }

        public void StartWorker()
        {
            if(!this.Running)
            {
                this._thread = new Thread(DoWork);
                this._thread.Start();

                this._backgroundWorker.DoWork += new DoWorkEventHandler(UpdateUsage);
                this._backgroundWorker.WorkerSupportsCancellation = true;
                this._backgroundWorker.RunWorkerAsync();
            }
        }

        private void DoWork()
        {
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

            this.Running = true;
            this.PID = this._process.Id;
            this._process.WaitForExit();
        }

        public void KillProcess()
        {
            this._process.Kill();
            this._thread.Join();

            this._backgroundWorker.CancelAsync();
            this._backgroundWorker.Dispose();
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            this.Running = false;
            this.PID = 0;
        }

        public void UpdateUsage(object sender, DoWorkEventArgs e)
        {
            while (this.Running)
            {
                Thread.Sleep(1000);
                try
                {
                    if(this.Running)
                    {
                        this.ProcessResponding = this._process.Responding;
                        this.ProcessMemoryUsage = this._process.WorkingSet64;
                        this.ProcessCPUUsage = (int)new PerformanceCounter("Process", "% Processor Time", this._process.ProcessName, true).NextValue();
                    }
                }
                catch (Exception ex)
                {
                    //Trace.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }
}
