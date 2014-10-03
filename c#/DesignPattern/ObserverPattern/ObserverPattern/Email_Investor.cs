using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    public class Email_Investor :IObserver
    {
        private string _name;
        private Stock _stock;
        public Email_Investor(string name,Stock stock)
        {
            this._name = name;
            this._stock = stock;
        }
        public void SendData()
        {
            Console.WriteLine("Use Email to Notified {0} of {1}'s " + "change to {2:C}", _name, _stock.Symbol, _stock.Price);
        }
    }
}
