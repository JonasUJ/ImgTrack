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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackN)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(307, 519);
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(315, 472);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(184, 35);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panelColor
            // 
            this.panelColor.Location = new System.Drawing.Point(316, 422);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(373, 44);
            this.panelColor.TabIndex = 3;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(505, 472);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(184, 35);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // trackBarB
            // 
            this.trackBarB.Location = new System.Drawing.Point(313, 302);
            this.trackBarB.Maximum = 255;
            this.trackBarB.Name = "trackBarB";
            this.trackBarB.Size = new System.Drawing.Size(373, 45);
            this.trackBarB.TabIndex = 5;
            this.trackBarB.Scroll += new System.EventHandler(this.trackBarB_Scroll);
            // 
            // trackBarG
            // 
            this.trackBarG.Location = new System.Drawing.Point(313, 251);
            this.trackBarG.Maximum = 255;
            this.trackBarG.Name = "trackBarG";
            this.trackBarG.Size = new System.Drawing.Size(373, 45);
            this.trackBarG.TabIndex = 6;
            this.trackBarG.Scroll += new System.EventHandler(this.trackBarG_Scroll);
            // 
            // trackBarR
            // 
            this.trackBarR.Location = new System.Drawing.Point(315, 200);
            this.trackBarR.Maximum = 255;
            this.trackBarR.Name = "trackBarR";
            this.trackBarR.Size = new System.Drawing.Size(373, 45);
            this.trackBarR.TabIndex = 7;
            this.trackBarR.Scroll += new System.EventHandler(this.trackBarR_Scroll);
            // 
            // chart_histogram
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_histogram.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_histogram.Legends.Add(legend1);
            this.chart_histogram.Location = new System.Drawing.Point(315, 0);
            this.chart_histogram.Name = "chart_histogram";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_histogram.Series.Add(series1);
            this.chart_histogram.Size = new System.Drawing.Size(372, 194);
            this.chart_histogram.TabIndex = 8;
            this.chart_histogram.Text = "chart1";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(712, 422);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(27, 13);
            this.labelRed.TabIndex = 9;
            this.labelRed.Text = "Red";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(753, 390);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(36, 13);
            this.labelGreen.TabIndex = 10;
            this.labelGreen.Text = "Green";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(748, 440);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(28, 13);
            this.labelBlue.TabIndex = 11;
            this.labelBlue.Text = "Blue";
            // 
            // trackN
            // 
            this.trackN.Location = new System.Drawing.Point(312, 352);
            this.trackN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackN.Maximum = 100;
            this.trackN.Minimum = 1;
            this.trackN.Name = "trackN";
            this.trackN.Size = new System.Drawing.Size(374, 45);
            this.trackN.TabIndex = 12;
            this.trackN.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(712, 453);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nøjagtighed";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 519);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackN);
            this.Controls.Add(this.labelBlue);
            this.Controls.Add(this.labelGreen);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.chart_histogram);
            this.Controls.Add(this.trackBarR);
            this.Controls.Add(this.trackBarG);
            this.Controls.Add(this.trackBarB);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.pictureBoxPreview);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}