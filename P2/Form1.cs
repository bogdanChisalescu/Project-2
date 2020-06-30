using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2
{
    public partial class Form1 : Form
    {
        bool isConnected = false;
        public Form1()
        {
            InitializeComponent();
            stateLabel.Text = "Neconectat";
            buttonDeconnect.Enabled = false;
            labelUmidVal.Text = "N/A";
            labelNivelVal.Text = "N/A";
            textBoxUmid.Text = "0";
            textBoxCantApa.Text = "0";
            textBoxUmid.Enabled = false;
            textBoxCantApa.Enabled = false;
            buttonSend.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comBox.Items.Add("COM1");
            comBox.Items.Add("COM2");
            comBox.Items.Add("COM3");
            comBox.Items.Add("COM4");
            comBox.Items.Add("COM5");
            comBox.SelectedIndex = 0;
            SerialPort.PortName = comBox.SelectedItem.ToString();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            buttonConnect.Enabled = false;
            buttonDeconnect.Enabled = true;
            textBoxUmid.Enabled = true;
            textBoxCantApa.Enabled = true;
            buttonSend.Enabled = true;
            buttonUpdate.Enabled = true;
            stateLabel.Text = "Conectat";

            SerialPort.Open();
            SerialPort.WriteLine("c");
            char ack = (char)SerialPort.ReadChar();
            if(ack == 'a')
            {
                isConnected = true;
                    byte[] b = new byte[2];
                    b[0] = (byte)SerialPort.ReadByte();
                    b[1] = (byte)SerialPort.ReadByte();
                    int realtimevalue = b[1];
                    realtimevalue = realtimevalue << 8;
                    realtimevalue += b[0];
                    labelUmidVal.Text = realtimevalue.ToString() + " %";

                b[0] = (byte)SerialPort.ReadByte();
                    b[1] = (byte)SerialPort.ReadByte();
                    realtimevalue = b[1];
                    realtimevalue = realtimevalue << 8;
                    realtimevalue += b[0];
                labelNivelVal.Text = realtimevalue.ToString() + " mm";
            }
        }

        private void comBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialPort.PortName = comBox.SelectedItem.ToString();
        }

        private void buttonDeconnect_Click(object sender, EventArgs e)
        {
            SerialPort.WriteLine("b");
            buttonConnect.Enabled = true;
            buttonDeconnect.Enabled = false;
            textBoxUmid.Enabled = false;
            textBoxCantApa.Enabled = false;
            buttonSend.Enabled = false;
            buttonUpdate.Enabled = false;
            stateLabel.Text = "Neconectat";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            if (SerialPort.IsOpen && isConnected)
            {
                byte[] b = new byte[2];
                b[0] = (byte)SerialPort.ReadByte();
                b[1] = (byte)SerialPort.ReadByte();
                int realtimevalue = b[1];
                realtimevalue = realtimevalue << 8;
                realtimevalue += b[0];
                labelUmidVal.Text = realtimevalue.ToString() + " %";

                b[0] = (byte)SerialPort.ReadByte();
                b[1] = (byte)SerialPort.ReadByte();
                realtimevalue = b[1];
                realtimevalue = realtimevalue << 8;
                realtimevalue += b[0];
                labelNivelVal.Text = realtimevalue.ToString() + " mm";

            }
            buttonUpdate.Enabled = true;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {

            if(textBoxUmid.Text != "" && textBoxCantApa.Text != "")
            {
                float cantitateApa = float.Parse(textBoxCantApa.Text);
                SerialPort.WriteLine("r");
                isConnected = false;
                byte[] b = BitConverter.GetBytes(cantitateApa);
                SerialPort.WriteLine(b[0].ToString());
                SerialPort.WriteLine(b[1].ToString());
                SerialPort.WriteLine(b[2].ToString());
                SerialPort.WriteLine(b[3].ToString());

                int umiditatePrag = int.Parse(textBoxUmid.Text);
                byte[] bi = BitConverter.GetBytes(umiditatePrag);
                SerialPort.WriteLine(bi[0].ToString());
                SerialPort.WriteLine(bi[1].ToString());

                SerialPort.WriteLine("x");
                isConnected = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SerialPort.WriteLine("b");
            SerialPort.Close();
        }
    }
}
