using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
    class Program
    {
        static void Main()
        {
            //foreach (var queue in MessageQueue.GetPublicQueues())
            //get private queue
            foreach (var queue in MessageQueue.GetPrivateQueuesByMachine("ncs-290714wh02"))
            {
                Console.WriteLine(queue.Path);
            }
            Console.ReadKey();
        }
    }
}

