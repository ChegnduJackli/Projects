using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    //谷歌公司的股票
    public class Google:Stock
    {
        public Google(String Symbol, double Price)
            : base(Symbol, Price)
        {
 
        }
    }
}
