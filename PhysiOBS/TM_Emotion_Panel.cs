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

namespace PhysiOBS_Kernel
{
    public class TM_Emotion_Panel
    {
        public TEmotion emotion;
        public Object panel;

        public TM_Emotion_Panel()
        {
            emotion = null;
            panel = null;
        }


        public TM_Emotion_Panel (TM_Emotion_Panel ob)
        {
            emotion = ob.emotion;
            panel = ob.panel;
        }
    }

    public class TM_Emotion_Panel_List : List<TM_Emotion_Panel>
    {
        public TSignal signal;
        public TM_Emotion_Panel_List()
        {
        }

        public TM_Emotion_Panel_List(TSignal s)
        {
            signal = s;
        }

        public void clear_objects()
        {
            foreach (TM_Emotion_Panel tp in this)
            {
                tp.emotion = null;
                ((Panel)tp.panel).Dispose();
            }
            this.Clear();           
        }

        public void Delete_Panel(String TM, int panel)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this[i].emotion.name == TM && i == panel)
                {
                    this.RemoveAt(i);
                }
            }
        }

        
    }

}
