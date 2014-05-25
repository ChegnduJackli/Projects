using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    public class Investor :IObserver
    {
        private string _name;
        private Stock _stock;
        public Investor(string name,Stock stock)
        {
            this._name = name;
            this._stock = stock;
        }
        public void SendData()
        {
            Console.WriteLine("Notified {0} of {1}'s " + "change to {2:C}", _name, _stock.Symbol, _stock.Price);
        }
    }
}
