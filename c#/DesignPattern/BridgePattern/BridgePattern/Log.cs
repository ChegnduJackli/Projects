using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern
{
    public abstract class Log
    {
       // public abstract void Write(string log);
        
        protected Platform plateForm;

        public Platform PlateForm
        {
            set { plateForm = value; }
        }
        public virtual void Write(string log)
        {
            plateForm.Execute(log);
        }
    }
}
