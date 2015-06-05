namespace PhysiOBS
{
    partial class Frm_Emotions_Grid
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.EmotionGridView = new System.Windows.Forms.DataGridView();
            this.LB_Anger = new System.Windows.Forms.Label();
            this.LB_Uncertainty = new System.Windows.Forms.Label();
            this.LB_happiness = new System.Windows.Forms.Label();
            this.LB_Anxiety = new System.Windows.Forms.Label();
            this.LB_Upset = new System.Windows.Forms.Label();
            this.LB_Nervousness = new System.Windows.Forms.Label();
            this.TB_Angertime = new System.Windows.Forms.TextBox();
            this.TB_Anxietytime = new System.Windows.Forms.TextBox();
            this.TB_Happinesstime = new System.Windows.Forms.TextBox();
            this.TB_Uncerttime = new System.Windows.Forms.TextBox();
            this.TB_Upsettime = new System.Windows.Forms.TextBox();
            this.TB_Nervousenesstime = new System.Windows.Forms.TextBox();
            this.GB_EmotionsTime = new System.Windows.Forms.GroupBox();
            this.LB_required = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BT_DeleteEmotion = new System.Windows.Forms.Button();
            this.BT_AddEmotion = new System.Windows.Forms.Button();
            this.cl1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.EmotionGridView)).BeginInit();
            this.GB_EmotionsTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // EmotionGridView
            // 
            this.EmotionGridView.AllowUserToAddRows = false;
            this.EmotionGridView.AllowUserToDeleteRows = false;
            this.EmotionGridView.AllowUserToResizeColumns = false;
            this.EmotionGridView.AllowUserToResizeRows = false;
            this.EmotionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmotionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl1,
            this.cl2,
            this.cl3,
            this.cl4});
            this.EmotionGridView.Location = new System.Drawing.Point(5, 49);
            this.EmotionGridView.Name = "EmotionGridView";
            this.EmotionGridView.Size = new System.Drawing.Size(810, 28);
            this.EmotionGridView.TabIndex = 0;
            this.EmotionGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmotionGridView_CellEndEdit);
            // 
            // LB_Anger
            // 
            this.LB_Anger.AutoSize = true;
            this.LB_Anger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Anger.Location = new System.Drawing.Point(50, 26);
            this.LB_Anger.Name = "LB_Anger";
            this.LB_Anger.Size = new System.Drawing.Size(52, 20);
            this.LB_Anger.TabIndex = 3;
            this.LB_Anger.Text = "Anger";
            // 
            // LB_Uncertainty
            // 
            this.LB_Uncertainty.AutoSize = true;
            this.LB_Uncertainty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Uncertainty.Location = new System.Drawing.Point(12, 92);
            this.LB_Uncertainty.Name = "LB_Uncertainty";
            this.LB_Uncertainty.Size = new System.Drawing.Size(90, 20);
            this.LB_Uncertainty.TabIndex = 4;
            this.LB_Uncertainty.Text = "Uncertainty";
            // 
            // LB_happiness
            // 
            this.LB_happiness.AutoSize = true;
            this.LB_happiness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_happiness.Location = new System.Drawing.Point(17, 70);
            this.LB_happiness.Name = "LB_happiness";
            this.LB_happiness.Size = new System.Drawing.Size(85, 20);
            this.LB_happiness.TabIndex = 5;
            this.LB_happiness.Text = "Happiness";
            // 
            // LB_Anxiety
            // 
            this.LB_Anxiety.AutoSize = true;
            this.LB_Anxiety.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Anxiety.Location = new System.Drawing.Point(42, 48);
            this.LB_Anxiety.Name = "LB_Anxiety";
            this.LB_Anxiety.Size = new System.Drawing.Size(60, 20);
            this.LB_Anxiety.TabIndex = 6;
            this.LB_Anxiety.Text = "Anxiety";
            // 
            // LB_Upset
            // 
            this.LB_Upset.AutoSize = true;
            this.LB_Upset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Upset.Location = new System.Drawing.Point(50, 114);
            this.LB_Upset.Name = "LB_Upset";
            this.LB_Upset.Size = new System.Drawing.Size(52, 20);
            this.LB_Upset.TabIndex = 7;
            this.LB_Upset.Text = "Upset";
            // 
            // LB_Nervousness
            // 
            this.LB_Nervousness.AutoSize = true;
            this.LB_Nervousness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Nervousness.Location = new System.Drawing.Point(1, 135);
            this.LB_Nervousness.Name = "LB_Nervousness";
            this.LB_Nervousness.Size = new System.Drawing.Size(101, 20);
            this.LB_Nervousness.TabIndex = 8;
            this.LB_Nervousness.Text = "Nervousness";
            // 
            // TB_Angertime
            // 
            this.TB_Angertime.Location = new System.Drawing.Point(107, 26);
            this.TB_Angertime.Name = "TB_Angertime";
            this.TB_Angertime.ReadOnly = true;
            this.TB_Angertime.Size = new System.Drawing.Size(97, 26);
            this.TB_Angertime.TabIndex = 9;
            // 
            // TB_Anxietytime
            // 
            this.TB_Anxietytime.Location = new System.Drawing.Point(107, 48);
            this.TB_Anxietytime.Name = "TB_Anxietytime";
            this.TB_Anxietytime.ReadOnly = true;
            this.TB_Anxietytime.Size = new System.Drawing.Size(97, 26);
            this.TB_Anxietytime.TabIndex = 10;
            // 
            // TB_Happinesstime
            // 
            this.TB_Happinesstime.Location = new System.Drawing.Point(107, 70);
            this.TB_Happinesstime.Name = "TB_Happinesstime";
            this.TB_Happinesstime.ReadOnly = true;
            this.TB_Happinesstime.Size = new System.Drawing.Size(97, 26);
            this.TB_Happinesstime.TabIndex = 11;
            // 
            // TB_Uncerttime
            // 
            this.TB_Uncerttime.Location = new System.Drawing.Point(107, 92);
            this.TB_Uncerttime.Name = "TB_Uncerttime";
            this.TB_Uncerttime.ReadOnly = true;
            this.TB_Uncerttime.Size = new System.Drawing.Size(97, 26);
            this.TB_Uncerttime.TabIndex = 12;
            // 
            // TB_Upsettime
            // 
            this.TB_Upsettime.Location = new System.Drawing.Point(107, 114);
            this.TB_Upsettime.Name = "TB_Upsettime";
            this.TB_Upsettime.ReadOnly = true;
            this.TB_Upsettime.Size = new System.Drawing.Size(97, 26);
            this.TB_Upsettime.TabIndex = 13;
            // 
            // TB_Nervousenesstime
            // 
            this.TB_Nervousenesstime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TB_Nervousenesstime.Location = new System.Drawing.Point(107, 135);
            this.TB_Nervousenesstime.Name = "TB_Nervousenesstime";
            this.TB_Nervousenesstime.ReadOnly = true;
            this.TB_Nervousenesstime.Size = new System.Drawing.Size(97, 22);
            this.TB_Nervousenesstime.TabIndex = 14;
            // 
            // GB_EmotionsTime
            // 
            this.GB_EmotionsTime.Controls.Add(this.LB_Anger);
            this.GB_EmotionsTime.Controls.Add(this.TB_Nervousenesstime);
            this.GB_EmotionsTime.Controls.Add(this.LB_Uncertainty);
            this.GB_EmotionsTime.Controls.Add(this.TB_Upsettime);
            this.GB_EmotionsTime.Controls.Add(this.LB_happiness);
            this.GB_EmotionsTime.Controls.Add(this.TB_Uncerttime);
            this.GB_EmotionsTime.Controls.Add(this.LB_Anxiety);
            this.GB_EmotionsTime.Controls.Add(this.TB_Happinesstime);
            this.GB_EmotionsTime.Controls.Add(this.LB_Upset);
            this.GB_EmotionsTime.Controls.Add(this.TB_Anxietytime);
            this.GB_EmotionsTime.Controls.Add(this.LB_Nervousness);
            this.GB_EmotionsTime.Controls.Add(this.TB_Angertime);
            this.GB_EmotionsTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.GB_EmotionsTime.Location = new System.Drawing.Point(5, 87);
            this.GB_EmotionsTime.Name = "GB_EmotionsTime";
            this.GB_EmotionsTime.Size = new System.Drawing.Size(218, 167);
            this.GB_EmotionsTime.TabIndex = 15;
            this.GB_EmotionsTime.TabStop = false;
            this.GB_EmotionsTime.Text = "Time ( in msec ) / Emotion";
            // 
            // LB_required
            // 
            this.LB_required.AutoSize = true;
            this.LB_required.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_required.Location = new System.Drawing.Point(351, 15);
            this.LB_required.Name = "LB_required";
            this.LB_required.Size = new System.Drawing.Size(362, 20);
            this.LB_required.TabIndex = 15;
            this.LB_required.Text = "*Emotion Name, Start and Stop fields are required";
            // 
            // chart1
            // 
            chartArea3.BorderColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(229, 84);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "ChartArea1";
            series3.IsValueShownAsLabel = true;
            series3.Label = "#VAL{P2}";
            series3.Legend = "Legend1";
            series3.Name = "Emotions";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(586, 170);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // BT_DeleteEmotion
            // 
            this.BT_DeleteEmotion.Enabled = false;
            this.BT_DeleteEmotion.Image = global::PhysiOBS.Properties.Resources.rs;
            this.BT_DeleteEmotion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_DeleteEmotion.Location = new System.Drawing.Point(94, 1);
            this.BT_DeleteEmotion.Name = "BT_DeleteEmotion";
            this.BT_DeleteEmotion.Size = new System.Drawing.Size(84, 44);
            this.BT_DeleteEmotion.TabIndex = 17;
            this.BT_DeleteEmotion.Text = "Delete \r\nEmotion";
            this.BT_DeleteEmotion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_DeleteEmotion.UseVisualStyleBackColor = true;
            this.BT_DeleteEmotion.Click += new System.EventHandler(this.BT_DeleteEmotion_Click);
            // 
            // BT_AddEmotion
            // 
            this.BT_AddEmotion.Image = global::PhysiOBS.Properties.Resources.AddSignal;
            this.BT_AddEmotion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_AddEmotion.Location = new System.Drawing.Point(5, 1);
            this.BT_AddEmotion.Name = "BT_AddEmotion";
            this.BT_AddEmotion.Size = new System.Drawing.Size(84, 44);
            this.BT_AddEmotion.TabIndex = 16;
            this.BT_AddEmotion.Text = "Add \r\nEmotion";
            this.BT_AddEmotion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_AddEmotion.UseVisualStyleBackColor = true;
            this.BT_AddEmotion.Click += new System.EventHandler(this.BT_AddEmotion_Click);
            // 
            // cl1
            // 
            this.cl1.HeaderText = "Emotion Name*";
            this.cl1.Items.AddRange(new object[] {
            "Anger",
            "Anxiety",
            "Happiness",
            "Nervousness",
            "Upset",
            "Uncertainty"});
            this.cl1.Name = "cl1";
            this.cl1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cl1.Width = 120;
            // 
            // cl2
            // 
            this.cl2.HeaderText = "Start Point (in msec)*";
            this.cl2.Name = "cl2";
            this.cl2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl2.Width = 150;
            // 
            // cl3
            // 
            this.cl3.HeaderText = "Stop Point (in msec)*";
            this.cl3.Name = "cl3";
            this.cl3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl3.Width = 150;
            // 
            // cl4
            // 
            this.cl4.HeaderText = "Comments";
            this.cl4.Name = "cl4";
            this.cl4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl4.Width = 347;
            // 
            // Frm_Emotions_Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 261);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.LB_required);
            this.Controls.Add(this.BT_DeleteEmotion);
            this.Controls.Add(this.BT_AddEmotion);
            this.Controls.Add(this.GB_EmotionsTime);
            this.Controls.Add(this.EmotionGridView);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(840, 300);
            this.Name = "Frm_Emotions_Grid";
            this.Text = "Emotions Grid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Emotions_Grid_FormClosing);
            this.Load += new System.EventHandler(this.Emotions_Grid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmotionGridView)).EndInit();
            this.GB_EmotionsTime.ResumeLayout(false);
            this.GB_EmotionsTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView EmotionGridView;
        private System.Windows.Forms.Label LB_Anger;
        private System.Windows.Forms.Label LB_Uncertainty;
        private System.Windows.Forms.Label LB_happiness;
        private System.Windows.Forms.Label LB_Anxiety;
        private System.Windows.Forms.Label LB_Upset;
        private System.Windows.Forms.Label LB_Nervousness;
        private System.Windows.Forms.TextBox TB_Angertime;
        private System.Windows.Forms.TextBox TB_Anxietytime;
        private System.Windows.Forms.TextBox TB_Happinesstime;
        private System.Windows.Forms.TextBox TB_Uncerttime;
        private System.Windows.Forms.TextBox TB_Upsettime;
        private System.Windows.Forms.TextBox TB_Nervousenesstime;
        private System.Windows.Forms.GroupBox GB_EmotionsTime;
        private System.Windows.Forms.Button BT_AddEmotion;
        private System.Windows.Forms.Button BT_DeleteEmotion;
        private System.Windows.Forms.Label LB_required;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewComboBoxColumn cl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl4;
    }
}