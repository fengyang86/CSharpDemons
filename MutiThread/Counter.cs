using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutiThread
{
    class Counter : CounterBase
    {
        private int _count;

        public int Count { get { return _count; } }

        public override void Increment()
        {
            _count++;
        }

        public override void Decrement()
        {
            _count--;
        }
    }
}
