namespace PhysiOBS
{
    partial class Frm_Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Test));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BT_add_PhySignal = new System.Windows.Forms.Button();
            this.BT_clear_em = new System.Windows.Forms.Panel();
            this.GB_statistics = new System.Windows.Forms.GroupBox();
            this.CB_SD_plusminus_2 = new System.Windows.Forms.CheckBox();
            this.CB_Mean = new System.Windows.Forms.CheckBox();
            this.CB_SD_plusminus_1 = new System.Windows.Forms.CheckBox();
            this.TB_mean = new System.Windows.Forms.TextBox();
            this.TB_std = new System.Windows.Forms.TextBox();
            this.BT_Obs_Emotions = new System.Windows.Forms.Button();
            this.BT_previous_emotion = new System.Windows.Forms.Button();
            this.BT_next_emotion = new System.Windows.Forms.Button();
            this.LB_obs_emotion = new System.Windows.Forms.Label();
            this.PL_Emotions_Bar = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.LB_S1 = new System.Windows.Forms.Label();
            this.BT_Pro_S1 = new System.Windows.Forms.Button();
            this.BT_Remove_S1 = new System.Windows.Forms.Button();
            this.PL_Signal1_Graph = new System.Windows.Forms.Panel();
            this.Chart_Signal2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.Line_up = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.Line_down = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.BT_clear_em.SuspendLayout();
            this.GB_statistics.SuspendLayout();
            this.PL_Signal1_Graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Signal2)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_add_PhySignal
            // 
            this.BT_add_PhySignal.Location = new System.Drawing.Point(4, 3);
            this.BT_add_PhySignal.Name = "BT_add_PhySignal";
            this.BT_add_PhySignal.Size = new System.Drawing.Size(78, 26);
            this.BT_add_PhySignal.TabIndex = 91;
            this.BT_add_PhySignal.Text = "Add Signal";
            this.BT_add_PhySignal.UseVisualStyleBackColor = true;
            this.BT_add_PhySignal.Click += new System.EventHandler(this.BT_add_PhySignal_Click);
            // 
            // BT_clear_em
            // 
            this.BT_clear_em.Controls.Add(this.GB_statistics);
            this.BT_clear_em.Controls.Add(this.TB_mean);
            this.BT_clear_em.Controls.Add(this.TB_std);
            this.BT_clear_em.Controls.Add(this.BT_Obs_Emotions);
            this.BT_clear_em.Controls.Add(this.BT_previous_emotion);
            this.BT_clear_em.Controls.Add(this.BT_next_emotion);
            this.BT_clear_em.Controls.Add(this.LB_obs_emotion);
            this.BT_clear_em.Controls.Add(this.PL_Emotions_Bar);
            this.BT_clear_em.Controls.Add(this.label5);
            this.BT_clear_em.Controls.Add(this.LB_S1);
            this.BT_clear_em.Controls.Add(this.BT_Pro_S1);
            this.BT_clear_em.Controls.Add(this.BT_Remove_S1);
            this.BT_clear_em.Controls.Add(this.PL_Signal1_Graph);
            this.BT_clear_em.Controls.Add(this.shapeContainer1);
            this.BT_clear_em.Location = new System.Drawing.Point(4, 35);
            this.BT_clear_em.Name = "BT_clear_em";
            this.BT_clear_em.Size = new System.Drawing.Size(1253, 156);
            this.BT_clear_em.TabIndex = 92;
            // 
            // GB_statistics
            // 
            this.GB_statistics.Controls.Add(this.CB_SD_plusminus_2);
            this.GB_statistics.Controls.Add(this.CB_Mean);
            this.GB_statistics.Controls.Add(this.CB_SD_plusminus_1);
            this.GB_statistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.GB_statistics.Location = new System.Drawing.Point(1155, 7);
            this.GB_statistics.Name = "GB_statistics";
            this.GB_statistics.Size = new System.Drawing.Size(95, 92);
            this.GB_statistics.TabIndex = 104;
            this.GB_statistics.TabStop = false;
            this.GB_statistics.Text = "Show on Graph";
            // 
            // CB_SD_plusminus_2
            // 
            this.CB_SD_plusminus_2.AutoSize = true;
            this.CB_SD_plusminus_2.Enabled = false;
            this.CB_SD_plusminus_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.CB_SD_plusminus_2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.CB_SD_plusminus_2.Location = new System.Drawing.Point(6, 65);
            this.CB_SD_plusminus_2.Name = "CB_SD_plusminus_2";
            this.CB_SD_plusminus_2.Size = new System.Drawing.Size(61, 17);
            this.CB_SD_plusminus_2.TabIndex = 103;
            this.CB_SD_plusminus_2.Text = "+/-2SD";
            this.CB_SD_plusminus_2.UseVisualStyleBackColor = true;
            // 
            // CB_Mean
            // 
            this.CB_Mean.AutoSize = true;
            this.CB_Mean.Enabled = false;
            this.CB_Mean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.CB_Mean.ForeColor = System.Drawing.Color.Red;
            this.CB_Mean.Location = new System.Drawing.Point(6, 19);
            this.CB_Mean.Name = "CB_Mean";
            this.CB_Mean.Size = new System.Drawing.Size(53, 17);
            this.CB_Mean.TabIndex = 101;
            this.CB_Mean.Text = "Mean";
            this.CB_Mean.UseVisualStyleBackColor = true;
            // 
            // CB_SD_plusminus_1
            // 
            this.CB_SD_plusminus_1.AutoSize = true;
            this.CB_SD_plusminus_1.Enabled = false;
            this.CB_SD_plusminus_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.CB_SD_plusminus_1.ForeColor = System.Drawing.Color.Sienna;
            this.CB_SD_plusminus_1.Location = new System.Drawing.Point(6, 42);
            this.CB_SD_plusminus_1.Name = "CB_SD_plusminus_1";
            this.CB_SD_plusminus_1.Size = new System.Drawing.Size(61, 17);
            this.CB_SD_plusminus_1.TabIndex = 102;
            this.CB_SD_plusminus_1.Text = "+/-1SD";
            this.CB_SD_plusminus_1.UseVisualStyleBackColor = true;
            // 
            // TB_mean
            // 
            this.TB_mean.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TB_mean.Location = new System.Drawing.Point(1211, 105);
            this.TB_mean.Multiline = true;
            this.TB_mean.Name = "TB_mean";
            this.TB_mean.ReadOnly = true;
            this.TB_mean.Size = new System.Drawing.Size(39, 19);
            this.TB_mean.TabIndex = 98;
            this.TB_mean.Text = "Mean";
            // 
            // TB_std
            // 
            this.TB_std.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TB_std.Location = new System.Drawing.Point(1211, 131);
            this.TB_std.Multiline = true;
            this.TB_std.Name = "TB_std";
            this.TB_std.ReadOnly = true;
            this.TB_std.Size = new System.Drawing.Size(39, 19);
            this.TB_std.TabIndex = 96;
            this.TB_std.Text = "St.Dev";
            // 
            // BT_Obs_Emotions
            // 
            this.BT_Obs_Emotions.BackgroundImage = global::PhysiOBS.Properties.Resources.em_table;
            this.BT_Obs_Emotions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_Obs_Emotions.Enabled = false;
            this.BT_Obs_Emotions.Location = new System.Drawing.Point(1155, 107);
            this.BT_Obs_Emotions.Name = "BT_Obs_Emotions";
            this.BT_Obs_Emotions.Size = new System.Drawing.Size(45, 43);
            this.BT_Obs_Emotions.TabIndex = 93;
            this.BT_Obs_Emotions.UseVisualStyleBackColor = true;
            // 
            // BT_previous_emotion
            // 
            this.BT_previous_emotion.Image = ((System.Drawing.Image)(resources.GetObject("BT_previous_emotion.Image")));
            this.BT_previous_emotion.Location = new System.Drawing.Point(112, 2);
            this.BT_previous_emotion.Name = "BT_previous_emotion";
            this.BT_previous_emotion.Size = new System.Drawing.Size(45, 38);
            this.BT_previous_emotion.TabIndex = 92;
            this.BT_previous_emotion.UseVisualStyleBackColor = true;
            // 
            // BT_next_emotion
            // 
            this.BT_next_emotion.Image = ((System.Drawing.Image)(resources.GetObject("BT_next_emotion.Image")));
            this.BT_next_emotion.Location = new System.Drawing.Point(112, 46);
            this.BT_next_emotion.Name = "BT_next_emotion";
            this.BT_next_emotion.Size = new System.Drawing.Size(45, 38);
            this.BT_next_emotion.TabIndex = 92;
            this.BT_next_emotion.UseVisualStyleBackColor = true;
            // 
            // LB_obs_emotion
            // 
            this.LB_obs_emotion.AutoSize = true;
            this.LB_obs_emotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_obs_emotion.Location = new System.Drawing.Point(11, 123);
            this.LB_obs_emotion.Name = "LB_obs_emotion";
            this.LB_obs_emotion.Size = new System.Drawing.Size(135, 15);
            this.LB_obs_emotion.TabIndex = 90;
            this.LB_obs_emotion.Text = "Observed Emotions:";
            // 
            // PL_Emotions_Bar
            // 
            this.PL_Emotions_Bar.BackColor = System.Drawing.Color.LightYellow;
            this.PL_Emotions_Bar.Cursor = System.Windows.Forms.Cursors.Default;
            this.PL_Emotions_Bar.Location = new System.Drawing.Point(162, 111);
            this.PL_Emotions_Bar.Margin = new System.Windows.Forms.Padding(0);
            this.PL_Emotions_Bar.Name = "PL_Emotions_Bar";
            this.PL_Emotions_Bar.Size = new System.Drawing.Size(990, 42);
            this.PL_Emotions_Bar.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(2, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Signal 1 / Options";
            // 
            // LB_S1
            // 
            this.LB_S1.AllowDrop = true;
            this.LB_S1.AutoSize = true;
            this.LB_S1.Location = new System.Drawing.Point(5, 86);
            this.LB_S1.Name = "LB_S1";
            this.LB_S1.Size = new System.Drawing.Size(22, 13);
            this.LB_S1.TabIndex = 40;
            this.LB_S1.Text = ".....";
            this.LB_S1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BT_Pro_S1
            // 
            this.BT_Pro_S1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Pro_S1.BackgroundImage")));
            this.BT_Pro_S1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_Pro_S1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BT_Pro_S1.Location = new System.Drawing.Point(8, 21);
            this.BT_Pro_S1.Name = "BT_Pro_S1";
            this.BT_Pro_S1.Size = new System.Drawing.Size(45, 45);
            this.BT_Pro_S1.TabIndex = 41;
            this.BT_Pro_S1.UseVisualStyleBackColor = true;
            // 
            // BT_Remove_S1
            // 
            this.BT_Remove_S1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_Remove_S1.BackgroundImage")));
            this.BT_Remove_S1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_Remove_S1.Enabled = false;
            this.BT_Remove_S1.ForeColor = System.Drawing.Color.Silver;
            this.BT_Remove_S1.Location = new System.Drawing.Point(57, 21);
            this.BT_Remove_S1.Name = "BT_Remove_S1";
            this.BT_Remove_S1.Size = new System.Drawing.Size(45, 45);
            this.BT_Remove_S1.TabIndex = 42;
            this.BT_Remove_S1.UseVisualStyleBackColor = true;
            // 
            // PL_Signal1_Graph
            // 
            this.PL_Signal1_Graph.Controls.Add(this.Chart_Signal2);
            this.PL_Signal1_Graph.Location = new System.Drawing.Point(162, 0);
            this.PL_Signal1_Graph.Name = "PL_Signal1_Graph";
            this.PL_Signal1_Graph.Size = new System.Drawing.Size(990, 108);
            this.PL_Signal1_Graph.TabIndex = 50;
            // 
            // Chart_Signal2
            // 
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.Chart_Signal2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart_Signal2.Legends.Add(legend1);
            this.Chart_Signal2.Location = new System.Drawing.Point(0, 1);
            this.Chart_Signal2.Name = "Chart_Signal2";
            this.Chart_Signal2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Time && Raw";
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Time && Mean";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Time && 1SD";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Time && -1 SD";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Time && 2 SD";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsVisibleInLegend = false;
            series6.Legend = "Legend1";
            series6.Name = "Time && -2 SD";
            this.Chart_Signal2.Series.Add(series1);
            this.Chart_Signal2.Series.Add(series2);
            this.Chart_Signal2.Series.Add(series3);
            this.Chart_Signal2.Series.Add(series4);
            this.Chart_Signal2.Series.Add(series5);
            this.Chart_Signal2.Series.Add(series6);
            this.Chart_Signal2.Size = new System.Drawing.Size(990, 105);
            this.Chart_Signal2.TabIndex = 0;
            this.Chart_Signal2.Text = "chart1";
            this.Chart_Signal2.Click += new System.EventHandler(this.Chart_Signal2_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.Line_up,
            this.Line_down});
            this.shapeContainer1.Size = new System.Drawing.Size(1253, 156);
            this.shapeContainer1.TabIndex = 89;
            this.shapeContainer1.TabStop = false;
            // 
            // Line_up
            // 
            this.Line_up.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.Line_up.BorderWidth = 2;
            this.Line_up.Name = "Line_up";
            this.Line_up.X1 = 163;
            this.Line_up.X2 = 0;
            this.Line_up.Y1 = 113;
            this.Line_up.Y2 = 113;
            // 
            // Line_down
            // 
            this.Line_down.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.Line_down.BorderWidth = 2;
            this.Line_down.Name = "Line_down";
            this.Line_down.X1 = 0;
            this.Line_down.X2 = 162;
            this.Line_down.Y1 = 151;
            this.Line_down.Y2 = 151;
            // 
            // Frm_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 199);
            this.Controls.Add(this.BT_clear_em);
            this.Controls.Add(this.BT_add_PhySignal);
            this.Name = "Frm_Test";
            this.Text = "Frm_Test";
            this.BT_clear_em.ResumeLayout(false);
            this.BT_clear_em.PerformLayout();
            this.GB_statistics.ResumeLayout(false);
            this.GB_statistics.PerformLayout();
            this.PL_Signal1_Graph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Signal2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_add_PhySignal;
        private System.Windows.Forms.Panel BT_clear_em;
        private System.Windows.Forms.GroupBox GB_statistics;
        private System.Windows.Forms.CheckBox CB_SD_plusminus_2;
        private System.Windows.Forms.CheckBox CB_Mean;
        private System.Windows.Forms.CheckBox CB_SD_plusminus_1;
        private System.Windows.Forms.TextBox TB_mean;
        private System.Windows.Forms.TextBox TB_std;
        private System.Windows.Forms.Button BT_Obs_Emotions;
        private System.Windows.Forms.Button BT_previous_emotion;
        private System.Windows.Forms.Button BT_next_emotion;
        private System.Windows.Forms.Label LB_obs_emotion;
        private System.Windows.Forms.Panel PL_Emotions_Bar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LB_S1;
        private System.Windows.Forms.Button BT_Pro_S1;
        private System.Windows.Forms.Button BT_Remove_S1;
        private System.Windows.Forms.Panel PL_Signal1_Graph;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Signal2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape Line_up;
        private Microsoft.VisualBasic.PowerPacks.LineShape Line_down;
    }
}