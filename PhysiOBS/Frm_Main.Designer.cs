namespace PhysiOBS
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.GB_uservideo = new System.Windows.Forms.GroupBox();
            this.MPlayer_UserVideo = new AxWMPLib.AxWindowsMediaPlayer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MPlayer_ScreenVideo = new AxWMPLib.AxWindowsMediaPlayer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BT_open_project = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BT_save_project = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BT_signal_analysis = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BT_emotion_options = new System.Windows.Forms.ToolStripButton();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.PL_TaskLine = new System.Windows.Forms.Panel();
            this.Bar = new System.Windows.Forms.Panel();
            this.Timer_Project = new System.Windows.Forms.Timer(this.components);
            this.tb_time = new System.Windows.Forms.TextBox();
            this.LB_Time = new System.Windows.Forms.Label();
            this.Obs_Emot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.upsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nervousnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmotionsMenou = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Total_Signal_PL = new System.Windows.Forms.Panel();
            this.LB_TaskLine = new System.Windows.Forms.Label();
            this.BT_Add_Video_S = new System.Windows.Forms.Button();
            this.BT_video_S_Properties = new System.Windows.Forms.Button();
            this.BT_video_U_properties = new System.Windows.Forms.Button();
            this.BT_Add_Video_U = new System.Windows.Forms.Button();
            this.BT_Task_Frm = new System.Windows.Forms.Button();
            this.AddSignalBT = new System.Windows.Forms.Button();
            this.BTNext_Task = new System.Windows.Forms.Button();
            this.BTPrevious_Task = new System.Windows.Forms.Button();
            this.BTNext_Total = new System.Windows.Forms.Button();
            this.BTPrevious_Total = new System.Windows.Forms.Button();
            this.BT_PlayPause = new System.Windows.Forms.Button();
            this.BT_Stop = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.GB_uservideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MPlayer_UserVideo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MPlayer_ScreenVideo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.EmotionsMenou.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_uservideo
            // 
            this.GB_uservideo.Controls.Add(this.MPlayer_UserVideo);
            this.GB_uservideo.Location = new System.Drawing.Point(57, 60);
            this.GB_uservideo.Name = "GB_uservideo";
            this.GB_uservideo.Size = new System.Drawing.Size(576, 370);
            this.GB_uservideo.TabIndex = 1;
            this.GB_uservideo.TabStop = false;
            this.GB_uservideo.Text = "User Observation";
            // 
            // MPlayer_UserVideo
            // 
            this.MPlayer_UserVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MPlayer_UserVideo.Enabled = true;
            this.MPlayer_UserVideo.Location = new System.Drawing.Point(3, 16);
            this.MPlayer_UserVideo.Name = "MPlayer_UserVideo";
            this.MPlayer_UserVideo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MPlayer_UserVideo.OcxState")));
            this.MPlayer_UserVideo.Size = new System.Drawing.Size(570, 351);
            this.MPlayer_UserVideo.TabIndex = 1;
            this.MPlayer_UserVideo.OpenStateChange += new AxWMPLib._WMPOCXEvents_OpenStateChangeEventHandler(this.MPlayer_UserVideo_OpenStateChange);
            this.MPlayer_UserVideo.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.MPlayer_UserVideo_PlayStateChange);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MPlayer_ScreenVideo);
            this.groupBox2.Location = new System.Drawing.Point(631, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 370);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Screen Capture";
            // 
            // MPlayer_ScreenVideo
            // 
            this.MPlayer_ScreenVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MPlayer_ScreenVideo.Enabled = true;
            this.MPlayer_ScreenVideo.Location = new System.Drawing.Point(3, 16);
            this.MPlayer_ScreenVideo.Name = "MPlayer_ScreenVideo";
            this.MPlayer_ScreenVideo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MPlayer_ScreenVideo.OcxState")));
            this.MPlayer_ScreenVideo.Size = new System.Drawing.Size(570, 351);
            this.MPlayer_ScreenVideo.TabIndex = 0;
            this.MPlayer_ScreenVideo.OpenStateChange += new AxWMPLib._WMPOCXEvents_OpenStateChangeEventHandler(this.MPlayer_ScreenVideo_OpenStateChange);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BT_open_project,
            this.toolStripSeparator4,
            this.BT_save_project,
            this.toolStripSeparator1,
            this.BT_signal_analysis,
            this.toolStripSeparator2,
            this.BT_emotion_options});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1257, 63);
            this.toolStrip1.TabIndex = 55;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BT_open_project
            // 
            this.BT_open_project.AutoSize = false;
            this.BT_open_project.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BT_open_project.Image = ((System.Drawing.Image)(resources.GetObject("BT_open_project.Image")));
            this.BT_open_project.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_open_project.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BT_open_project.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BT_open_project.Name = "BT_open_project";
            this.BT_open_project.Size = new System.Drawing.Size(50, 50);
            this.BT_open_project.Text = "Open Project";
            this.BT_open_project.Click += new System.EventHandler(this.BT_open_project_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 63);
            // 
            // BT_save_project
            // 
            this.BT_save_project.AutoSize = false;
            this.BT_save_project.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BT_save_project.Image = ((System.Drawing.Image)(resources.GetObject("BT_save_project.Image")));
            this.BT_save_project.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BT_save_project.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BT_save_project.Name = "BT_save_project";
            this.BT_save_project.Size = new System.Drawing.Size(50, 50);
            this.BT_save_project.Text = "Save Project";
            this.BT_save_project.Click += new System.EventHandler(this.BT_save_project_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 63);
            // 
            // BT_signal_analysis
            // 
            this.BT_signal_analysis.AutoSize = false;
            this.BT_signal_analysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BT_signal_analysis.Image = ((System.Drawing.Image)(resources.GetObject("BT_signal_analysis.Image")));
            this.BT_signal_analysis.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BT_signal_analysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BT_signal_analysis.Name = "BT_signal_analysis";
            this.BT_signal_analysis.Size = new System.Drawing.Size(50, 50);
            this.BT_signal_analysis.Text = "Signal Analysis";
            this.BT_signal_analysis.Click += new System.EventHandler(this.BT_signal_analysis_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 63);
            // 
            // BT_emotion_options
            // 
            this.BT_emotion_options.AutoSize = false;
            this.BT_emotion_options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BT_emotion_options.Image = global::PhysiOBS.Properties.Resources._48;
            this.BT_emotion_options.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BT_emotion_options.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BT_emotion_options.Margin = new System.Windows.Forms.Padding(0);
            this.BT_emotion_options.Name = "BT_emotion_options";
            this.BT_emotion_options.Size = new System.Drawing.Size(50, 50);
            this.BT_emotion_options.Text = "Emotion Options";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1265, 585);
            this.shapeContainer1.TabIndex = 59;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.Blue;
            this.lineShape2.BorderWidth = 3;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 5;
            this.lineShape2.X2 = 1259;
            this.lineShape2.Y1 = 434;
            this.lineShape2.Y2 = 434;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Blue;
            this.lineShape1.BorderWidth = 3;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 4;
            this.lineShape1.X2 = 1260;
            this.lineShape1.Y1 = 512;
            this.lineShape1.Y2 = 512;
            // 
            // PL_TaskLine
            // 
            this.PL_TaskLine.ForeColor = System.Drawing.Color.Black;
            this.PL_TaskLine.Location = new System.Drawing.Point(171, 462);
            this.PL_TaskLine.Name = "PL_TaskLine";
            this.PL_TaskLine.Size = new System.Drawing.Size(985, 37);
            this.PL_TaskLine.TabIndex = 71;
            this.PL_TaskLine.Paint += new System.Windows.Forms.PaintEventHandler(this.PL_TaskLine_Paint);
            // 
            // Bar
            // 
            this.Bar.BackColor = System.Drawing.Color.Maroon;
            this.Bar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.Bar.Location = new System.Drawing.Point(170, 462);
            this.Bar.Margin = new System.Windows.Forms.Padding(0);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(1, 36);
            this.Bar.TabIndex = 53;
            this.Bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Bar_MouseDown);
            this.Bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Bar_MouseMove);
            this.Bar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Bar_MouseUp);
            // 
            // Timer_Project
            // 
            this.Timer_Project.Tick += new System.EventHandler(this.Timer_Project_Tick);
            // 
            // tb_time
            // 
            this.tb_time.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tb_time.BackColor = System.Drawing.SystemColors.Info;
            this.tb_time.Enabled = false;
            this.tb_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tb_time.Location = new System.Drawing.Point(791, 537);
            this.tb_time.Name = "tb_time";
            this.tb_time.Size = new System.Drawing.Size(103, 24);
            this.tb_time.TabIndex = 74;
            this.tb_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_time_KeyPress);
            // 
            // LB_Time
            // 
            this.LB_Time.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LB_Time.AutoSize = true;
            this.LB_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Time.Location = new System.Drawing.Point(902, 539);
            this.LB_Time.Name = "LB_Time";
            this.LB_Time.Size = new System.Drawing.Size(91, 20);
            this.LB_Time.TabIndex = 75;
            this.LB_Time.Text = "Time in Sec";
            // 
            // Obs_Emot
            // 
            this.Obs_Emot.Name = "Obs_Emot";
            this.Obs_Emot.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.upsetToolStripMenuItem,
            this.nervousnessToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 136);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem1.Text = "Anger";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem2.Text = "Anxiety";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem3.Text = "Happiness";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem4.Text = "Uncertainty";
            // 
            // upsetToolStripMenuItem
            // 
            this.upsetToolStripMenuItem.Name = "upsetToolStripMenuItem";
            this.upsetToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.upsetToolStripMenuItem.Text = "Upset";
            // 
            // nervousnessToolStripMenuItem
            // 
            this.nervousnessToolStripMenuItem.Name = "nervousnessToolStripMenuItem";
            this.nervousnessToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.nervousnessToolStripMenuItem.Text = "Nervousness";
            // 
            // EmotionsMenou
            // 
            this.EmotionsMenou.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6});
            this.EmotionsMenou.Name = "EmotionsMenou";
            this.EmotionsMenou.Size = new System.Drawing.Size(108, 26);
            this.EmotionsMenou.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.EmotionsMenou_ItemClicked);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem6.Text = "Delete";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "Properties";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // Total_Signal_PL
            // 
            this.Total_Signal_PL.Location = new System.Drawing.Point(2, 518);
            this.Total_Signal_PL.Name = "Total_Signal_PL";
            this.Total_Signal_PL.Size = new System.Drawing.Size(1262, 0);
            this.Total_Signal_PL.TabIndex = 99;
            // 
            // LB_TaskLine
            // 
            this.LB_TaskLine.AutoSize = true;
            this.LB_TaskLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_TaskLine.Location = new System.Drawing.Point(596, 443);
            this.LB_TaskLine.Name = "LB_TaskLine";
            this.LB_TaskLine.Size = new System.Drawing.Size(66, 16);
            this.LB_TaskLine.TabIndex = 100;
            this.LB_TaskLine.Text = "Task Bar ";
            // 
            // BT_Add_Video_S
            // 
            this.BT_Add_Video_S.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Add_Video_S.BackgroundImage")));
            this.BT_Add_Video_S.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_Add_Video_S.Location = new System.Drawing.Point(1210, 76);
            this.BT_Add_Video_S.Name = "BT_Add_Video_S";
            this.BT_Add_Video_S.Size = new System.Drawing.Size(50, 50);
            this.BT_Add_Video_S.TabIndex = 23;
            this.toolTip.SetToolTip(this.BT_Add_Video_S, "Open Screen Video");
            this.BT_Add_Video_S.UseVisualStyleBackColor = true;
            this.BT_Add_Video_S.Click += new System.EventHandler(this.BT_Add_Video_S_Click);
            // 
            // BT_video_S_Properties
            // 
            this.BT_video_S_Properties.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_video_S_Properties.BackgroundImage")));
            this.BT_video_S_Properties.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_video_S_Properties.Enabled = false;
            this.BT_video_S_Properties.Location = new System.Drawing.Point(1210, 132);
            this.BT_video_S_Properties.Name = "BT_video_S_Properties";
            this.BT_video_S_Properties.Size = new System.Drawing.Size(50, 50);
            this.BT_video_S_Properties.TabIndex = 24;
            this.toolTip.SetToolTip(this.BT_video_S_Properties, "Screen Option");
            this.BT_video_S_Properties.UseVisualStyleBackColor = true;
            this.BT_video_S_Properties.Click += new System.EventHandler(this.BT_video_S_Properties_Click);
            // 
            // BT_video_U_properties
            // 
            this.BT_video_U_properties.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_video_U_properties.BackgroundImage")));
            this.BT_video_U_properties.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_video_U_properties.Enabled = false;
            this.BT_video_U_properties.Location = new System.Drawing.Point(5, 133);
            this.BT_video_U_properties.Name = "BT_video_U_properties";
            this.BT_video_U_properties.Size = new System.Drawing.Size(50, 50);
            this.BT_video_U_properties.TabIndex = 22;
            this.toolTip.SetToolTip(this.BT_video_U_properties, "User\'s options");
            this.BT_video_U_properties.UseVisualStyleBackColor = true;
            this.BT_video_U_properties.Click += new System.EventHandler(this.BT_video_U_properties_Click);
            // 
            // BT_Add_Video_U
            // 
            this.BT_Add_Video_U.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Add_Video_U.BackgroundImage")));
            this.BT_Add_Video_U.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_Add_Video_U.Location = new System.Drawing.Point(5, 76);
            this.BT_Add_Video_U.Name = "BT_Add_Video_U";
            this.BT_Add_Video_U.Size = new System.Drawing.Size(50, 50);
            this.BT_Add_Video_U.TabIndex = 21;
            this.toolTip.SetToolTip(this.BT_Add_Video_U, "Open User\'s Video");
            this.BT_Add_Video_U.UseVisualStyleBackColor = true;
            this.BT_Add_Video_U.Click += new System.EventHandler(this.BT_Add_Video_U_Click_1);
            // 
            // BT_Task_Frm
            // 
            this.BT_Task_Frm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_Task_Frm.Enabled = false;
            this.BT_Task_Frm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.BT_Task_Frm.Image = global::PhysiOBS.Properties.Resources.task_are;
            this.BT_Task_Frm.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BT_Task_Frm.Location = new System.Drawing.Point(1159, 438);
            this.BT_Task_Frm.Name = "BT_Task_Frm";
            this.BT_Task_Frm.Size = new System.Drawing.Size(103, 69);
            this.BT_Task_Frm.TabIndex = 58;
            this.BT_Task_Frm.Text = "Add/Remove/Edit Tasks";
            this.BT_Task_Frm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BT_Task_Frm.UseVisualStyleBackColor = true;
            this.BT_Task_Frm.Click += new System.EventHandler(this.BT_Task_Frm_Click);
            // 
            // AddSignalBT
            // 
            this.AddSignalBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddSignalBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.AddSignalBT.Image = global::PhysiOBS.Properties.Resources.AddSignal;
            this.AddSignalBT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddSignalBT.Location = new System.Drawing.Point(4, 438);
            this.AddSignalBT.Name = "AddSignalBT";
            this.AddSignalBT.Size = new System.Drawing.Size(61, 70);
            this.AddSignalBT.TabIndex = 41;
            this.AddSignalBT.Text = "Add \r\nSignal";
            this.AddSignalBT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.AddSignalBT, "Add Physiological Signal");
            this.AddSignalBT.UseVisualStyleBackColor = true;
            this.AddSignalBT.Click += new System.EventHandler(this.BTAddSignalClick);
            // 
            // BTNext_Task
            // 
            this.BTNext_Task.Image = global::PhysiOBS.Properties.Resources.forw;
            this.BTNext_Task.Location = new System.Drawing.Point(120, 462);
            this.BTNext_Task.Name = "BTNext_Task";
            this.BTNext_Task.Size = new System.Drawing.Size(45, 37);
            this.BTNext_Task.TabIndex = 91;
            this.toolTip.SetToolTip(this.BTNext_Task, "Next Point");
            this.BTNext_Task.UseVisualStyleBackColor = true;
            this.BTNext_Task.Click += new System.EventHandler(this.ΒΤNextClick);
            // 
            // BTPrevious_Task
            // 
            this.BTPrevious_Task.Image = global::PhysiOBS.Properties.Resources.back;
            this.BTPrevious_Task.Location = new System.Drawing.Point(72, 462);
            this.BTPrevious_Task.Name = "BTPrevious_Task";
            this.BTPrevious_Task.Size = new System.Drawing.Size(45, 37);
            this.BTPrevious_Task.TabIndex = 90;
            this.toolTip.SetToolTip(this.BTPrevious_Task, "Previous Point");
            this.BTPrevious_Task.UseVisualStyleBackColor = true;
            this.BTPrevious_Task.Click += new System.EventHandler(this.BTPreviousClick);
            // 
            // BTNext_Total
            // 
            this.BTNext_Total.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTNext_Total.Image = ((System.Drawing.Image)(resources.GetObject("BTNext_Total.Image")));
            this.BTNext_Total.Location = new System.Drawing.Point(718, 523);
            this.BTNext_Total.Name = "BTNext_Total";
            this.BTNext_Total.Size = new System.Drawing.Size(58, 55);
            this.BTNext_Total.TabIndex = 77;
            this.toolTip.SetToolTip(this.BTNext_Total, "Next point (Task-Signal)");
            this.BTNext_Total.UseVisualStyleBackColor = true;
            this.BTNext_Total.Click += new System.EventHandler(this.ΒΤNextClick);
            // 
            // BTPrevious_Total
            // 
            this.BTPrevious_Total.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTPrevious_Total.Image = ((System.Drawing.Image)(resources.GetObject("BTPrevious_Total.Image")));
            this.BTPrevious_Total.Location = new System.Drawing.Point(475, 523);
            this.BTPrevious_Total.Name = "BTPrevious_Total";
            this.BTPrevious_Total.Size = new System.Drawing.Size(62, 55);
            this.BTPrevious_Total.TabIndex = 76;
            this.toolTip.SetToolTip(this.BTPrevious_Total, "Previous Point (Task-Signal)");
            this.BTPrevious_Total.UseVisualStyleBackColor = true;
            this.BTPrevious_Total.Click += new System.EventHandler(this.BTPreviousClick);
            // 
            // BT_PlayPause
            // 
            this.BT_PlayPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_PlayPause.Enabled = false;
            this.BT_PlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.BT_PlayPause.Image = global::PhysiOBS.Properties.Resources.play;
            this.BT_PlayPause.Location = new System.Drawing.Point(559, 523);
            this.BT_PlayPause.Name = "BT_PlayPause";
            this.BT_PlayPause.Size = new System.Drawing.Size(56, 55);
            this.BT_PlayPause.TabIndex = 36;
            this.BT_PlayPause.Text = " ";
            this.toolTip.SetToolTip(this.BT_PlayPause, "Play All");
            this.BT_PlayPause.UseVisualStyleBackColor = true;
            this.BT_PlayPause.Click += new System.EventHandler(this.BT_Pause_Click);
            // 
            // BT_Stop
            // 
            this.BT_Stop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Stop.Enabled = false;
            this.BT_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.BT_Stop.Image = ((System.Drawing.Image)(resources.GetObject("BT_Stop.Image")));
            this.BT_Stop.Location = new System.Drawing.Point(638, 523);
            this.BT_Stop.Name = "BT_Stop";
            this.BT_Stop.Size = new System.Drawing.Size(58, 55);
            this.BT_Stop.TabIndex = 37;
            this.toolTip.SetToolTip(this.BT_Stop, "Stop All");
            this.BT_Stop.UseVisualStyleBackColor = true;
            this.BT_Stop.Click += new System.EventHandler(this.BT_Stop_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1265, 585);
            this.Controls.Add(this.LB_TaskLine);
            this.Controls.Add(this.BT_Add_Video_S);
            this.Controls.Add(this.BT_video_S_Properties);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GB_uservideo);
            this.Controls.Add(this.BT_video_U_properties);
            this.Controls.Add(this.BT_Add_Video_U);
            this.Controls.Add(this.BT_Task_Frm);
            this.Controls.Add(this.AddSignalBT);
            this.Controls.Add(this.BTNext_Task);
            this.Controls.Add(this.BTPrevious_Task);
            this.Controls.Add(this.BTNext_Total);
            this.Controls.Add(this.BTPrevious_Total);
            this.Controls.Add(this.BT_PlayPause);
            this.Controls.Add(this.BT_Stop);
            this.Controls.Add(this.Bar);
            this.Controls.Add(this.LB_Time);
            this.Controls.Add(this.tb_time);
            this.Controls.Add(this.PL_TaskLine);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Total_Signal_PL);
            this.Controls.Add(this.shapeContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1281, 624);
            this.Name = "Frm_Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.GB_uservideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MPlayer_UserVideo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MPlayer_ScreenVideo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.EmotionsMenou.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_uservideo;
        private AxWMPLib.AxWindowsMediaPlayer MPlayer_UserVideo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BT_Add_Video_U;
        private System.Windows.Forms.Button BT_video_U_properties;
        private System.Windows.Forms.Button BT_video_S_Properties;
        private System.Windows.Forms.Button BT_Add_Video_S;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BT_Stop;
        private System.Windows.Forms.Button BT_PlayPause;
        private System.Windows.Forms.Button AddSignalBT;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BT_save_project;
        private System.Windows.Forms.ToolStripButton BT_open_project;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BT_signal_analysis;
        private System.Windows.Forms.Button BT_Task_Frm;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private AxWMPLib.AxWindowsMediaPlayer MPlayer_ScreenVideo;
        private System.Windows.Forms.Panel Bar;
        private System.Windows.Forms.Timer Timer_Project;
        private System.Windows.Forms.TextBox tb_time;
        private System.Windows.Forms.Label LB_Time;
        private System.Windows.Forms.Button BTPrevious_Total;
        private System.Windows.Forms.Button BTNext_Total;
        private System.Windows.Forms.ContextMenuStrip Obs_Emot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BT_emotion_options;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.Panel PL_TaskLine;
        private System.Windows.Forms.ContextMenuStrip EmotionsMenou;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.Button BTPrevious_Task;
        private System.Windows.Forms.Button BTNext_Task;
        private System.Windows.Forms.ToolStripMenuItem upsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nervousnessToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel Total_Signal_PL;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label LB_TaskLine;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

