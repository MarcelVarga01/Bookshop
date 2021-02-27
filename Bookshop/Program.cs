using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bookshop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool admin = false;
        public static bool ok = false;
        public static string password = "password";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (ok == true) Application.Run(new Form2());
        }
    }
}
