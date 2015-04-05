using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization; 

namespace PhysiOBS_Kernel
{
    public class TManager
    {

        public TProject PhysioProject;

        public TManager()
        {        
            PhysioProject = new TProject();
        }

        public int SignalAI_ID
        {
            get
            {
                return getSignalList().AI_ID;
            }
            set
            {
                getSignalList().AI_ID = value;
            }
        }

        public String filename()
        {
            return PhysioProject.filename;
        }       
        public TSignalList getSignalList()
        {
            return PhysioProject.signalList;
        }
        public TTaskList getTaskList()
        {
            return PhysioProject.taskList;
        }
        public TAssignmentList getAssignmentList()
        {
            return PhysioProject.assignmentList;
        }     
        public TCriticalPointsList getCriticalList()
        {
            return PhysioProject.criticalList;
        }

        public TEmotionList getEmotionList(string ID)
        {
            return PhysioProject.signalList.GetSignalByID(ID).SignalEmotionList;
        }

        public int saveProject(String Path)
        {
            try
            {
                PhysioProject.filename = Path;
                XmlWriter writer = XmlWriter.Create(Path);
                writer.WriteStartDocument();
                writer.WriteStartElement("PhysiOBS_Project");

                    writer.WriteStartElement("Version");
                    writer.WriteString(PhysioProject.Version);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Date");
                    writer.WriteString(PhysioProject.Date);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Title");
                        writer.WriteString(PhysioProject.title);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Signals");
                    foreach (TSignal s in PhysioProject.signalList)
                    {
                        writer.WriteStartElement("Signal");
                            writer.WriteStartElement("ID");
                            writer.WriteString(s.ID);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Filename");
                            writer.WriteString(s.filename);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Title");
                            writer.WriteString(s.title);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Type");
                            writer.WriteString(s.type);
                            writer.WriteEndElement();
                            writer.WriteStartElement("SignalType");
                            writer.WriteString(s.signaltype);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Duration");
                            writer.WriteString(s.duration.ToString());
                            writer.WriteEndElement();
                            writer.WriteStartElement("Format");
                            writer.WriteString(s.format);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Delay");
                            writer.WriteString(s.delay.ToString());
                            writer.WriteEndElement();
                            writer.WriteStartElement("Output");
                            writer.WriteString(s.output);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Sampling");
                            writer.WriteString(s.sampling);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Emotions");//<Emotions>
                            if (s.SignalEmotionList.Count() > 0)//Save's emotions for each Signal
                                {
                                    foreach (TEmotion e in s.SignalEmotionList)
                                    {
                                        writer.WriteStartElement("Emotion");//<Emotion>
                                           writer.WriteStartElement("ID");
                                           writer.WriteString(e.ID);
                                           writer.WriteEndElement();
                                           writer.WriteStartElement("Name");
                                           writer.WriteString(e.name);
                                           writer.WriteEndElement();
                                           writer.WriteStartElement("Start");
                                           writer.WriteString(e.start.ToString());
                                           writer.WriteEndElement();
                                           writer.WriteStartElement("Stop");
                                           writer.WriteString(e.stop.ToString());
                                           writer.WriteEndElement();
                                           writer.WriteStartElement("Comments");
                                           writer.WriteString(e.comments);
                                           writer.WriteEndElement();
                                        writer.WriteEndElement();//</Emotion>
                                    }
                                }
                            writer.WriteEndElement();//</Emotions>

                            writer.WriteEndElement();//Signal                      
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("Tasks");
                    foreach (TTask t in PhysioProject.taskList)
                    {
                        writer.WriteStartElement("Task");
                            writer.WriteStartElement("ID");
                            writer.WriteString(t.ID);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Name");
                            writer.WriteString(t.name);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Start");
                            writer.WriteString(t.start.ToString());
                            writer.WriteEndElement();
                            writer.WriteStartElement("Stop");
                            writer.WriteString(t.stop.ToString());
                            writer.WriteEndElement();
                            writer.WriteStartElement("Succeed");
                            writer.WriteString((t.succeed?"1":"0"));
                            writer.WriteEndElement();
                            writer.WriteStartElement("Comments");
                            writer.WriteString(t.comments);
                            writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                   
                writer.WriteStartElement("Assignments");
                    foreach (TAssignment a in PhysioProject.assignmentList)
                    {
                        writer.WriteStartElement("Assignment");
                        writer.WriteStartElement("AlgName");
                        writer.WriteString(a.algname);
                        writer.WriteEndElement();
                        writer.WriteStartElement("SignalName");
                        writer.WriteString(a.signalname);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Order");
                        writer.WriteString(a.order.ToString());
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();                   
                
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }


        public int loadProject(String Path)
        {
            try
            {
                PhysioProject.Clear();
                XmlTextReader m_xmlr = new XmlTextReader(Path);
                m_xmlr.WhitespaceHandling = WhitespaceHandling.None;
                m_xmlr.Read();
                while (!m_xmlr.EOF)
                {
                    switch (m_xmlr.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (m_xmlr.Name == "PhysiOBS_Project")
                            {
                                m_xmlr.Read();
                                continue;
                            }
                            if (m_xmlr.Name == "Version")
                            {
                                PhysioProject.Version = m_xmlr.ReadElementContentAsString();
                                continue;
                            }
                             if (m_xmlr.Name == "Date")
                            {
                                PhysioProject.Date = m_xmlr.ReadElementContentAsString();
                                continue;
                            }
                           if (m_xmlr.Name == "Title")
                            {
                                PhysioProject.title = m_xmlr.ReadElementContentAsString();
                                continue;
                            }
                            if (m_xmlr.Name == "Signals")
                            {
                               m_xmlr.Read();
                               continue;
                            }
                            if (m_xmlr.Name == "Signal")
                            {
                                #region Signal
                                bool EndOfSignal = false;
                                TSignal el = new TSignal();
                                while (!EndOfSignal)
                                {
                                    if (m_xmlr.Name == "ID")
                                    {
                                        el.ID = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Filename")
                                    {
                                        el.filename = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Title")
                                    {
                                        el.title = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Type")
                                    {
                                        el.type = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "SignalType")
                                    {
                                        el.signaltype = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Duration")
                                    {
                                        el.duration = Double.Parse(m_xmlr.ReadElementContentAsString());
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Format")
                                    {
                                        el.format = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }

                                    if (m_xmlr.Name == "Delay")
                                    {
                                        el.delay = Double.Parse(m_xmlr.ReadElementContentAsString());
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Output")
                                    {
                                        el.output = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Sampling")
                                    {
                                        el.sampling = m_xmlr.ReadElementContentAsString();                                        
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Emotions")
                                    {
                                        m_xmlr.Read();
                                        #region Emotions
                                        bool EndOfEmotions = false;
                                        while (!EndOfEmotions)
                                        {
                                            if (m_xmlr.Name == "Emotion")
                                            {
                                                m_xmlr.Read();
                                                #region EmotionFields
                                                bool EndOfEmotionFields = false;
                                                TEmotion em = new TEmotion();
                                                while (!EndOfEmotionFields)
                                                {
                                                    if (m_xmlr.Name == "ID")
                                                    {
                                                        em.ID = m_xmlr.ReadElementContentAsString();
                                                        continue;
                                                    }
                                                    if (m_xmlr.Name == "Name")
                                                    {
                                                        em.name = m_xmlr.ReadElementContentAsString();
                                                        continue;
                                                    }
                                                    if (m_xmlr.Name == "Start")
                                                    {
                                                        em.start = Double.Parse(m_xmlr.ReadElementContentAsString());
                                                        continue;
                                                    }
                                                    if (m_xmlr.Name == "Stop")
                                                    {
                                                        em.stop = Double.Parse(m_xmlr.ReadElementContentAsString());
                                                        continue;
                                                    }
                                                    if (m_xmlr.Name == "Comments")
                                                    {
                                                        em.comments = m_xmlr.ReadElementContentAsString();
                                                        EndOfEmotionFields = true;
                                                        continue;
                                                    }
                                                }
                                                #endregion
                                                el.SignalEmotionList.Add(em);
                                            }
                                            else
                                            EndOfEmotions = true;
                                            m_xmlr.Read();
                                        }
                                        #endregion
                                        EndOfSignal = true;
                                        continue;
                                    }
                                    m_xmlr.Read();
                                }
                                PhysioProject.addSignal(el);
                                #endregion
                            }

                            if (m_xmlr.Name == "Tasks")
                            {
                               m_xmlr.Read();
                               continue;
                            }
                            if (m_xmlr.Name == "Task")
                            {
                                bool EndOfElement = false;
                                TTask el = new TTask();
                                while (!EndOfElement)
                                {
                                    if (m_xmlr.Name == "ID")
                                    {
                                        el.ID = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Name")
                                    {
                                        el.name = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Start")
                                    {
                                        CultureInfo provider = new CultureInfo("el-GR");
                                        el.start = Double.Parse(m_xmlr.ReadElementContentAsString());
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Stop")
                                    {
                                        CultureInfo provider = new CultureInfo("el-GR");
                                        el.stop = Double.Parse(m_xmlr.ReadElementContentAsString());
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Succeed")
                                    {
                                        el.succeed = (m_xmlr.ReadElementContentAsString() == "1");
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Comments")
                                    {
                                        el.comments = m_xmlr.ReadElementContentAsString();
                                        EndOfElement = true;
                                        continue;
                                    }
                                    m_xmlr.Read();
                                }
                                PhysioProject.taskList.Add(el);
                            }

                            
                            if (m_xmlr.Name == "Assignments")
                            {
                               m_xmlr.Read();
                               continue;
                            }
                            if (m_xmlr.Name == "Assignment")
                            {
                                bool EndOfElement = false;
                                TAssignment el = new TAssignment();
                                while (!EndOfElement)
                                {
                                    if (m_xmlr.Name == "AlgName")
                                    {
                                        el.algname = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "SignalName")
                                    {
                                        el.signalname = m_xmlr.ReadElementContentAsString();
                                        continue;
                                    }
                                    if (m_xmlr.Name == "Order")
                                    {
                                        el.order = Int32.Parse(m_xmlr.ReadElementContentAsString());
                                        EndOfElement = true;
                                        continue;
                                    }
                                    m_xmlr.Read();
                                }
                                PhysioProject.assignmentList.Add(el);
                            }
                            break;
                        default: m_xmlr.Read(); break;
                    }
                }
                m_xmlr.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public TSignal addSignal(String fname, String title, String type, String stype, Double dur,String frm, Double del, String Out, String sample)
        {
            TSignal s = new TSignal();
            s.filename=fname;
            s.title=title;
            s.type=type;
            s.signaltype = stype;
            s.duration=dur;
            s.format=frm;
            s.delay=0;
            s.output = Out;
            s.sampling = sample;      
            PhysioProject.addSignal(s);
            return s;
        }
        public TSignal addVideo(String fname, String type, String frm, Double dur)
        {
            TSignal s = new TSignal();
            s.filename = fname;
            s.type = type;
            s.format = frm;
            s.duration = dur;
            PhysioProject.addSignal(s);
            return s;
        }        
        public void removeSignal(TSignal R1)
        {
            getCriticalList().clear_points("emotion_" + R1.ID);
            PhysioProject.removeSignal(R1);
         }

    }
}
