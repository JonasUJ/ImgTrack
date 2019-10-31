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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.pb_preview = new System.Windows.Forms.PictureBox();
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
            this.gb_settings = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackC = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelAvg = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_picker = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackN)).BeginInit();
            this.gb_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackC)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_preview
            // 
            this.pb_preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_preview.Location = new System.Drawing.Point(0, 0);
            this.pb_preview.Name = "pb_preview";
            this.pb_preview.Size = new System.Drawing.Size(430, 675);
            this.pb_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_preview.TabIndex = 0;
            this.pb_preview.TabStop = false;
            this.pb_preview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_preview_MouseClick);
            // 
            // panelColor
            // 
            this.panelColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelColor.Location = new System.Drawing.Point(6, 553);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(181, 51);
            this.panelColor.TabIndex = 3;
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonApply.Location = new System.Drawing.Point(747, 642);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "&Luk";
            this.toolTip.SetToolTip(this.buttonApply, "Luk vinduet, indstillingerne er blevet gemt");
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.CloseForm);
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
            this.toolTip.SetToolTip(this.trackBarB, "Blå-komponenten i den valgte farve");
            this.trackBarB.Value = 180;
            this.trackBarB.Scroll += new System.EventHandler(this.trackBarB_Scroll);
            this.trackBarB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tb_MouseUp);
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
            this.toolTip.SetToolTip(this.trackBarG, "Grøn-komponenten i den valgte farve");
            this.trackBarG.Value = 180;
            this.trackBarG.Scroll += new System.EventHandler(this.trackBarG_Scroll);
            this.trackBarG.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tb_MouseUp);
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
            this.toolTip.SetToolTip(this.trackBarR, "Rød-komponenten i den valgte farve");
            this.trackBarR.Value = 180;
            this.trackBarR.Scroll += new System.EventHandler(this.trackBarR_Scroll);
            this.trackBarR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tb_MouseUp);
            // 
            // chart_histogram
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_histogram.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_histogram.Legends.Add(legend1);
            this.chart_histogram.Location = new System.Drawing.Point(6, 18);
            this.chart_histogram.Name = "chart_histogram";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_histogram.Series.Add(series1);
            this.chart_histogram.Size = new System.Drawing.Size(372, 194);
            this.chart_histogram.TabIndex = 8;
            this.chart_histogram.Text = "chart1";
            this.toolTip.SetToolTip(this.chart_histogram, "Histogram over gennemsnittet af billedets rød-grøn-blå komponenter");
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(3, 215);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(27, 13);
            this.labelRed.TabIndex = 9;
            this.labelRed.Text = "Rød";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(3, 279);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(30, 13);
            this.labelGreen.TabIndex = 10;
            this.labelGreen.Text = "Grøn";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(3, 343);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(22, 13);
            this.labelBlue.TabIndex = 11;
            this.labelBlue.Text = "Blå";
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
            this.toolTip.SetToolTip(this.trackN, "Hvor præcist farven på billedet skal matche den valgte farve. Lavere nøjagtighed " +
        "kan se et bredere spektrum af farver");
            this.trackN.Value = 50;
            this.trackN.Scroll += new System.EventHandler(this.trackN_Scroll);
            this.trackN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tb_MouseUp);
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
            // gb_settings
            // 
            this.gb_settings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_settings.Controls.Add(this.label9);
            this.gb_settings.Controls.Add(this.label8);
            this.gb_settings.Controls.Add(this.label7);
            this.gb_settings.Controls.Add(this.label6);
            this.gb_settings.Controls.Add(this.trackC);
            this.gb_settings.Controls.Add(this.label5);
            this.gb_settings.Controls.Add(this.label4);
            this.gb_settings.Controls.Add(this.panelAvg);
            this.gb_settings.Controls.Add(this.label3);
            this.gb_settings.Controls.Add(this.label2);
            this.gb_settings.Controls.Add(this.trackBarR);
            this.gb_settings.Controls.Add(this.labelRed);
            this.gb_settings.Controls.Add(this.chart_histogram);
            this.gb_settings.Controls.Add(this.label1);
            this.gb_settings.Controls.Add(this.labelBlue);
            this.gb_settings.Controls.Add(this.trackN);
            this.gb_settings.Controls.Add(this.labelGreen);
            this.gb_settings.Controls.Add(this.trackBarG);
            this.gb_settings.Controls.Add(this.trackBarB);
            this.gb_settings.Controls.Add(this.panelColor);
            this.gb_settings.Location = new System.Drawing.Point(436, 12);
            this.gb_settings.Name = "gb_settings";
            this.gb_settings.Size = new System.Drawing.Size(386, 624);
            this.gb_settings.TabIndex = 14;
            this.gb_settings.TabStop = false;
            this.gb_settings.Text = "Grænseindstilling";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(336, 523);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Kvalitet";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(351, 523);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 523);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Hastighed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Kompression";
            // 
            // trackC
            // 
            this.trackC.Location = new System.Drawing.Point(6, 491);
            this.trackC.Maximum = 100;
            this.trackC.Minimum = 5;
            this.trackC.Name = "trackC";
            this.trackC.Size = new System.Drawing.Size(372, 45);
            this.trackC.TabIndex = 18;
            this.trackC.TickFrequency = 5;
            this.toolTip.SetToolTip(this.trackC, "Hvor meget billedet skal komprimeres, fra 0% til 95%. Høj komprimering giver hurt" +
        "igere tracking");
            this.trackC.Value = 25;
            this.trackC.Scroll += new System.EventHandler(this.trackC_Scroll);
            this.trackC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tb_MouseUp);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 611);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Billedets gns. Farve";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 611);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Valgte Farve";
            // 
            // panelAvg
            // 
            this.panelAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAvg.Location = new System.Drawing.Point(193, 553);
            this.panelAvg.Name = "panelAvg";
            this.panelAvg.Size = new System.Drawing.Size(185, 51);
            this.panelAvg.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 454);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Lav";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Høj";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pb_preview);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 675);
            this.panel1.TabIndex = 15;
            // 
            // btn_picker
            // 
            this.btn_picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_picker.BackColor = System.Drawing.SystemColors.Control;
            this.btn_picker.Image = ((System.Drawing.Image)(resources.GetObject("btn_picker.Image")));
            this.btn_picker.Location = new System.Drawing.Point(446, 569);
            this.btn_picker.Name = "btn_picker";
            this.btn_picker.Size = new System.Drawing.Size(30, 30);
            this.btn_picker.TabIndex = 0;
            this.toolTip.SetToolTip(this.btn_picker, "Vælg en farve fra billedet med musepilen");
            this.btn_picker.UseVisualStyleBackColor = false;
            this.btn_picker.Click += new System.EventHandler(this.btn_picker_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 677);
            this.Controls.Add(this.btn_picker);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb_settings);
            this.Controls.Add(this.buttonApply);
            this.MinimumSize = new System.Drawing.Size(849, 716);
            this.Name = "FormSettings";
            this.Text = "Grænseindstillinger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackN)).EndInit();
            this.gb_settings.ResumeLayout(false);
            this.gb_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_preview;
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
        private System.Windows.Forms.GroupBox gb_settings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelAvg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackC;
        private System.Windows.Forms.Button btn_picker;
        private System.Windows.Forms.ToolTip toolTip;
    }
}