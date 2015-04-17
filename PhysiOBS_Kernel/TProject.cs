using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysiOBS_Kernel
{
    public class TProject
    {
        public String Version = "0.0.1";
        public String Date = "Jan, 2013";
        public String filename;
        public String title;


        public int m_ana_px;
        public int SignalAI_ID
        {
            get
            {
                return signalList.AI_ID;
            }
            set
            {
                signalList.AI_ID = value;
            }
        }
        
        private int _panelwidth;
        public int panelWidth
        {
            get
            {
                return _panelwidth;
            }
            set
            {
                _panelwidth = value;
                m_ana_px = (int)_duration / (int)value;
            }
        }

        private Double _duration;
        public Double duration
        {
            get
            {
                return _duration;
            }
            set
            {
                m_ana_px = (int)value / panelWidth;
                _duration = value;
            }
        }

        public TSignalList signalList;
        public TTaskList taskList;
        public TAssignmentList assignmentList;
        public TCriticalPointsList criticalList;

        public TProject()
        {
            title = "";
            filename = "";
            signalList = new TSignalList();
            taskList = new TTaskList();
            assignmentList = new TAssignmentList();
            criticalList = new TCriticalPointsList();
            _duration = 0;
            _panelwidth = 0;
            m_ana_px = 0;
        }

        public void Clear()
        {
            title = "";
            filename = "";
            Version = "";
            Date = "";
            signalList.Clear();
            taskList.Clear();
            assignmentList.Clear();
            _duration = 0;
            _panelwidth = 0;
            m_ana_px = 0;
        }

        public void addSignal(TSignal s)
        {
            if (s.type == "VIDEO_U")
            {
                TSignal P = signalList.GetSignalByType("VIDEO_U");
                if (P != null) signalList.Remove(P);
            }
            else if (s.type == "VIDEO_S")
            {
                TSignal P = signalList.GetSignalByType("VIDEO_S");
                if (P != null) signalList.Remove(P);
            }
            signalList.Add(s);
        }
        public void removeSignal(TSignal s)
        {
            criticalList.clear_points("emotion_" + s.ID);
            s.SignalEmotionList.Clear();
            signalList.Remove(s);
        }

        public TSignal addSignal(String fname, String title, String type, String stype, Double dur, String frm, Double del, String Out, String sample)
        {
            TSignal s = new TSignal();
            s.filename = fname;
            s.title = title;
            s.type = type;
            s.signaltype = stype;
            s.duration = dur;
            s.format = frm;
            s.delay = 0;
            s.output = Out;
            s.sampling = sample;
            addSignal(s);
            return s;
        }
        public TSignal addVideo(String fname, String type, String frm, Double dur)
        {
            TSignal s = new TSignal();
            s.filename = fname;
            s.type = type;
            s.format = frm;
            s.duration = dur;
            addSignal(s);
            return s;
        }

        public TEmotionList getEmotionListBySignalID(string ID)
        {
            return signalList.GetSignalByID(ID).SignalEmotionList;
        }

      
    }
}
