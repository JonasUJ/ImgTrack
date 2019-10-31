namespace ImgTrack
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pb_left = new System.Windows.Forms.PictureBox();
            this.pb_right = new System.Windows.Forms.PictureBox();
            this.btn_capture = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gemBilledeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgw_setres = new System.ComponentModel.BackgroundWorker();
            this.btn_track = new System.Windows.Forms.Button();
            this.cb_isolate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(16, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pb_left);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pb_right);
            this.splitContainer1.Size = new System.Drawing.Size(760, 304);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 0;
            // 
            // pb_left
            // 
            this.pb_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_left.Location = new System.Drawing.Point(0, 0);
            this.pb_left.Margin = new System.Windows.Forms.Padding(4);
            this.pb_left.Name = "pb_left";
            this.pb_left.Size = new System.Drawing.Size(376, 302);
            this.pb_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_left.TabIndex = 0;
            this.pb_left.TabStop = false;
            // 
            // pb_right
            // 
            this.pb_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_right.Location = new System.Drawing.Point(0, 0);
            this.pb_right.Margin = new System.Windows.Forms.Padding(4);
            this.pb_right.Name = "pb_right";
            this.pb_right.Size = new System.Drawing.Size(376, 302);
            this.pb_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_right.TabIndex = 0;
            this.pb_right.TabStop = false;
            // 
            // btn_capture
            // 
            this.btn_capture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_capture.Location = new System.Drawing.Point(11, 338);
            this.btn_capture.Margin = new System.Windows.Forms.Padding(2);
            this.btn_capture.Name = "btn_capture";
            this.btn_capture.Size = new System.Drawing.Size(75, 23);
            this.btn_capture.TabIndex = 1;
            this.btn_capture.Text = "&Tag Billede";
            this.btn_capture.UseVisualStyleBackColor = true;
            this.btn_capture.Click += new System.EventHandler(this.Btn_capture_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSettingsToolStripMenuItem,
            this.exportSettingsToolStripMenuItem,
            this.openImageToolStripMenuItem,
            this.gemBilledeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.fileToolStripMenuItem.Text = "&Fil";
            // 
            // importSettingsToolStripMenuItem
            // 
            this.importSettingsToolStripMenuItem.Name = "importSettingsToolStripMenuItem";
            this.importSettingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.importSettingsToolStripMenuItem.Text = "&Imporér Indstillinger";
            this.importSettingsToolStripMenuItem.Click += new System.EventHandler(this.importSettingsToolStripMenuItem_Click);
            // 
            // exportSettingsToolStripMenuItem
            // 
            this.exportSettingsToolStripMenuItem.Name = "exportSettingsToolStripMenuItem";
            this.exportSettingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportSettingsToolStripMenuItem.Text = "&Exportér Indstillinger";
            this.exportSettingsToolStripMenuItem.Click += new System.EventHandler(this.exportSettingsToolStripMenuItem_Click);
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openImageToolStripMenuItem.Text = "Å&ben Billede";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // gemBilledeToolStripMenuItem
            // 
            this.gemBilledeToolStripMenuItem.Name = "gemBilledeToolStripMenuItem";
            this.gemBilledeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.gemBilledeToolStripMenuItem.Text = "&Gem Billede";
            this.gemBilledeToolStripMenuItem.Click += new System.EventHandler(this.gemBilledeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "&Afslut";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdToolStripMenuItem,
            this.videoToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.settingsToolStripMenuItem.Text = "&Indstillinger";
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.thresholdToolStripMenuItem.Text = "&Grænse";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.thresholdToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.videoToolStripMenuItem.Text = "&Video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // bgw_setres
            // 
            this.bgw_setres.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bgw_setres_DoWork);
            // 
            // btn_track
            // 
            this.btn_track.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_track.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_track.Location = new System.Drawing.Point(680, 338);
            this.btn_track.Name = "btn_track";
            this.btn_track.Size = new System.Drawing.Size(92, 23);
            this.btn_track.TabIndex = 4;
            this.btn_track.Text = "&Start Tracking";
            this.btn_track.UseVisualStyleBackColor = false;
            this.btn_track.Click += new System.EventHandler(this.btn_track_Click);
            // 
            // cb_isolate
            // 
            this.cb_isolate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_isolate.AutoSize = true;
            this.cb_isolate.Location = new System.Drawing.Point(596, 342);
            this.cb_isolate.Name = "cb_isolate";
            this.cb_isolate.Size = new System.Drawing.Size(78, 17);
            this.cb_isolate.TabIndex = 5;
            this.cb_isolate.Text = "Isolér farve";
            this.cb_isolate.UseVisualStyleBackColor = true;
            this.cb_isolate.CheckedChanged += new System.EventHandler(this.cb_isolate_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 372);
            this.Controls.Add(this.cb_isolate);
            this.Controls.Add(this.btn_track);
            this.Controls.Add(this.btn_capture);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Form1";
            this.Text = "ImgTrack";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pb_left;
        private System.Windows.Forms.PictureBox pb_right;
        private System.Windows.Forms.Button btn_capture;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgw_setres;
        private System.Windows.Forms.Button btn_track;
        private System.Windows.Forms.ToolStripMenuItem gemBilledeToolStripMenuItem;
        private System.Windows.Forms.CheckBox cb_isolate;
    }
}

