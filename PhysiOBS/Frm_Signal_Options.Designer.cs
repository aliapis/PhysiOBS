namespace PhysiOBS
{
    partial class Frm_Signal_Options
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
            this.LB_Signal_Title = new System.Windows.Forms.Label();
            this.LB_Signal_Type = new System.Windows.Forms.Label();
            this.CB_Signal_Type = new System.Windows.Forms.ComboBox();
            this.LB_Output_Method = new System.Windows.Forms.Label();
            this.BT_Open_Signal = new System.Windows.Forms.Button();
            this.TB_Filename = new System.Windows.Forms.TextBox();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.BT_Save = new System.Windows.Forms.Button();
            this.CB_Output_Method = new System.Windows.Forms.ComboBox();
            this.TB_Signal_Title = new System.Windows.Forms.TextBox();
            this.LB_Required = new System.Windows.Forms.Label();
            this.TB_Sampling = new System.Windows.Forms.TextBox();
            this.LB_Sampling = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LB_Signal_Title
            // 
            this.LB_Signal_Title.AutoSize = true;
            this.LB_Signal_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Signal_Title.Location = new System.Drawing.Point(3, 42);
            this.LB_Signal_Title.Name = "LB_Signal_Title";
            this.LB_Signal_Title.Size = new System.Drawing.Size(85, 20);
            this.LB_Signal_Title.TabIndex = 2;
            this.LB_Signal_Title.Text = "Signal Info";
            // 
            // LB_Signal_Type
            // 
            this.LB_Signal_Type.AutoSize = true;
            this.LB_Signal_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Signal_Type.Location = new System.Drawing.Point(4, 13);
            this.LB_Signal_Type.Name = "LB_Signal_Type";
            this.LB_Signal_Type.Size = new System.Drawing.Size(105, 20);
            this.LB_Signal_Type.TabIndex = 4;
            this.LB_Signal_Type.Text = "Signal Name*";
            // 
            // CB_Signal_Type
            // 
            this.CB_Signal_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Signal_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.CB_Signal_Type.FormattingEnabled = true;
            this.CB_Signal_Type.Items.AddRange(new object[] {
            "Blood Volume Pressure (BVP)",
            "ElectoMyoGram (EMG)",
            "ElectroCardioGram (ECG)",
            "Galvanic Skin Response (GSR)",
            "Heart Rate (HR)",
            "Respiration Rate (RR)",
            "Temperature (TMP)"});
            this.CB_Signal_Type.Location = new System.Drawing.Point(115, 9);
            this.CB_Signal_Type.Name = "CB_Signal_Type";
            this.CB_Signal_Type.Size = new System.Drawing.Size(265, 24);
            this.CB_Signal_Type.TabIndex = 1;
            // 
            // LB_Output_Method
            // 
            this.LB_Output_Method.AutoSize = true;
            this.LB_Output_Method.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Output_Method.Location = new System.Drawing.Point(3, 102);
            this.LB_Output_Method.Name = "LB_Output_Method";
            this.LB_Output_Method.Size = new System.Drawing.Size(122, 20);
            this.LB_Output_Method.TabIndex = 10;
            this.LB_Output_Method.Text = "Output Method*";
            // 
            // BT_Open_Signal
            // 
            this.BT_Open_Signal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.BT_Open_Signal.Location = new System.Drawing.Point(7, 131);
            this.BT_Open_Signal.Name = "BT_Open_Signal";
            this.BT_Open_Signal.Size = new System.Drawing.Size(96, 29);
            this.BT_Open_Signal.TabIndex = 5;
            this.BT_Open_Signal.Text = "Browse*";
            this.BT_Open_Signal.UseVisualStyleBackColor = true;
            this.BT_Open_Signal.Click += new System.EventHandler(this.BT_Open_Signal_Click);
            // 
            // TB_Filename
            // 
            this.TB_Filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Filename.Location = new System.Drawing.Point(135, 131);
            this.TB_Filename.Multiline = true;
            this.TB_Filename.Name = "TB_Filename";
            this.TB_Filename.ReadOnly = true;
            this.TB_Filename.Size = new System.Drawing.Size(245, 29);
            this.TB_Filename.TabIndex = 14;
            // 
            // BT_Cancel
            // 
            this.BT_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.BT_Cancel.Location = new System.Drawing.Point(186, 194);
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.Size = new System.Drawing.Size(94, 38);
            this.BT_Cancel.TabIndex = 6;
            this.BT_Cancel.Text = "Cancel";
            this.BT_Cancel.UseVisualStyleBackColor = true;
            this.BT_Cancel.Click += new System.EventHandler(this.BT_Cancel_Click);
            // 
            // BT_Save
            // 
            this.BT_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.BT_Save.Location = new System.Drawing.Point(286, 194);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(94, 38);
            this.BT_Save.TabIndex = 7;
            this.BT_Save.Text = "Save";
            this.BT_Save.UseVisualStyleBackColor = true;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // CB_Output_Method
            // 
            this.CB_Output_Method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Output_Method.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.CB_Output_Method.FormattingEnabled = true;
            this.CB_Output_Method.Items.AddRange(new object[] {
            "Simple Signal Graph"});
            this.CB_Output_Method.Location = new System.Drawing.Point(135, 98);
            this.CB_Output_Method.Name = "CB_Output_Method";
            this.CB_Output_Method.Size = new System.Drawing.Size(245, 24);
            this.CB_Output_Method.TabIndex = 4;
            // 
            // TB_Signal_Title
            // 
            this.TB_Signal_Title.BackColor = System.Drawing.SystemColors.Info;
            this.TB_Signal_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TB_Signal_Title.Location = new System.Drawing.Point(115, 39);
            this.TB_Signal_Title.Multiline = true;
            this.TB_Signal_Title.Name = "TB_Signal_Title";
            this.TB_Signal_Title.Size = new System.Drawing.Size(265, 23);
            this.TB_Signal_Title.TabIndex = 2;
            // 
            // LB_Required
            // 
            this.LB_Required.AutoSize = true;
            this.LB_Required.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Required.Location = new System.Drawing.Point(5, 168);
            this.LB_Required.Name = "LB_Required";
            this.LB_Required.Size = new System.Drawing.Size(191, 18);
            this.LB_Required.TabIndex = 20;
            this.LB_Required.Text = "Fields with ( * ) are required.";
            // 
            // TB_Sampling
            // 
            this.TB_Sampling.BackColor = System.Drawing.SystemColors.Info;
            this.TB_Sampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TB_Sampling.Location = new System.Drawing.Point(162, 68);
            this.TB_Sampling.Multiline = true;
            this.TB_Sampling.Name = "TB_Sampling";
            this.TB_Sampling.Size = new System.Drawing.Size(218, 23);
            this.TB_Sampling.TabIndex = 3;
            // 
            // LB_Sampling
            // 
            this.LB_Sampling.AutoSize = true;
            this.LB_Sampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Sampling.Location = new System.Drawing.Point(3, 71);
            this.LB_Sampling.Name = "LB_Sampling";
            this.LB_Sampling.Size = new System.Drawing.Size(154, 20);
            this.LB_Sampling.TabIndex = 22;
            this.LB_Sampling.Text = "Sampling Rate (Hz)*";
            // 
            // Frm_Signal_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 239);
            this.Controls.Add(this.LB_Sampling);
            this.Controls.Add(this.TB_Sampling);
            this.Controls.Add(this.TB_Signal_Title);
            this.Controls.Add(this.BT_Save);
            this.Controls.Add(this.BT_Cancel);
            this.Controls.Add(this.TB_Filename);
            this.Controls.Add(this.BT_Open_Signal);
            this.Controls.Add(this.CB_Output_Method);
            this.Controls.Add(this.LB_Output_Method);
            this.Controls.Add(this.CB_Signal_Type);
            this.Controls.Add(this.LB_Signal_Type);
            this.Controls.Add(this.LB_Signal_Title);
            this.Controls.Add(this.LB_Required);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(401, 278);
            this.MinimumSize = new System.Drawing.Size(401, 278);
            this.Name = "Frm_Signal_Options";
            this.Text = "Signal Options";
            this.Load += new System.EventHandler(this.Frm_Signal_Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_Signal_Title;
        private System.Windows.Forms.Label LB_Signal_Type;
        private System.Windows.Forms.ComboBox CB_Signal_Type;
        private System.Windows.Forms.Label LB_Output_Method;
        private System.Windows.Forms.Button BT_Open_Signal;
        private System.Windows.Forms.TextBox TB_Filename;
        private System.Windows.Forms.Button BT_Cancel;
        private System.Windows.Forms.Button BT_Save;
        private System.Windows.Forms.ComboBox CB_Output_Method;
        private System.Windows.Forms.TextBox TB_Signal_Title;
        private System.Windows.Forms.Label LB_Required;
        private System.Windows.Forms.TextBox TB_Sampling;
        private System.Windows.Forms.Label LB_Sampling;
    }
}