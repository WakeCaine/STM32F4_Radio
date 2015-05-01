using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


namespace STM32F4_RF_PROG
{
    public partial class Form1 : Form
    {
        SerialPort portDevice;
        string[] ports;

        public Form1()
        {
            InitializeComponent();

            this.ports = SerialPort.GetPortNames();

            //this.AvailablePorts.Items.Add = "cos";
            foreach (string port in this.ports)
            {
                this.AvailablePorts.Items.Add(port);
                //Console.WriteLine(porta);
            }
        }

        [STAThread]

        private void SendSampleData(SerialPort port, string l)
        {
            this.portDevice.Write(l);
            //this.gettingText.AppendText(l);
            //port.Write(l + "&");
            //port.Write(new byte[] { 0x0A, 0xE2, 0xFF }, 0, 3);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BarCzulosc_ValueChanged(object sender, EventArgs e)
        {
            this.LabelCzulosc.Text = this.BarCzulosc.Value.ToString();
        }

        private void BarPower_ValueChanged(object sender, EventArgs e)
        {
            this.LabelPower.Text = this.BarPower.Value.ToString();
        }

        private void BarKanal_ValueChanged(object sender, EventArgs e)
        {
            this.LabelKanal.Text = this.BarKanal.Value.ToString();
        }

        private void BarSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LabelSpeed.Text = this.BarSpeed.SelectedItem.ToString();
        }

        private void start_Click(object sender, EventArgs e)
        {
            string com = this.AvailablePorts.SelectedItem.ToString();

            this.portDevice = new SerialPort(com, 56000, Parity.None, 8, StopBits.One);
            
            this.portDevice.Open();
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x010, Convert.ToByte(3) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x09, Convert.ToByte(7) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x08, Convert.ToByte(50) }, 0, 5);
            Listen LISTEN = new Listen(this.portDevice, this.gettingText);
            
            Thread oThread = new Thread(new ThreadStart(LISTEN.Listening));
            oThread.Start();

            // odblokowanie przycisków

            GroupConfig.Enabled = true;
            GroupSend.Enabled = true;
            GroupSending.Enabled = true;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string text = this.BoxSend.Text;
            SendSampleData(this.portDevice, text);
            this.BoxSend.Text = "";
        }

        private void saveConfig_Click(object sender, EventArgs e)
        {
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x09, Convert.ToByte(this.LabelPower.Text) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x010, Convert.ToByte(this.LabelCzulosc.Text) }, 0, 5);
            //this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x07, Convert.ToByte(this.LabelKanal.Text) }, 0, 5);
            //this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x08, Convert.ToByte(this.LabelSpeed.Text) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x11, Convert.ToByte(this.LabelBuffor.Text) }, 0, 5);

            this.save.Visible = true;
            this.TimerSave.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendSampleData(this.portDevice, "*");
        }

        private void StartSend_Click(object sender, EventArgs e)
        {
            if (this.TimerSend.Enabled == false) {
                this.TimerSend.Enabled = true;
                this.label4.Text = "Wysyła...";
            }
        }

        private void StopSend_Click(object sender, EventArgs e)
        {
            if (this.TimerSend.Enabled == true)
            {
                this.TimerSend.Enabled = false;
                this.label4.Text = "Zatrzymano!";
            }
        }

        private void BarBuffor_ValueChanged(object sender, EventArgs e)
        {
            this.LabelBuffor.Text = this.BarBuffor.Value.ToString();
        }

        private void SetMax_Click(object sender, EventArgs e)
        {
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x09, Convert.ToByte(0) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x010, Convert.ToByte(0) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x07, Convert.ToByte(0) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x08, Convert.ToByte(50) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x11, Convert.ToByte(128) }, 0, 5);

            this.LabelPower.Text = "0";
            this.LabelCzulosc.Text = "0";
            this.LabelKanal.Text = "0";
            this.LabelSpeed.Text = "50";
            this.LabelBuffor.Text = "128";

            this.BarPower.Value = 0;
            this.BarCzulosc.Value = 0;
            this.BarKanal.Value = 0;
            this.BarBuffor.Value = 128;
            this.BarSpeed.SelectedItem = 49;

            this.save.Visible = true;
            this.TimerSave.Enabled = true;
        }

        private void SetMin_Click(object sender, EventArgs e)
        {
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x09, Convert.ToByte(7) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x010, Convert.ToByte(3) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x07, Convert.ToByte(0) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x08, Convert.ToByte(50) }, 0, 5);
            this.portDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x11, Convert.ToByte(1) }, 0, 5);

            this.LabelPower.Text = "7";
            this.LabelCzulosc.Text = "3";
            this.LabelKanal.Text = "0";
            this.LabelSpeed.Text = "50";
            this.LabelBuffor.Text = "1";

            this.BarPower.Value = 7;
            this.BarCzulosc.Value = 3;
            this.BarKanal.Value = 0;
            this.BarBuffor.Value = 1;
            this.BarSpeed.SelectedItem = 49;

            this.save.Visible = true;
            this.TimerSave.Enabled = true;
        }

        private void TimerSave_Tick(object sender, EventArgs e)
        {
            this.save.Visible = false;
            this.TimerSave.Enabled = false;
        }

        

    }
}
