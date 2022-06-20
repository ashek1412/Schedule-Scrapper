
namespace ScheduleFinder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NextCnt = new System.Windows.Forms.Label();
            this.prevCnt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelSlotBooked = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(3, 3);
            this.webView21.MinimumSize = new System.Drawing.Size(780, 680);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1423, 938);
            this.webView21.Source = new System.Uri("https://www.gov.uk/book-pupil-driving-test", System.UriKind.Absolute);
            this.webView21.TabIndex = 2;
            this.webView21.ZoomFactor = 1D;
            this.webView21.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.webView21_CoreWebView2InitializationCompleted);
            this.webView21.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webView21_NavigationCompleted);
            this.webView21.SourceChanged += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs>(this.webView21_SourceChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.BackColor = System.Drawing.Color.DarkRed;
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.ForeColor = System.Drawing.Color.White;
            this.buttonStop.Location = new System.Drawing.Point(1272, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(108, 32);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.BackColor = System.Drawing.Color.Green;
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Enabled = false;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonStart.Location = new System.Drawing.Point(1133, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(115, 32);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Elapsed Time :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(479, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Next Clicked :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(279, 12);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Previos Clicked :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NextCnt
            // 
            this.NextCnt.AutoSize = true;
            this.NextCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextCnt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.NextCnt.Location = new System.Drawing.Point(577, 13);
            this.NextCnt.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.NextCnt.Name = "NextCnt";
            this.NextCnt.Size = new System.Drawing.Size(16, 16);
            this.NextCnt.TabIndex = 8;
            this.NextCnt.Text = "0";
            this.NextCnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prevCnt
            // 
            this.prevCnt.AutoSize = true;
            this.prevCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevCnt.ForeColor = System.Drawing.Color.Red;
            this.prevCnt.Location = new System.Drawing.Point(387, 13);
            this.prevCnt.Name = "prevCnt";
            this.prevCnt.Size = new System.Drawing.Size(16, 16);
            this.prevCnt.TabIndex = 9;
            this.prevCnt.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.labelSlotBooked);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Controls.Add(this.prevCnt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NextCnt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 941);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1427, 44);
            this.panel1.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(914, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(133, 21);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // labelSlotBooked
            // 
            this.labelSlotBooked.AutoSize = true;
            this.labelSlotBooked.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSlotBooked.ForeColor = System.Drawing.Color.Purple;
            this.labelSlotBooked.Location = new System.Drawing.Point(724, 13);
            this.labelSlotBooked.Name = "labelSlotBooked";
            this.labelSlotBooked.Size = new System.Drawing.Size(113, 16);
            this.labelSlotBooked.TabIndex = 12;
            this.labelSlotBooked.Text = "Slot Booked : 0";
            this.labelSlotBooked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 985);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webView21);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Finder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NextCnt;
        private System.Windows.Forms.Label prevCnt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSlotBooked;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

