using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    public class Mobile_Investor : IObserver
    {

        private string _name;
        private Stock _stock;
        public Mobile_Investor(string mobileNumber, Stock stock)
        {
            this._name = mobileNumber;
            this._stock = stock;
        }
        public void SendData()
        {
            Console.WriteLine("user Mobile to Notified {0} of {1}'s " + "change to {2:C}", _name, _stock.Symbol, _stock.Price);
        }
    }
}
