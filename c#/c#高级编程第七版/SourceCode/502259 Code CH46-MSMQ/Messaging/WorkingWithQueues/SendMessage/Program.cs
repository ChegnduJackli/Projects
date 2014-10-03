using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
    class Program
    {
        static void Main()
        {
            string queueName = @".\Private$\myqueue1";
            try
            {
                if (!MessageQueue.Exists(queueName))
                {
                    MessageQueue.Create(queueName);
                }
                //var formatter = new BinaryMessageFormatter();
                var formatter = new XmlMessageFormatter();
                var queue = new MessageQueue(queueName);
                queue.Formatter = formatter;
                queue.Send("Sample Message1", "Label1");
                queue.Send("Sample Message2", "Label2");
                queue.Send("Sample Message3", "Label3");
                Console.WriteLine("Send Message successfully.");
            }
            catch (MessageQueueException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}

