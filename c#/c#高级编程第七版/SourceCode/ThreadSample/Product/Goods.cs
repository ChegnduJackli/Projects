using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product
{
    public class Goods
    {
        //物品名称
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //重写ToString()
        public override string ToString()
        {
            return "Goods Name：" + name;
        }
    }
}
