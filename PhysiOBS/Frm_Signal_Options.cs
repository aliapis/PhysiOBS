using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PhysiOBS_Kernel;


namespace PhysiOBS
{
    public partial class Frm_Signal_Options : Form
    {
        public TManager Manager;
        OpenFileDialog ofd = new OpenFileDialog();
        public TSignal Signal;
        public FileInfo finfo;
        public Frm_Signal_Options()
        {
            InitializeComponent();
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_Open_Signal_Click(object sender, EventArgs e)
        {            
            //ofd.InitialDirectory = "C:\\";
            //if (CB_Signal_Format.Text == ".csv")
            //{
                ofd.Filter = "csv|*.csv";
           // }
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {

                TB_Filename.Text = ofd.FileName;
                finfo = new FileInfo(ofd.FileName);
            }
            else
            {
                return;
            }
           
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            //έλεγχος για απαιτούμενα πεδία στη φόρμα
            if (CB_Output_Method.Text == ""|| TB_Sampling.Text=="" || TB_Filename.Text=="" || CB_Signal_Type.Text=="") 
            {
               MessageBox.Show("Required Fields Are Missing", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }
            else
            {
                Signal.filename = ofd.FileName;
                Signal.title = TB_Signal_Title.Text.ToString();
                Signal.type = "Bio-SIGNAL";
                Signal.signaltype=CB_Signal_Type.Text.ToString();
                Signal.format=Path.GetExtension(ofd.FileName);
                Signal.delay= 0;
                Signal.output=CB_Output_Method.Text.ToString();
                Signal.sampling=TB_Sampling.Text.ToString();
                this.Close();
            }
        }

        private void Frm_Signal_Options_Load(object sender, EventArgs e)
        {
        }

        private void BT_Clear_Form_Click(object sender, EventArgs e)
        {
        }

        
        private void CB_Signal_Format_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (CB_Signal_Format.Text!="")
            {
                BT_Open_Signal.Enabled = true;
            }*/
        }
    }
}
