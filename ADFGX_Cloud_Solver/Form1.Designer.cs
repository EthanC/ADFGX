namespace ADFGX_Cloud_Solver
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statuslbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pbar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabber = new System.Windows.Forms.TabControl();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.Description = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CPUlevel = new System.Windows.Forms.ComboBox();
            this.ContribText = new System.Windows.Forms.TextBox();
            this.ContribLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GPUCheck = new System.Windows.Forms.CheckBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdQuit = new System.Windows.Forms.Button();
            this.LogLabel = new System.Windows.Forms.Label();
            this.LogText = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.resultsText = new System.Windows.Forms.TextBox();
            this.NewsPage = new System.Windows.Forms.TabPage();
            this.newsText = new System.Windows.Forms.TextBox();
            this.InitServerWorker = new System.ComponentModel.BackgroundWorker();
            this.UpdateServerInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.cmdCredit = new System.Windows.Forms.Label();
            this.BruteForceWorker = new System.ComponentModel.BackgroundWorker();
            this.UpdateLogTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.KeysTried = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.GoodKeys = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.tabber.SuspendLayout();
            this.MainPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.NewsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statuslbl,
            this.Pbar,
            this.toolStripStatusLabel2,
            this.KeysTried,
            this.toolStripStatusLabel4,
            this.GoodKeys});
            this.statusStrip1.Location = new System.Drawing.Point(0, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(714, 30);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 53;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(70, 25);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // statuslbl
            // 
            this.statuslbl.BackColor = System.Drawing.Color.Transparent;
            this.statuslbl.Name = "statuslbl";
            this.statuslbl.Size = new System.Drawing.Size(47, 25);
            this.statuslbl.Text = "IDLE";
            // 
            // Pbar
            // 
            this.Pbar.Name = "Pbar";
            this.Pbar.Size = new System.Drawing.Size(100, 24);
            this.Pbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // tabber
            // 
            this.tabber.Controls.Add(this.MainPage);
            this.tabber.Controls.Add(this.tabPage2);
            this.tabber.Controls.Add(this.NewsPage);
            this.tabber.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabber.Location = new System.Drawing.Point(0, 105);
            this.tabber.Name = "tabber";
            this.tabber.SelectedIndex = 0;
            this.tabber.Size = new System.Drawing.Size(714, 350);
            this.tabber.TabIndex = 5;
            this.tabber.TabStop = false;
            // 
            // MainPage
            // 
            this.MainPage.BackColor = System.Drawing.Color.Transparent;
            this.MainPage.Controls.Add(this.Description);
            this.MainPage.Controls.Add(this.groupBox1);
            this.MainPage.Controls.Add(this.LogLabel);
            this.MainPage.Controls.Add(this.LogText);
            this.MainPage.Location = new System.Drawing.Point(4, 34);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainPage.Size = new System.Drawing.Size(706, 312);
            this.MainPage.TabIndex = 0;
            this.MainPage.Text = "Main";
            // 
            // Description
            // 
            this.Description.BackColor = System.Drawing.Color.Gainsboro;
            this.Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.ForeColor = System.Drawing.Color.Maroon;
            this.Description.Location = new System.Drawing.Point(0, 1);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(706, 72);
            this.Description.TabIndex = 59;
            this.Description.Text = resources.GetString("Description.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CPUlevel);
            this.groupBox1.Controls.Add(this.ContribText);
            this.groupBox1.Controls.Add(this.ContribLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.GPUCheck);
            this.groupBox1.Controls.Add(this.cmdStart);
            this.groupBox1.Controls.Add(this.cmdQuit);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 102);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // CPUlevel
            // 
            this.CPUlevel.FormattingEnabled = true;
            this.CPUlevel.Items.AddRange(new object[] {
            "LOW",
            "HIGH"});
            this.CPUlevel.Location = new System.Drawing.Point(116, 31);
            this.CPUlevel.Name = "CPUlevel";
            this.CPUlevel.Size = new System.Drawing.Size(121, 28);
            this.CPUlevel.TabIndex = 1;
            // 
            // ContribText
            // 
            this.ContribText.Location = new System.Drawing.Point(513, 67);
            this.ContribText.Name = "ContribText";
            this.ContribText.Size = new System.Drawing.Size(168, 26);
            this.ContribText.TabIndex = 0;
            this.ContribText.Text = "UrRedditName";
            // 
            // ContribLabel
            // 
            this.ContribLabel.AutoSize = true;
            this.ContribLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContribLabel.Location = new System.Drawing.Point(6, 69);
            this.ContribLabel.Name = "ContribLabel";
            this.ContribLabel.Size = new System.Drawing.Size(501, 20);
            this.ContribLabel.TabIndex = 53;
            this.ContribLabel.Text = "Contributor Name (Used to identify what you contribute later):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "CPU Power:";
            // 
            // GPUCheck
            // 
            this.GPUCheck.AutoSize = true;
            this.GPUCheck.Enabled = false;
            this.GPUCheck.Location = new System.Drawing.Point(256, 32);
            this.GPUCheck.Name = "GPUCheck";
            this.GPUCheck.Size = new System.Drawing.Size(145, 24);
            this.GPUCheck.TabIndex = 52;
            this.GPUCheck.TabStop = false;
            this.GPUCheck.Text = "GPU (SOON!)";
            this.GPUCheck.UseVisualStyleBackColor = true;
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(443, 29);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(116, 28);
            this.cmdStart.TabIndex = 2;
            this.cmdStart.Text = "Start Factoring";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdQuit
            // 
            this.cmdQuit.Location = new System.Drawing.Point(565, 29);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(116, 28);
            this.cmdQuit.TabIndex = 3;
            this.cmdQuit.Text = "Stop";
            this.cmdQuit.UseVisualStyleBackColor = true;
            this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogLabel.Location = new System.Drawing.Point(8, 184);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(116, 20);
            this.LogLabel.TabIndex = 57;
            this.LogLabel.Text = "Running Log:";
            // 
            // LogText
            // 
            this.LogText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogText.Location = new System.Drawing.Point(8, 207);
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogText.Size = new System.Drawing.Size(690, 102);
            this.LogText.TabIndex = 56;
            this.LogText.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.resultsText);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(706, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Top Results";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // resultsText
            // 
            this.resultsText.AcceptsReturn = true;
            this.resultsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsText.Location = new System.Drawing.Point(3, 3);
            this.resultsText.Multiline = true;
            this.resultsText.Name = "resultsText";
            this.resultsText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultsText.Size = new System.Drawing.Size(700, 306);
            this.resultsText.TabIndex = 4;
            this.resultsText.Text = "Loading, Please Wait...";
            // 
            // NewsPage
            // 
            this.NewsPage.Controls.Add(this.newsText);
            this.NewsPage.Location = new System.Drawing.Point(4, 34);
            this.NewsPage.Name = "NewsPage";
            this.NewsPage.Padding = new System.Windows.Forms.Padding(3);
            this.NewsPage.Size = new System.Drawing.Size(706, 312);
            this.NewsPage.TabIndex = 2;
            this.NewsPage.Text = "News";
            this.NewsPage.UseVisualStyleBackColor = true;
            // 
            // newsText
            // 
            this.newsText.AcceptsReturn = true;
            this.newsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsText.Location = new System.Drawing.Point(3, 3);
            this.newsText.Multiline = true;
            this.newsText.Name = "newsText";
            this.newsText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.newsText.Size = new System.Drawing.Size(700, 306);
            this.newsText.TabIndex = 1;
            this.newsText.Text = "Loading, Please Wait...";
            // 
            // InitServerWorker
            // 
            this.InitServerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InitServerWorker_DoWork);
            // 
            // UpdateServerInfoTimer
            // 
            this.UpdateServerInfoTimer.Enabled = true;
            this.UpdateServerInfoTimer.Interval = 600000;
            this.UpdateServerInfoTimer.Tick += new System.EventHandler(this.UpdateServerInfoTimer_Tick);
            // 
            // cmdCredit
            // 
            this.cmdCredit.AutoSize = true;
            this.cmdCredit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCredit.ForeColor = System.Drawing.Color.White;
            this.cmdCredit.Location = new System.Drawing.Point(608, 105);
            this.cmdCredit.Name = "cmdCredit";
            this.cmdCredit.Size = new System.Drawing.Size(99, 25);
            this.cmdCredit.TabIndex = 6;
            this.cmdCredit.Text = "Credits...";
            this.cmdCredit.Click += new System.EventHandler(this.cmdCredit_Click);
            // 
            // BruteForceWorker
            // 
            this.BruteForceWorker.WorkerReportsProgress = true;
            this.BruteForceWorker.WorkerSupportsCancellation = true;
            this.BruteForceWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BruteForceWorker_DoWork);
            // 
            // UpdateLogTimer
            // 
            this.UpdateLogTimer.Interval = 5000;
            this.UpdateLogTimer.Tick += new System.EventHandler(this.UpdateLogTimer_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = global::ADFGX_Cloud_Solver.Properties.Resources.logo;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(0, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(534, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 55;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ADFGX_Cloud_Solver.Properties.Resources.Thumbnail;
            this.pictureBox1.Location = new System.Drawing.Point(531, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(178, 25);
            this.toolStripStatusLabel2.Text = "Approx. Keys Tried:";
            // 
            // KeysTried
            // 
            this.KeysTried.Name = "KeysTried";
            this.KeysTried.Size = new System.Drawing.Size(112, 25);
            this.KeysTried.Text = "0000000000";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(108, 25);
            this.toolStripStatusLabel4.Text = "Good Keys:";
            // 
            // GoodKeys
            // 
            this.GoodKeys.Name = "GoodKeys";
            this.GoodKeys.Size = new System.Drawing.Size(42, 25);
            this.GoodKeys.Text = "000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(714, 485);
            this.Controls.Add(this.cmdCredit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tabber);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ADFGX Cloud Factoring Application v2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabber.ResumeLayout(false);
            this.MainPage.ResumeLayout(false);
            this.MainPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.NewsPage.ResumeLayout(false);
            this.NewsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statuslbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabber;
        private System.Windows.Forms.TabPage MainPage;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox GPUCheck;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdQuit;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.TextBox LogText;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox resultsText;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage NewsPage;
        private System.Windows.Forms.TextBox newsText;
        private System.ComponentModel.BackgroundWorker InitServerWorker;
        private System.Windows.Forms.Timer UpdateServerInfoTimer;
        private System.Windows.Forms.Label cmdCredit;
        private System.ComponentModel.BackgroundWorker BruteForceWorker;
        private System.Windows.Forms.TextBox ContribText;
        private System.Windows.Forms.Label ContribLabel;
        private System.Windows.Forms.ToolStripProgressBar Pbar;
        private System.Windows.Forms.Timer UpdateLogTimer;
        private System.Windows.Forms.ComboBox CPUlevel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel KeysTried;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel GoodKeys;
    }
}

