using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CompositePattern
{
    //这是个复杂类，做更多的事情,web中的panel,相同的实现方式。
    public class Picture : Graphics
    {
        protected ArrayList picList = new ArrayList();
        public ControlsClass _controls;
        
        public virtual ControlsClass Controls
        {
            get
            {
                if (this._controls == null)
                {
                    this._controls = new ControlsClass();
                }
                return this._controls;
            }
        }
        public Picture(string name)
            : base(name)
        { }

        public override void Draw()
        {
            Console.WriteLine("Draw a " + _name.ToString());
            foreach (Graphics g in picList)
            {
                g.Draw();
            }
        }

        public void Add(Graphics g)
        {
            picList.Add(g);

        }

        public void Remove(Graphics g)
        {
            picList.Remove(g);
        }

        public void Clear(Graphics g)
        {
            picList.Clear();
        }
    }
}
