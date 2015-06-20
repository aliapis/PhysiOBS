using System;
using System.Collections;
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
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.PowerPacks;
using smoothing_testing;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;




namespace PhysiOBS
{
    public partial class Frm_Main : Form
    {
        public DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        public DispatcherTimer dispatcherTimer2 = new DispatcherTimer();
        public Boolean allSynchedDone = false;

        TManager Manager = new TManager();

        TSignal CurrentVideo_U;
        TSignal CurrentVideo_S;

        public bool drag;
        Point? prevPosition = null;

        ToolTip tooltp = new ToolTip();

        public int panel_x; //global for drugging panels
        public bool panel_resize;
        public bool panel_drag;

        Panel temp_emotion_panel = new Panel();
        Panel current_emotion_panel;
        int temp_emotion_start_x;
        bool emotion_mark = false;
        object contextMenuStripParent = null;
        private DateTime firstClick = DateTime.Now;

        //----smoothing variables----//
        public List<int> Counter_For_Smooth_list = new List<int>();
        public List<int> SID_Info = new List<int>();
        public List<double> error_list = new List<double>(); 
        public List<double[]> rawsignals = new List<double[]>();//θα κρατάει όλα τα rawsignals θα πάρει τιμή μέσα στην draw_graph
        public List<DataTable> alltables = new List<DataTable>();//θα κρατάει όλα τα datatables θα πάρει τιμή μέσα στην draw_graph
        Smooth smth_proc = new Smooth();
        public MWArray[] result = null;
        public MWNumericArray output = null;
        public float t;//sampling rate
        //----end of smoothing variables----//


        private Boolean IsVideoUloaded
        {
            get
            {
                if (CurrentVideo_U != null)
                    if (CurrentVideo_U.filename != "")
                        return true;
                return false;
            }
        }
        private Boolean IsVideoSloaded
        {  
            get
            {
                if (CurrentVideo_S != null)
                    if (CurrentVideo_S.filename != "")
                        return true;
                return false;
            }
        }

        public Frm_Main()
        {
            InitializeComponent();
            temp_emotion_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowEmotionSelectMenu);
        }

        
        private double PixelToTime(int x)
        {
            return (double)((x) * (double)(Manager.PhysioProject.m_ana_px));
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string chosen_file = "";
            openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Title = "Please inset the appropriate file";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            chosen_file = openFileDialog1.FileName;
        }

        #region VIDEO

