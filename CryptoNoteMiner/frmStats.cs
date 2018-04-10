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
    public partial class frmStats : Form
    {
        int carga = 0;
        string address = "";
        public frmStats()
        {
            InitializeComponent();
            Main frm = new Main();
            address = frm.textBoxAddress.Text;
            lbaddress.Text = address;

            webBrowser1.Navigate("http://superiorcoinpool.com/");
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (webBrowser1.Url.ToString() == "http://superiorcoinpool.com/")
                {
                    button1.Enabled = true;
                    carga = carga + 1;
                }
            }
            catch
            {

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (webBrowser1.Url.ToString() == "http://superiorcoinpool.com/")
                {
                    webBrowser1.Document.GetElementById("yourStatsInput").InvokeMember("focus");
                    webBrowser1.Document.GetElementById("yourStatsInput").InnerText = address;
                    webBrowser1.Document.GetElementById("lookUp").InvokeMember("click");
                    carga = 3;

                    timer1.Enabled = true;
                    timer1.Start();
                }
            }
            catch
            {

            }
            

            
        }

        private void frmStats_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (carga>=3)
                {
                    lbbalance.Text = webBrowser1.Document.GetElementById("yourPendingBalance").InnerText;
                    lbhash.Text = webBrowser1.Document.GetElementById("yourHashrateHolder").InnerText;
                    lbpaid.Text = webBrowser1.Document.GetElementById("yourPaid").InnerText;
                    lbshare.Text = webBrowser1.Document.GetElementById("yourLastShare").InnerText;
                    lbtotalhash.Text = webBrowser1.Document.GetElementById("yourHashes").InnerText;
                }
                
            }
            catch
            {

            }
            
        }
    }
}
