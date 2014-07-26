using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SocketClient
{
    class Program
    {
        static byte[] buffer = new byte[1024];
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("localhost", 4530);

            //实现接受消息的方法
            var buffer = new byte[1024];//设置一个缓冲区，用来保存数据
            //socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback((ar) => 
            //{
            //    var length = socket.EndReceive(ar);
            //    var message = Encoding.Unicode.GetString(buffer, 0, length);
            //    //显示读出来的消息
            //    Console.WriteLine(message);
            //}), null);

            Console.WriteLine("Client connec to the server");
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
            //接受用户输入,将消息发送给服务器端
            while (true)
            {
                var message = "message from client: " + Console.ReadLine();
                var outputBuffer = Encoding.Unicode.GetBytes(message);
                socket.BeginSend(outputBuffer, 0, outputBuffer.Length, SocketFlags.None, null, null);
            }
            Console.Read();
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
