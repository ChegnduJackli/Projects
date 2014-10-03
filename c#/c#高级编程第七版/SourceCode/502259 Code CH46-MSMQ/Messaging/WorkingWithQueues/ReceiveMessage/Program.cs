using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
    class Program
    {
        static void Main()
        {
            string queueName = @".\Private$\myqueue1";
            var queue = new MessageQueue(queueName);       
            queue.Formatter = new XmlMessageFormatter(new string[] { "System.String" });
            //Receive 读取一条消息，然后会删除该消息
            Message message = queue.Receive();
            Console.WriteLine(message.Body);
            Console.ReadKey();
        }
    }
}

