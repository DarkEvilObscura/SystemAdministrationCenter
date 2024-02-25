using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace SystemAdministrationCenter
{
    public static class Printer
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);

        //TKey: Druckername, TValue: Standarddrucker ?
        static List<KeyValuePair<string, bool>> listPrinters;

        static Printer()
        {
            listPrinters = new List<KeyValuePair<string, bool>>();
            GetPrinters();
        }

        static void GetPrinters()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings = new PrinterSettings();
            foreach (string item in PrinterSettings.InstalledPrinters)
            {
                listPrinters.Add(new KeyValuePair<string, bool>(item, printDocument.PrinterSettings.IsDefaultPrinter));
            }
        }

        public static void SetPrinter(string printerName)
        {
            SetDefaultPrinter(printerName);
        }
    }
}
