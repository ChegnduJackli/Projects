using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    //微软公司的股票
    public class Microsoft:Stock
    {
        public Microsoft(string symbol, double price)
            : base(symbol, price)
        { }
    }
}
