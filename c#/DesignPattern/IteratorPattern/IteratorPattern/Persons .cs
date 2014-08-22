using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IteratorPattern
{
    class Persons : IEnumerable
    {
        string[] m_Names;

        public Persons(params string[] Names)
        {
            m_Names = new string[Names.Length];

            Names.CopyTo(m_Names, 0);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (string s in m_Names)
            {
                yield return s;
            }
        }
    }
}
