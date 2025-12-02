using System;
using System.Windows.Forms;
using ThemeManagerDemo;

namespace ThemeManagerDemo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Create and show the sample form
            Application.Run(new SampleForm());
        }
    }
}