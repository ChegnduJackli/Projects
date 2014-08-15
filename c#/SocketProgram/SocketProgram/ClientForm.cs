using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SocketProgram
{
    public partial class ClientForm : Form
    {
        byte[] buffer = new byte[1024];//设置一个缓冲区，用来保存数据

        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Socket newclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string host = this.txtHost.Text.Trim();
            int port = Convert.ToInt32(this.txtPort.Text.Trim());

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);//服务器的IP和端口

            try
            {
                newclient.Connect(ipe);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("unable to connect to server:" + ex.ToString());
                return;
            }
            //实现接受消息的方法

            int recv = newclient.Receive(buffer);
            string stringdata = Encoding.Unicode.GetString(buffer, 0, recv);
            this.richTextBox1.Text = stringdata;

            //newclient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), newclient);


        }
        public void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;
                var length = socket.EndReceive(ar);
                var message = Encoding.Unicode.GetString(buffer, 0, length);
                this.richTextBox1.Text = message;
                //接受下一个消息，（因为这是个递归的调用，所以可以一直接受消息）
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
