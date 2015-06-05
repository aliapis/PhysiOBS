using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhysiOBS_Kernel;


namespace PhysiOBS
{
    public partial class Frm_Emotions_Grid : Form
    {
        public string SignalID;
        public TCriticalPointsList CP;
        public TEmotionList EL;
        public int number=-1;
        double temp;
        public Frm_Emotions_Grid()
        {
            InitializeComponent();
        }
        private void DrawEmotions()
        {
            double stotal=0;
            double Sang = 0, Shap = 0, Sner = 0, Sanx = 0, Sups = 0, Sunc = 0;
            int i;
            for (i = 0; i < EmotionGridView.Rows.Count;i++)
            {
                if (((EmotionGridView.Rows[i].Cells[0].Value == null) || (EmotionGridView.Rows[i].Cells[1].Value == null) || (EmotionGridView.Rows[i].Cells[2].Value == null))) continue;
                
                stotal += (double.Parse(EmotionGridView.Rows[i].Cells[2].Value.ToString())) - (double.Parse(EmotionGridView.Rows[i].Cells[1].Value.ToString()));
                if (EmotionGridView.Rows[i].Cells[0].Value.ToString() == "Anger")
                {
                    Sang += (double.Parse(EmotionGridView.Rows[i].Cells[2].Value.ToString())) - (double.Parse(EmotionGridView.Rows[i].Cells[1].Value.ToString()));
                }
                else if (EmotionGridView.Rows[i].Cells[0].Value.ToString() == "Anxiety")
                {
                    Sanx += (double.Parse(EmotionGridView.Rows[i].Cells[2].Value.ToString())) - (double.Parse(EmotionGridView.Rows[i].Cells[1].Value.ToString()));
                }
                else if (EmotionGridView.Rows[i].Cells[0].Value.ToString() == "Happiness")
                {
                    Shap += (double.Parse(EmotionGridView.Rows[i].Cells[2].Value.ToString())) - (double.Parse(EmotionGridView.Rows[i].Cells[1].Value.ToString()));
                }
                else if (EmotionGridView.Rows[i].Cells[0].Value.ToString() == "Uncertainty")
                {
                    Sunc += (double.Parse(EmotionGridView.Rows[i].Cells[2].Value.ToString())) - (double.Parse(EmotionGridView.Rows[i].Cells[1].Value.ToString()));
                }
                else if (EmotionGridView.Rows[i].Cells[0].Value.ToString() == "Nervousness")
                {
                    Sner += (double.Parse(EmotionGridView.Rows[i].Cells[2].Value.ToString())) - (double.Parse(EmotionGridView.Rows[i].Cells[1].Value.ToString()));
                }
                else if (EmotionGridView.Rows[i].Cells[0].Value.ToString() == "Upset")
                {
                    Sups += (double.Parse(EmotionGridView.Rows[i].Cells[2].Value.ToString())) - (double.Parse(EmotionGridView.Rows[i].Cells[1].Value.ToString()));
                }
                
            }
            
            TB_Angertime.Text = Sang.ToString();
            TB_Happinesstime.Text = Shap.ToString();
            TB_Uncerttime.Text = Sunc.ToString();
            TB_Nervousenesstime.Text = Sner.ToString();
            TB_Upsettime.Text = Sups.ToString();
            TB_Anxietytime.Text = Sanx.ToString();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.Series["Emotions"].Points.Clear();
            if (stotal != 0)
            {
                
                chart1.Series["Emotions"].Points.AddXY("Anger %", Sang / stotal);
                chart1.Series["Emotions"].Points[0].Color = System.Drawing.Color.Red;
                chart1.Series["Emotions"].Points.AddXY("Anxiety %", Sanx / stotal);
                chart1.Series["Emotions"].Points[1].Color = System.Drawing.Color.Orange;
                chart1.Series["Emotions"].Points.AddXY("Happiness %", Shap / stotal);
                chart1.Series["Emotions"].Points[2].Color = System.Drawing.Color.Green;
                chart1.Series["Emotions"].Points.AddXY("Uncertainty %", Sunc / stotal);
                chart1.Series["Emotions"].Points[3].Color = System.Drawing.Color.Blue;
                chart1.Series["Emotions"].Points.AddXY("Nervousness %", Sner / stotal);
                chart1.Series["Emotions"].Points[4].Color = System.Drawing.Color.Coral;
                chart1.Series["Emotions"].Points.AddXY("Upset %", Sups / stotal);
                chart1.Series["Emotions"].Points[5].Color = System.Drawing.Color.OrangeRed;
            }
        }
   
