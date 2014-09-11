using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern1
{
    /// <summary>
    /// 三星牌电视机，重写基类的抽象方法
    /// </summary>
    public class Samsung : TV
    {
        public override void On()
        {
            //Console.WriteLine("三星牌电视机已经打开了");
            Console.WriteLine("Samsung TV is turn on");
        }

        public override void Off()
        {
           //Console.WriteLine("三星牌电视机已经关掉了");
            Console.WriteLine("Samsung TV is turn off");
        }

        public override void tuneChannel()
        {
           // Console.WriteLine("三星牌电视机换频道");
            Console.WriteLine("Samsung TV is change channel");
        }
    }
}
