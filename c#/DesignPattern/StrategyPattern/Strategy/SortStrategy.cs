using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Strategy
{
    public abstract class SortStrategy
    {
        abstract public void Sort(ArrayList list);
    }
}
