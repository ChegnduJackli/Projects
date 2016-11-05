using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    static class StringExtension
    {
        public static int ToInt(this string t)
        {
            int id;
            int.TryParse(t, out id);//这里当转换失败时返回的id为0
            return id;
        }
    }
}
