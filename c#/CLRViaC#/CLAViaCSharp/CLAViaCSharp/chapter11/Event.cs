using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAViaCSharp.chapter11
{
    public class Event
    {
    }
    internal class NewMailEventArgs : EventArgs
    {
        private readonly string m_from, m_to,m_subject;
        
    }
}
