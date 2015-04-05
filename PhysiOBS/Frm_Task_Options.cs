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
    public partial class Frm_Task_Options : Form
    {
        public string higli = "";
        public TTask Task;
        public TCriticalPointsList CP;
        public int index;
        public Frm_Task_Options()
        {
            InitializeComponent();
            TXT_Tcomments.Select();
            if (Task != null)
            {
                higli = Task.name;
            }
        }
    
        private void Frm_Task_Options_Load(object sender, EventArgs e)
        {  
             TXT_Tcomments.Text = Task.comments;
             TXT_Tname.Text = Task.name;
             TXT_Tstop.Text = Task.stop.ToString();
             TXT_Tstart.Text = Task.start.ToString();
             if (Task.succeed)
             {
                 CHK_Success.Checked = true;
             }
             else
             {
                 CHK_Success.Checked = false;
             }       
        }       
        private void BT_Cancel_Topt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_Save_Topt_Click(object sender, EventArgs e)
        {

            if (TXT_Tstop.Text == "" || TXT_Tstart.Text == "" || TXT_Tname.Text=="")
            {
                MessageBox.Show("Required Fields Are Missing", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Task.comments = TXT_Tcomments.Text;
            Task.name = TXT_Tname.Text;
            Task.stop = double.Parse(TXT_Tstop.Text);
            Task.start = double.Parse(TXT_Tstart.Text);
            if (CHK_Success.Checked == false)
            {
                Task.succeed = false;
            }
            else
            {
                Task.succeed = true;
            }
           
            this.Close();                    
        }

    
       
         
    }
}
