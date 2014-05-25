using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogWrite
{
    public class EventFactory:LogFactory
    {
        public override Log Create()
        {
            return new EventLog();
        }
    }
}
