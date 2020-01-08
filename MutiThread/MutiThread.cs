using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutiThread
{
    public partial class MutiThread : Form
    {
        public MutiThread()
        {
            InitializeComponent();
        }
        private void CountBigData()
        {
            int num = (int)Math.Pow(10, 10);
            while (num > 0)
            {
                Thread.Sleep(1000);
                num--;
            }
            Debug.Print("无参数");
        }
        private void CountBigData(object state)
        {
            int num = (int)Math.Pow(10, 10);
            while (num > 0)
            {
                Thread.Sleep(1000);
                num--;
            }
            Debug.Print((string) state);
        }
        //线程函数通过委托传递，可以不带参数，也可以带参数（只能有一个参数），可以用一个类或结构体封装参数。
        private void ThreadFun_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(CountBigData));
            Thread t2 = new Thread(new ParameterizedThreadStart(CountBigData));
            t1.IsBackground = true;
            t2.IsBackground = true;
            t1.Start();
            t2.Start("hello");
        }

        //由于线程的创建和销毁需要耗费一定的开销，过多的使用线程会造成内存资源的浪费，出于对性能的考虑，于是引入了线程池的概念。
        //线程池维护一个请求队列，线程池的代码从队列提取任务，然后委派给线程池的一个线程执行，线程执行完不会被立即销毁，这样既可以在后台执行任务，又可以减少线程创建和销毁所带来的开销。
        //线程池线程默认为后台线程（IsBackground）。
        private void ThreadPool_Click(object sender, EventArgs e)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(this.CountBigData, "Hello");
            System.Threading.ThreadPool.QueueUserWorkItem(this.CountBigData, "Hello1");
        }

        //使用ThreadPool的QueueUserWorkItem()方法发起一次异步的线程执行很简单，但是该方法最大的问题是没有一个内建的机制让你知道操作什么时候完成，有没有一个内建的机制在操作完成后获得一个返回值。
        //为此，可以使用System.Threading.Tasks中的Task类。
        //构造一个Task<TResult> 对象，并为泛型TResult参数传递一个操作的返回类型。
        private void TaskFun_Click(object sender, EventArgs e)
        {
            Task<string> t = new Task<string>(n => { return n.ToString(); }, "Task");
            
            t.Start();
            //t.Wait();
            Task cwt = t.ContinueWith(task => Debug.Print("The result is {0}", t.Result));//一个任务完成时，自动启动一个新任务。
        }


        //委托的异步调用：BeginInvoke() 和 EndInvoke()
        private void AsyncDelegate_Click(object sender, EventArgs e)
        {
            Action<object> myAction = new Action<object>(CountBigData);

            IAsyncResult result= myAction.BeginInvoke("异步", new AsyncCallback(asyncResult => { Debug.Print(asyncResult.AsyncState.ToString()); }),"回调参数");
            //异步执行完成
            myAction.EndInvoke(result);
        }

        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }

        #region Interlocked原子操作
        private void InterlockedUse_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Incorrect counter");

            var c = new Counter();

            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Debug.WriteLine("Total count: {0}", c.Count);
            Debug.WriteLine("--------------------------");

            Debug.WriteLine("Correct counter");

            var c1 = new CounterNoLock();

            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() => TestCounter(c1));
            t3 = new Thread(() => TestCounter(c1));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Debug.WriteLine("Total count: {0}", c1.Count);
            //我们采用上述方式执行该操作中途不能停止。而借助于Interlocked类,我们无需锁定任何对象即可获取到正确的结果

        }
        #endregion

        #region Lock关键字的使用
        private void LockUse_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Incorrect counter");

            var c = new Counter();

            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Debug.WriteLine("Total count: {0}", c.Count);
            Debug.WriteLine("--------------------------");

            Debug.WriteLine("Correct counter");

            var c1 = new CounterWithLock();

            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() => TestCounter(c1));
            t3 = new Thread(() => TestCounter(c1));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Debug.WriteLine("Total count: {0}", c1.Count);

        }
        #endregion

        #region Monitor类的使用
        static void LockTooMuch(object lock1, object lock2)
        {
            lock (lock1)
            {
                Thread.Sleep(1000);
                lock (lock2) ;
            }
        }
        private void MonitorUse_Click(object sender, EventArgs e)
        {
            object lock1 = new object();
            object lock2 = new object();

            new Thread(() => LockTooMuch(lock1, lock2)).Start();

            lock (lock2)
            {
                Thread.Sleep(1000);
                Debug.WriteLine("Monitor.TryEnter allows not to get stuck, returning false after a specified timeout is elapsed");
                if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))//5s内获取不了资源就返回false
                {
                    Debug.WriteLine("Acquired a protected resource succesfully");
                }
                else
                {
                    Debug.WriteLine("Timeout acquiring a resource!");
                }
            }

            new Thread(() => LockTooMuch(lock1, lock2)).Start();

            Debug.WriteLine("----------------------------------");
            lock (lock2)
            {
                Debug.WriteLine("This will be a deadlock!");
                Thread.Sleep(1000);
                lock (lock1)
                {
                    Debug.WriteLine("Acquired a protected resource succesfully");
                }
            }

        }
        #endregion
    }

}
