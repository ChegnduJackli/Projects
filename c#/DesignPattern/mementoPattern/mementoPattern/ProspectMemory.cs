using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mementoPattern
{
    class ProspectMemory
    {
        private Memento memento;

        public Memento Memento
        {
            get { return memento; }
            set { memento = value; }
        }
    }
}
