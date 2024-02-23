using System;

namespace SystemAdministrationCenter
{
    [Serializable]
    public class SystemInformation
    {
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public int IPAddress { get; set; }
    }
}