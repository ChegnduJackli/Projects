using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public class Rectangle:Graphics
    {
        public Rectangle(string name)
            : base(name)
        { }

        public override void Draw()
        {
            Console.WriteLine("Draw a " + _name.ToString());
        }
    }
}
