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

namespace Server
{
    public partial class ServerForm : Form
    {
        List<ConnectEntitry> clientInfo = new List<ConnectEntitry>();

        public ServerForm()
        {
            InitializeComponent();
        }
        //start server
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                clientInfo.Clear();

                string host = this.txtHost.Text.Trim();
                int port = Convert.ToInt32(this.txtPort.Text.Trim());

                IPAddress ip = IPAddress.Parse(host);
                IPEndPoint ipe = new IPEndPoint(ip, port);//把ip和端口转化为IPEndpoint实例

                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //将socket绑定到主机上面的某个端口
                socket.Bind(ipe);
                //启动监听，并且设置最大的队列长度
                socket.Listen(10);

                this.lblMessage.Text = "Server is running....";
                Socket client = socket.Accept();
                IPEndPoint clientip = (IPEndPoint)client.RemoteEndPoint;
                BindGv(clientip);
                //提示客户端连接成功
                client.Send(Encoding.Unicode.GetBytes("Connect to server successfully at " + DateTime.Now.ToString()));


        
                //while (true)
                {
                  
                    //byte[] data = new byte[1024];//用于缓存客户端所发送的信息,通过socket传递的信息必须为字节数组
                    //data = new byte[1024];
                    //int recv = client.Receive(data);
                }
                //socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //get client information
        public void ClientAccepted(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;
                //客户端的socket实例
                var client = socket.EndAccept(ar);
                IPEndPoint clientip = (IPEndPoint)client.RemoteEndPoint;

                //BindGv(clientip);

                //给客户端发送一个欢迎消息
                client.Send(Encoding.Unicode.GetBytes("Connect to server successfully at " + DateTime.Now.ToString()));

                socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);
            }
            catch 
            {
                throw;
            }
        }
        private void BindGv(IPEndPoint clientip)
        {
            ConnectEntitry connectEntity = new ConnectEntitry();
            connectEntity.IP = clientip.Address.ToString();
            connectEntity.Port = clientip.Port;
            connectEntity.ConnectTime = DateTime.Now;
            clientInfo.Add(connectEntity);

            this.dataGridView1.DataSource = clientInfo;
        }
    }
}
