using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mementoPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesProspect s = new SalesProspect();
            s.Name = "xiaoming";
            s.Phone = "(010)65236523";
            s.Budget = 28000.0;

            //Store internal state
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            s.Name = "deke";
            s.Phone = "(029)85423657";
            s.Budget = 80000.0;

            //Restore saved state 
            s.RestoreMemento(m.Memento);

            //Wait for user 
            Console.Read();
        }
    }
}
