using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SystemAdministrationCenter
{
    public class TaskErstellenBearbeiten
    {
        public enum Condition
        {
            Systemstart,
            Uhrzeit
        }

        public enum StatusTyp
        {
            NochNichtAusgefuehrt,
            WirdAusgefuehrt,
            Beendet
        }

        public int ID { get; set; } = GenerateID();
        public string TaskName { get; set; }
        public Condition TaskCondition { get; set; }
        public DateTime TaskConditionTime { get; set; }
        public List<KeyValuePair<string, string>> TaskExecution { get; set; }
        public StatusTyp StatusText { get; set; }
        public bool NoWindow { get; set; }
        public ProcessWindowStyle WindowStyle { get; set; }
        public bool RunOnce { get; set; }

        public static int GenerateID()
        {
            DateTime now = DateTime.Now;
            return ((now.Hour * 3600) + (now.Minute * 60) + now.Second + now.Millisecond + now.Day + now.Month + now.Year);
        }
    }
}
