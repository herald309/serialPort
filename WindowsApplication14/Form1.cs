using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsApplication14
{
    public partial class Form1 : Form
    {
        SerialPort _serialPort;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                _serialPort = new SerialPort(portList.Text, 9600, Parity.None, 8, StopBits.One);
                _serialPort.Open();
                 MessageBox.Show("Port Opened Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            portList.Items.AddRange(ports);
            portList.SelectedIndex = 0;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                _serialPort.Write(textBox1.Text);
                MessageBox.Show("Message Sent Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
            }
        }
    }
}