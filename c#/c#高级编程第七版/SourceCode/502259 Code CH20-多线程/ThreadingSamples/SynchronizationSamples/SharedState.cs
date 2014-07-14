using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Wrox.ProCSharp.Threading
{
    public class SharedState
    {
        private int state = 0;

        public int State { get; set; }

        private object synRoot = new object();

        public int IncrementState()
        {
            //lock (synRoot)
            //{
            //    return ++state;
            //}
            //这个速度比较快
             return Interlocked.Increment(ref state);
        }

    }
}
