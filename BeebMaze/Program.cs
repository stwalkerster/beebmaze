using System;
using System.Windows.Forms;

namespace BeebMaze
{
    internal static class Program
    {
        public static MainForm app;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            app = new MainForm();
            Application.Run(app);
        }
    }
}