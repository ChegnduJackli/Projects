﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GenerateScript
{
    public class Context
    {
        Strategy strategy;

        public void SetStrategy()
        {
            this.strategy = LoadClassInstance();
        }

        public void GenereateScript(string filePath)
        {
             this.strategy.GenerateScripts(filePath);
        }

        public Strategy LoadClassInstance()
        {
            Strategy strategy;
            string assembleType = GetStrategy();

            Type type = Type.GetType(assembleType, true);
            strategy = (Strategy)Activator.CreateInstance(type);
            return strategy;
        }

        private string GetStrategy()
        {
            return "GenerateScript."+PubConstant.Database;;
        }
    }

}
