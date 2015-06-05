using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows.Forms;
using System.IO;
using PhysiOBS_Kernel;
using WMPLib;
using System.Windows.Forms.DataVisualization.Charting;


namespace PhysiOBS
{
    public class TM_Task_Panel
    {
        public TTask task;
        public Object panel;

        public TM_Task_Panel()
        {
            task = null;
            panel=null;
        }


        public TM_Task_Panel (TM_Task_Panel ob)
        {
            task = ob.task;
            panel = ob.panel;
        }

    }
    
    public class TM_Task_Panel_List : List<TM_Task_Panel>
    {
        public TM_Task_Panel_List()
        {
            
        }
        public void clear_objects() 
        {
            foreach (TM_Task_Panel tp in this)
            {
                tp.task = null;
                ((Panel)tp.panel).Dispose();       
            }
            this.Clear();
        }
    }

}
