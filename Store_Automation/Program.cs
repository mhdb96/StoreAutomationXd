using StoreAutomationUI;
using System;
using System.Windows.Forms;

namespace Store_Automation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginForm());
            //Application.Run(new admin());
            //Application.Run(new data_entry());
        }
    }
}
