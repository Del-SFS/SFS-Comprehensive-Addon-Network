using System;
using System.Windows.Forms;

namespace SCAN
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            // Executa a MainForm (UI)
            Application.Run(new UI.MainForm());
        }
    }
}