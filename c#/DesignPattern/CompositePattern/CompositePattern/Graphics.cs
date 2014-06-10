using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public abstract class Graphics
    {
        protected string _name;
        public Graphics(string name)
        {
            this._name = name;
        }
        public abstract void Draw(); //draw a picture.
    }

}
