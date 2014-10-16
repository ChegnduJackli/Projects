using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenereateTableDictionary
{
    public class Context
    {
        private List<IGenerateExcel> objList = new List<IGenerateExcel>();
        public void AddObject(IGenerateExcel obj)
        {
            if (!objList.Contains(obj))
            {
                objList.Add(obj);
            }
        }
        public void RemoveObject(IGenerateExcel obj)
        {
            if (objList.Contains(obj))
            {
                objList.Remove(obj);
            }
        }
        public void GenerateExcel()
        {
            foreach (IGenerateExcel i in objList)
            {
                i.GenerateExcel();
            }
        }
    }
}
