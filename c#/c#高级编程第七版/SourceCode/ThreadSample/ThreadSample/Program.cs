using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceConditions();
            Console.ReadLine();
        }
        static void RaceConditions()
        {
            var state = new StateObject();
            for (int i = 0; i < 2; i++)
            {
                new Task(new SampleTask().RaceCondition, state).Start();
            }
        }

    }
    public class StateObject
    {
        private int state = 5;
        private object sync = new object();

        public void ChangeState(int loop)
        {
            lock (sync)
            {
                if (state == 5)
                {
                    state++;
                    Trace.Assert(state == 6, "Race condition occurred after " + loop + " loops");
                    Console.WriteLine("Race condition occurred after " + loop + " loops");
                }
                state = 5;
            }
        }
    }
    public class SampleTask
    {
        //internal static int a;
        //private static Object sync = new object();

        public SampleTask()
        {

        }

        public void RaceCondition(object o)
        {
            Trace.Assert(o is StateObject, "o must be of type StateObject");
            StateObject state = o as StateObject;

            int i = 0;
            while (true)
            {
                // lock (state) // no race condition with this lock
                {
                    state.ChangeState(i++);
                }
            }

        }
    }
}
