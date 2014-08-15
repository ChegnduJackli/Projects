using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace Product
{
    class Program
    {
        //创建一个消费者和生产者共用的一个容器
        ArrayList container = new ArrayList();

        Producer producer = null;
        Consumer consumer = null;
 
        static void Main(string[] args)
        {
            Program p = new Program();

            //创建两个线程并启动
            Thread t1 = new Thread(new ThreadStart(p.ThreadProduct));
            Thread t2 = new Thread(new ThreadStart(p.ThreadConsumption));

            t1.Start();
            t2.Start();

            Console.Read();
        }
        //定义一个线程方法生产8个物品
        public void ThreadProduct()
        {
            //创建一个生产者
            producer = new Producer(this.container);
            lock (this)
            {
                for (int i = 1; i <= 8; i++)
                {
                    //如果容器中没有就进行生产
                    if (this.container.Count == 0)
                    {
                        //调用方法进行生产
                        producer.Product(i + "");
                        //生产好了一个通知消费者消费
                        Monitor.Pulse(this);
                    }
                    //容器中还有物品等待消费者消费后再生产
                    Monitor.Wait(this);
                }
            }
        }
        //定义一个线程方法消费生产的物品
        public void ThreadConsumption()
        {
            //创建一个消费者
            consumer = new Consumer(this.container);
            lock (this)
            {
                while (true)
                {
                    //如果容器中有商品就进行消费
                    if (this.container.Count != 0)
                    {
                        //调用方法进行消费
                        consumer.Consumption();
                        //当拥有对象锁的线程准备释放锁时，它使用Monitor.Pulse()方法通知等待队列中的第一个线程，
                        //于是该线程被转移到预备队列中，当对象锁被释放时，在预备队列中的线程可以立即获得对象锁。
                        Monitor.Pulse(this);
                    }
                    //容器中没有商品通知消费者消费
                    Monitor.Wait(this);
                }
            }
        }
    }
}
