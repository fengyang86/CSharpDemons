using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutiThread
{


    //Interlocked提供了Increment, Decrement和Add等基本数学操作的原子方法,从而帮助我们,在编写Counter类时无需使用锁
    class CounterNoLock : CounterBase
    {
        private int _count;

        public int Count { get { return _count; } }

        public override void Increment()
        {
            Interlocked.Increment(ref _count);
        }

        public override void Decrement()
        {
            Interlocked.Decrement(ref _count);
        }
    }

   

}
