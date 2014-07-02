using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvertType
{
    public class ConvertToType
    {
        /// <summary>
        /// convert string value to specified type value.
        /// if convert failed, then return default value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(String value)
        {
            if (string.IsNullOrEmpty(value)) return default(T);  //return default value by pass type

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                //throw ex;
               return default(T);
            }
        }
    }
}
