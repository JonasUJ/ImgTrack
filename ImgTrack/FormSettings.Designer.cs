namespace ImgTrack
{
    partial class FormSettings
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelColor = new System.Windows.Forms.Panel();
            this.buttonApply = new System.Windows.Forms.Button();
            this.trackBarB = new System.Windows.Forms.TrackBar();
            this.trackBarG = new System.Windows.Forms.TrackBar();
            this.trackBarR = new System.Windows.Forms.TrackBar();
            this.chart_histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.trackN = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackN)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(430, 591);
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(666, 556);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panelColor
            // 
            this.panelColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelColor.Location = new System.Drawing.Point(6, 472);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(373, 46);
            this.panelColor.TabIndex = 3;
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(747, 556);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // trackBarB
            // 
            this.trackBarB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarB.Location = new System.Drawing.Point(6, 359);
            this.trackBarB.Maximum = 255;
            this.trackBarB.Name = "trackBarB";
            this.trackBarB.Size = new System.Drawing.Size(372, 45);
            this.trackBarB.TabIndex = 5;
            this.trackBarB.Scroll += new System.EventHandler(this.trackBarB_Scroll);
            // 
            // trackBarG
            // 
            this.trackBarG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarG.Location = new System.Drawing.Point(6, 295);
            this.trackBarG.Maximum = 255;
            this.trackBarG.Name = "trackBarG";
            this.trackBarG.Size = new System.Drawing.Size(372, 45);
            this.trackBarG.TabIndex = 6;
            this.trackBarG.Scroll += new System.EventHandler(this.trackBarG_Scroll);
            // 
            // trackBarR
            // 
            this.trackBarR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarR.Location = new System.Drawing.Point(6, 231);
            this.trackBarR.Maximum = 255;
            this.trackBarR.Name = "trackBarR";
            this.trackBarR.Size = new System.Drawing.Size(372, 45);
            this.trackBarR.TabIndex = 7;
            this.trackBarR.Scroll += new System.EventHandler(this.trackBarR_Scroll);
            // 
            // chart_histogram
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_histogram.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_histogram.Legends.Add(legend2);
            this.chart_histogram.Location = new System.Drawing.Point(6, 18);
            this.chart_histogram.Name = "chart_histogram";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_histogram.Series.Add(series2);
            this.chart_histogram.Size = new System.Drawing.Size(372, 194);
            this.chart_histogram.TabIndex = 8;
            this.chart_histogram.Text = "chart1";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(3, 215);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(27, 13);
            this.labelRed.TabIndex = 9;
            this.labelRed.Text = "Red";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(3, 279);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(36, 13);
            this.labelGreen.TabIndex = 10;
            this.labelGreen.Text = "Green";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(3, 343);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(28, 13);
            this.labelBlue.TabIndex = 11;
            this.labelBlue.Text = "Blue";
            // 
            // trackN
            // 
            this.trackN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackN.Location = new System.Drawing.Point(6, 422);
            this.trackN.Margin = new System.Windows.Forms.Padding(2);
            this.trackN.Maximum = 100;
            this.trackN.Minimum = 1;
            this.trackN.Name = "trackN";
            this.trackN.Size = new System.Drawing.Size(372, 45);
            this.trackN.TabIndex = 12;
            this.trackN.TickFrequency = 2;
            this.trackN.Value = 1;
            this.trackN.Scroll += new System.EventHandler(this.trackN_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 407);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nøjagtighed";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.trackBarR);
            this.groupBox1.Controls.Add(this.labelRed);
            this.groupBox1.Controls.Add(this.chart_histogram);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelBlue);
            this.groupBox1.Controls.Add(this.trackN);
            this.groupBox1.Controls.Add(this.labelGreen);
            this.groupBox1.Controls.Add(this.trackBarG);
            this.groupBox1.Controls.Add(this.trackBarB);
            this.groupBox1.Controls.Add(this.panelColor);
            this.groupBox1.Location = new System.Drawing.Point(436, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 538);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Threshold Settings";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 591);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.pictureBoxPreview);
            this.MinimumSize = new System.Drawing.Size(850, 630);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.TrackBar trackBarB;
        private System.Windows.Forms.TrackBar trackBarG;
        private System.Windows.Forms.TrackBar trackBarR;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_histogram;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.TrackBar trackN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}