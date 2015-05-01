using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace RadioPlane
{
    class _RadioControl
    {
        public SerialPort PortDevice;
        public string Buffor;
        public string Name;
        public string Power;
        public string Sensitiveness;
        public string Channel;
        public string Speed;
        public string LimitBuffor;
        public bool Signal;

        public _RadioControl()
        {
            this.Signal = false;
        }

        public _RadioControl(string name)
        {
            this.Name = name;
            this.PortDevice = new SerialPort(name, 57600, Parity.None, 8, StopBits.One);
            this.PortDevice.Open();
            this.Signal = false;
        }

        public void CreatPort(string name)
        {
            this.Name = name;
            this.PortDevice = new SerialPort(name, 57600, Parity.None, 8, StopBits.One);
            this.PortDevice.Open();
        }

        public void StartListen()
        {
            Thread oThread = new Thread(new ThreadStart(Listening));
            oThread.Start();
        }

        public void Listening()
        {
            this.PortDevice.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Buffor += this.PortDevice.ReadExisting();
        }

        public void ListeningSignal()
        {
            this.PortDevice.DataReceived += new SerialDataReceivedEventHandler(SetSignal);
        }

        public void SetSignal(object sender, SerialDataReceivedEventArgs e)
        {
            Buffor += this.PortDevice.ReadExisting();
            
            if (this.Buffor.Length > 2)
            {
                if (checkMark(this.Buffor))
                {
                    this.Signal = true;
                    Buffor = "";
                }
                
            }
             
            // stara wersja 
            /*
            if (this.Buffor.Length > 0)
            {
                if (!this.Signal) this.Signal = true;
                Buffor = "";
            }
             */
        }

        public bool checkMark(string b)
        {
            int i = 0;
            while (i < b.Length)
            {
                if (b[i] == '*')
                    if (b[i + 1] == '&')
                        if (b[i + 2] == '*')
                            return true;
                if(i+3 == b.Length) break;
                i++;
            }
            return false;
        }

        public bool CheckSignal()
        {
            if (this.Signal)
            {
                this.Signal = false;
                return true;
            }
            else return false;
        }

        public void StatingSignal()
        {
            if (this.CheckSignal())
            {
                /*
                if (this.radioButton1.Checked == false)
                {
                    this.radioButton1.Checked = true;
                    this.radioButton1.Text = "TRUE";
                }
                */
            }
            else
            {
                /*
                if (this.radioButton1.Checked == true)
                {
                    this.radioButton1.Checked = false;
                    this.radioButton1.Text = "FALSE";
                    this.textBox2.AppendText(DateTime.Now.ToString("h:mm:ss tt") + " - Rozłączono.\n");
                }
                 */
            }
        }

        public void ClearBuf()
        {
            this.Buffor = "";
        }

        public string Read()
        {
            return this.Buffor;
        }

        public string ReadAndClear()
        {
            string Buf = this.Buffor;
            this.Buffor = "";
            return Buf;
        }

        public void ChangePower(string val)
        {
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x09, Convert.ToByte(val) }, 0, 5);
            this.Power = val;
        }

        public void ChangeSensitiveness(string val)
        {
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x010, Convert.ToByte(val) }, 0, 5);
            this.Sensitiveness = val;
        }

        public void ChangeChannel(string val)
        {
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x07, Convert.ToByte(val) }, 0, 5);
            this.Channel = val;
        }

        public void ChangeSpeed(string val)
        {
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x08, Convert.ToByte(val) }, 0, 5);
            this.Speed = val;
        }

        public void ChangeLimitBuffor(string val)
        {
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x11, Convert.ToByte(val) }, 0, 5);
            this.LimitBuffor = val;
        }

        public string[] CheckPorts()
        {
            return SerialPort.GetPortNames();
        }

        public void SendData(string data)
        {
            this.PortDevice.Write(data);
        }

        public void SendDataSuffix(string data, string suffix)
        {
            this.PortDevice.Write(data + suffix);
        }

        public void SetMin()
        {
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x09, Convert.ToByte(7) }, 0, 5);
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x010, Convert.ToByte(3) }, 0, 5);
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x07, Convert.ToByte(0) }, 0, 5);
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x08, Convert.ToByte(50) }, 0, 5);
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x11, Convert.ToByte(8) }, 0, 5);

            this.Power = "7";
            this.Sensitiveness = "3";
            this.Channel = "0";
            this.Speed = "50";
            this.LimitBuffor = "8";
        }

        public void SetMax()
        {
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x09, Convert.ToByte(0) }, 0, 5);
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x010, Convert.ToByte(0) }, 0, 5);
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x07, Convert.ToByte(0) }, 0, 5);
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x08, Convert.ToByte(50) }, 0, 5);
            this.PortDevice.Write(new byte[] { 0x43, 0x78, 0x1E, 0x11, Convert.ToByte(128) }, 0, 5);

            this.Power = "0";
            this.Sensitiveness = "0";
            this.Channel = "0";
            this.Speed = "50";
            this.LimitBuffor = "128";

        }

        public string GetSets()
        {
            string Stats = "";

            Stats += "Power: " + this.Power + "\n";
            Stats += "Sensitiveness: " + this.Sensitiveness + "\n";
            Stats += "Channel: " + this.Channel + "\n";
            Stats += "Speed: " + this.Speed + "\n";
            Stats += "LimitBuffor: " + this.Buffor + "\n";

            return Stats;
        }
    }
}