        private void Emotions_Grid_Load(object sender, EventArgs e)
        {
            
            chart1.Titles.Add("Emotions Chart");
            int i;
            TEmotion te;
            for (i = 0; i < EL.Count; i++)
            {
                EmotionGridView.Rows.Add();
                number++;
                te = (TEmotion)EL[i];
                ((DataGridViewComboBoxCell)EmotionGridView.Rows[i].Cells[0]).Value = te.name;
                ((DataGridViewTextBoxCell)EmotionGridView.Rows[i].Cells[1]).Value = double.Parse(te.start.ToString());
                ((DataGridViewTextBoxCell)EmotionGridView.Rows[i].Cells[2]).Value = double.Parse(te.stop.ToString());
                ((DataGridViewTextBoxCell)EmotionGridView.Rows[i].Cells[3]).Value = te.comments;
                EmotionGridView.Height += 22;
                GB_EmotionsTime.SetBounds(GB_EmotionsTime.Location.X, GB_EmotionsTime.Location.Y + 22, GB_EmotionsTime.Width, GB_EmotionsTime.Height);
                chart1.SetBounds(chart1.Location.X, chart1.Location.Y + 22, chart1.Width, chart1.Height);
                this.Size = new Size(this.Width, this.Height + 22);
            }
            
            if (EL.Count != 0) BT_DeleteEmotion.Enabled = true;
            DrawEmotions();
            
        }


        private void BT_AddEmotion_Click(object sender, EventArgs e)
        {
            if (EmotionGridView.Rows.Count != EL.Count)
            {
                MessageBox.Show("Required Fields Are Missing", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EmotionGridView.Rows.Add();
            number++;
            EmotionGridView.Height += 22;
            GB_EmotionsTime.SetBounds(GB_EmotionsTime.Location.X, GB_EmotionsTime.Location.Y + 22, GB_EmotionsTime.Width, GB_EmotionsTime.Height);
            chart1.SetBounds(chart1.Location.X, chart1.Location.Y + 22, chart1.Width, chart1.Height);
            this.Size = new Size(this.Width, this.Height + 22);
            BT_DeleteEmotion.Enabled = true;
        }


        private void BT_DeleteEmotion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The selected emotion will be removed!!!" + Environment.NewLine + "Are you Sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //user clicked yes          
                int selectedIndex = EmotionGridView.CurrentCell.RowIndex;
                EmotionGridView.Rows.RemoveAt(selectedIndex);
                if (selectedIndex < EL.Count) EL.RemoveAt(selectedIndex);
                number--;
                EmotionGridView.Height -= 22;
                GB_EmotionsTime.SetBounds(GB_EmotionsTime.Location.X, GB_EmotionsTime.Location.Y - 22, GB_EmotionsTime.Width, GB_EmotionsTime.Height);
                chart1.SetBounds(chart1.Location.X, chart1.Location.Y - 22, chart1.Width, chart1.Height);
                this.Size = new Size(this.Width, this.Height - 22);
                if (EL.Count == 0) BT_DeleteEmotion.Enabled = false;
                DrawEmotions();
            }
            else
            {
                //user clicked no
                return;
            }
            
        }

      

