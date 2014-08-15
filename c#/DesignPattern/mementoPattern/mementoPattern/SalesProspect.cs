using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mementoPattern
{
    class SalesProspect
    {
        private string name;
        private string phone;
        private double budget;

        public string Name
        {
            get { return name; }
            set { name = value; Console.WriteLine("Name:" + name); }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; Console.WriteLine("Phone:" + phone); }
        }

        public double Budget
        {
            get { return Budget; }
            set { budget = value; Console.WriteLine("Budget:" + budget); }
        }

        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(name, phone, budget);
        }

        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }
}
