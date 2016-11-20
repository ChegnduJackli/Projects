using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    class staticVar
    {
        private string name;
        private static string password;
        static staticVar()
        {
            password = "123";
           //name = "";
           
        }
        public staticVar()
        {
            this.name = "123";
            password = "456";
        }

        public void ouput()
        {
            Console.WriteLine("this.name: "+this.name);
            Console.WriteLine("this.password: " + password);
        }
    }
}