        private void EmotionGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (number == EmotionGridView.CurrentCell.RowIndex)
            {
                if (EmotionGridView.Rows[number].Cells[0].Value != null && EmotionGridView.Rows[number].Cells[1].Value != null && EmotionGridView.Rows[number].Cells[2].Value != null)
                {
                    if (double.Parse(EmotionGridView.Rows[number].Cells[1].Value.ToString()) > double.Parse(EmotionGridView.Rows[number].Cells[2].Value.ToString()))
                    {
                        temp = double.Parse(EmotionGridView.Rows[number].Cells[2].Value.ToString());
                        EmotionGridView.Rows[number].Cells[2].Value = EmotionGridView.Rows[number].Cells[1].Value.ToString();
                        EmotionGridView.Rows[number].Cells[1].Value = temp;
                    }
                    AddEmotion(number);
                }
                else return;
            }
            else
            {
                if (double.Parse(EmotionGridView.Rows[EmotionGridView.CurrentCell.RowIndex].Cells[1].Value.ToString()) > double.Parse(EmotionGridView.Rows[EmotionGridView.CurrentCell.RowIndex].Cells[2].Value.ToString()))
                {

                    temp = double.Parse(EmotionGridView.Rows[EmotionGridView.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    EmotionGridView.Rows[EmotionGridView.CurrentCell.RowIndex].Cells[2].Value = EmotionGridView.Rows[EmotionGridView.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    EmotionGridView.Rows[EmotionGridView.CurrentCell.RowIndex].Cells[1].Value = temp;
                }
                if (EmotionGridView.Rows[EmotionGridView.CurrentCell.RowIndex].Cells[0].Value != null && EmotionGridView.Rows[EmotionGridView.CurrentCell.RowIndex].Cells[1].Value != null && EmotionGridView.Rows[EmotionGridView.CurrentCell.RowIndex].Cells[2].Value != null)
                {
                    UpdateEmotion(EmotionGridView.CurrentCell.RowIndex);               
                }
            }
            
            DrawEmotions();
        }


        public void AddEmotion(int n)
        {
            TEmotion t;
            if (EL.Count - 1 < n)
            {
                t = new TEmotion();
            }
            else
            {
                t = (TEmotion)EL[n];
            }
            t.name = EmotionGridView.Rows[n].Cells[0].Value.ToString();
            if (double.Parse(EmotionGridView.Rows[n].Cells[1].Value.ToString()) > double.Parse(EmotionGridView.Rows[n].Cells[2].Value.ToString()))
            {
               t.start = Double.Parse(EmotionGridView.Rows[n].Cells[2].Value.ToString());
               t.stop = Double.Parse(EmotionGridView.Rows[n].Cells[1].Value.ToString());
            }
            else
            {
               t.start = Double.Parse(EmotionGridView.Rows[n].Cells[1].Value.ToString());
               t.stop = Double.Parse(EmotionGridView.Rows[n].Cells[2].Value.ToString());
            }
            if (EmotionGridView.Rows[n].Cells[3].Value == null)
            {
                t.comments = "";
            }
            else
            {
                t.comments = EmotionGridView.Rows[n].Cells[3].Value.ToString();
            }
            if (EL.Count - 1 < n)
            {
                EL.Add(t);
            }
        }

        public void UpdateEmotion(int n)
        {
            TEmotion t = (TEmotion)EL[n];
            t.name = EmotionGridView.Rows[n].Cells[0].Value.ToString();
            if (double.Parse(EmotionGridView.Rows[n].Cells[1].Value.ToString()) > double.Parse(EmotionGridView.Rows[n].Cells[2].Value.ToString()))
            {
                t.start = Double.Parse(EmotionGridView.Rows[n].Cells[2].Value.ToString());
                t.stop = Double.Parse(EmotionGridView.Rows[n].Cells[1].Value.ToString());
            }
            else
            {
                t.start = Double.Parse(EmotionGridView.Rows[n].Cells[1].Value.ToString());
                t.stop = Double.Parse(EmotionGridView.Rows[n].Cells[2].Value.ToString());
            }
            if (EmotionGridView.Rows[n].Cells[3].Value == null)
            {
                t.comments = "";
            }
            else
            {
                t.comments = EmotionGridView.Rows[n].Cells[3].Value.ToString();
            }
        }

        private void BT_Close_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Emotions_Grid_FormClosing(object sender, FormClosingEventArgs e)
        {

            CP.clear_points("emotion_"+SignalID);
            foreach (TEmotion te in EL)
            {
                TCriticalPoint point1 = new TCriticalPoint();
                point1.name = te.name;
                point1.time = te.start;
                point1.Bar = "emotion_" + SignalID;
                point1.obj = (object)te;
                CP.Add(point1);
                TCriticalPoint point2 = new TCriticalPoint();
                point2.name = te.name;
                point2.time = te.stop;
                point2.Bar = "emotion_" + SignalID;
                point2.obj = (object)te;
                CP.Add(point2);
            }
            CP.Sort();
        }

    }
}
