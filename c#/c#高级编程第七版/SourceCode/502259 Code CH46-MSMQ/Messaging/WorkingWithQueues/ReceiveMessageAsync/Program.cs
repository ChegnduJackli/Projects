using System;
using System.Messaging;
using System.Threading;

namespace Wrox.ProCSharp.Messaging
{
    class Program
    {
        static void Main()
        {
            string queueName = @".\Private$\myqueue1";
            var queue = new MessageQueue(queueName);
            queue.Formatter = new XmlMessageFormatter(
                  new string[] { "System.String" });

            queue.ReceiveCompleted += MessageArrived;

            queue.BeginReceive();
            // thread does not wait
            // can do something else
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("...");
                Thread.Sleep(100);
                
            }
            Console.ReadKey();
        }

        public static void MessageArrived(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue queue = (MessageQueue)source;
            Message message = queue.EndReceive(e.AsyncResult);
            Console.WriteLine(message.Body);
        }

    }
}


