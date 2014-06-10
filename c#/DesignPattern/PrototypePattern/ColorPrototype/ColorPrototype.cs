using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ColorPrototype
{
    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }
    public class ConcteteColorPrototype : ColorPrototype
    {
        private int _red, _green, _blue;
        public ConcteteColorPrototype(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }
        public override ColorPrototype Clone()
        {
            //实现浅拷贝
            return (ColorPrototype)this.MemberwiseClone();
        }
        public void Display(string _colorname)
        {
            Console.WriteLine("{0}'s RGB Values are: {1},{2},{3}",
                _colorname, _red, _green, _blue);
        }
    }
    public class ColorManager
    {
        Hashtable colors = new Hashtable();
        public ColorPrototype this[string name]
        {
            get
            {
                return (ColorPrototype)colors[name];
            }
            set
            {
                colors.Add(name, value);
            }
        }

    }
}

