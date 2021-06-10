using System;
using System.Security.Cryptography;
using System.Text;
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
        public static string password = new System.IO.StreamReader(Application.StartupPath + "\\credentials.txt").ReadLine();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            if (ok == true) 
            Application.Run(new displayBooks());
        }
        static public string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        static public string hash(string input)
        {
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(input);
            byte[] hashed = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            return ByteArrayToString(hashed);
        }
    }
}