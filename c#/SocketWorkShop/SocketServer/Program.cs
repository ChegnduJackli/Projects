using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SocketServer
{
    class Program
    {
        static byte[] buffer = new byte[1024];
        static void Main(string[] args)
        {
            //创建一个socket
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            //将socket绑定到主机上面的某个端口
            socket.Bind(new IPEndPoint(IPAddress.Any,4530));
            //启动监听，并且设置最大的队列长度
            socket.Listen(4);

            ////开始接受客户端连接请求
            //socket.BeginAccept(new AsyncCallback((ar) =>
            //    {
            //        //客户端的socket实例
            //        var client = socket.EndAccept(ar);
            //        //给客户端发送一个欢迎消息
            //        client.Send(Encoding.Unicode.GetBytes("Hi there,I accept your request at "+DateTime.Now.ToString()));
            //        //实现每隔两秒给客户端发一个信息.
            //        var timer = new System.Timers.Timer();
            //        timer.Interval = 2000;
            //        timer.Enabled = true;
            //        timer.Elapsed += (o, a) =>
            //        {
            //            //检测客户端的状态
            //            if (client.Connected)
            //            {
            //                try
            //                {
            //                    client.Send(Encoding.Unicode.GetBytes("Message from server at " + DateTime.Now.ToString()));
            //                }
            //                catch (SocketException ex)
            //                {
            //                    Console.WriteLine(ex.Message);
            //                }
            //            }
            //            else
            //            {
            //                timer.Stop();
            //                timer.Enabled = false;
            //                Console.WriteLine("Client is disconnected,the timer is stop.");
            //            }

            //        };
            //        timer.Start();
            //        client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
            //    }), null);
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);
            
            Console.WriteLine("Server is ready!");
            Console.Read();
        }
        public static void ClientAccepted(IAsyncResult ar)
        {
            var socket = ar.AsyncState as Socket;
            //客户端的socket实例
            var client = socket.EndAccept(ar);
            //给客户端发送一个欢迎消息
            client.Send(Encoding.Unicode.GetBytes("Hi there,I accept your request at " + DateTime.Now.ToString()));
            var timer = new System.Timers.Timer();
            timer.Interval = 2000;
            timer.Enabled = true;
            timer.Elapsed += (o, a) =>
                {
                    if (client.Connected)
                    {
                        try
                        {
                            client.Send(Encoding.Unicode.GetBytes("Message from server at " + DateTime.Now.ToString()));
                        }
                        catch (SocketException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        timer.Stop();
                        timer.Enabled = false;
                        Console.WriteLine("Client is disconnected,the timer is stop.");
                    }

                };
            timer.Start();
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);

        }
        public static void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;
                var length = socket.EndReceive(ar);
                var message = Encoding.Unicode.GetString(buffer, 0, length);
                //显示读出来的消息
                Console.WriteLine(message);

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
