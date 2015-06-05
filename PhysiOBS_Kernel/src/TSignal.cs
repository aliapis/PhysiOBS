using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysiOBS_Kernel
{
    

    public class TSignal
    {
        public string ID;
        public String filename;
        public String title;
        public String type;      // VIDEO_U, VIDEO_S, SIGNAL
        public int position___;
        public String signaltype;// KARDIO, GSR, RR, ....
        public String format;        
        public Double duration;
        public Double delay;
        public String output;
        public String sampling;
        public TEmotionList SignalEmotionList; 
        
        public TSignal()//constructor
        {
            ID = "";
            filename = "";
            title = "";
            type = "";
            signaltype = "";
            duration =0;
            format = "";
            delay = 0.0;
            output = "";
            sampling = "";
            SignalEmotionList = new TEmotionList();
        }
        public TSignal(TSignal s)
        {
            ID = s.ID;
            filename = s.filename;
            title = s.title;
            type = s.type;
            signaltype = s.signaltype;
            duration= s.duration;
            format = s.format;
            delay = s.delay;
            output = s.output;
            sampling = s.sampling;
            SignalEmotionList = s.SignalEmotionList;             
        }
    }

    public class TSignalList : List<TSignal>
    {

        public int AI_ID = 0;

        public TSignal GetSignalByID(string ID)
        {
            foreach (TSignal s in this)
            {
                if (s.ID == ID)
                    return s;
            }
            return null;
        }

        public TSignal GetSignalByType(String type)
        {
            foreach (TSignal s in this)
            {
                if (s.type == type)
                    return s;
            }
            return null;
        }

        public int GetSignalCountByType(String type)
        {
            int i = 0;
            foreach (TSignal s in this)
            {
                if (s.type == type)
                    i++;
            }
            return i;
        }

    }

}