        private void BT_Add_Video_S_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = "C:\\";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string S_filename = openFileDialog1.FileName;
            FileInfo finfo = new FileInfo(S_filename);
            MPlayer_ScreenVideo.URL = openFileDialog1.FileName;
            WindowsMediaPlayer wmp = new WindowsMediaPlayerClass();//Initiate's video duration
            IWMPMedia fdur = wmp.newMedia(S_filename);//Initiate's video duration
            CurrentVideo_S = Manager.PhysioProject.addVideo(S_filename, "VIDEO_S", finfo.Extension, fdur.duration);
            BT_video_S_Properties.Enabled = true;
            BT_Task_Frm.Enabled = true;
            //allplay.Enabled = true;
            String seconds = fdur.duration.ToString();
            MPlayer_ScreenVideo.Ctlcontrols.play();
        }
        private void BT_video_S_Properties_Click(object sender, EventArgs e)
        {
            Frm_VideoProperties Fprop = new Frm_VideoProperties();
            Fprop.S = CurrentVideo_S;
            Fprop.StartPosition = FormStartPosition.CenterScreen;
            Fprop.ShowDialog();
            Fprop.Close();
        }

        private void BT_Add_Video_U_Click_1(object sender, EventArgs e)
        {
            PL_TaskLine.Refresh();
            openFileDialog1.InitialDirectory = "C:\\";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                DrawTasks();
                return;
            }
            BT_PlayPause.Enabled = true;
            BT_Stop.Enabled = true;
            Bar.Enabled = true;
            tb_time.Enabled = true;
            Bar.SetBounds(PL_TaskLine.Location.X, Bar.Location.Y, Bar.Width, Bar.Height);
            Manager.PhysioProject.taskList.Clear();
            string U_filename = openFileDialog1.FileName;
            FileInfo finfo = new FileInfo(U_filename);
            WindowsMediaPlayer wmp = new WindowsMediaPlayerClass();//Initiate's video duration
            IWMPMedia fdur = wmp.newMedia(U_filename);//Initiate's video duration
            MPlayer_UserVideo.URL = openFileDialog1.FileName;
            CurrentVideo_U = Manager.PhysioProject.addVideo(U_filename, "VIDEO_U", finfo.Extension, fdur.duration * 1000);
            BT_video_U_properties.Enabled = true;
            BT_Task_Frm.Enabled = true;
            //allplay.Enabled = true;
            Manager.PhysioProject.panelWidth = PL_TaskLine.Width;
            Manager.PhysioProject.duration = fdur.duration * 1000;
            LB_Duration.Text = "Total: " + (Manager.PhysioProject.duration/1000).ToString();
            Timer_Project.Interval = Manager.PhysioProject.m_ana_px;
            MPlayer_UserVideo.Ctlcontrols.play();
        }
        private void BT_video_U_properties_Click(object sender, EventArgs e)
        {
            Frm_VideoProperties Fprop = new Frm_VideoProperties();
            Fprop.S = CurrentVideo_U;
            Fprop.StartPosition = FormStartPosition.CenterScreen;
            Fprop.ShowDialog();
            Fprop.Close();
        }

        void dispatcherTimer1_Tick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer).Stop();
            MPlayer_UserVideo.Ctlcontrols.play();
            if (CurrentVideo_U.delay >= CurrentVideo_S.delay) allSynchedDone = true;
        }

        void dispatcherTimer2_Tick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer).Stop();
            MPlayer_ScreenVideo.Ctlcontrols.play();
            if (CurrentVideo_U.delay <= CurrentVideo_S.delay) allSynchedDone = true;
        }

        private void BT_Pause_Click(object sender, EventArgs e)
        {
            if (BT_PlayPause.Text == " ")//one space for play
            {
                if (CurrentVideo_U != null || CurrentVideo_S != null)
                {
                    BT_Stop.Enabled = true;
                    Timer_Project.Enabled = true;
                    Timer_Project.Start();
                    if (CurrentVideo_U != null)
                    {
                        MPlayer_UserVideo.Ctlcontrols.play();
                    }
                    if (CurrentVideo_S != null)
                    {
                        MPlayer_ScreenVideo.Ctlcontrols.play();
                    }
                    Bitmap b2 = new Bitmap(Properties.Resources.pause);
                    BT_PlayPause.Image = b2;
                }
                else if ((CurrentVideo_S == null) && (CurrentVideo_U == null))
                {
                    MessageBox.Show("No Video Uploaded");
                    BT_PlayPause.Text = " ";//one space for play     
                }
                else
                    if (!allSynchedDone)
                    {
                        dispatcherTimer1.Tick += new EventHandler(dispatcherTimer1_Tick);
                        dispatcherTimer1.Interval = new TimeSpan(0, 0, (int)CurrentVideo_U.delay / 1000);
                        dispatcherTimer2.Tick += new EventHandler(dispatcherTimer2_Tick);
                        dispatcherTimer2.Interval = new TimeSpan(0, 0, (int)CurrentVideo_S.delay / 1000);
                        dispatcherTimer1.Start();
                        dispatcherTimer2.Start();
                    }
                    else
                    {
                        Timer_Project.Enabled = true;
                        Timer_Project.Start();
                        MPlayer_UserVideo.Ctlcontrols.play();
                        MPlayer_ScreenVideo.Ctlcontrols.play();
                    }
                BT_PlayPause.Text = "  ";//double space for pause
                if ((CurrentVideo_S == null) && (CurrentVideo_U == null))
                {
                    BT_PlayPause.Text = " ";//play
                }
            }
            else
            {
                MPlayer_UserVideo.Ctlcontrols.pause();
                MPlayer_ScreenVideo.Ctlcontrols.pause();
                Timer_Project.Stop();
                BT_PlayPause.Text = " ";
                Bitmap b2 = new Bitmap(Properties.Resources.play);
                BT_PlayPause.Image = b2;
            }
        }

        private void BT_Stop_Click(object sender, EventArgs e)
        {
            Timer_Project.Stop();
            MPlayer_UserVideo.Ctlcontrols.stop();
            MPlayer_ScreenVideo.Ctlcontrols.stop();
            Bar.SetBounds(PL_TaskLine.Location.X, Bar.Location.Y, Bar.Width, Bar.Height);
            Bitmap b2 = new Bitmap(Properties.Resources.play);
            BT_PlayPause.Image = b2;
        }

        private void MPlayer_UserVideo_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if (this.MPlayer_UserVideo.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (IsVideoUloaded)
                {
                    Application.DoEvents();
                    MPlayer_UserVideo.Ctlcontrols.pause();
                    MPlayer_ScreenVideo.Ctlcontrols.pause();
                    //videoUloaded = false;
                }
            }
        }

        private void MPlayer_ScreenVideo_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if (this.MPlayer_ScreenVideo.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (IsVideoSloaded)
                {
                    //MPlayer_ScreenVideo.Ctlcontrols.currentPosition = 0.01;
                    Application.DoEvents();
                    MPlayer_ScreenVideo.Ctlcontrols.pause();
                    //videoSloaded = false;
                }
            }
        }

        private void MPlayer_UserVideo_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
            {
                Timer_Project.Stop();
                BT_PlayPause.Text = " ";//Play
                Bar.SetBounds(PL_TaskLine.Location.X, Bar.Location.Y, Bar.Width, Bar.Height);
                tb_time.Text = "  ";
                BTPrevious_Total.Enabled = true;
                BTNext_Total.Enabled = true;
                Bitmap b2 = new Bitmap(Properties.Resources.play);
                BT_PlayPause.Image = b2;
            }
            else if (e.newState == 3)
            {
                BTPrevious_Total.Enabled = false;
                BTNext_Total.Enabled = false;
            }
            else if (e.newState == 2)
            {

                BTPrevious_Total.Enabled = true;
                BTNext_Total.Enabled = true;
            }

        }

        private void Timer_Project_Tick(object sender, EventArgs e)
        {
            if (Bar.Location.X < PL_TaskLine.Location.X + PL_TaskLine.Width)
            {
                double t = Math.Floor(MPlayer_UserVideo.currentMedia.duration - MPlayer_UserVideo.Ctlcontrols.currentPosition);
                int newX = (int)(Math.Round(PL_TaskLine.Width * MPlayer_UserVideo.Ctlcontrols.currentPosition * 1000 / Manager.PhysioProject.duration));
                Bar.SetBounds(PL_TaskLine.Location.X + newX, Bar.Location.Y, Bar.Width, Bar.Height);
                tb_time.Text = Math.Round((MPlayer_UserVideo.Ctlcontrols.currentPosition * 1000) / 1000, 3).ToString("0.000");
            }
        }

        #region This part of code moves the play bar if you type a time in Time in Sec text box
        private void tb_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                MPlayer_UserVideo.Ctlcontrols.currentPosition = Double.Parse(tb_time.Text);
                MPlayer_UserVideo.Ctlcontrols.play();
                MPlayer_UserVideo.Ctlcontrols.pause();
                int move = (int)(Math.Round(PL_TaskLine.Width * MPlayer_UserVideo.Ctlcontrols.currentPosition * 1000 / Manager.PhysioProject.duration));
                Bar.SetBounds(PL_TaskLine.Location.X + move, Bar.Location.Y, Bar.Width, Bar.Height);
            }
        }
        #endregion

        #region This Part of Code allowing user to move the project play bar....
        Control actcontrol;
        Point preloc;
        private void Bar_MouseDown(object sender, MouseEventArgs e)
        {
            if (BT_PlayPause.Text != "  " && CurrentVideo_U != null)
            {
                actcontrol = sender as Control;
                preloc = e.Location;
            }
        }
        private void Bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (actcontrol == null || actcontrol != sender)
                return;
            var location = actcontrol.Location;
            if (actcontrol.Location.X + (e.Location.X - preloc.X) > PL_TaskLine.Width + PL_TaskLine.Location.X)
            {
                location.X = PL_TaskLine.Width + PL_TaskLine.Location.X;
                actcontrol.Location = location;
                return;
            }
            if (actcontrol.Location.X + (e.Location.X - preloc.X) < PL_TaskLine.Location.X)
            {
                location.X = PL_TaskLine.Location.X;
                actcontrol.Location = location;
                return;
            }
            location.Offset(e.Location.X - preloc.X, 0);
            actcontrol.Location = location;
            double move = (double)((actcontrol.Location.X - 171) * (double)(Manager.PhysioProject.m_ana_px) / 1000);
            tb_time.Text = move.ToString("0.000");

        }
        private void Bar_MouseUp(object sender, MouseEventArgs e)
        {
            if (BT_PlayPause.Text != "  " && CurrentVideo_U != null)
            {

                double move = (double)((actcontrol.Location.X - 171) * (double)(Manager.PhysioProject.m_ana_px) / 1000);
                tb_time.Text = move.ToString("0.000");
                MPlayer_UserVideo.Ctlcontrols.currentPosition = Double.Parse(tb_time.Text);
                MPlayer_ScreenVideo.Ctlcontrols.currentPosition = Double.Parse(tb_time.Text);
                MPlayer_UserVideo.Ctlcontrols.play();
                MPlayer_UserVideo.Ctlcontrols.pause();
                MPlayer_ScreenVideo.Ctlcontrols.play();
                MPlayer_ScreenVideo.Ctlcontrols.pause();
            }
            actcontrol = null;
            Cursor = Cursors.Default;
        }

        private void reAlocateBar()
        {
            int move = (int)(Math.Round(PL_TaskLine.Width * MPlayer_UserVideo.Ctlcontrols.currentPosition * 1000 / Manager.PhysioProject.duration));
            Bar.SetBounds(PL_TaskLine.Location.X + move, Bar.Location.Y, Bar.Width, Bar.Height);
        }

        #endregion

        #region Previous & Next Start and Stop points in Project

        private void ΒΤNextClick(object sender, EventArgs e)
        {
            double time = Math.Round(MPlayer_UserVideo.Ctlcontrols.currentPosition,3);
            string buttonType = ((Button)sender).Name.Split('_')[1];
            TCriticalPoint cp;
            if (buttonType == "Total")
                cp = Manager.PhysioProject.criticalList.GetNextPoint(time * 1000, "");
            else if (buttonType == "Task")
                cp = Manager.PhysioProject.criticalList.GetNextPoint(time * 1000, "task");
            else
                cp = Manager.PhysioProject.criticalList.GetNextPoint(time * 1000, "emotion_" + buttonType);
            if (cp == null)
            {
                Bar.SetBounds(PL_TaskLine.Location.X + PL_TaskLine.Width, Bar.Location.Y, Bar.Width, Bar.Height);
                MPlayer_UserVideo.Ctlcontrols.currentPosition = PL_TaskLine.Width * Manager.PhysioProject.m_ana_px;
                MPlayer_ScreenVideo.Ctlcontrols.currentPosition = PL_TaskLine.Width * Manager.PhysioProject.m_ana_px;
                return;
            }
            double go = Math.Round(cp.time / Manager.PhysioProject.m_ana_px);
            Bar.SetBounds(PL_TaskLine.Location.X + (int)go, Bar.Location.Y, Bar.Width, Bar.Height);
            tb_time.Text = (cp.time / 1000).ToString("0.000");
            MPlayer_UserVideo.Ctlcontrols.currentPosition = (cp.time / 1000);
            MPlayer_ScreenVideo.Ctlcontrols.currentPosition = (cp.time / 1000);
            MPlayer_UserVideo.Ctlcontrols.play();
            MPlayer_ScreenVideo.Ctlcontrols.play();
            MPlayer_UserVideo.Ctlcontrols.pause();
            MPlayer_ScreenVideo.Ctlcontrols.pause();
        }
        private void BTPreviousClick(object sender, EventArgs e)
        {

            double time = Math.Round(MPlayer_UserVideo.Ctlcontrols.currentPosition, 3);
            string buttonType = ((Button)sender).Name.Split('_')[1];
            TCriticalPoint cp ;
            if (buttonType == "Total")
                cp = Manager.PhysioProject.criticalList.GetPreviousPoint(time * 1000, "");
            else if (buttonType == "Task")
                cp = Manager.PhysioProject.criticalList.GetPreviousPoint(time * 1000, "task");
            else
                cp = Manager.PhysioProject.criticalList.GetPreviousPoint(time * 1000, "emotion_" + buttonType);

            if (cp == null)
            {
                Bar.SetBounds(PL_TaskLine.Location.X, Bar.Location.Y, Bar.Width, Bar.Height);
                MPlayer_UserVideo.Ctlcontrols.currentPosition = 0;
                MPlayer_ScreenVideo.Ctlcontrols.currentPosition = 0;
                return;
            }
            double go = Math.Round(cp.time / Manager.PhysioProject.m_ana_px);
            Bar.SetBounds(PL_TaskLine.Location.X + (int)go, Bar.Location.Y, Bar.Width, Bar.Height);
            tb_time.Text = (cp.time / 1000).ToString("0.000");
            MPlayer_UserVideo.Ctlcontrols.currentPosition = (cp.time / 1000);
            MPlayer_ScreenVideo.Ctlcontrols.currentPosition = (cp.time / 1000);
            MPlayer_UserVideo.Ctlcontrols.play();
            MPlayer_ScreenVideo.Ctlcontrols.play();
            MPlayer_UserVideo.Ctlcontrols.pause();
            MPlayer_ScreenVideo.Ctlcontrols.pause();

        }
        #endregion


        #endregion

        #region PROJECT
        //Open Project Button in menustrip!!!
        private void BT_open_project_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Filter = "Xml Files|*.xml";
            openFileDialog1.InitialDirectory = "C:\\";
            DialogResult result = openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName == "") return;

            Manager.PhysioProject.criticalList.Clear();
            Manager.PhysioProject.signalList.Clear();
            Manager.PhysioProject.taskList.Clear();

            //Bar.SetBounds(PL_TaskLine.Location.X, Bar.Location.Y, Bar.Width, Bar.Height);
            Manager.loadProject(openFileDialog1.FileName);
            Manager.PhysioProject.panelWidth = PL_TaskLine.Width;
            Manager.PhysioProject.duration = Manager.PhysioProject.signalList.GetSignalByType("VIDEO_U").duration;
            Timer_Project.Interval = Manager.PhysioProject.m_ana_px;
            UpdateUI_FromProject();
        }

        //Save Project Button in menustrip!!!
        private void BT_save_project_Click(object sender, EventArgs e)
        {
            if (!IsVideoSloaded && !IsVideoUloaded)
            {
                MessageBox.Show("PhysiOBS needs at least one video source (User or Screen)", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (Manager.filename() != "") saveFileDialog1.FileName = Manager.filename();
                saveFileDialog1.Title = "Save as an xml File";
                saveFileDialog1.DefaultExt = "xml";
                saveFileDialog1.Filter = "Xml Files|*.xml";
                saveFileDialog1.InitialDirectory = "C:\\";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    String filename = saveFileDialog1.FileName;
                    Manager.saveProject(filename);
                }
            }
        }

        //Signal Analysis Button in menustrip!!!
        private void BT_signal_analysis_Click(object sender, EventArgs e)
        {
            Frm_Ass_Alg Frm_Task = new Frm_Ass_Alg();
            Frm_Task.SL = Manager.PhysioProject.signalList;
            Frm_Task.AL = Manager.PhysioProject.assignmentList;
            Frm_Task.ShowDialog();
        }

        void UpdateUI_FromProject()
        {   
            //Reset Form UI
            PL_TaskLine.Controls.Clear();
            Total_Signal_PL.Controls.Clear();
            this.Size = new Size (1281, 625);
            Bar.Size = new Size(2, 36);
            Total_Signal_PL.Size = new Size(1262, 0);
            
            //VIDEO_U
            if (Manager.PhysioProject.signalList.GetSignalByType("VIDEO_U") != null)
            {
                CurrentVideo_U = Manager.PhysioProject.signalList.GetSignalByType("VIDEO_U");
            }
            else
            {
                CurrentVideo_U = null;
                MPlayer_UserVideo.URL = "";
            }
            if (CurrentVideo_U != null)
            {
                MPlayer_UserVideo.URL = CurrentVideo_U.filename;
                BT_video_U_properties.Enabled = true;
                BT_Task_Frm.Enabled = true;
                MPlayer_UserVideo.Ctlcontrols.play();
                tb_time.Enabled = true;
                BT_PlayPause.Enabled = true;
            }

            //VIDEO_S
            if (Manager.PhysioProject.signalList.GetSignalByType("VIDEO_S") != null)
            {
                CurrentVideo_S = Manager.PhysioProject.signalList.GetSignalByType("VIDEO_S");
            }
            else
            {
                CurrentVideo_S = null;
                MPlayer_ScreenVideo.URL = "";
            }

            if (CurrentVideo_S != null)
            {
                MPlayer_ScreenVideo.URL = CurrentVideo_S.filename;
                BT_video_S_Properties.Enabled = true;
                BT_Task_Frm.Enabled = true;
                MPlayer_ScreenVideo.Ctlcontrols.play();
            }


            //Loads project's tasks
            foreach (TTask t in Manager.PhysioProject.taskList)
            {
                TCriticalPoint point1 = new TCriticalPoint();
                point1.name = t.name;
                point1.time = t.start;
                point1.Bar = "task";
                point1.obj = (object)t;
                Manager.PhysioProject.criticalList.Add(point1);
                TCriticalPoint point2 = new TCriticalPoint();
                point2.name = t.name;
                point2.time = t.stop;
                point2.Bar = "task";
                point2.obj = (object)t;
                Manager.PhysioProject.criticalList.Add(point2);
            }       
            DrawTasks();
            int orderID = 0;
            Manager.PhysioProject.SignalAI_ID = 0;
            foreach (TSignal s in Manager.PhysioProject.signalList)
            {
                
                if (s.type == "Bio-SIGNAL")
                {
                    orderID++;
                    if (Manager.PhysioProject.SignalAI_ID <= Int32.Parse(s.ID)) Manager.PhysioProject.SignalAI_ID = Int32.Parse(s.ID) + 1;
                    this.Size = new Size(this.Width, this.Height + 160);//Αλλαγή ύψους της Φόρμας 
                    Total_Signal_PL.Size = new Size(Total_Signal_PL.Width, Total_Signal_PL.Height + 160);//Αλλαγή ύψους Total panel
                    Panel newP = create_signal_panel(Int32.Parse(s.ID), orderID);
                    newP.Visible = false;
                    Total_Signal_PL.Controls.Add(newP);
                    newP.Parent = Total_Signal_PL;
                    if (orderID == 1)
                    {
                        Bar.SetBounds(PL_TaskLine.Location.X, Bar.Location.Y, Bar.Width, Bar.Height + 160+14);
                    }
                    else
                    {
                        Bar.SetBounds(PL_TaskLine.Location.X, Bar.Location.Y, Bar.Width, Bar.Height + 160);

                    }

                    draw_graph(s);
                    foreach (TEmotion em in Manager.PhysioProject.getEmotionListBySignalID(s.ID))
                    {
                        CreateEmotionPanel(em, s.ID);
                    }  
                    
                    BT_PlayPause.BringToFront();
                    BT_Stop.BringToFront();
                    BTPrevious_Total.BringToFront();
                    BTNext_Total.BringToFront();
                    newP.BringToFront(); 
                    newP.Visible = true;            
                }
            } 
            Manager.PhysioProject.criticalList.Sort();                 
        }

        #endregion

        #region TASK

        private void PL_TaskLine_Paint(object sender, PaintEventArgs e)
        {
            PL_TaskLine.BackColor = Color.White;
        }

        public int GetPixelFromTime(double Start_Stop)
        {
            return ((int)Math.Round(Start_Stop / Manager.PhysioProject.m_ana_px, 0));
        }

        void draw(TTask t)
        {
            int start = GetPixelFromTime(t.start);
            int stop = GetPixelFromTime(t.stop);
            int width = stop - start;
            Panel p = CreatePanel(start, width, PL_TaskLine.Height);
            if (t.succeed == true)
            {
                p.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                p.BackColor = System.Drawing.Color.Red;
            }
            p.Parent = PL_TaskLine;
            p.Name = t.ID;
            tooltp.SetToolTip(p, "Task Name:" + t.name + "\nStart Time:" + t.start.ToString() + "\nStop Time:" + t.stop.ToString() + "\nComments:" + t.comments + "\nSuccess:" + t.succeed.ToString());
        }

        public void ClearTasks()
        {
            foreach (Control p in PL_TaskLine.Controls)
            {
                p.Dispose();
            }

            PL_TaskLine.Controls.Clear();
        }

        public void DrawTasks()
        {
            if (Manager.PhysioProject.taskList.Count > 0)
            {
                BTNext_Total.Enabled = true;
                BTPrevious_Total.Enabled = true;
            }
            PL_TaskLine.BackColor = Color.White;
            foreach (TTask t in Manager.PhysioProject.taskList)
            {
                Manager.PhysioProject.criticalList.update(t);
                draw(t);
            }
            
        }

        private void BT_Task_Frm_Click(object sender, EventArgs e) //Task Form
        {
            PL_TaskLine.Refresh();
            Frm_User_Task Task_Form = new Frm_User_Task();
            Task_Form.CP = Manager.PhysioProject.criticalList;
            Task_Form.TL = Manager.PhysioProject.taskList;
            Task_Form.StartPosition = FormStartPosition.CenterScreen;
            Task_Form.ShowDialog();
            ClearTasks();
            DrawTasks();
        }

        private void PL_TaskLine_Resize(object sender, EventArgs e)
        {
            Manager.PhysioProject.panelWidth = PL_TaskLine.Width;
            PL_TaskLine.Refresh();
            ClearTasks();
            DrawTasks();
            reAlocateBar();
            ReAlocateSignalsEmotions();
        }

        #region This part of code Resizes and moves the task panels in TaskLine Bar

        Boolean left = false;//gia elegxo an ginetai resize apo aristera
        Boolean right = false;//gia elegxo an ginetai resize apo dexia

        public void MouseisDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                firstClick = DateTime.Now;
                panel_drag = true;
                panel_x = e.X;
            }
        }

        public void MouseisUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (!panel_drag) return;
            panel_drag = false; 
            if (DateTime.Now < firstClick.AddMilliseconds(SystemInformation.DoubleClickTime)) return; //periptosh doubleclick
            
            Panel p = (Panel)((Panel)sender).Parent;
            TTask t = Manager.PhysioProject.taskList.GetTaskByID(p.Name);
            t.start = p.Left * Manager.PhysioProject.m_ana_px; //antistoixo to p.left;  
            t.stop = (p.Left + p.Width) * Manager.PhysioProject.m_ana_px; //antistoixo to p.left;+p.width;
            tooltp.SetToolTip(((Panel)sender).Parent, "Task Name:" + t.name + "\nStart Time:" + t.start.ToString() + "\nStop Time:" + t.stop.ToString() + "\nComments:" + t.comments + "\nSuccess:" + t.succeed.ToString());
            Manager.PhysioProject.criticalList.update(t);
            return;
        }

        public void MouseResizeisDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panel_resize = true;
            }
        }

        public void MouseResizeisUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            panel_resize = false;
            Panel p = (Panel)((Panel)sender).Parent;
            TTask t = Manager.PhysioProject.taskList.GetTaskByID(p.Name);
                if (right == true) //otan kanw resize mono apo dexia
                {
                    t.stop = (p.Left + p.Width) * Manager.PhysioProject.m_ana_px;//antistoixo to p.left;+p.width;
                    tooltp.SetToolTip((Panel)sender, "Task Name:" + t.name + "\nStart Time:" + t.start.ToString() + "\nStop Time:" + t.stop.ToString() + "\nComments:" + t.comments + "\nSuccess:" + t.succeed.ToString());
                    right = false;
                    Manager.PhysioProject.criticalList.update(t);
                }
                else
                    if (left == true) //otan kanw resize mono apo aristera
                    {
                        t.start = p.Left * Manager.PhysioProject.m_ana_px;//antistoixo to p.left;
                        tooltp.SetToolTip((Panel)sender, "Task Name:" + t.name + "\nStart Time:" + t.start.ToString() + "\nStop Time:" + t.stop.ToString() + "\nComments:" + t.comments + "\nSuccess:" + t.succeed.ToString());
                        left = false;
                        Manager.PhysioProject.criticalList.update(t);
                    }
        }

        public void MouseMoves(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (panel_drag)
            {
                if (e.X == 0) return;
                Panel panel1 = (Panel)((Panel)sender).Parent;

                if (panel1.Left + e.X - panel_x < 0)
                {
                    panel1.Location = new Point(0, panel1.Top);
                    return;
                }

                if (panel1.Left + panel1.Width - panel_x + e.X > PL_TaskLine.Width)
                {
                    panel1.Location = new Point(PL_TaskLine.Width - panel1.Width, panel1.Top);
                    return;
                }

                panel1.Location = new Point(e.X + panel1.Left - panel_x, panel1.Top);
            }
        }

        public void MouseLResizeMoves(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (panel_resize)
            {
                if (e.X == 0) return;
                Panel panel1 = (Panel)((Panel)sender).Parent;
                int x = e.X;

                left = true;//gia na katalavw oti ginetai resize apo aristera
                int oldleft = panel1.Left;
                if (panel1.Left + x > panel1.Left + panel1.Width - 3) return;//ama kano resize terma deksia
                if (panel1.Left + x < 0) x = -panel1.Left;
                panel1.Left = panel1.Left + x;
                panel1.Width = panel1.Width + (oldleft - panel1.Left);

                Panel drag = (Panel)panel1.Controls[0];
                drag.Location = new Point(3, 0);
                drag.Size = new Size(panel1.Width - 6, panel1.Height);

                tooltp.SetToolTip((Panel)sender, "Start: " + PixelToTime(panel1.Left).ToString());

            }
        }

        public void MouseRResizeMoves(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (panel_resize)
            {
                if (e.X == 0) return;
                Panel panel1 = (Panel)((Panel)sender).Parent;
                int x = e.X;
                right = true;//gia na katalavw oti ginetai resize apo dexia
                if (panel1.Left + panel1.Width + x < panel1.Left + 3) return;//ama kano resize terma aristera
                if (panel1.Left + panel1.Width + x > PL_TaskLine.Width) x = PL_TaskLine.Width - panel1.Left - panel1.Width;

                panel1.Width = panel1.Width + x;

                Panel drag = (Panel)panel1.Controls[0];
                drag.Location = new Point(3, 0);
                drag.Size = new Size(panel1.Width - 6, panel1.Height);

                tooltp.SetToolTip((Panel)sender, "Stop: " + PixelToTime(panel1.Left + panel1.Width).ToString());

            }
        }

        public void TaskPanel_Double_Click(object sender, System.EventArgs e)//Double click panw se panel kai anoigma formas
        {
            panel_drag = false;
            panel_resize = false;
            Panel p = (Panel)((Panel)sender).Parent;
            TTask t = Manager.PhysioProject.taskList.GetTaskByID(p.Name);
            Frm_Task_Options Task_Options = new Frm_Task_Options();
            Task_Options.Task = t;
            Task_Options.StartPosition = FormStartPosition.CenterScreen;
            Task_Options.ShowDialog();
            ClearTasks();
            DrawTasks();
        }

        public Panel CreatePanel(int x, int l, int h)
        {

            //Create BasicPanel
            Panel p = new Panel();
            p.Location = new Point(x, 0);
            p.BackColor = Color.Yellow;
            p.Size = new Size(l, h);
            //Create dragPanel
            Panel d = new Panel();
            d.Location = new Point(3, 0);
            d.BackColor = Color.Transparent;
            d.Size = new Size(l - 6, h);
            d.Parent = p;
            d.Anchor = AnchorStyles.Top;
            d.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseisDown);
            d.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoves);
            d.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseisUp);
            d.DoubleClick += new System.EventHandler(this.TaskPanel_Double_Click);
            //Create leftPanel
            Panel lp = new Panel();
            lp.Location = new Point(0, 2);
            lp.BackColor = Color.Black;
            lp.Size = new Size(1, h - 4);
            lp.Parent = p;
            lp.Anchor = AnchorStyles.Left;
            lp.Cursor = Cursors.SizeWE;
            lp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseResizeisDown);
            lp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseLResizeMoves);
            lp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseResizeisUp);
            //Create rightPanel
            Panel rp = new Panel();
            rp.Location = new Point(l - 2, 2);
            rp.BackColor = Color.Black;
            rp.Size = new Size(1, h - 4);
            rp.Parent = p;
            rp.Anchor = AnchorStyles.Right;
            rp.Cursor = Cursors.SizeWE;
            rp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseResizeisDown);
            rp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseRResizeMoves);
            rp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseResizeisUp);
            return p;
        }

        #endregion

        #endregion

	    #region SIGNAL

        #region EMOTION

        private void EmotionsMenou_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Delete":
                    string SignalID = ((Panel)((Panel)current_emotion_panel).Parent).Name.Split('_')[1];
                    string EmotionID = ((Panel)current_emotion_panel).Name;
                    DeleteEmotionPanel(SignalID, EmotionID);
                break;
            }
        }

        private void DeleteEmotionPanel(string SignalID, string EmotionID)
        {
            TEmotion emotion = Manager.PhysioProject.getEmotionListBySignalID(SignalID).GetEmotionByID(EmotionID);
            Manager.PhysioProject.criticalList.clear_emotion(emotion);
            Manager.PhysioProject.getEmotionListBySignalID(SignalID).Remove(emotion);
            Manager.PhysioProject.criticalList.Sort();
            current_emotion_panel.Dispose();
        }
      
        public void DrawEmotions(string SignalID)
        {
            foreach (TEmotion e in Manager.PhysioProject.getEmotionListBySignalID(SignalID))
            {
                CreateEmotionPanel(e, SignalID);
            }
        }

        private void BT_Obs_Emotios_Click(object sender, EventArgs e)
        {
            Frm_Emotions_Grid Emotion_Form = new Frm_Emotions_Grid();
            Emotion_Form.SignalID = ((Panel)((Button)sender).Parent).Name.Split('_')[1];
            Emotion_Form.CP = Manager.PhysioProject.criticalList;
            Emotion_Form.EL = Manager.PhysioProject.getEmotionListBySignalID(((Panel)((Button)sender).Parent).Name.Split('_')[1]);
            Emotion_Form.StartPosition = FormStartPosition.CenterScreen;
            Emotion_Form.ShowDialog();
           
            //βρίσκω το control και στη συνέχεια καθαρίζω τα panels
            Panel psvou = (Panel)((Panel)((Button)sender).Parent).Controls["EmotionPanel_" + (((Panel)((Button)sender).Parent).Name.Split('_')[1])];
            ClearEmotions(psvou);

            //Δημιουργώ ξανά panel για όσα esmotions υπάρχουν στη λίστα για το συγκεκριμένο panel
            DrawEmotions(((Panel)((Button)sender).Parent).Name.Split('_')[1]);
            
        }

        #region Emotions_Bar

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string ID = ((Control)contextMenuStripParent).Name.Split('_')[1];
            TEmotion emotion = new TEmotion();
            emotion.start = temp_emotion_panel.Left * Manager.PhysioProject.m_ana_px;
            emotion.stop = (temp_emotion_panel.Left + temp_emotion_panel.Width) * Manager.PhysioProject.m_ana_px;
            switch (e.ClickedItem.Text)
            {
                case "Anger":
                    emotion.name = "Anger";
                    CreateEmotionPanel(emotion, ID);
                    Manager.PhysioProject.signalList.GetSignalByID(ID).SignalEmotionList.Add(emotion);
                    temp_emotion_panel.Width = 0;
                    break;
                case "Anxiety":
                    emotion.name = "Anxiety";
                    CreateEmotionPanel(emotion, ID);
                    temp_emotion_panel.Width = 0;
                     Manager.PhysioProject.signalList.GetSignalByID(ID).SignalEmotionList.Add(emotion);
                   break;
                case "Happiness":
                    emotion.name = "Happiness";
                    CreateEmotionPanel(emotion, ID);
                    temp_emotion_panel.Width = 0;
                     Manager.PhysioProject.signalList.GetSignalByID(ID).SignalEmotionList.Add(emotion);
                   break;
                case "Uncertainty":
                    emotion.name = "Uncertainty";
                    CreateEmotionPanel(emotion, ID);
                    temp_emotion_panel.Width = 0;
                    Manager.PhysioProject.signalList.GetSignalByID(ID).SignalEmotionList.Add(emotion);
                    break;
                case "Upset":
                    emotion.name = "Upset";
                    CreateEmotionPanel(emotion, ID);
                    temp_emotion_panel.Width = 0;
                    Manager.PhysioProject.signalList.GetSignalByID(ID).SignalEmotionList.Add(emotion);
                    break;
                case "Nervousness":
                    emotion.name = "Nervousness";
                    CreateEmotionPanel(emotion, ID);
                    temp_emotion_panel.Width = 0;
                    Manager.PhysioProject.signalList.GetSignalByID(ID).SignalEmotionList.Add(emotion);
                    break;
                case "Delete": ;
                    break;
            }
        }

        //Area highlight
        private void PL_Emotions_Bar_MouseDown(object sender, MouseEventArgs e)
        {
           temp_emotion_panel.Location = new Point(e.X, 1);
           temp_emotion_panel.BackColor = Color.FromArgb(25, Color.Gray);
           temp_emotion_panel.Size = new Size(1, ((Panel)sender).Height - 2);
           temp_emotion_panel.Parent = ((Panel)sender);
           temp_emotion_panel.SendToBack();
           emotion_mark = true;
           temp_emotion_start_x = e.X;

        }
        private void PL_Emotions_Bar_MouseMove(object sender, MouseEventArgs e)
        {
           if (emotion_mark)
           {
                if (e.X > temp_emotion_start_x)
                {
                    temp_emotion_panel.Width = -temp_emotion_start_x + e.X;
                }
                else
                {
                    temp_emotion_panel.Left = e.X;
                    temp_emotion_panel.Width = temp_emotion_start_x - temp_emotion_panel.Left;
                }
           }
        }
        private void PL_Emotions_Bar_MouseUp(object sender, MouseEventArgs e)
        {
            if (emotion_mark)
            {
                emotion_mark = false;
                //p.Width = -start_x + e.X;
            }
        }


        public void ReAlocateSignalsEmotions()
        {
            foreach (TSignal signal in Manager.PhysioProject.signalList)
                if (signal.type == "Bio-SIGNAL")
                    ReAlocateSignalEmotions(signal);
        }

        public void ReAlocateSignalEmotions(TSignal signal)
        {
            //βρίσκω το control και στη συνέχεια καθαρίζω τα panels
            Panel pp = (Panel)Total_Signal_PL.Controls["PanelSignal_" + signal.ID.ToString()];
            Panel psvou=(Panel)pp.Controls["EmotionPanel_" + signal.ID.ToString()];
            ClearEmotions(psvou);

            //Δημιουργώ ξανά panel για όσα esmotions υπάρχουν στη λίστα για το συγκεκριμένο panel
            DrawEmotions(signal.ID.ToString());
        }

 
        public void CreateEmotionPanel(TEmotion emotion, string SignalID)
        {
            //Create BasicPanel
            TCriticalPoint p1 = new TCriticalPoint();
            TCriticalPoint p2 = new TCriticalPoint();
            int h = TEmotionPropertiesList.height;
            Panel p = new Panel();
            emotion.ID = (Manager.PhysioProject.signalList.GetSignalByID(SignalID).SignalEmotionList.AI_ID++).ToString();
            p.Name = emotion.ID;
            int x = (int)emotion.start / Manager.PhysioProject.m_ana_px;
            p1.name = emotion.name;
            p1.time = emotion.start;
            p1.Bar = "emotion_" + SignalID;
            p1.obj = (object)emotion;
            Manager.PhysioProject.criticalList.Add(p1);
            p2.name = emotion.name;
            p2.Bar = "emotion_" + SignalID;
            int l = (int)(emotion.stop - emotion.start) / Manager.PhysioProject.m_ana_px;
            p2.time = emotion.stop;
            p2.obj = (object)emotion;
            Manager.PhysioProject.criticalList.Add(p2);
            p.Location = new Point(x, emotion.GetProperties().order * h);
            p.BackColor = Color.FromName(emotion.GetProperties().color);
            p.Size = new Size(l, h);
            p.Parent = (Panel)GetSignalControl(Manager.PhysioProject.signalList.GetSignalByID(SignalID), "EmotionPanel_" + SignalID);
            p.BringToFront();
            //Create dragPanel
            Panel d = new Panel();
            d.Location = new Point(3, 0);
            d.BackColor = Color.Transparent;
            d.Size = new Size(l - 6, h);
            d.Parent = p;
            d.Anchor = AnchorStyles.Top;
            //d.Cursor = Cursors.SizeAll;
            d.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EMouseisDown);
            d.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EMouseMoves);
            d.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EMouseisUp);
            d.DoubleClick += new System.EventHandler(this.EmotionPanel_Double_Click);
            //Create leftPanel
            Panel lp = new Panel();
            lp.Location = new Point(0, 2);
            lp.BackColor = Color.Black;
            lp.Size = new Size(2, h - 4);
            lp.Parent = p;
            lp.Anchor = AnchorStyles.Left;
            lp.Cursor = Cursors.SizeWE;
            lp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EMouseResizeisDown);
            lp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EMouseLResizeMoves);
            lp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EMouseResizeisUp);
            //Create rightPanel
            Panel rp = new Panel();
            rp.Location = new Point(l - 2, 2);
            rp.BackColor = Color.Black;
            rp.Size = new Size(2, h - 4);
            rp.Parent = p;
            rp.Anchor = AnchorStyles.Right;
            rp.Cursor = Cursors.SizeWE;
            rp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EMouseResizeisDown);
            rp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EMouseRResizeMoves);
            rp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EMouseResizeisUp);
            Manager.PhysioProject.criticalList.Sort();
        }

        //Resize - Drag Emotion Panels
        public void EMouseisDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                firstClick = DateTime.Now;
                panel_drag = true;
                panel_x = e.X;
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                ShowEmotionMenu(sender, e);
            }
        }
        public void EMouseisUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!panel_drag) return;
            panel_drag = false;
            if (DateTime.Now < firstClick.AddMilliseconds(SystemInformation.DoubleClickTime)) return; //periptosh doubleclick
            string SignalID = ((Control)((Control)((Control)sender).Parent).Parent).Name.Split('_')[1];
            Panel p = (Panel)((Panel)sender).Parent;
            TEmotion em = Manager.PhysioProject.getEmotionListBySignalID(SignalID).GetEmotionByID(p.Name);
            em.start = p.Left * Manager.PhysioProject.m_ana_px; //antistoixo to p.left;  
            em.stop = (p.Left + p.Width) * Manager.PhysioProject.m_ana_px; //antistoixo to p.left;+p.width;               
            tooltp.SetToolTip((Panel)sender, "Emotion Name:" + em.name + "\nStart Time:" + em.start.ToString() + "\nStop Time:" + em.stop.ToString() + "\nComments:" + em.comments);
            Manager.PhysioProject.criticalList.update(em);
            return;
        }
        
        public void EMouseResizeisDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panel_resize = true;
            }
        }
        public void EMouseResizeisUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            string SignalID = ((Control)((Control)((Control)sender).Parent).Parent).Name.Split('_')[1];
            panel_resize = false;
            Panel p = (Panel)((Panel)sender).Parent;
            TEmotion em = Manager.PhysioProject.getEmotionListBySignalID(SignalID).GetEmotionByID(p.Name);
                if (right == true) //otan kanw resize mono apo dexia
                {
                    em.stop = (p.Left + p.Width) * Manager.PhysioProject.m_ana_px; //antistoixo to p.left;+p.width;
                    tooltp.SetToolTip((Panel)sender, "Emotion Name:" + em.name + "\nStart Time:" + em.start.ToString() + "\nStop Time:" + em.stop.ToString() + "\nComments:" + em.comments);
                    right = false;
                    Manager.PhysioProject.criticalList.update(em);
                }
                else
                    if (left == true) // otan kanw resize mono apo aristera
                    {
                        em.start = p.Left * Manager.PhysioProject.m_ana_px; //antistoixo to p.left;
                        tooltp.SetToolTip((Panel)sender, "Task Name:" + em.name + "\nStart Time:" + em.start.ToString() + "\nStop Time:" + em.stop.ToString() + "\nComments:" + em.comments);
                        left = false;
                        Manager.PhysioProject.criticalList.update(em);
                    }
        }
        public void EMouseMoves(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (panel_drag)
            {
                Panel panel1 = (Panel)((Panel)sender).Parent;
                if (panel1.Left + e.X - panel_x < 0)
                {
                    panel1.Location = new Point(0, panel1.Top);
                    return;
                }
                if (panel1.Left + panel1.Width - panel_x + e.X > PL_TaskLine.Width)
                {
                    panel1.Location = new Point(PL_TaskLine.Width - panel1.Width, panel1.Top);
                    return;
                }
                panel1.Location = new Point(e.X + panel1.Left - panel_x, panel1.Top);
            }
        }
        public void EMouseLResizeMoves(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (panel_resize)
            {
                if (e.X == 0) return;
                Panel panel1 = (Panel)((Panel)sender).Parent;
                int x = e.X;
                //if (x < panel1.Left - PL_TaskLine.Left) x = panel1.Left - PL_TaskLine.Left;

                left = true;//gia na katalavw oti ginetai resize apo aristera
                int oldleft = panel1.Left;
                if (panel1.Left + x > panel1.Left + panel1.Width - 3) return;//ama kano resize terma deksia
                if (panel1.Left + x < 0) x = -panel1.Left;
                panel1.Left = panel1.Left + x;
                panel1.Width = panel1.Width + (oldleft - panel1.Left);

                Panel drag = (Panel)panel1.Controls[0];
                drag.Location = new Point(3, 0);
                drag.Size = new Size(panel1.Width - 6, 4);
                tooltp.SetToolTip((Panel)sender, "Start: " + PixelToTime(panel1.Left).ToString("0,000"));
            }
        }
        public void EMouseRResizeMoves(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (panel_resize)
            {
                if (e.X == 0) return;
                Panel panel1 = (Panel)((Panel)sender).Parent;
                int x = e.X;
                right = true;//gia na katalavw oti ginetai resize apo dexia
                if (panel1.Left + panel1.Width + x < panel1.Left + 3) return;//ama kano resize terma aristera
                if (panel1.Left + panel1.Width + x > PL_TaskLine.Width) x = PL_TaskLine.Width - panel1.Left - panel1.Width;

                panel1.Width = panel1.Width + x;

                Panel drag = (Panel)panel1.Controls[0];
                drag.Location = new Point(3, 0);
                drag.Size = new Size(panel1.Width - 6, 4);
                tooltp.SetToolTip((Panel)sender, "Stop: " + PixelToTime(panel1.Left + panel1.Width).ToString("0,000"));
            }
        }


        public void ShowEmotionSelectMenu(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            contextMenuStripParent = ((Panel)sender).Parent;
            contextMenuStrip1.Show();
            contextMenuStrip1.Left = System.Windows.Forms.Cursor.Position.X;
            contextMenuStrip1.Top = System.Windows.Forms.Cursor.Position.Y;
        }
        public void ShowEmotionMenu(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            current_emotion_panel = (Panel)((Panel)sender).Parent;
            EmotionsMenou.Show();
            EmotionsMenou.Left = System.Windows.Forms.Cursor.Position.X;
            EmotionsMenou.Top = System.Windows.Forms.Cursor.Position.Y;
        }

        //Emotion properties DoubleClick
        public void EmotionPanel_Double_Click(object sender, System.EventArgs e)
        {
            panel_drag=false;
            panel_resize = false;
            Panel p = (Panel)((Panel)((Panel)sender).Parent).Parent;
            Panel psvou =p;
            string SignalID = p.Name.Split('_')[1];
            p = (Panel)((Panel)sender).Parent;
            TEmotion em = Manager.PhysioProject.getEmotionListBySignalID(SignalID).GetEmotionByID(p.Name);
            Frm_Emotion_options Emotion_Options = new Frm_Emotion_options();
            Emotion_Options.CP = Manager.PhysioProject.criticalList;
            Emotion_Options.Emotion = em;
            Emotion_Options.StartPosition = FormStartPosition.CenterScreen;
            Emotion_Options.ShowDialog();
            ClearEmotions(psvou);
            Manager.PhysioProject.criticalList.clear_points("emotion_" + SignalID);
            DrawEmotions(SignalID);
            return;
        }


        public void ClearEmotions(Panel C)
        {
            C.Controls.Clear();
            C.BringToFront();
        }

        #endregion

        #endregion

        #region This Part of Code Display The values of X and Y in Chart on mouse over!!!!
        private void Chart_Signal_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltp.RemoveAll();
            prevPosition = pos;
            var results = ((Chart)sender).HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 && Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            //tooltp.SetToolTip(Chart_Signal1, "X=" + prop.XValue.ToString("0.000") + ", Y=" + prop.YValues[0].ToString("0.000"));
                            tooltp.Show("Time(sec)=" + prop.XValue.ToString("0.000") + ", Signal Value=" + prop.YValues[0].ToString("0.000"), ((Chart)sender), pos.X, pos.Y);
                        }
                    }
                }
            }
        }
        #endregion

        #region This part of code Enable and Disable Mean and SD in graph

        private void CB_Raw_CheckedChanged(object sender, EventArgs ee)
        {
            string ID = ((CheckBox)sender).Name.Split('_')[1];
            Chart ch = (Chart)GetControl(((CheckBox)sender).Parent.Parent, "ChartSignal_" + ID);
            if (((CheckBox)sender).Checked == true)
            {
                //Time && Raw Data                  
                ch.Series[0].Enabled = true;
                ch.Series[0].BorderWidth = 1;
                ch.Series[0].Color = Color.Black;
                ch.Series[0].ChartType = SeriesChartType.Line;

                for (int i = 0; i < SID_Info.Count; i++)
                {
                    if (SID_Info[i] == int.Parse(ID))
                    {
                        ch.Series[0].XValueMember = alltables[i].Columns[0].ColumnName;
                        ch.Series[0].YValueMembers = alltables[i].Columns[1].ColumnName;
                        break;
                    }
                }
                
            }
            else
            {
                ch.Series[0].Enabled = false;
            }
        }

        private void CB_Mean_CheckedChanged(object sender, EventArgs ee)
        {
            string ID=((CheckBox)sender).Name.Split('_')[1];
            Chart ch = (Chart)GetControl(((CheckBox)sender).Parent.Parent, "ChartSignal_" + ID);
            if (((CheckBox)sender).Checked == true)
            {
                //Time && Mean
                ch.Series[1].Enabled = true;
                ch.Series[1].BorderWidth = 1;
                ch.Series[1].Color = Color.Red;
                ch.Series[1].ChartType = SeriesChartType.Line;
                
                for (int i = 0; i < SID_Info.Count; i++)
                {
                    if (SID_Info[i] == int.Parse(ID))
                    {
                        ch.Series[1].XValueMember = alltables[i].Columns[0].ColumnName;
                        ch.Series[1].YValueMembers = alltables[i].Columns[2].ColumnName;
                        break;
                    }
                }
                
            }
            else
            {
                ch.Series[1].Enabled = false;
            }
        }

        private void CB_SD_plusminus_1_CheckedChanged(object sender, EventArgs e)
        {
            string ID = ((CheckBox)sender).Name.Split('_')[1];
            Chart ch = (Chart)GetControl(((CheckBox)sender).Parent.Parent, "ChartSignal_" + ID);
            if (((CheckBox)sender).Checked == true)
            {
                //Time && +1SD
                ch.Series[2].Enabled = true;
                ch.Series[2].BorderWidth = 1;
                ch.Series[2].Color = Color.Sienna;
                ch.Series[2].ChartType = SeriesChartType.Line;
                //Time && -1SD
                ch.Series[3].Enabled = true;
                ch.Series[3].BorderWidth = 1;
                ch.Series[3].Color = Color.Sienna;
                ch.Series[3].ChartType = SeriesChartType.Line;

                for (int i = 0; i < SID_Info.Count; i++)
                {
                    if (SID_Info[i] == int.Parse(ID))
                    {
                        ch.Series[2].XValueMember = alltables[i].Columns[0].ColumnName;
                        ch.Series[2].YValueMembers = alltables[i].Columns[3].ColumnName;
                        ch.Series[3].XValueMember = alltables[i].Columns[0].ColumnName;
                        ch.Series[3].YValueMembers = alltables[i].Columns[4].ColumnName;
                        break;
                    }
                }
                
            }
            else
            {
                ch.Series[2].Enabled = false;
                ch.Series[3].Enabled = false;
            }
        }
        private void CB_SD_plusminus_2_CheckedChanged(object sender, EventArgs e)
        {
            string ID = ((CheckBox)sender).Name.Split('_')[1];
            Chart ch = (Chart)GetControl(((CheckBox)sender).Parent.Parent, "ChartSignal_" + ID);

            if (((CheckBox)sender).Checked == true)
            {
                //Time && +2SD
                ch.Series[4].Enabled = true;
                ch.Series[4].BorderWidth = 1;
                ch.Series[4].Color = Color.RoyalBlue;
                ch.Series[4].ChartType = SeriesChartType.Line;
                //Time && -2SD
                ch.Series[5].Enabled = true;
                ch.Series[5].BorderWidth = 1;
                ch.Series[5].Color = Color.RoyalBlue;
                ch.Series[5].ChartType = SeriesChartType.Line;

                for (int i = 0; i < SID_Info.Count; i++)
                {
                    if (SID_Info[i] == int.Parse(ID))
                    {
                        ch.Series[4].XValueMember = alltables[i].Columns[0].ColumnName;
                        ch.Series[4].YValueMembers = alltables[i].Columns[5].ColumnName;
                        ch.Series[5].XValueMember = alltables[i].Columns[0].ColumnName;
                        ch.Series[5].YValueMembers = alltables[i].Columns[6].ColumnName;
                        break;
                    }
                }
                
            }
            else
            {
                ch.Series[4].Enabled = false;
                ch.Series[5].Enabled = false;
            }
        }

        #endregion

        private Control GetControl(Control Parent, string controlName)
        {
            Control c=null;
            foreach (Control p in Parent.Controls)
            {
                if (p.Name == controlName)
                {
                    return p;
                }

                if (p.HasChildren)
                    c = GetControl(p, controlName);
                if (c != null) return c;

            }
            return null;
        }

        private Control GetSignalControl(TSignal signal, string controlName)//Βρίσκει το Κατάλληλο control
        {
            string ID=signal.ID;
            Panel currentpanel = (Panel)Total_Signal_PL.Controls["PanelSignal_" + ID];
            if (currentpanel == null) return null;
            return GetControl(currentpanel, controlName);
        }

       


        private void draw_graph(TSignal Signal)
        {
            ((Button)GetSignalControl(Signal, "BTObservedEmotions_" + Signal.ID)).Enabled = true;
            if (Signal != null && Signal.output == "Simple Signal Graph")
            {
                if (Path.GetExtension(Signal.filename) != "")
                {
                    Label LB_SignalID = (Label)GetSignalControl(Signal, "LBSignalID_" + Signal.ID);
                    LB_SignalID.Font = new Font(LB_SignalID.Font, FontStyle.Bold);
                    LB_SignalID.ForeColor = Color.Black;

                    Button BT_Remove = (Button)GetSignalControl(Signal, "BTRemoveSignal_" + Signal.ID);
                    BT_Remove.ForeColor = Color.Black;
                    BT_Remove.Enabled = true;

                    Label LabelEmotionName = (Label)GetSignalControl(Signal, "LabelEmotionName_" + Signal.ID);
                    LabelEmotionName.Text = Signal.signaltype;
                    
                    //Προετοιμασία για διάγραμμα
                    Chart ChartSignal = (Chart)GetSignalControl(Signal, "ChartSignal_" + Signal.ID);
                    ChartSignal.ChartAreas.Add(new ChartArea());
                    ChartSignal.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    ChartSignal.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                    ChartSignal.MouseMove += new MouseEventHandler(Chart_Signal_MouseMove);
                    
                    DataTable TableTotal = new DataTable();//Δημιουργία νέου πίνακα
                    
                    TableTotal.Columns.Clear();
                    TableTotal.Rows.Clear();
                    TableTotal.Columns.Add(new DataColumn("Time", typeof(float)));
                    TableTotal.Columns.Add(new DataColumn("Raw", typeof(float)));
                    TableTotal.Columns.Add(new DataColumn("Mean", typeof(float)));
                    TableTotal.Columns.Add(new DataColumn("+1SD", typeof(float)));
                    TableTotal.Columns.Add(new DataColumn("-1SD", typeof(float)));
                    TableTotal.Columns.Add(new DataColumn("+2SD", typeof(float)));
                    TableTotal.Columns.Add(new DataColumn("-2SD", typeof(float)));
                    //TableTotal.Columns.Add(new DataColumn("Smoothing Signal", typeof(float)));//smoothing sima

                    alltables.Add(TableTotal);//mesa sti lista me ta all tables

                    t = (float)(1.0 / Int32.Parse(Signal.sampling));
                    float time_S = t;
                    double sum = 0;
                    double min=10^6;
                    double max = -10 ^ 7;
                   

                    //read table for send it to matlab
                    int ind = 0;
                    List<double> sample_list = new List<double>();
                    foreach (String line in File.ReadAllLines(Signal.filename))
                    {
                        sample_list.Add(double.Parse(line));
                        ind++;
                    }

                    double[] raw_bio_signal = sample_list.ToArray();//Μετατρέπει τη λίστα σε πίνακα
                    int length = raw_bio_signal.Length;//Βρίσκω το μέγεθος του πίνακα

                    rawsignals.Add(raw_bio_signal);//Προσθήκη στη λίστα με τα ακατέργαστα σήματα

                    int i = 0;
                    for (i = 0; i < length; i++)
                    {
                        if (raw_bio_signal[i] > max) max = raw_bio_signal[i];
                        if (raw_bio_signal[i] < min) min = raw_bio_signal[i];
                    }

                    double oldrange = max - min;
                    double newrange = 100;

                    for (i = 0; i < length; i++)
                    {
                        raw_bio_signal[i] = ((((raw_bio_signal[i] - min) * newrange) / oldrange) /*+ 0*/);
                        sum = sum + raw_bio_signal[i];
                    }

                    Double average = sum / length;
                    Double SumSqrt = 0;
                    for (int j = 0; j < i; j++)
                    {
                        SumSqrt = SumSqrt + (raw_bio_signal[j] - average) * (raw_bio_signal[j] - average);//Sum of Square
                    }

                    double Stdev = Math.Sqrt(SumSqrt / (length - 1)); //Standard Deviation
                    for (int j = 0; j < i; j++)
                    {
                        time_S = time_S + t;
                        TableTotal.Rows.Add(time_S, raw_bio_signal[j], average, average + Stdev, average - Stdev, average + (2 * Stdev), average - (2 * Stdev));
                    }
                    
                    
                    //Τέλος Δημιουργίας δεδομένων για γράφημα


                    TextBox ΤΒStDev = (TextBox)GetSignalControl(Signal, "ΤΒStDev_" + Signal.ID);
                    ΤΒStDev.Text = Stdev.ToString("0.00");
                    TextBox TB_Mean = (TextBox)GetSignalControl(Signal, "TBMean_" + Signal.ID);
                    TB_Mean.Text = average.ToString("0.00");

                    //Set Graph Scale to a specific range of Value
                    ChartSignal.ChartAreas[0].AxisY.Maximum =110;
                    ChartSignal.ChartAreas[0].AxisY.Minimum =-10;


                    ChartSignal.DataSource = TableTotal;
                    ChartSignal.ChartAreas[0].Position.X = 100;
                    ChartSignal.ChartAreas[0].Position.Y = 100;
                    ChartSignal.ChartAreas[0].Position.Width = 100;
                    ChartSignal.ChartAreas[0].Position.Height = 100;

                    ChartSignal.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                    ChartSignal.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;

                    //Series Creation
                    ChartSignal.Series.Add(new Series());
                    ChartSignal.Series.Add(new Series());
                    ChartSignal.Series.Add(new Series());
                    ChartSignal.Series.Add(new Series());
                    ChartSignal.Series.Add(new Series());
                    ChartSignal.Series.Add(new Series());
                    //ChartSignal.Series.Add(new Series());//desmeumeni gia to smootharismeno sima 



                                                       
                    CheckBox CB_RawSignal = (CheckBox)GetSignalControl(Signal, "CBRawSignal_" + Signal.ID);
                    CB_RawSignal.Checked = true;


                    ChartSignal.DataBind();
                }
                else
                {
                    Panel PanelGraph = (Panel)GetSignalControl(Signal, "PanelGraph_" + Signal.ID);
                    PanelGraph.BackColor = Color.Empty;
                    PanelGraph.BackgroundImage = null;
                    
                    Label LB_SignalID = (Label)GetSignalControl(Signal, "LBSignalID_" + Signal.ID);
                    LB_SignalID.Font = new Font(LB_SignalID.Font, FontStyle.Regular);
                    LB_SignalID.ForeColor = Color.Silver;

                    Button BTAddSignal = (Button)GetSignalControl(Signal, "BTAddSignal_" + Signal.ID);
                    BTAddSignal.Enabled = true;

                    Button BTRemoveSignal = (Button)GetSignalControl(Signal, "BTRemoveSignal_" + Signal.ID);
                    BTRemoveSignal.ForeColor = Color.Silver;
                    BTRemoveSignal.Enabled = false;                   
                }
            }
        }  
        
        private Panel create_signal_panel(int SID, int OrderID) // Δημιουργεί τα controls προγραμματιστικά
        {

            Counter_For_Smooth_list.Add(0);
            SID_Info.Add(SID);
            
            Panel PanelSignal = new Panel();
            PanelSignal.Name = "PanelSignal_" + SID.ToString();
            PanelSignal.Parent = Total_Signal_PL;
            PanelSignal.SetBounds(5, (OrderID - 1) * (160), Total_Signal_PL.Width-9, 156);
            PanelSignal.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            PanelSignal.BringToFront();

            Panel PanelGraph = new Panel();
            PanelSignal.Controls.Add(PanelGraph);
            PanelGraph.Name = "PanelGraph_" + SID;
            PanelGraph.Parent = PanelSignal;
            PanelGraph.BackColor = Color.White;
            PanelGraph.SetBounds(164, 0, PanelSignal.Width - 164 - 104, 108);
            PanelGraph.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
           
            Button BTRemoveSignal = new Button();
            PanelSignal.Controls.Add(BTRemoveSignal);
            BTRemoveSignal.Name = "BTRemoveSignal_" + SID;
            BTRemoveSignal.Enabled = false;
            BTRemoveSignal.BackgroundImage = Properties.Resources.rs;
            BTRemoveSignal.BackgroundImageLayout = ImageLayout.Stretch;
            BTRemoveSignal.Parent = PanelSignal;
            BTRemoveSignal.SetBounds(8, 22, 45, 45);
            BTRemoveSignal.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            BTRemoveSignal.Click += new EventHandler(BTRemoveSignalClick_NK);//Κλήση Event   
            //ToolTip tooltp = new ToolTip();
            //tooltp.SetToolTip(BTRemoveSignal, "iuiiiuiuiuiuiu");

            Button ΒΤNextEmotion = new Button();
            PanelSignal.Controls.Add(ΒΤNextEmotion);
            ΒΤNextEmotion.Name = "ΒΤNextEmotion_" + SID;
            ΒΤNextEmotion.BackgroundImage = Properties.Resources.forw;
            ΒΤNextEmotion.BackgroundImageLayout = ImageLayout.Center;
            ΒΤNextEmotion.Parent = PanelSignal;
            ΒΤNextEmotion.SetBounds(113, 25, 45, 38);
            ΒΤNextEmotion.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            ΒΤNextEmotion.Click += new EventHandler(ΒΤNextClick);//Κλήση Event next Event

            Button BTPreviousEmotion = new Button();
            PanelSignal.Controls.Add(BTPreviousEmotion);
            BTPreviousEmotion.Name = "BTPreviousEmotion_" + SID;
            BTPreviousEmotion.BackgroundImage = Properties.Resources.back;
            BTPreviousEmotion.BackgroundImageLayout = ImageLayout.Center;
            BTPreviousEmotion.Parent = PanelSignal;
            BTPreviousEmotion.SetBounds(65, 25, 45, 38);
            BTPreviousEmotion.BringToFront();
            BTPreviousEmotion.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            BTPreviousEmotion.Click += new EventHandler(BTPreviousClick);//Κλήση Event next Event

            Panel New_Emotion_PL = new Panel();
            PanelSignal.Controls.Add(New_Emotion_PL);
            New_Emotion_PL.Parent = PanelSignal;
            New_Emotion_PL.Name = "EmotionPanel_" + SID; 
            New_Emotion_PL.BackColor = Color.LightYellow;
            New_Emotion_PL.SetBounds(164, 110, PanelSignal.Width - 164 - 104, 42);
            New_Emotion_PL.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            New_Emotion_PL.MouseDown += new MouseEventHandler(PL_Emotions_Bar_MouseDown);
            New_Emotion_PL.MouseMove += new MouseEventHandler(PL_Emotions_Bar_MouseMove);
            New_Emotion_PL.MouseUp += new MouseEventHandler(PL_Emotions_Bar_MouseUp);

            GroupBox New_Statistics_GB = new GroupBox();
            PanelSignal.Controls.Add(New_Statistics_GB);
            New_Statistics_GB.Text = "Show on Graph";
            New_Statistics_GB.Parent = PanelSignal;
            New_Statistics_GB.SetBounds(PanelSignal.Width-98, 0, 95, 84);
            New_Statistics_GB.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            New_Statistics_GB.BringToFront();
           
            CheckBox CB_RawSignal = new CheckBox();
            New_Statistics_GB.Controls.Add(CB_RawSignal);
            CB_RawSignal.Name = "CBRawSignal_" + SID;
            CB_RawSignal.Text = "Raw Signal";
            CB_RawSignal.Enabled = true;
            CB_RawSignal.ForeColor = Color.Black;
            CB_RawSignal.Parent = New_Statistics_GB;
            CB_RawSignal.SetBounds(6, 13, 86, 17);
            CB_RawSignal.BringToFront();
            CB_RawSignal.CheckedChanged += new EventHandler(CB_Raw_CheckedChanged);

            CheckBox CB_Mean = new CheckBox();
            New_Statistics_GB.Controls.Add(CB_Mean);
            CB_Mean.Name = "CBMean_" + SID;
            CB_Mean.Text = "Mean";
            CB_Mean.Enabled = true;
            CB_Mean.ForeColor = Color.Red;
            CB_Mean.Parent = New_Statistics_GB;
            CB_Mean.SetBounds(6, 30, 53, 17);
            CB_Mean.BringToFront();
            CB_Mean.CheckedChanged += new EventHandler(CB_Mean_CheckedChanged);

            CheckBox CB_SD1 = new CheckBox();
            New_Statistics_GB.Controls.Add(CB_SD1);
            CB_SD1.Name = "CBSD1_" + SID;
            CB_SD1.Text = "+/-1SD";
            CB_SD1.Enabled = true;
            CB_SD1.ForeColor = Color.Sienna;
            CB_SD1.Parent = New_Statistics_GB;
            CB_SD1.SetBounds(6, 48, 61, 17);
            CB_SD1.BringToFront();
            CB_SD1.CheckedChanged += new EventHandler(CB_SD_plusminus_1_CheckedChanged);

            CheckBox CB_SD2 = new CheckBox();
            New_Statistics_GB.Controls.Add(CB_SD2);
            CB_SD2.Name = "CBSD2_" + SID;
            CB_SD2.Text = "+/-2SD";
            CB_SD2.Enabled = true;
            CB_SD2.ForeColor = Color.RoyalBlue;
            CB_SD2.Parent = New_Statistics_GB;
            CB_SD2.SetBounds(6, 66, 61, 17);
            CB_SD2.BringToFront();
            CB_SD2.CheckedChanged += new EventHandler(CB_SD_plusminus_2_CheckedChanged);

            TextBox TBMean = new TextBox();
            PanelSignal.Controls.Add(TBMean);
            TBMean.Name = "TBMean_" + SID;
            TBMean.Parent = PanelSignal;
            TBMean.Text = "Mean";
            TBMean.ReadOnly = true;
            TBMean.SetBounds(PanelSignal.Width - 42, 99, 39, 19);
            TBMean.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            TextBox ΤΒStDev = new TextBox();
            PanelSignal.Controls.Add(ΤΒStDev);
            ΤΒStDev.Text = "St.Dev";
            ΤΒStDev.Name = "ΤΒStDev_" + SID;
            ΤΒStDev.Parent = PanelSignal;
            ΤΒStDev.ReadOnly = true;
            ΤΒStDev.SetBounds(PanelSignal.Width-42, 132, 39, 19);
            ΤΒStDev.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            Label Mean = new Label();//Πρόβάλλει τη μέση τιμή του σήματος!!!
            PanelSignal.Controls.Add(Mean);
            Mean.AutoSize = true;
            Mean.Text = "Mean";
            Mean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
            Mean.Parent = PanelSignal;
            Mean.SetBounds(PanelSignal.Width - 42, 86, 96, 3);
            Mean.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            Label STD = new Label();//Πρόβάλλει την τυπική απόκλιση του σήματος!!!
            PanelSignal.Controls.Add(STD);
            STD.AutoSize = true;
            STD.Text = "St.Dev";
            STD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
            STD.Parent = PanelSignal;
            STD.SetBounds(PanelSignal.Width - 42, 119, 96, 3);
            STD.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            Button BTObservedEmotions = new Button();
            PanelSignal.Controls.Add(BTObservedEmotions);
            BTObservedEmotions.Name = "BTObservedEmotions_" + SID;
            BTObservedEmotions.Enabled = false;
            BTObservedEmotions.BackgroundImage = Properties.Resources.em_table;
            BTObservedEmotions.BackgroundImageLayout = ImageLayout.Stretch;
            BTObservedEmotions.Parent = PanelSignal;
            BTObservedEmotions.SetBounds(PanelSignal.Width - 98, 104, 45, 43);
            BTObservedEmotions.BringToFront();
            BTObservedEmotions.Click += new EventHandler(BT_Obs_Emotios_Click);
            BTObservedEmotions.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            Label EmList = new Label();//keimeno panw apo pinaka me emotions
            PanelSignal.Controls.Add(EmList);
            EmList.AutoSize = true;
            EmList.Text = "Em. List";
            EmList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
            EmList.Parent = PanelSignal;
            EmList.SetBounds(PanelSignal.Width - 98, 90, 96, 3);
            //EmList.SetBounds(PanelSignal.Width - 98, 104, 45, 43);
            EmList.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            Label LabelEmotionName = new Label();//Πρόβάλλει το είδος του σήματος Galvanic Skin Response etc.!!!
            PanelSignal.Controls.Add(LabelEmotionName);
            LabelEmotionName.AutoSize = true;
            LabelEmotionName.Name = "LabelEmotionName_" + SID;
            LabelEmotionName.Parent = PanelSignal;
            LabelEmotionName.Text = "....";
            //LabelEmotionName.SetBounds(5, 86, 22, 13);
            LabelEmotionName.SetBounds(5, 69, 22, 13);
            LabelEmotionName.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            /*--Cotrols for smoothing--*/
            NumericUpDown Error_Correction = new NumericUpDown();//setting error correction value
            PanelSignal.Controls.Add(Error_Correction);
            Error_Correction.Maximum = 90;
            Error_Correction.Minimum = 0;
            Error_Correction.Name = "NUDErrorCorrection_" + SID;
            Error_Correction.Parent = PanelSignal;
            //Error_Setting.SetBounds(0, 115, 40, 32);
            Error_Correction.SetBounds(7, 107, 40, 31);
            Error_Correction.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            Label Error_Corr_lb = new Label();//Πρόβάλλει το keimeno error correction
            PanelSignal.Controls.Add(Error_Corr_lb);
            Error_Corr_lb.AutoSize = true;
            //Error_Corr_lb.Name = "LabelErrorCorrection_" + SID;
            Error_Corr_lb.Parent = PanelSignal;
            Error_Corr_lb.Text = "Smooth with Error Correction(%):";
            Error_Corr_lb.SetBounds(5, 90, 94, 32);
            Error_Corr_lb.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            Button BTRunsmooth = new Button();
            PanelSignal.Controls.Add(BTRunsmooth);
            BTRunsmooth.Name = "BTRunsmooth_" + SID;
            BTRunsmooth.Enabled = true;
            BTRunsmooth.Parent = PanelSignal;
            BTRunsmooth.SetBounds(50, 106, 49, 22);
            BTRunsmooth.BringToFront();
            BTRunsmooth.Text = "smooth";
            BTRunsmooth.TextAlign = ContentAlignment.TopLeft;
            BTRunsmooth.Click += new EventHandler(BT_Run_Correction_Click);
            BTRunsmooth.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            /*--end of smoothing controls--*/

            Label New_Obs_Emotions_LB = new Label();
            PanelSignal.Controls.Add(New_Obs_Emotions_LB);
            New_Obs_Emotions_LB.AutoSize = true;
            New_Obs_Emotions_LB.Text = "Emotions Panel";
            New_Obs_Emotions_LB.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            New_Obs_Emotions_LB.Parent = PanelSignal;
            New_Obs_Emotions_LB.SetBounds(26, 132, 135, 15);
            New_Obs_Emotions_LB.SendToBack();
            New_Obs_Emotions_LB.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            Chart ChartSignal = new Chart();
            PanelGraph.Controls.Add(ChartSignal);
            ChartSignal.Name = "ChartSignal_" + SID;
            ChartSignal.Parent = PanelGraph;
            ChartSignal.SetBounds(1, 1, PanelGraph.Width, 100);
            ChartSignal.BringToFront();
            ChartSignal.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

            ShapeContainer canvas = new ShapeContainer();
            LineShape theLine1 = new LineShape();
            // Set the New_Signal_PL as the parent of the ShapeContainer.
            canvas.Parent = PanelSignal;
            // Set the canvas as the parent of the LineShape.
            theLine1.Parent = canvas;
            // Set the starting and ending coordinates for the line.
            theLine1.BorderWidth = 2;
            theLine1.BorderColor = Color.Blue;
            theLine1.SelectionColor = Color.Blue;
            theLine1.StartPoint = new System.Drawing.Point(0, 130);
            theLine1.EndPoint = new System.Drawing.Point(163, 130);
            theLine1.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            ShapeContainer canvas_2 = new ShapeContainer();
            LineShape theLine2 = new LineShape();
            // Set the New_Signal_PL as the parent of the ShapeContainer.
            canvas_2.Parent = PanelSignal;
            // Set the canvas as the parent of the LineShape.
            theLine2.Parent = canvas_2;
            // Set the starting and ending coordinates for the line.
            theLine2.BorderWidth = 2;
            theLine2.BorderColor = Color.Blue;
            theLine2.StartPoint = new System.Drawing.Point(0, 151);
            theLine2.EndPoint = new System.Drawing.Point(163, 151);
            theLine2.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            
            ShapeContainer canvas_3 = new ShapeContainer();
            LineShape theLine3 = new LineShape();
            // Set the New_Signal_PL as the parent of the ShapeContainer.
            canvas_3.Parent = PanelSignal;
            // Set the canvas as the parent of the LineShape.
            theLine3.Parent = canvas_2;
            // Set the starting and ending coordinates for the line.
            theLine3.BorderWidth = 1;
            theLine3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            theLine3.BorderColor = Color.Blue;
            theLine3.StartPoint = new System.Drawing.Point(0, 87);
            theLine3.EndPoint = new System.Drawing.Point(163, 87);
            theLine3.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            Label LB_SignalID = new Label();
            PanelSignal.Controls.Add(LB_SignalID);
            LB_SignalID.AutoSize = true;
            LB_SignalID.Name = "LBSignalID_" + SID;
            LB_SignalID.Parent = PanelSignal;
            LB_SignalID.Text = "Bio-Signal_" + SID;
            LB_SignalID.SetBounds(2, 6, 92, 13);
            LB_SignalID.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            return PanelSignal;
        }

        private void BTAddSignalClick(object sender, EventArgs e)//Συνάρτηση για Event στο BTAddSignal
        {
            Frm_Signal_Options Sopt = new Frm_Signal_Options();
            Sopt.Manager = Manager;// Public in Sopt Form
            TSignal CurrentSignal=new TSignal();
            Sopt.Signal = CurrentSignal;
            Sopt.StartPosition = FormStartPosition.CenterScreen;
            Sopt.ShowDialog();
            CurrentSignal = Sopt.Signal;
            if (CurrentSignal.filename == "") return;
          
            Manager.PhysioProject.signalList.Add(CurrentSignal);
            CurrentSignal.ID = Manager.PhysioProject.SignalAI_ID++.ToString();
            this.Size = new Size(this.Width, this.Height+160);//Αλλαγή ύψους της Φόρμας 
            Total_Signal_PL.Size = new Size(Total_Signal_PL.Width, Total_Signal_PL.Height + 160);//Αλλαγή ύψους Total panel
            Panel newP = create_signal_panel(Int32.Parse(CurrentSignal.ID), Manager.PhysioProject.signalList.GetSignalCountByType("Bio-SIGNAL"));
            newP.Visible = false;
            Total_Signal_PL.Controls.Add(newP);
            newP.Parent = Total_Signal_PL;
            Total_Signal_PL.SendToBack();
           
            BT_PlayPause.BringToFront();
            BT_Stop.BringToFront();
            BTPrevious_Total.BringToFront();
            BTNext_Total.BringToFront();
            if (Manager.PhysioProject.signalList.GetSignalCountByType("Bio-SIGNAL") == 1)
            {
                Bar.SetBounds(PL_TaskLine.Location.X, Bar.Location.Y, Bar.Width, Bar.Height + 160 + 14);
            }
            else
            {
                Bar.SetBounds(PL_TaskLine.Location.X, Bar.Location.Y, Bar.Width, Bar.Height + 160);

            }
            draw_graph(CurrentSignal);

            newP.Visible = true;
            newP.BringToFront();

        }

        private void ReorderSignalPanels()
        {
            int i=0;
            foreach (TSignal s in Manager.PhysioProject.signalList)
            {
                if (s.type != "Bio-SIGNAL") continue;
                Panel p = (Panel)Total_Signal_PL.Controls["PanelSignal_" + s.ID];
                p.Location = new Point(p.Location.X,i*160);
                i++;                
            }
        }

        private void BTRemoveSignalClick_NK(object sender, EventArgs e)
        {
            string ID = ((Button)sender).Name.Split('_')[1];
                  
            if (MessageBox.Show("The Signal will be removed!!!" + Environment.NewLine + "Are you Sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                //1. Delete Signal
                TSignal DelSignal = Manager.PhysioProject.signalList.GetSignalByID(ID);
                Manager.PhysioProject.removeSignal(DelSignal);

                //2. Remove Panel
                Panel c = (Panel)Total_Signal_PL.Controls["PanelSignal_" + ID];
                this.Size = new Size(this.Width, this.Height - 160);//Αλλαγή ύψους της Φόρμας 
                Total_Signal_PL.Size = new Size(Total_Signal_PL.Width, Total_Signal_PL.Height - 160);//Αλλαγή ύψους Total panel                    
                Bar.Size = new Size(1, Bar.Height - 160);//Αρχικοποίηση Bar
                if (Manager.PhysioProject.signalList.GetSignalCountByType("Bio-SIGNAL") == 0)
                Bar.Size = new Size(1, 36);//Αρχικοποίηση Bar
                c.Dispose();
                ReorderSignalPanels();
            }
            else
            {
                //user clicked no
                return;
            }
        }

        #endregion

        #region//----Smoothing Process----//
        
        private void BT_Run_Correction_Click(object sender, EventArgs e)
        {    
            
            string ID = ((Button)sender).Name.Split('_')[1];
            Chart ch = (Chart)GetControl(((Button)sender).Parent.Parent, "ChartSignal_" + ID);//vriskw to grafima gia na plotarw//
            
            int index = int.Parse(ID);//deiktis gia na xeiristw tis listes
            
            NumericUpDown error = (NumericUpDown)GetControl(((Button)sender).Parent.Parent, "NUDErrorCorrection_" + ID);
            double current_selected_error= double.Parse(error.Value.ToString());;

            if (current_selected_error == 0) //elegxos giati mporei na xrypisw to run xwris pososto 
            {
                return;
            }
            else
            {
                Counter_For_Smooth_list[index] = Counter_For_Smooth_list[index] + 1;
                if (Counter_For_Smooth_list[index] == 1)
                {
                    error_list.Add(current_selected_error);//gia kathe sima tha exw mia lista pou tha krataw to error wste na to sigrinw me to epomeno
                    MWNumericArray arg1 = rawsignals[index];//Signal
                    MWNumericArray arg2 = current_selected_error / 100;//ErrorGoal default heuristic variable
                    MWNumericArray arg3 = 1 / t;//to kanw pali akeraio
                    result = smth_proc.smoothing_testing(1, arg1, arg2, arg3);//to 1 deixnei posa orismata tha exw exodo
                    output = (MWNumericArray)result[0];//krataw to smootharismeno sima
                    float[] array_from_mat = (float[])((MWNumericArray)output).ToVector(MWArrayComponent.Real);//metatrepw se double to sima apo matlab

                    for (int j = 0; j < array_from_mat.Length; j++)
                    {
                        alltables[index].Rows[j][7] = array_from_mat[j];

                    }
                    ch.Series[6].BorderWidth = 1;
                    ch.Series[6].Color = Color.Green;
                    ch.Series[6].XValueMember = alltables[index].Columns[0].ColumnName;
                    ch.Series[6].ChartType = SeriesChartType.Line;
                    ch.Series[6].YValueMembers = alltables[index].Columns[7].ColumnName;
                }
                else if (current_selected_error != error_list[index])//elegxos wste na min trexw to smooth gia idio pososto
                {
                    error_list[index] = current_selected_error;
                    MWNumericArray arg1 = rawsignals[index];//Signal
                    MWNumericArray arg2 = current_selected_error / 100;//ErrorGoal default heuristic variable
                    MWNumericArray arg3 = 1 / t;//to kanw pali akeraio
                    result = smth_proc.smoothing_testing(1, arg1, arg2, arg3);//to 1 deixnei posa orismata tha exw exodo
                    output = (MWNumericArray)result[0];//krataw to smootharismeno sima
                    float[] array_from_mat = (float[])((MWNumericArray)output).ToVector(MWArrayComponent.Real);//metatrepw se double to sima apo matlab

                    for (int j = 0; j < array_from_mat.Length; j++)
                    {
                        alltables[index].Rows[j][7] = array_from_mat[j];

                    }
                    ch.Series[6].BorderWidth = 1;
                    ch.Series[6].Color = Color.Green;
                    ch.Series[6].XValueMember = alltables[index].Columns[0].ColumnName;
                    ch.Series[6].ChartType = SeriesChartType.Line;
                    ch.Series[6].YValueMembers = alltables[index].Columns[7].ColumnName;
                }

            }
         
        }

        //----End of Smoothing Process----//
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.Top = 1;
        }


    }
}   