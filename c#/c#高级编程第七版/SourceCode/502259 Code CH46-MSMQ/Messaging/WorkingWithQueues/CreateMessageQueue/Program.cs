using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
    class Program
    {
        static void Main()
        {
            using (var queue = MessageQueue.Create(@"ncs-290714wh02\private$\myqueue1"))
            {
                queue.Label = "Demo Queue";
                Console.WriteLine("Queue created:");
                Console.WriteLine("\tPath: {0}", queue.Path);
                Console.WriteLine("\tFormatName: {0}", queue.FormatName);
            }
            Console.ReadKey();
        }
    }
}

