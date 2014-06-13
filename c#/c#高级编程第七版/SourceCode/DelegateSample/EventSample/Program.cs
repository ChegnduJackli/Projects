using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//窗体中的click button事件
namespace EventSample
{
    class Program
    {
        static void Main(string[] args)
        {   
            //连接事件发布程序和订阅器
            var dealer = new CarDealer();
            var michael = new Consumer("Michael");
            //dealer.NewCarInfo+=new EventHandler<CarInfoEventArgs>(michael.NewCarIsHere);
            //等价于
            dealer.NewCarInfo += michael.NewCarIsHere;
            dealer.NewCar("Mercedes");

            var nick = new Consumer("Nick");
            dealer.NewCarInfo += nick.NewCarIsHere;
            dealer.NewCar("Ferrari");
            Console.ReadKey();

        }
    }
    class CarInfoEventArgs : EventArgs
    {
        public string Car { get; set; }
        public CarInfoEventArgs(string car)
        {
            this.Car = car;
        }
    }
    //事件发布
    class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;
        public void NewCar(string car)
        {
            Console.WriteLine("CarDealer, New car {0}", car);
            if (NewCarInfo != null)
            {
                //作为约定，事件一般带有2个参数的方法，第一个参数是对象，包含事件的发送者，第二个参数提供了事件的相关信息.
                //在触发事件之前，需要检查委托是否为空，如果没有订阅处理程序，委托就是空.
                NewCarInfo(this, new CarInfoEventArgs(car));
            }
        }
    }
    //事件侦听
    class Consumer
    {
        private string name;
        public Consumer(string name)
        {
            this.name = name;
        }
        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine("{0}:car {1} is  new ",name,e.Car);
        }
    }

}
