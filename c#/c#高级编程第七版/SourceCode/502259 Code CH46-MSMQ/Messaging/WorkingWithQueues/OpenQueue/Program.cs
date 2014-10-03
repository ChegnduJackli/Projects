using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
    class Program
    {
        static void Main()
        {
            string queueName = @"ncs-290714wh02\private$\myqueue1";
            if (MessageQueue.Exists(queueName))
            {
                MessageQueue queue = new MessageQueue(queueName);
                
                Console.WriteLine("queue exist");
                //...
            }
            else
            {
                Console.WriteLine("Queue {0} does not exist", queueName);
            }

            Console.ReadKey();
        }
    }
}

