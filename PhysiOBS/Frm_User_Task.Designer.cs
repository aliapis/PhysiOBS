namespace PhysiOBS
{
    partial class Frm_User_Task
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TB_Add_Task = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CL1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CL5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BT_RemoveTask = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TB_numberTasks = new System.Windows.Forms.TextBox();
            this.LB_numTasks = new System.Windows.Forms.Label();
            this.LB_comTasks = new System.Windows.Forms.Label();
            this.TB_completedtasks = new System.Windows.Forms.TextBox();
            this.LB_unTasks = new System.Windows.Forms.Label();
            this.TB_uncompletedtasks = new System.Windows.Forms.TextBox();
            this.GB_taskinfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.GB_taskinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Add_Task
            // 
            this.TB_Add_Task.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TB_Add_Task.Image = global::PhysiOBS.Properties.Resources.AddSignal;
            this.TB_Add_Task.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TB_Add_Task.Location = new System.Drawing.Point(7, 3);
            this.TB_Add_Task.Name = "TB_Add_Task";
            this.TB_Add_Task.Size = new System.Drawing.Size(90, 44);
            this.TB_Add_Task.TabIndex = 2;
            this.TB_Add_Task.Text = "Add\r\nTask";
            this.TB_Add_Task.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Add_Task.UseVisualStyleBackColor = true;
            this.TB_Add_Task.Click += new System.EventHandler(this.BT_Add_Task_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CL1,
            this.CL2,
            this.CL3,
            this.CL4,
            this.CL5});
            this.dataGridView1.Location = new System.Drawing.Point(7, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1005, 29);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // CL1
            // 
            this.CL1.HeaderText = "Task Name *";
            this.CL1.Name = "CL1";
            this.CL1.Width = 200;
            // 
            // CL2
            // 
            this.CL2.HeaderText = "Start Point (in msec) *";
            this.CL2.Name = "CL2";
            this.CL2.Width = 150;
            // 
            // CL3
            // 
            this.CL3.HeaderText = "Stop Point (in msec) *";
            this.CL3.Name = "CL3";
            this.CL3.Width = 150;
            // 
            // CL4
            // 
            this.CL4.HeaderText = "Success";
            this.CL4.Name = "CL4";
            this.CL4.Width = 60;
            // 
            // CL5
            // 
            this.CL5.HeaderText = "Comments";
            this.CL5.Name = "CL5";
            this.CL5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CL5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CL5.Width = 400;
            // 
            // BT_RemoveTask
            // 
            this.BT_RemoveTask.Enabled = false;
            this.BT_RemoveTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.BT_RemoveTask.Image = global::PhysiOBS.Properties.Resources.rs;
            this.BT_RemoveTask.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_RemoveTask.Location = new System.Drawing.Point(103, 3);
            this.BT_RemoveTask.Name = "BT_RemoveTask";
            this.BT_RemoveTask.Size = new System.Drawing.Size(90, 44);
            this.BT_RemoveTask.TabIndex = 4;
            this.BT_RemoveTask.Text = "Delete\r\nTask";
            this.BT_RemoveTask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_RemoveTask.UseVisualStyleBackColor = true;
            this.BT_RemoveTask.Click += new System.EventHandler(this.BT_RemoveTask_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(7, 89);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.Label = "#VAL{P2}";
            series1.Legend = "Legend1";
            series1.Name = "Tasks";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(444, 256);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // TB_numberTasks
            // 
            this.TB_numberTasks.Location = new System.Drawing.Point(166, 20);
            this.TB_numberTasks.Name = "TB_numberTasks";
            this.TB_numberTasks.ReadOnly = true;
            this.TB_numberTasks.Size = new System.Drawing.Size(54, 26);
            this.TB_numberTasks.TabIndex = 6;
            // 
            // LB_numTasks
            // 
            this.LB_numTasks.AutoSize = true;
            this.LB_numTasks.Location = new System.Drawing.Point(25, 24);
            this.LB_numTasks.Name = "LB_numTasks";
            this.LB_numTasks.Size = new System.Drawing.Size(133, 20);
            this.LB_numTasks.TabIndex = 7;
            this.LB_numTasks.Text = "Number of Tasks:";
            // 
            // LB_comTasks
            // 
            this.LB_comTasks.AutoSize = true;
            this.LB_comTasks.Location = new System.Drawing.Point(19, 53);
            this.LB_comTasks.Name = "LB_comTasks";
            this.LB_comTasks.Size = new System.Drawing.Size(136, 20);
            this.LB_comTasks.TabIndex = 9;
            this.LB_comTasks.Text = "Completed Tasks:";
            // 
            // TB_completedtasks
            // 
            this.TB_completedtasks.Location = new System.Drawing.Point(166, 50);
            this.TB_completedtasks.Name = "TB_completedtasks";
            this.TB_completedtasks.ReadOnly = true;
            this.TB_completedtasks.Size = new System.Drawing.Size(54, 26);
            this.TB_completedtasks.TabIndex = 8;
            // 
            // LB_unTasks
            // 
            this.LB_unTasks.AutoSize = true;
            this.LB_unTasks.Location = new System.Drawing.Point(6, 83);
            this.LB_unTasks.Name = "LB_unTasks";
            this.LB_unTasks.Size = new System.Drawing.Size(154, 20);
            this.LB_unTasks.TabIndex = 11;
            this.LB_unTasks.Text = "Uncompleted Tasks:";
            // 
            // TB_uncompletedtasks
            // 
            this.TB_uncompletedtasks.Location = new System.Drawing.Point(166, 80);
            this.TB_uncompletedtasks.Name = "TB_uncompletedtasks";
            this.TB_uncompletedtasks.ReadOnly = true;
            this.TB_uncompletedtasks.Size = new System.Drawing.Size(54, 26);
            this.TB_uncompletedtasks.TabIndex = 10;
            // 
            // GB_taskinfo
            // 
            this.GB_taskinfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GB_taskinfo.Controls.Add(this.label3);
            this.GB_taskinfo.Controls.Add(this.LB_numTasks);
            this.GB_taskinfo.Controls.Add(this.LB_unTasks);
            this.GB_taskinfo.Controls.Add(this.TB_numberTasks);
            this.GB_taskinfo.Controls.Add(this.TB_uncompletedtasks);
            this.GB_taskinfo.Controls.Add(this.label2);
            this.GB_taskinfo.Controls.Add(this.TB_completedtasks);
            this.GB_taskinfo.Controls.Add(this.LB_comTasks);
            this.GB_taskinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.GB_taskinfo.Location = new System.Drawing.Point(457, 89);
            this.GB_taskinfo.Name = "GB_taskinfo";
            this.GB_taskinfo.Size = new System.Drawing.Size(233, 119);
            this.GB_taskinfo.TabIndex = 12;
            this.GB_taskinfo.TabStop = false;
            this.GB_taskinfo.Text = "Task Info:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Uncompleted Tasks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Completed Tasks:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(321, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "* Task Name, Start and Stop are required fields.";
            // 
            // Frm_User_Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 351);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GB_taskinfo);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.BT_RemoveTask);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TB_Add_Task);
            this.MinimumSize = new System.Drawing.Size(1035, 390);
            this.Name = "Frm_User_Task";
            this.Text = "User\'s Tasks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_User_Task_FormClosing);
            this.Load += new System.EventHandler(this.Frm_User_Task_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.GB_taskinfo.ResumeLayout(false);
            this.GB_taskinfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TB_Add_Task;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BT_RemoveTask;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox TB_numberTasks;
        private System.Windows.Forms.Label LB_numTasks;
        private System.Windows.Forms.Label LB_comTasks;
        private System.Windows.Forms.TextBox TB_completedtasks;
        private System.Windows.Forms.Label LB_unTasks;
        private System.Windows.Forms.TextBox TB_uncompletedtasks;
        private System.Windows.Forms.GroupBox GB_taskinfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CL4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}