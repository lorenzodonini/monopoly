using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Text;

namespace Monopoli
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
            //StringBuilder sb = new StringBuilder();
            /*foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                sb.Append(t.Name + " - " + t.FullName);
                sb.Append("\n");
            }
            MessageBox.Show(sb.ToString());*/
            Application.Run(new MainView());
        }
    }
}
