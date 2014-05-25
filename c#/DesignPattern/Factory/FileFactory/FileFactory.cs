using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogWrite
{
    public class FileFactory:LogFactory
    {
        public override Log Create()
        {
            return new FileLog();
        }
    }
}
