using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace CallCMD
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //if (PriorProcess() != null)
            //{
            //    MessageBox.Show("Your Programe is running already.");
            //    return;
            //}
            //Process curr = Process.GetCurrentProcess();
            //Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            //foreach (Process p in procs)
            //{
            //    if ((p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName))
            //    {
            //        MessageBox.Show("Program run already.");
            //        SetForegroundWindow(p.MainWindowHandle);
            //        Environment.Exit(0);
            //    }
            //}
            bool CreateNew;
            Mutex mutex = new Mutex(false, "SingleInstanceStart", out CreateNew);
            //返回为false,表示互斥已经定义
            if (!CreateNew)
            {
                MessageBox.Show("You can only start one instance of the application.");
                Application.Exit();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static Process PriorProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName))
                {
                    SetForegroundWindow(p.MainWindowHandle);
                    Environment.Exit(0);
                }
            }
            return null;
        }

    }
}
