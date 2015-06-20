using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhysiOBS_Kernel;

namespace PhysiOBS
{
    static class Program
    {


        //public static TSignal Signal1 = new TSignal();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Main()); 
        }
    }
}
