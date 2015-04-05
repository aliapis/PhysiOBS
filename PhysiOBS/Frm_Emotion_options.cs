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
    public partial class Frm_Emotion_options : Form
    {
       
        public TEmotion Emotion;
        public TCriticalPointsList CP;
        public int index;
        public string id;
        public Frm_Emotion_options()
        {
            InitializeComponent();
            TXT_Ecomments.Select();          
        }

        private void Frm_Emotion_options_Load(object sender, EventArgs e)
        {
            TXT_Ecomments.Text = Emotion.comments;
            CB_Ename.Text = Emotion.name;
            TXT_Estop.Text = Emotion.stop.ToString();
            TXT_Estart.Text = Emotion.start.ToString();
        }

        private void BT_Save_Eopt_Click_1(object sender, EventArgs e)
        {
            if (TXT_Estop.Text == "" || TXT_Estart.Text == "")
            {
                MessageBox.Show("Required Fields Are Missing", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            Emotion.comments = TXT_Ecomments.Text;
            Emotion.name = CB_Ename.Text;
            Emotion.stop = double.Parse(TXT_Estop.Text);
            Emotion.start = double.Parse(TXT_Estart.Text);       
            this.Close();
        }

        private void BT_Cancel_Eopt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
