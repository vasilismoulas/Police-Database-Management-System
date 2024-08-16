using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    internal class Tuple<T1,T2>
    {
        public T1 item1 { get; set; }
        public T2 item2 { get; set; }

        public Tuple()
        {
       
        }

        public Tuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public string ToString()
        {
            return item1 + ", " + item2;
        }
    }
}
