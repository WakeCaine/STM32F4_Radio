namespace STM32F4_RF_PROG
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
            this.label1 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.gettingText = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupConfig = new System.Windows.Forms.GroupBox();
            this.save = new System.Windows.Forms.Label();
            this.SetMin = new System.Windows.Forms.Button();
            this.SetMax = new System.Windows.Forms.Button();
            this.LabelBuffor = new System.Windows.Forms.Label();
            this.BarBuffor = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.saveConfig = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BarKanal = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.LabelKanal = new System.Windows.Forms.Label();
            this.BarSpeed = new System.Windows.Forms.ComboBox();
            this.BarCzulosc = new System.Windows.Forms.TrackBar();
            this.LabelCzulosc = new System.Windows.Forms.Label();
            this.LabelSpeed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LabelPower = new System.Windows.Forms.Label();
            this.BarPower = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.BoxSend = new System.Windows.Forms.TextBox();
            this.GroupSend = new System.Windows.Forms.GroupBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.GroupSending = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StopSend = new System.Windows.Forms.Button();
            this.StartSend = new System.Windows.Forms.Button();
            this.TimerSend = new System.Windows.Forms.Timer(this.components);
            this.TimerSave = new System.Windows.Forms.Timer(this.components);
            this.AvailablePorts = new System.Windows.Forms.ComboBox();
            this.GroupConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarBuffor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarKanal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCzulosc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarPower)).BeginInit();
            this.GroupSend.SuspendLayout();
            this.GroupSending.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj nr portu ( COM3/COM4/etc )";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(148, 34);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(77, 29);
            this.start.TabIndex = 2;
            this.start.Text = "Połącz";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // gettingText
            // 
            this.gettingText.Location = new System.Drawing.Point(291, 34);
            this.gettingText.Name = "gettingText";
            this.gettingText.Size = new System.Drawing.Size(233, 304);
            this.gettingText.TabIndex = 3;
            this.gettingText.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Odebrane dane";
            // 
            // GroupConfig
            // 
            this.GroupConfig.Controls.Add(this.save);
            this.GroupConfig.Controls.Add(this.SetMin);
            this.GroupConfig.Controls.Add(this.SetMax);
            this.GroupConfig.Controls.Add(this.LabelBuffor);
            this.GroupConfig.Controls.Add(this.BarBuffor);
            this.GroupConfig.Controls.Add(this.label9);
            this.GroupConfig.Controls.Add(this.saveConfig);
            this.GroupConfig.Controls.Add(this.label3);
            this.GroupConfig.Controls.Add(this.BarKanal);
            this.GroupConfig.Controls.Add(this.label7);
            this.GroupConfig.Controls.Add(this.LabelKanal);
            this.GroupConfig.Controls.Add(this.BarSpeed);
            this.GroupConfig.Controls.Add(this.BarCzulosc);
            this.GroupConfig.Controls.Add(this.LabelCzulosc);
            this.GroupConfig.Controls.Add(this.LabelSpeed);
            this.GroupConfig.Controls.Add(this.label8);
            this.GroupConfig.Controls.Add(this.LabelPower);
            this.GroupConfig.Controls.Add(this.BarPower);
            this.GroupConfig.Controls.Add(this.label5);
            this.GroupConfig.Enabled = false;
            this.GroupConfig.Location = new System.Drawing.Point(530, 13);
            this.GroupConfig.Name = "GroupConfig";
            this.GroupConfig.Size = new System.Drawing.Size(373, 294);
            this.GroupConfig.TabIndex = 5;
            this.GroupConfig.TabStop = false;
            this.GroupConfig.Text = "Konfiguracja";
            this.GroupConfig.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // save
            // 
            this.save.AutoSize = true;
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.save.ForeColor = System.Drawing.Color.LimeGreen;
            this.save.Location = new System.Drawing.Point(149, 258);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(79, 20);
            this.save.TabIndex = 10;
            this.save.Text = "Zapisano!";
            this.save.Visible = false;
            // 
            // SetMin
            // 
            this.SetMin.Location = new System.Drawing.Point(199, 222);
            this.SetMin.Name = "SetMin";
            this.SetMin.Size = new System.Drawing.Size(163, 24);
            this.SetMin.TabIndex = 17;
            this.SetMin.Text = "Ustaw Minimum";
            this.SetMin.UseVisualStyleBackColor = true;
            this.SetMin.Click += new System.EventHandler(this.SetMin_Click);
            // 
            // SetMax
            // 
            this.SetMax.Location = new System.Drawing.Point(18, 222);
            this.SetMax.Name = "SetMax";
            this.SetMax.Size = new System.Drawing.Size(163, 24);
            this.SetMax.TabIndex = 16;
            this.SetMax.Text = "Ustaw Max";
            this.SetMax.UseVisualStyleBackColor = true;
            this.SetMax.Click += new System.EventHandler(this.SetMax_Click);
            // 
            // LabelBuffor
            // 
            this.LabelBuffor.AutoSize = true;
            this.LabelBuffor.Location = new System.Drawing.Point(338, 88);
            this.LabelBuffor.Name = "LabelBuffor";
            this.LabelBuffor.Size = new System.Drawing.Size(13, 13);
            this.LabelBuffor.TabIndex = 15;
            this.LabelBuffor.Text = "1";
            // 
            // BarBuffor
            // 
            this.BarBuffor.Location = new System.Drawing.Point(187, 107);
            this.BarBuffor.Maximum = 128;
            this.BarBuffor.Minimum = 1;
            this.BarBuffor.Name = "BarBuffor";
            this.BarBuffor.Size = new System.Drawing.Size(175, 45);
            this.BarBuffor.TabIndex = 14;
            this.BarBuffor.Value = 1;
            this.BarBuffor.ValueChanged += new System.EventHandler(this.BarBuffor_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Wielkość buffora";
            // 
            // saveConfig
            // 
            this.saveConfig.Location = new System.Drawing.Point(204, 158);
            this.saveConfig.Name = "saveConfig";
            this.saveConfig.Size = new System.Drawing.Size(145, 43);
            this.saveConfig.TabIndex = 12;
            this.saveConfig.Text = "Zapisz";
            this.saveConfig.UseVisualStyleBackColor = true;
            this.saveConfig.Click += new System.EventHandler(this.saveConfig_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Numer kanału";
            // 
            // BarKanal
            // 
            this.BarKanal.Location = new System.Drawing.Point(6, 107);
            this.BarKanal.Maximum = 9;
            this.BarKanal.Name = "BarKanal";
            this.BarKanal.Size = new System.Drawing.Size(175, 45);
            this.BarKanal.TabIndex = 1;
            this.BarKanal.ValueChanged += new System.EventHandler(this.BarKanal_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Czułość sygnału";
            // 
            // LabelKanal
            // 
            this.LabelKanal.AutoSize = true;
            this.LabelKanal.Location = new System.Drawing.Point(157, 88);
            this.LabelKanal.Name = "LabelKanal";
            this.LabelKanal.Size = new System.Drawing.Size(13, 13);
            this.LabelKanal.TabIndex = 2;
            this.LabelKanal.Text = "0";
            // 
            // BarSpeed
            // 
            this.BarSpeed.FormattingEnabled = true;
            this.BarSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56"});
            this.BarSpeed.Location = new System.Drawing.Point(18, 180);
            this.BarSpeed.Name = "BarSpeed";
            this.BarSpeed.Size = new System.Drawing.Size(151, 21);
            this.BarSpeed.TabIndex = 11;
            this.BarSpeed.SelectedIndexChanged += new System.EventHandler(this.BarSpeed_SelectedIndexChanged);
            // 
            // BarCzulosc
            // 
            this.BarCzulosc.Location = new System.Drawing.Point(6, 40);
            this.BarCzulosc.Maximum = 3;
            this.BarCzulosc.Name = "BarCzulosc";
            this.BarCzulosc.Size = new System.Drawing.Size(175, 45);
            this.BarCzulosc.TabIndex = 7;
            this.BarCzulosc.ValueChanged += new System.EventHandler(this.BarCzulosc_ValueChanged);
            // 
            // LabelCzulosc
            // 
            this.LabelCzulosc.AutoSize = true;
            this.LabelCzulosc.Location = new System.Drawing.Point(157, 21);
            this.LabelCzulosc.Name = "LabelCzulosc";
            this.LabelCzulosc.Size = new System.Drawing.Size(13, 13);
            this.LabelCzulosc.TabIndex = 8;
            this.LabelCzulosc.Text = "0";
            // 
            // LabelSpeed
            // 
            this.LabelSpeed.AutoSize = true;
            this.LabelSpeed.Location = new System.Drawing.Point(150, 155);
            this.LabelSpeed.Name = "LabelSpeed";
            this.LabelSpeed.Size = new System.Drawing.Size(19, 13);
            this.LabelSpeed.TabIndex = 10;
            this.LabelSpeed.Text = "55";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Prędkość wysyłania";
            // 
            // LabelPower
            // 
            this.LabelPower.AutoSize = true;
            this.LabelPower.Location = new System.Drawing.Point(338, 21);
            this.LabelPower.Name = "LabelPower";
            this.LabelPower.Size = new System.Drawing.Size(13, 13);
            this.LabelPower.TabIndex = 5;
            this.LabelPower.Text = "0";
            // 
            // BarPower
            // 
            this.BarPower.Location = new System.Drawing.Point(187, 40);
            this.BarPower.Maximum = 7;
            this.BarPower.Name = "BarPower";
            this.BarPower.Size = new System.Drawing.Size(175, 45);
            this.BarPower.TabIndex = 4;
            this.BarPower.ValueChanged += new System.EventHandler(this.BarPower_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Moc sygnału";
            // 
            // BoxSend
            // 
            this.BoxSend.Location = new System.Drawing.Point(19, 25);
            this.BoxSend.Name = "BoxSend";
            this.BoxSend.Size = new System.Drawing.Size(208, 20);
            this.BoxSend.TabIndex = 6;
            // 
            // GroupSend
            // 
            this.GroupSend.Controls.Add(this.BtnSend);
            this.GroupSend.Controls.Add(this.BoxSend);
            this.GroupSend.Enabled = false;
            this.GroupSend.Location = new System.Drawing.Point(36, 76);
            this.GroupSend.Name = "GroupSend";
            this.GroupSend.Size = new System.Drawing.Size(242, 89);
            this.GroupSend.TabIndex = 7;
            this.GroupSend.TabStop = false;
            this.GroupSend.Text = "Wysyłanie";
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(55, 51);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(117, 28);
            this.BtnSend.TabIndex = 7;
            this.BtnSend.Text = "Wyślij wiadomość";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // GroupSending
            // 
            this.GroupSending.Controls.Add(this.label4);
            this.GroupSending.Controls.Add(this.StopSend);
            this.GroupSending.Controls.Add(this.StartSend);
            this.GroupSending.Enabled = false;
            this.GroupSending.Location = new System.Drawing.Point(36, 171);
            this.GroupSending.Name = "GroupSending";
            this.GroupSending.Size = new System.Drawing.Size(242, 100);
            this.GroupSending.TabIndex = 8;
            this.GroupSending.TabStop = false;
            this.GroupSending.Text = "Wysyłanie ciągłe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            // 
            // StopSend
            // 
            this.StopSend.Location = new System.Drawing.Point(130, 33);
            this.StopSend.Name = "StopSend";
            this.StopSend.Size = new System.Drawing.Size(99, 28);
            this.StopSend.TabIndex = 9;
            this.StopSend.Text = "Stop";
            this.StopSend.UseVisualStyleBackColor = true;
            this.StopSend.Click += new System.EventHandler(this.StopSend_Click);
            // 
            // StartSend
            // 
            this.StartSend.Location = new System.Drawing.Point(9, 33);
            this.StartSend.Name = "StartSend";
            this.StartSend.Size = new System.Drawing.Size(100, 28);
            this.StartSend.TabIndex = 8;
            this.StartSend.Text = "Start";
            this.StartSend.UseVisualStyleBackColor = true;
            this.StartSend.Click += new System.EventHandler(this.StartSend_Click);
            // 
            // TimerSend
            // 
            this.TimerSend.Interval = 10;
            this.TimerSend.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerSave
            // 
            this.TimerSave.Interval = 3000;
            this.TimerSave.Tick += new System.EventHandler(this.TimerSave_Tick);
            // 
            // AvailablePorts
            // 
            this.AvailablePorts.FormattingEnabled = true;
            this.AvailablePorts.Location = new System.Drawing.Point(36, 39);
            this.AvailablePorts.Name = "AvailablePorts";
            this.AvailablePorts.Size = new System.Drawing.Size(97, 21);
            this.AvailablePorts.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 350);
            this.Controls.Add(this.AvailablePorts);
            this.Controls.Add(this.GroupSending);
            this.Controls.Add(this.GroupSend);
            this.Controls.Add(this.GroupConfig);
            this.Controls.Add(this.gettingText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Program Kontroli Radiowej";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupConfig.ResumeLayout(false);
            this.GroupConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarBuffor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarKanal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCzulosc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarPower)).EndInit();
            this.GroupSend.ResumeLayout(false);
            this.GroupSend.PerformLayout();
            this.GroupSending.ResumeLayout(false);
            this.GroupSending.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.RichTextBox gettingText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GroupConfig;
        private System.Windows.Forms.TrackBar BarKanal;
        private System.Windows.Forms.Label LabelKanal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BarSpeed;
        private System.Windows.Forms.Label LabelSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LabelCzulosc;
        private System.Windows.Forms.TrackBar BarCzulosc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LabelPower;
        private System.Windows.Forms.TrackBar BarPower;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveConfig;
        private System.Windows.Forms.TextBox BoxSend;
        private System.Windows.Forms.GroupBox GroupSend;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.GroupBox GroupSending;
        private System.Windows.Forms.Button StartSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StopSend;
        private System.Windows.Forms.Timer TimerSend;
        private System.Windows.Forms.Label LabelBuffor;
        private System.Windows.Forms.TrackBar BarBuffor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button SetMin;
        private System.Windows.Forms.Button SetMax;
        private System.Windows.Forms.Label save;
        private System.Windows.Forms.Timer TimerSave;
        private System.Windows.Forms.ComboBox AvailablePorts;
    }
}

