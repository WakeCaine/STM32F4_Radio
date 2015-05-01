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
    public partial class Listen : Form
    {
        public SerialPort port;
        public string buffor;
        System.Windows.Forms.RichTextBox TextBox;
        delegate void SetTextDelegat(string text);

        public Listen()
        {

        }

        public void SetText(string Text)
        {
            if (this.TextBox.InvokeRequired)
            {
                SetTextDelegat d = new SetTextDelegat(SetText);
                //this.Invoke(d, new object[] { Text });
            }
            else
            {
                this.TextBox.Text += ("\n" + Text); 
            }
        }
        public Listen(SerialPort p, System.Windows.Forms.RichTextBox getText)
        {
            this.port = p;
            this.TextBox = getText;
        }

        public void Listening()
        {
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //this.TextBox.Text = port.ReadExisting();
            buffor += port.ReadExisting();
            TextBox.Invoke(new Action(delegate()
            {
                TextBox.AppendText(buffor);
                buffor = "";
            }));


            //SetText(port.ReadExisting());
            /*
            Console.WriteLine("Data incoming: " + port.ReadExisting());

            buffor += port.ReadExisting();
            if (buffor.Length > 0)
                if (buffor[buffor.Length - 1] == '&')
                {
                    if (buffor[0] == '\n') buffor = buffor.Remove(0, 1);
                    Console.WriteLine("\nOdebrano: " + buffor.Remove(buffor.Length - 1, 1));
                    buffor = "";
                }
            */
        }
    }
}
