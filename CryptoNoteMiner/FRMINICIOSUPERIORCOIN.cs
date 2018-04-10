using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VFCNMiner
{
    public partial class FRMINICIOSUPERIORCOIN : Form
    {
        public FRMINICIOSUPERIORCOIN()
        {
            InitializeComponent();
            TIEMPO.Enabled = true;
            TIEMPO.Interval = 4000;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void TIEMPO_Tick(object sender, EventArgs e)
        {
            TIEMPO.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
