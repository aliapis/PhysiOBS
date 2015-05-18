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
        public int panelWidth;
        public int m_ana_px;

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
        }

        public void Clear()
        {
            title = "";
            Version = "";
            Date = "";
            signalList.Clear();
            taskList.Clear();
            assignmentList.Clear();
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
            s.SignalEmotionList.Clear();
            signalList.Remove(s);
        }
      
    }
}
