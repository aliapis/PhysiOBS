namespace PhysiOBS
{
    partial class Frm_Ass_Alg
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
            this.BT_Close = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CL_SIGNAL = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CL_ALGORITHM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CL_ORDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BT_Frm_AssAlg_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_Close
            // 
            this.BT_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Close.Location = new System.Drawing.Point(433, 204);
            this.BT_Close.Name = "BT_Close";
            this.BT_Close.Size = new System.Drawing.Size(86, 33);
            this.BT_Close.TabIndex = 0;
            this.BT_Close.Text = "Save";
            this.BT_Close.UseVisualStyleBackColor = true;
            this.BT_Close.Click += new System.EventHandler(this.BT_Close_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CL_SIGNAL,
            this.CL_ALGORITHM,
            this.CL_ORDER});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(507, 186);
            this.dataGridView1.TabIndex = 1;
            // 
            // CL_SIGNAL
            // 
            this.CL_SIGNAL.HeaderText = "SIGNAL";
            this.CL_SIGNAL.Name = "CL_SIGNAL";
            this.CL_SIGNAL.Width = 200;
            // 
            // CL_ALGORITHM
            // 
            this.CL_ALGORITHM.HeaderText = "ALGORITHM";
            this.CL_ALGORITHM.Name = "CL_ALGORITHM";
            this.CL_ALGORITHM.Width = 200;
            // 
            // CL_ORDER
            // 
            this.CL_ORDER.HeaderText = "ORDER";
            this.CL_ORDER.Name = "CL_ORDER";
            this.CL_ORDER.Width = 60;
            // 
            // BT_Frm_AssAlg_Close
            // 
            this.BT_Frm_AssAlg_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_Frm_AssAlg_Close.Location = new System.Drawing.Point(344, 204);
            this.BT_Frm_AssAlg_Close.Name = "BT_Frm_AssAlg_Close";
            this.BT_Frm_AssAlg_Close.Size = new System.Drawing.Size(83, 33);
            this.BT_Frm_AssAlg_Close.TabIndex = 2;
            this.BT_Frm_AssAlg_Close.Text = "Cancel";
            this.BT_Frm_AssAlg_Close.UseVisualStyleBackColor = true;
            this.BT_Frm_AssAlg_Close.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm_Ass_Alg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 249);
            this.Controls.Add(this.BT_Frm_AssAlg_Close);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BT_Close);
            this.Name = "Frm_Ass_Alg";
            this.Text = "Frm_Ass_Alg";
            this.Load += new System.EventHandler(this.Frm_Ass_Alg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_Close;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BT_Frm_AssAlg_Close;
        private System.Windows.Forms.DataGridViewComboBoxColumn CL_SIGNAL;
        private System.Windows.Forms.DataGridViewComboBoxColumn CL_ALGORITHM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL_ORDER;
    }
}