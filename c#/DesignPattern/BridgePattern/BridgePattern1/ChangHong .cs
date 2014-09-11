using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern1
{
    /// <summary>
    /// 长虹牌电视机，重写基类的抽象方法
    /// 提供具体的实现
    /// </summary>
    public class ChangHong : TV
    {
        public override void On()
        {
            //Console.WriteLine("长虹牌电视机已经打开了");
            Console.WriteLine("ChagnHong TV is turn on");
        }

        public override void Off()
        {
            //Console.WriteLine("长虹牌电视机已经关掉了");
            Console.WriteLine("ChagnHong TV is turn off");
        }

        public override void tuneChannel()
        {
           // Console.WriteLine("长虹牌电视机换频道");
            Console.WriteLine("ChagnHong TV is Change channel");
        }
    }
}
