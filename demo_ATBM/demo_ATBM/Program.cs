﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_ATBM
{
    
    public static class Account
    {
        public static string username;
        public static string password;
        public static string connectString;
        public static string host = "192.168.1.8";
        public static int port = 1521;
        public static string sid = "hospital";
        
    }
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
            Application.Run(new Admin());
        }
    }
}
