using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GenerateScript
{
    public abstract class Strategy
    {
        public abstract void GenerateScripts(string filePath = "");
      
        //Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "GenerateScript");

        //for (int i = 0; i < typelist.Length; i++)
        //{
        //    Console.WriteLine(typelist[i].Name);
        //}
        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

      

    }
}
