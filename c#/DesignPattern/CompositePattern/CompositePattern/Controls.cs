using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public class ControlsClass
    {
        List<Graphics> gList = new List<Graphics>();
        public void Add(Graphics g)
        {
            gList.Add(g);
        }
        public void Remove(Graphics g)
        {
            gList.Remove(g);
        }
    }
}
