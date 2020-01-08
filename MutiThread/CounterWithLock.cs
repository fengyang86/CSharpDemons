using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutiThread
{
    class CounterWithLock : CounterBase
    {
        private readonly object _syncRoot = new Object();

        public int Count { get; private set; }

        public override void Increment()
        {
            lock (_syncRoot)
            {
                Count++;
            }
        }

        public override void Decrement()
        {
            lock (_syncRoot)
            {
                Count--;
            }
        }
    }

}
