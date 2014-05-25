using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    //股票价格，针对不同的公司,监测的目标对象
    public abstract class Stock
    {
        private List<IObserver> observers = new List<IObserver>();

        private String _symbol;

        private double _price;

        public Stock(String symbol, double price)
        {
            this._symbol = symbol;

            this._price = price;
        }

        public void Update()
        {
            foreach (IObserver ob in observers)
            {
                ob.SendData();
            }

        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public String Symbol
        {
            get { return _symbol; }
        }

        public double Price
        {
            get { return _price; }
        }
    }
}
