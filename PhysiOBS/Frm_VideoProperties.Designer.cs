namespace PhysiOBS
{
    partial class Frm_VideoProperties
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
            this.BT_Save_V = new System.Windows.Forms.Button();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.TB_Duration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Delay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_FileFormat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_Title = new System.Windows.Forms.TextBox();
            this.LB_Title = new System.Windows.Forms.Label();
            this.TB_Type = new System.Windows.Forms.TextBox();
            this.LB_Type = new System.Windows.Forms.Label();
            this.TB_Filename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_Save_V
            // 
            this.BT_Save_V.Location = new System.Drawing.Point(454, 182);
            this.BT_Save_V.Name = "BT_Save_V";
            this.BT_Save_V.Size = new System.Drawing.Size(87, 39);
            this.BT_Save_V.TabIndex = 46;
            this.BT_Save_V.Text = "Save";
            this.BT_Save_V.UseVisualStyleBackColor = true;
            this.BT_Save_V.Click += new System.EventHandler(this.BT_Save_Vid);
            // 
            // BT_Cancel
            // 
            this.BT_Cancel.Location = new System.Drawing.Point(361, 182);
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.Size = new System.Drawing.Size(87, 39);
            this.BT_Cancel.TabIndex = 47;
            this.BT_Cancel.Text = "Cancel";
            this.BT_Cancel.UseVisualStyleBackColor = true;
            this.BT_Cancel.Click += new System.EventHandler(this.BT_Cancel_Click);
            // 
            // TB_Duration
            // 
            this.TB_Duration.Location = new System.Drawing.Point(465, 67);
            this.TB_Duration.Name = "TB_Duration";
            this.TB_Duration.ReadOnly = true;
            this.TB_Duration.Size = new System.Drawing.Size(75, 20);
            this.TB_Duration.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.Location = new System.Drawing.Point(370, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "Duration:";
            // 
            // TB_Delay
            // 
            this.TB_Delay.BackColor = System.Drawing.SystemColors.Info;
            this.TB_Delay.Location = new System.Drawing.Point(465, 137);
            this.TB_Delay.Name = "TB_Delay";
            this.TB_Delay.Size = new System.Drawing.Size(75, 20);
            this.TB_Delay.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.Location = new System.Drawing.Point(342, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 56;
            this.label6.Text = "Delay (in msec):";
            // 
            // TB_FileFormat
            // 
            this.TB_FileFormat.Location = new System.Drawing.Point(465, 44);
            this.TB_FileFormat.Name = "TB_FileFormat";
            this.TB_FileFormat.ReadOnly = true;
            this.TB_FileFormat.Size = new System.Drawing.Size(75, 20);
            this.TB_FileFormat.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label7.Location = new System.Drawing.Point(370, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 53;
            this.label7.Text = "File Format:";
            // 
            // TB_Title
            // 
            this.TB_Title.BackColor = System.Drawing.SystemColors.Info;
            this.TB_Title.Location = new System.Drawing.Point(60, 137);
            this.TB_Title.Name = "TB_Title";
            this.TB_Title.Size = new System.Drawing.Size(267, 20);
            this.TB_Title.TabIndex = 1;
            // 
            // LB_Title
            // 
            this.LB_Title.AutoSize = true;
            this.LB_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Title.Location = new System.Drawing.Point(12, 137);
            this.LB_Title.Name = "LB_Title";
            this.LB_Title.Size = new System.Drawing.Size(42, 20);
            this.LB_Title.TabIndex = 50;
            this.LB_Title.Text = "Title:";
            // 
            // TB_Type
            // 
            this.TB_Type.Location = new System.Drawing.Point(89, 66);
            this.TB_Type.Name = "TB_Type";
            this.TB_Type.ReadOnly = true;
            this.TB_Type.Size = new System.Drawing.Size(267, 20);
            this.TB_Type.TabIndex = 49;
            // 
            // LB_Type
            // 
            this.LB_Type.AutoSize = true;
            this.LB_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.LB_Type.Location = new System.Drawing.Point(11, 66);
            this.LB_Type.Name = "LB_Type";
            this.LB_Type.Size = new System.Drawing.Size(47, 20);
            this.LB_Type.TabIndex = 48;
            this.LB_Type.Text = "Type:";
            // 
            // TB_Filename
            // 
            this.TB_Filename.Location = new System.Drawing.Point(89, 43);
            this.TB_Filename.Name = "TB_Filename";
            this.TB_Filename.ReadOnly = true;
            this.TB_Filename.Size = new System.Drawing.Size(267, 20);
            this.TB_Filename.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(11, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 64;
            this.label1.Text = "FileName: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 24);
            this.label2.TabIndex = 66;
            this.label2.Text = "Video Information";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(547, 225);
            this.shapeContainer1.TabIndex = 67;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape3
            // 
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 15;
            this.lineShape3.X2 = 539;
            this.lineShape3.Y1 = 174;
            this.lineShape3.Y2 = 174;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 16;
            this.lineShape2.X2 = 540;
            this.lineShape2.Y1 = 128;
            this.lineShape2.Y2 = 128;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 16;
            this.lineShape1.X2 = 540;
            this.lineShape1.Y1 = 34;
            this.lineShape1.Y2 = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 24);
            this.label3.TabIndex = 68;
            this.label3.Text = "Video Options";
            // 
            // Frm_VideoProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 225);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Filename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Duration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_Delay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_FileFormat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TB_Title);
            this.Controls.Add(this.LB_Title);
            this.Controls.Add(this.TB_Type);
            this.Controls.Add(this.LB_Type);
            this.Controls.Add(this.BT_Cancel);
            this.Controls.Add(this.BT_Save_V);
            this.Controls.Add(this.shapeContainer1);
            this.MaximumSize = new System.Drawing.Size(563, 264);
            this.MinimumSize = new System.Drawing.Size(563, 264);
            this.Name = "Frm_VideoProperties";
            this.Text = "Frm_VideoProperties";
            this.Load += new System.EventHandler(this.Frm_VideoProperties_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_Save_V;
        private System.Windows.Forms.Button BT_Cancel;
        private System.Windows.Forms.TextBox TB_Duration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Delay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_FileFormat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_Title;
        private System.Windows.Forms.Label LB_Title;
        private System.Windows.Forms.TextBox TB_Type;
        private System.Windows.Forms.Label LB_Type;
        private System.Windows.Forms.TextBox TB_Filename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label3;
    }
}