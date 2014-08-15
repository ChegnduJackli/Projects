using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Product
{
    public class Consumer
    {
        ArrayList container = null;

        //得到一个容器
        public Consumer(ArrayList container)
        {
            this.container = container;
        }

        //定义一个消费的方法
        public void Consumption()
        {
            Goods goods = (Goods)this.container[0];

            Console.WriteLine("Consume Goods：" + goods.ToString());

            //消费掉容器中的一个物品
            this.container.RemoveAt(0);
        }
    }
 
}
