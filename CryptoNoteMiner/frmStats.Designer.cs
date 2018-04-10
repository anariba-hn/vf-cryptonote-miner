namespace VFCNMiner
{
    partial class frmStats
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStats));
            this.label1 = new System.Windows.Forms.Label();
            this.lbaddress = new System.Windows.Forms.Label();
            this.lbbalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbshare = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbpaid = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbhash = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbtotalhash = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address :";
            // 
            // lbaddress
            // 
            this.lbaddress.AutoSize = true;
            this.lbaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbaddress.Location = new System.Drawing.Point(82, 14);
            this.lbaddress.Name = "lbaddress";
            this.lbaddress.Size = new System.Drawing.Size(0, 15);
            this.lbaddress.TabIndex = 1;
            // 
            // lbbalance
            // 
            this.lbbalance.AutoSize = true;
            this.lbbalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbalance.Location = new System.Drawing.Point(135, 51);
            this.lbbalance.Name = "lbbalance";
            this.lbbalance.Size = new System.Drawing.Size(0, 15);
            this.lbbalance.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Pending Balance :";
            // 
            // lbshare
            // 
            this.lbshare.AutoSize = true;
            this.lbshare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbshare.Location = new System.Drawing.Point(161, 118);
            this.lbshare.Name = "lbshare";
            this.lbshare.Size = new System.Drawing.Size(0, 15);
            this.lbshare.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Last Share Submitted:";
            // 
            // lbpaid
            // 
            this.lbpaid.AutoSize = true;
            this.lbpaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpaid.Location = new System.Drawing.Point(91, 83);
            this.lbpaid.Name = "lbpaid";
            this.lbpaid.Size = new System.Drawing.Size(0, 15);
            this.lbpaid.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Total Paid :";
            // 
            // lbhash
            // 
            this.lbhash.AutoSize = true;
            this.lbhash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhash.Location = new System.Drawing.Point(91, 155);
            this.lbhash.Name = "lbhash";
            this.lbhash.Size = new System.Drawing.Size(0, 15);
            this.lbhash.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Hash Rate:";
            // 
            // lbtotalhash
            // 
            this.lbtotalhash.AutoSize = true;
            this.lbtotalhash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotalhash.Location = new System.Drawing.Point(174, 191);
            this.lbtotalhash.Name = "lbtotalhash";
            this.lbtotalhash.Size = new System.Drawing.Size(0, 15);
            this.lbtotalhash.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Total Hashes Submitted:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(49, 71);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(686, 158);
            this.webBrowser1.TabIndex = 12;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(420, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Load Your Stats";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbaddress);
            this.panel1.Controls.Add(this.lbtotalhash);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbbalance);
            this.panel1.Controls.Add(this.lbhash);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lbpaid);
            this.panel1.Controls.Add(this.lbshare);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 215);
            this.panel1.TabIndex = 14;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 263);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Your Stats & Payment History";
            this.Load += new System.EventHandler(this.frmStats_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbaddress;
        private System.Windows.Forms.Label lbbalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbshare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbpaid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbhash;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbtotalhash;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}