namespace Aparature_Proxies
{
    partial class mainFrm
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
            this.LV_Proxies = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Btn_StartChecking = new System.Windows.Forms.Button();
            this.LB_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.PB_Status = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_Proxies
            // 
            this.LV_Proxies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LV_Proxies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Proxies.FullRowSelect = true;
            this.LV_Proxies.GridLines = true;
            this.LV_Proxies.Location = new System.Drawing.Point(3, 16);
            this.LV_Proxies.Name = "LV_Proxies";
            this.LV_Proxies.Size = new System.Drawing.Size(350, 206);
            this.LV_Proxies.TabIndex = 0;
            this.LV_Proxies.UseCompatibleStateImageBehavior = false;
            this.LV_Proxies.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 267;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MS";
            this.columnHeader2.Width = 86;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LV_Proxies);
            this.groupBox1.Location = new System.Drawing.Point(12, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxy Checker";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LB_Status,
            this.PB_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 320);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(380, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Btn_StartChecking
            // 
            this.Btn_StartChecking.Location = new System.Drawing.Point(15, 12);
            this.Btn_StartChecking.Name = "Btn_StartChecking";
            this.Btn_StartChecking.Size = new System.Drawing.Size(75, 23);
            this.Btn_StartChecking.TabIndex = 3;
            this.Btn_StartChecking.Text = "Start";
            this.Btn_StartChecking.UseVisualStyleBackColor = true;
            this.Btn_StartChecking.Click += new System.EventHandler(this.Btn_StartChecking_Click);
            // 
            // LB_Status
            // 
            this.LB_Status.Name = "LB_Status";
            this.LB_Status.Size = new System.Drawing.Size(143, 17);
            this.LB_Status.Text = "Success: N/A - Failed N/A";
            // 
            // PB_Status
            // 
            this.PB_Status.Name = "PB_Status";
            this.PB_Status.Size = new System.Drawing.Size(100, 16);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 342);
            this.Controls.Add(this.Btn_StartChecking);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aparature Proxies";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFrm_FormClosing);
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LV_Proxies;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button Btn_StartChecking;
        private System.Windows.Forms.ToolStripStatusLabel LB_Status;
        private System.Windows.Forms.ToolStripProgressBar PB_Status;
    }
}

