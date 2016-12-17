using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// new 隐藏基类方法，子类和基类方法独立
/// override,覆盖基类方法,基类方法也会被覆盖 
/// </summary>
namespace CLAViaCSharp
{
    public class NewBasic
    {
        public void Test()
        {
            Phone p;
            BetterPhone ph;
            p = new Phone();
           // p.Dial();

        
            ph = new BetterPhone();
            ph.Dial(); 
            

        }
    }
    class Phone
    {
        public  void Dial()
        {
            Console.WriteLine("Phone.Dial");
            EstablishConnection();
        }
        protected virtual void EstablishConnection()
        {
            Console.WriteLine("Phone.EstablishConnection");
        }
    }

    class BetterPhone : Phone
    {
        //public  void Dial()
        //{
        //    Console.WriteLine("betterPhone.Dial");
        //    base.Dial();
        //}

        public new void Dial()
        {
            Console.WriteLine("betterPhone.Dial");
            EstablishConnection();
            base.Dial();
        }
        protected  override void EstablishConnection()
        {
            Console.WriteLine("BetterPhone.EstablishConnection");
        }
        
    }
}
