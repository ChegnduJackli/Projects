using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Product
{
    class Producer
    {
        ArrayList container = null;

        //得到一个容器
        public Producer(ArrayList container)
        {
            this.container = container;
        }

        //定义一个生产物品的方法装入容器
        public void Product(string name)
        {
            //创建一个新物品装入容器
            Goods goods = new Goods();
            goods.Name = name;
            this.container.Add(goods);

            Console.WriteLine("Produce Goods：" + goods.ToString());
        }
    }
}
