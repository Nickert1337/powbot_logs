using System;
using System.Windows.Forms;

namespace Powbot.Logs
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new MainFrm());
        }
    }
}