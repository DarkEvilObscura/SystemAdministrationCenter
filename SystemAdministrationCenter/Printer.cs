using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace SystemAdministrationCenter
{
    public static class Printer
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);

        //[DllImport("shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //private static extern int ExtractIconEx(string file, int nIconIndex, out IntPtr phiconLarge, out IntPtr phiconSmall, int nIcons);

        //public static int NumberOfIcons { get; private set; }

        //TKey: Druckername, TValue: Standarddrucker ?
        public static List<KeyValuePair<string, bool>> ListPrinter { get; private set; }

        static Printer()
        {
            ListPrinter = new List<KeyValuePair<string, bool>>();
            GetPrinters();
        }

        static void GetPrinters()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings = new PrinterSettings();
            foreach (string item in PrinterSettings.InstalledPrinters)
            {
                printDocument.PrinterSettings.PrinterName = item;
                ListPrinter.Add(new KeyValuePair<string, bool>(item, printDocument.PrinterSettings.IsDefaultPrinter));
            }
        }

        public static void SetPrinter(string printerName)
        {
            SetDefaultPrinter(printerName);
        }

        //public static Icon GetPrinterIcon(int id, bool defaultPrinter)
        //{
        //    IntPtr largeIcon;

        //    //81: std-printer, 16: normal printer
        //    //NumberOfIcons = ExtractIconEx("imageres.dll", defaultPrinter ? 81 : 16, out largeIcon, out _, 1);
        //    NumberOfIcons = ExtractIconEx("shell32.dll", 32, out largeIcon, out _, 1);
        //    return Icon.FromHandle(largeIcon);
        //}
    }
}
