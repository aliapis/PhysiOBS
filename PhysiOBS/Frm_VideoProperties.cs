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
    public partial class Frm_VideoProperties : Form
    {

        public TSignal S = new TSignal();

        public Frm_VideoProperties()
        {
            InitializeComponent();
        }

        

        private void Frm_VideoProperties_Load(object sender, EventArgs e)
        {
            //ΓΙΑ ΚΑΘΕ PEDIO FORTVNEI ΤΙΣ ARXIKES ΤΙΜΕΣ
            if (S != null)
            {
                TB_Filename.Text = S.filename;
                TB_Type.Text = S.type;
                TB_Duration.Text = S.duration.ToString();
                TB_FileFormat.Text = S.format;
                TB_Title.Text = S.title;
                TB_Delay.Text = S.delay.ToString();
            }
        }

        private void BT_Save_Vid(object sender, EventArgs e)
        {
            //ΓΙΑ ΚΑΘΕ PEDIO POY BAZEI O USER TO ANAPODO
            S.title = TB_Title.Text;
            S.delay = Double.Parse(TB_Delay.Text);
            this.Close();
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
        
    }
}
