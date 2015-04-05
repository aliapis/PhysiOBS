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
    public partial class Frm_User_Task : Form
    {
        public TTaskList TL;
        public TCriticalPointsList CP;
        public int number = -1;
        double temp;
        public Frm_User_Task()
        {
            InitializeComponent();     
        }

        private void GraphTask()
        {
            double stotal=0;
            double s = 0, ns = 0;
            int i;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (((dataGridView1.Rows[i].Cells[0].Value == null) || (dataGridView1.Rows[i].Cells[1].Value == null) || (dataGridView1.Rows[i].Cells[2].Value == null))) continue;

                if (dataGridView1.Rows[i].Cells[3].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "1")
                    {
                        s += 1;
                    }
                    else
                    {
                        ns += 1;
                    }
                }
                else 
                {
                    ns += 1;
                }                
            }

            stotal = s + ns;
            TB_numberTasks.Text = stotal.ToString();
            TB_completedtasks.Text = s.ToString();
            TB_uncompletedtasks.Text = ns.ToString();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.Series["Tasks"].Points.Clear();
            if (stotal != 0)
            {
                chart1.Series["Tasks"].Points.AddXY("Success %", s / stotal);
                chart1.Series["Tasks"].Points[0].Color = System.Drawing.Color.LightGreen;
                chart1.Series["Tasks"].Points.AddXY("No Success %", ns / stotal);
                chart1.Series["Tasks"].Points[1].Color = System.Drawing.Color.Red;          
            }
            
        }

        private void Frm_User_Task_Load(object sender, EventArgs e)
        {
            chart1.Titles.Add("Task Success Rate");
            dataGridView1.Rows.Clear();
            ((DataGridViewCheckBoxColumn)dataGridView1.Columns[3]).FalseValue = "0";
            ((DataGridViewCheckBoxColumn)dataGridView1.Columns[3]).TrueValue = "1";
            TTask t;
            for (int i = 0; i < TL.Count; i++)
            {
                t = (TTask)TL[i];
                dataGridView1.Rows.Add();
                number++;
                ((DataGridViewTextBoxCell)dataGridView1.Rows[i].Cells[0]).Value = t.name;
                ((DataGridViewTextBoxCell)dataGridView1.Rows[i].Cells[1]).Value = double.Parse(t.start.ToString());
                ((DataGridViewTextBoxCell)dataGridView1.Rows[i].Cells[2]).Value = double.Parse(t.stop.ToString());
                dataGridView1.Rows[i].Cells[3].Value = (t.succeed?"1":"0");
                ((DataGridViewTextBoxCell)dataGridView1.Rows[i].Cells[4]).Value = t.comments;
                dataGridView1.Height += 22;
                this.Size = new Size(this.Width, this.Height + 22);
            }
            if (TL.Count != 0) BT_RemoveTask.Enabled = true;
            GraphTask();
        }

        private void BT_Add_Task_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != TL.Count)
            {
                MessageBox.Show("Required Fields Are Missing", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dataGridView1.Rows.Add();
            number++;
            dataGridView1.Height += 22;
            this.Size = new Size(this.Width, this.Height + 22);
            BT_RemoveTask.Enabled = true;
        }
       
        private void BT_RemoveTask_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The selected emotion will be removed!!!" + Environment.NewLine + "Are you Sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //user clicked yes          
                int selectedIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(selectedIndex);
                if (selectedIndex < TL.Count) TL.RemoveAt(selectedIndex);
                number--;
                dataGridView1.Height -= 22;
                this.Size = new Size(this.Width, this.Height - 22);
                if (TL.Count == 0) BT_RemoveTask.Enabled = false;
                GraphTask();
            }
            else
            {
                //user clicked no
                return;
            }
          
        }

        public void AddTask(int n)
            {
            TTask t;
            if (TL.Count - 1 < n)
            {
                t = new TTask();
                if (TL.Count() != 0)
                {
                    int max = -1;
                    foreach (TTask tt in TL)
                    {
                        if (Int32.Parse(tt.ID) > max)
                        {
                            max = Int32.Parse(tt.ID);
                        }
                    }
                    t.ID = (++max).ToString();
                }
                else
                {
                    t.ID = (++TL.ID).ToString();
                }
            }
            else
            {
                t = (TTask)TL[n];
            }
            t.name = dataGridView1.Rows[n].Cells[0].Value.ToString();
            if (double.Parse(dataGridView1.Rows[n].Cells[1].Value.ToString()) > double.Parse(dataGridView1.Rows[n].Cells[2].Value.ToString()))
            {
                t.start = Double.Parse(dataGridView1.Rows[n].Cells[2].Value.ToString());
                t.stop = Double.Parse(dataGridView1.Rows[n].Cells[1].Value.ToString());
            }
            else
            {
                t.start = Double.Parse(dataGridView1.Rows[n].Cells[1].Value.ToString());
                t.stop = Double.Parse(dataGridView1.Rows[n].Cells[2].Value.ToString());
            }
            t.succeed = (dataGridView1.Rows[n].Cells[3].Value == null ? false : dataGridView1.Rows[n].Cells[3].Value.ToString() == "1");
            if (dataGridView1.Rows[n].Cells[4].Value == null)
            {
                t.comments = "";
            }
            else
            {
                t.comments = dataGridView1.Rows[n].Cells[4].Value.ToString();
            }
            if (TL.Count - 1 < n)
            {
                TL.Add(t);
            }
        }

        public void UpdateTask(int n)
        {
            TTask t = (TTask)TL[n];
            t.name = dataGridView1.Rows[n].Cells[0].Value.ToString();
            if (double.Parse(dataGridView1.Rows[n].Cells[1].Value.ToString()) > double.Parse(dataGridView1.Rows[n].Cells[2].Value.ToString()))
            {
                t.start = Double.Parse(dataGridView1.Rows[n].Cells[2].Value.ToString());
                t.stop = Double.Parse(dataGridView1.Rows[n].Cells[1].Value.ToString());
            }
            else
            {
                t.start = Double.Parse(dataGridView1.Rows[n].Cells[1].Value.ToString());
                t.stop = Double.Parse(dataGridView1.Rows[n].Cells[2].Value.ToString());
            }
            t.succeed = (dataGridView1.Rows[n].Cells[3].Value == null ? false : dataGridView1.Rows[n].Cells[3].Value.ToString() == "1");
            if (dataGridView1.Rows[n].Cells[4].Value == null)
            {
                t.comments = "";
            }
            else
            {
                t.comments = dataGridView1.Rows[n].Cells[4].Value.ToString();
            }
        }       

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (number == dataGridView1.CurrentCell.RowIndex)
            {
                if (dataGridView1.Rows[number].Cells[0].Value != null && dataGridView1.Rows[number].Cells[1].Value != null && dataGridView1.Rows[number].Cells[2].Value != null)
                {
                    if (double.Parse(dataGridView1.Rows[number].Cells[1].Value.ToString()) > double.Parse(dataGridView1.Rows[number].Cells[2].Value.ToString()))
                    {
                        temp = double.Parse(dataGridView1.Rows[number].Cells[2].Value.ToString());
                        dataGridView1.Rows[number].Cells[2].Value = dataGridView1.Rows[number].Cells[1].Value.ToString();
                        dataGridView1.Rows[number].Cells[1].Value = temp;
                    }
                    AddTask(number);
                }
                else
                {
                   
                    return;
                } 
            }
            else
            {
                if (double.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString()) > double.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString()))
                {

                    temp = double.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value = temp;
                }
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value != null && dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value != null && dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value != null)
                {
                    UpdateTask(dataGridView1.CurrentCell.RowIndex);
                }
            }
            GraphTask();
        }
     

        private void Frm_User_Task_FormClosing(object sender, FormClosingEventArgs e)
        {
            CP.clear_points("task");
            foreach (TTask te in TL)
            {
                TCriticalPoint point1 = new TCriticalPoint();
                point1.name = te.name;
                point1.time = te.start;
                point1.Bar = "task";
                point1.obj = (object)te;
                CP.Add(point1);
                TCriticalPoint point2 = new TCriticalPoint();
                point2.name = te.name;
                point2.time = te.stop;
                point2.Bar = "task";
                point2.obj = (object)te;
                CP.Add(point2);
            }
            CP.Sort();
        }

       
    
    }
}
