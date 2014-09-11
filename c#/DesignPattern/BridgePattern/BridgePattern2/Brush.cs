using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern2
{
    abstract class Brush
    {
        protected Color c;
        public abstract void Paint();

        public void SetColor(Color c)
        { 
            this.c = c; 
        }
    }

    class BigBrush : Brush
    {
        public override void Paint()
        {
            Console.WriteLine("Using big brush and color {0} painting", c.color); 
        }
    }

    class SmallBrush : Brush
    {
        public override void Paint()
        { 
            Console.WriteLine("Using small brush and color {0} painting", c.color);
        }
    }
}
