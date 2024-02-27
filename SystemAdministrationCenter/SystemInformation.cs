using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace SystemAdministrationCenter
{
    [Serializable]
    public static class SystemInformation
    {
        public static string UserName { get; private set; }
        public static string ComputerName { get; private set; }
        public static string IPAddress { get; private set; }

        public static string MainboardVendor { get; private set; }
        public static string MainboardModel { get; private set; }

        public static int MemoryTotal { get; private set; }

        public static string OSName { get; private set; }
        public static string OSVersion { get; private set; }
        public static string OSArchitecture { get; private set; }

        public static string CPUName { get; private set; }
        public static string CPUCores { get; private set; }
        public static string CPULogicalProcessors { get; private set; }

        public static bool Completed { get; private set; } = false;

        static readonly PerformanceCounter cpu_PerformanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        static readonly PerformanceCounter memory_PerformanceCounter = new PerformanceCounter("Memory", "Available MBytes");

        public static void Run()
        {
            if (!Completed)
            {
                using (BackgroundWorker backgroundWorker = new BackgroundWorker())
                {
                    backgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
                    backgroundWorker.RunWorkerAsync();
                }
            }
        }

        static void DoWork(object sender, DoWorkEventArgs e)
        {
            UserName = Environment.UserName;
            ComputerName = Environment.MachineName;
            //IPAddress
            MainboardVendor = GetWMIInformation("Win32_ComputerSystem", "Manufacturer");
            MainboardModel = GetWMIInformation("Win32_ComputerSystem", "Model");
            MemoryTotal = (int)(long.Parse(GetWMIInformation("Win32_ComputerSystem", "TotalPhysicalMemory")) / (long)Math.Pow(1024, 2));
            OSName = GetWMIInformation("Win32_OperatingSystem", "Caption");
            OSVersion = GetWMIInformation("Win32_OperatingSystem", "Version");
            OSArchitecture = GetWMIInformation("Win32_OperatingSystem", "OSArchitecture");
            CPUName = GetWMIInformation("Win32_Processor", "Name");
            CPUCores = GetWMIInformation("Win32_Processor", "NumberOfCores");
            CPULogicalProcessors = GetWMIInformation("Win32_Processor", "NumberOfLogicalProcessors");

            Completed = true;
        }

        static string GetWMIInformation(string className, string propertyName)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", $"SELECT * FROM {className}");

                foreach (ManagementObject queryObj in searcher.Get().Cast<ManagementObject>())
                {
                    return queryObj[propertyName].ToString();
                }
            }
            catch (ManagementException e)
            {
                return "WMI-ERROR: " + e.Message;
            }

            return null;
        }

        public static int GetCPUUsage()
        {
            return (int)cpu_PerformanceCounter.NextValue();
        }

        public static int GetFreeMemory()
        {
            return (int)memory_PerformanceCounter.NextValue();
        }
    }
}

/*

 Win32_ComputerSystem:
 - Manufacturer //Motherboard-Hersteller
 - Model //Motherboard-Modell

Win32_OperatingSystem:
 - Caption //OS-Name
 - Version //OS-Version (10.0.19045)
 - OSArchitecture //Architektur
 - 

Win32_Processor:
 - Name
 - NumberOfCores
 - NumberOfLogicalProcessors

Win32_DiskDrive:
 - Caption //Festplatten-Name
 - Index //Festplatten-Nummer
 - Partitions //Enthaltene Partitionen
 - Size //Größe in kB

Win32_DiskPartition:
 - DiskIndex //Festplatten-Nummer
 - 

 */