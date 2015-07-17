using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.PowerPacks;

namespace PhysiOBS
{
    public partial class Frm_Test : Form
    {
        
        public int move=165;
        public Frm_Test()
        {
            
            InitializeComponent();
        }

        private void BT_add_PhySignal_Click(object sender, EventArgs e)
        {     
            this.Size = new Size(this.Width, this.Height + 165);//Αλλαγή ύψους της Φόρμας 
            create_signal_panel(move);
            move+=165;
        }

        private void create_signal_panel(int move)
        {
            Panel PL_panel_Total = new Panel();
            this.Controls.Add(PL_panel_Total);
            PL_panel_Total.SetBounds(BT_clear_em.Location.X, BT_clear_em.Location.Y + move, BT_clear_em.Width, BT_clear_em.Height);

            Panel PL_emotion_panel = new Panel();
            this.Controls.Add(PL_emotion_panel);
            PL_emotion_panel.BackColor = Color.LightYellow;
            PL_emotion_panel.Parent = PL_panel_Total;
            PL_emotion_panel.SetBounds(PL_Emotions_Bar.Location.X, PL_Emotions_Bar.Location.Y, PL_Emotions_Bar.Width, PL_Emotions_Bar.Height);
            PL_emotion_panel.BringToFront();

            Panel PL_graph_panel = new Panel();
            this.Controls.Add(PL_graph_panel);
            PL_graph_panel.BackColor = Color.White;
            PL_graph_panel.Parent = PL_panel_Total;
            PL_graph_panel.SetBounds(PL_Signal1_Graph.Location.X, PL_Signal1_Graph.Location.Y, PL_Signal1_Graph.Width, PL_Signal1_Graph.Height);
            PL_graph_panel.BringToFront();

            Button BT_Add_Signal_2 = new Button();
            this.Controls.Add(BT_Add_Signal_2);
            BT_Add_Signal_2.BackgroundImage = Image.FromFile(@"C:\Users\aliapis\Desktop\PhysiOBS_testing_2\images\48(4).png");
            BT_Add_Signal_2.BackgroundImageLayout = ImageLayout.Stretch;
            BT_Add_Signal_2.Parent = PL_panel_Total;
            BT_Add_Signal_2.SetBounds(BT_Pro_S1.Location.X, BT_Pro_S1.Location.Y, BT_Pro_S1.Width, BT_Pro_S1.Height);
            BT_Add_Signal_2.BringToFront();

            Button BT_Remove_Signal_2 = new Button();
            this.Controls.Add(BT_Remove_Signal_2);
            BT_Remove_Signal_2.Enabled = false;
            BT_Remove_Signal_2.BackgroundImage = Image.FromFile(@"C:\Users\aliapis\Desktop\PhysiOBS_testing_2\images\rs.png");
            BT_Remove_Signal_2.BackgroundImageLayout = ImageLayout.Stretch;
            BT_Remove_Signal_2.Parent = PL_panel_Total;
            BT_Remove_Signal_2.SetBounds(BT_Remove_S1.Location.X, BT_Remove_S1.Location.Y, BT_Remove_S1.Width, BT_Remove_S1.Height);
            BT_Remove_Signal_2.BringToFront();

            Button BT_Next_CP_2 = new Button();
            this.Controls.Add(BT_Next_CP_2);
            BT_Next_CP_2.BackgroundImage = Image.FromFile(@"C:\Users\aliapis\Desktop\PhysiOBS_testing_2\images\forw.png");
            BT_Next_CP_2.BackgroundImageLayout = ImageLayout.Center;
            BT_Next_CP_2.Parent = PL_panel_Total;
            BT_Next_CP_2.SetBounds(BT_next_emotion.Location.X, BT_next_emotion.Location.Y, BT_next_emotion.Width, BT_next_emotion.Height);
            BT_Next_CP_2.BringToFront();

            Button BT_Previous_CP_2 = new Button();
            this.Controls.Add(BT_Previous_CP_2);
            BT_Previous_CP_2.BackgroundImage = Image.FromFile(@"C:\Users\aliapis\Desktop\PhysiOBS_testing_2\images\back.png");
            BT_Previous_CP_2.BackgroundImageLayout = ImageLayout.Center;
            BT_Previous_CP_2.Parent = PL_panel_Total;
            BT_Previous_CP_2.SetBounds(BT_previous_emotion.Location.X, BT_previous_emotion.Location.Y, BT_previous_emotion.Width, BT_previous_emotion.Height);
            BT_Previous_CP_2.BringToFront();

            Button BT_Obs_Emotion_2 = new Button();
            this.Controls.Add(BT_Obs_Emotion_2);
            BT_Obs_Emotion_2.BackgroundImage = Image.FromFile(@"C:\Users\aliapis\Desktop\PhysiOBS_testing_2\PhysiOBS\Resources\em_table.png");
            BT_Obs_Emotion_2.BackgroundImageLayout = ImageLayout.Stretch;
            BT_Obs_Emotion_2.Parent = PL_panel_Total;
            BT_Obs_Emotion_2.SetBounds(BT_Obs_Emotions.Location.X, BT_Obs_Emotions.Location.Y, BT_Obs_Emotions.Width, BT_Obs_Emotions.Height);
            BT_Obs_Emotion_2.BringToFront();

            GroupBox GB_Statistics_2 = new GroupBox();
            this.Controls.Add(GB_Statistics_2);
            GB_Statistics_2.Text = "Show on Graph";
            GB_Statistics_2.Parent = PL_panel_Total;
            GB_Statistics_2.SetBounds(GB_statistics.Location.X, GB_statistics.Location.Y, GB_statistics.Width, GB_statistics.Height);
            GB_Statistics_2.BringToFront();

            CheckBox CB_Mean_2 = new CheckBox();
            this.Controls.Add(CB_Mean_2);
            CB_Mean_2.Text = "Mean";
            CB_Mean_2.Enabled = false;
            CB_Mean_2.ForeColor = Color.Red;
            CB_Mean_2.Parent = GB_Statistics_2;
            CB_Mean_2.SetBounds(CB_Mean.Location.X, CB_Mean.Location.Y, CB_Mean.Width, CB_Mean.Height);
            CB_Mean_2.BringToFront();

            CheckBox CB_SD_pm1_2 = new CheckBox();
            this.Controls.Add(CB_SD_pm1_2);
            CB_SD_pm1_2.Text = "+/-1SD";
            CB_SD_pm1_2.Enabled = false;
            CB_SD_pm1_2.ForeColor = Color.Sienna;
            CB_SD_pm1_2.Parent = GB_Statistics_2;
            CB_SD_pm1_2.SetBounds(CB_SD_plusminus_1.Location.X, CB_SD_plusminus_1.Location.Y, CB_SD_plusminus_1.Width, CB_SD_plusminus_1.Height);
            CB_SD_pm1_2.BringToFront();

            CheckBox CB_SD_pm2_2 = new CheckBox();
            this.Controls.Add(CB_SD_pm2_2);
            CB_SD_pm2_2.Text = "+/-2SD";
            CB_SD_pm2_2.Enabled = false;
            CB_SD_pm2_2.ForeColor = Color.RoyalBlue;
            CB_SD_pm2_2.Parent = GB_Statistics_2;
            CB_SD_pm2_2.SetBounds(CB_SD_plusminus_2.Location.X, CB_SD_plusminus_2.Location.Y, CB_SD_plusminus_2.Width, CB_SD_plusminus_2.Height);
            CB_SD_pm2_2.BringToFront();

            TextBox TB_Mean_2 = new TextBox();
            this.Controls.Add(TB_Mean_2);
            TB_Mean_2.Parent = PL_panel_Total;
            TB_Mean_2.Text = "Mean";
            TB_Mean_2.ReadOnly = true;
            TB_Mean_2.SetBounds(TB_mean.Location.X, TB_mean.Location.Y, TB_mean.Width, TB_mean.Height);

            TextBox TB_StDev_2 = new TextBox();
            this.Controls.Add(TB_StDev_2);
            TB_StDev_2.Text = "St.Dev";
            TB_StDev_2.Parent = PL_panel_Total;
            TB_StDev_2.ReadOnly = true;
            TB_StDev_2.SetBounds(TB_std.Location.X, TB_std.Location.Y, TB_std.Width, TB_std.Height);

            Chart Chart_Signal2 = new Chart();
            this.Controls.Add(Chart_Signal2);
            Chart_Signal2.Parent = PL_graph_panel;
            Chart_Signal2.SetBounds(Chart_Signal2.Location.X, Chart_Signal2.Location.Y, Chart_Signal2.Width, Chart_Signal2.Height);
            Chart_Signal2.BringToFront();

           Label LB_S2 = new Label();
           this.Controls.Add(LB_S2);
           LB_S2.Parent=PL_panel_Total;
           LB_S2.Text = "....";
           LB_S2.SetBounds(LB_S1.Location.X, LB_S1.Location.Y, LB_S1.Width, LB_S1.Height);

           Label LB_obs_emotions_2 = new Label();
           this.Controls.Add(LB_obs_emotions_2);       
           LB_obs_emotions_2.Text = "Observed Emotions:";
           LB_obs_emotions_2.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
           LB_obs_emotions_2.Parent = PL_panel_Total;
           LB_obs_emotions_2.SetBounds(LB_obs_emotion.Location.X, LB_obs_emotion.Location.Y, LB_obs_emotion.Width, LB_obs_emotion.Height);
           LB_obs_emotions_2.BringToFront();

           
        }

        private void Chart_Signal2_Click(object sender, EventArgs e)
        {

        }
    }
}
