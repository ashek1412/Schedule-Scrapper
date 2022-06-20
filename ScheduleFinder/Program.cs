using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ScheduleFinder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static Mutex mutex = new Mutex(false, "db58737d-20c4-489b-b18c-0a4e78a19184");
        static Form MainForm;
        [STAThread]
        static void Main()
        {
            try
            {
                if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else
                {
                    MessageBox.Show("only one instance at a time");
                }

            }

            catch (Exception ex1)
            {
                // Globals.WriteToFile(Extensions.ExceptionInfo(ex1));
                MessageBox.Show(ex1.Message);

            }
        }
    }
}
