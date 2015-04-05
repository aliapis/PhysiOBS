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
    public partial class Frm_Ass_Alg : Form
    {
        public TSignalList SL;
        public TAssignmentList AL;

        public Frm_Ass_Alg()
        {
            InitializeComponent();
        }

        private void Frm_Ass_Alg_Load(object sender, EventArgs e)
        {
            if (SL.Count == 0)
            {
                MessageBox.Show("NO SIGNALS UPLOADED");
                this.Close();
            }
            foreach (TSignal s in SL)
            {
                if (s.type=="Bio-SIGNAL")
                    ((DataGridViewComboBoxColumn)dataGridView1.Columns[0]).Items.Add(s.title);
            }

            ((DataGridViewComboBoxColumn)dataGridView1.Columns[1]).Items.Add("ΑΛΓ1");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[1]).Items.Add("ΑΛΓ2");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[1]).Items.Add("ΑΛΓ3");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[1]).Items.Add("ΑΛΓ4");

            dataGridView1.Rows.Clear();
            TAssignment a;
            for (int i = 0; i < AL.Count; i++)
            {
                a = (TAssignment)AL[i];
                dataGridView1.Rows.Add();
                ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[0]).Value = a.signalname;
                ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1]).Value = a.algname;
                dataGridView1.Rows[i].Cells[2].Value = a.order.ToString();
            }
        }

        private void BT_Close_Click(object sender, EventArgs e)
        {
            AL.Clear();
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Cells[0].Value == null) continue;
                TAssignment a = new TAssignment();
                a.signalname = r.Cells[0].Value.ToString();
                a.algname = r.Cells[1].Value.ToString();
                a.order = Int32.Parse(r.Cells[2].Value.ToString());
                AL.Add(a);
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
