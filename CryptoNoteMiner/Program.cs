using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VFCNMiner
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
            FRMINICIOSUPERIORCOIN sp = new FRMINICIOSUPERIORCOIN();
            if (sp.ShowDialog()== DialogResult.OK )
            {
                Application.Run(new Main());
            }

            

        }
    }
}
