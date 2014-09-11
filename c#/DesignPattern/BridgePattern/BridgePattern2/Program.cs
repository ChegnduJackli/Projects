using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern2
{
    class Program
    {
        static void Main(string[] args)
        {
            Brush b = new BigBrush();
            b.SetColor(new Red());
            b.Paint();
            b.SetColor(new Blue());
            b.Paint();
            b.SetColor(new Green());
            b.Paint();

            b = new SmallBrush();
            b.SetColor(new Red());
            b.Paint();
            b.SetColor(new Blue());
            b.Paint();
            b.SetColor(new Green());
            b.Paint();

            Console.ReadKey();
        }
    }
}
