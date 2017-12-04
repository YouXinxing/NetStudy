using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy.Tasks
{
    public class TaskTest
    {
        public TaskTest()
        {
            //initTask();

            //initTask2();
            //InitTask4();

            //InitTask5();

            InitTask7();
            Console.ReadLine();
        }

        public void InitTask7()
        {
            var list = new List<Task>();
            for (var i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
                var t1 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Task" + i);
                });
                list.Add(t1);
            }
            Task.WaitAll(list.ToArray());
        }




        public void InitTask6()
        {
            Task parent = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                var tf = new TaskFactory<Int32>(cts.Token, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

                    //创建并启动3个子任务
                    var childTasks = new[] {
                            tf.StartNew(() => Sum(cts.Token, 10000)),
                            tf.StartNew(() => Sum(cts.Token, 20000)),
                            tf.StartNew(() => Sum(cts.Token, Int32.MaxValue))  // 这个会抛异常
                    };

                    // 任何子任务抛出异常就取消其余子任务
                    for (Int32 task = 0; task < childTasks.Length; task++)
                    childTasks[task].ContinueWith(t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);

                    // 所有子任务完成后，从未出错/未取消的任务获取返回的最大值
                    // 然后将最大值传给另一个任务来显示最大结果
                    tf.ContinueWhenAll(childTasks,completedTasks => completedTasks.Where(t => !t.IsFaulted && !t.IsCanceled).Max(t => t.Result),
                   CancellationToken.None) .ContinueWith(t => Console.WriteLine("The maxinum is: " + t.Result),
                      TaskContinuationOptions.ExecuteSynchronously).Wait(); // Wait用于测试
             });

            // 子任务完成后，也显示任何未处理的异常
            parent.ContinueWith(p =>
            {
                    // 用StringBuilder输出所有

                    StringBuilder sb = new StringBuilder("The following exception(s) occurred:" + Environment.NewLine);
                foreach (var e in p.Exception.Flatten().InnerExceptions)
                    sb.AppendLine("   " + e.GetType().ToString());
                Console.WriteLine(sb.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);

            // 启动父任务
            parent.Start();

            try
            {
                parent.Wait(); //显示结果
            }
            catch (AggregateException)
            {
            }
        }

        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                ct.ThrowIfCancellationRequested();
                checked { sum += n; }
            }
            return sum;
        }




        public void InitTask5()
        {
            Task<Int32> t = new Task<Int32>(i => Sum((Int32)i), 10000);
            t.Start();

            t.ContinueWith(task => Console.WriteLine("The sum is:{0}", task.Result),
                TaskContinuationOptions.OnlyOnRanToCompletion);

            t.ContinueWith(task => Console.WriteLine("Sum throw:" + task.Exception),
                TaskContinuationOptions.OnlyOnFaulted);

            t.ContinueWith(task => Console.WriteLine("Sum was cancel:" + task.IsCanceled),
                TaskContinuationOptions.OnlyOnCanceled);
            try
            {
                t.Wait();  // 测试用
                Task.WaitAll();
            }
            catch (AggregateException)
            {
                Console.WriteLine("出错");
            }
        }


        public void InitTask4()
        {
            Task<Int32> t = new Task<Int32>(i => Sum((Int32)i), 10000);
            //可以现在开始，也可以以后开始 
            t.Start();
            Task cwt = t.ContinueWith(task => Console.WriteLine("The sum is:{0}", task.Result));
            cwt.Wait();

        }


        public void initTask()
        {
            Console.WriteLine("主线程：启动专用线程...");
            Thread dedicatedThread = new Thread(StartCode);

            dedicatedThread.Start(5);

            Console.WriteLine("主线程：运行到此");
            Thread.Sleep(10000);//模拟主线程操作
            dedicatedThread.Join();
            Console.WriteLine("主线程：运行完毕");
        }

        public void InitTask3()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<Int32> t = new Task<Int32>(() => Sum(cts.Token, 10000), cts.Token);
            //可以现在开始，也可以以后开始 
            t.Start();
            //在之后的某个时间，取消CancellationTokenSource 以取消Task
            cts.Cancel();//这是个异步请求，Task可能已经完成了。我是双核机器，Task没有完成过
            //注释这个为了测试抛出的异常
            //Console.WriteLine("This sum is:" + t.Result);
            try
            {
                //如果任务已经取消了，Result会抛出AggregateException

                Console.WriteLine("This sum is:" + t.Result);
            }
            catch (AggregateException x)
            {
                //将任何OperationCanceledException对象都视为已处理。
                //其他任何异常都造成抛出一个AggregateException，其中
                //只包含未处理的异常

                x.Handle(e => e is OperationCanceledException);
                Console.WriteLine("Sum was Canceled");
            }

        }

        //private static Int32 Sum(CancellationToken ct, Int32 i)
        //{
        //    Int32 sum = 0;
        //    for (; i > 0; i--)
        //    {
        //        //在取消标志引用的CancellationTokenSource上如果调用
        //        //Cancel，下面这一行就会抛出OperationCanceledException

        //        ct.ThrowIfCancellationRequested();

        //        checked { sum += i; }
        //    }

        //    return sum;
        //}
        private static Int32 Sum(Int32 i)
        {
            Int32 sum = 0;
            for (; i > 0; i--)
                checked { sum += i; }
            Console.WriteLine("SUM = ", sum);
            return sum;
        }

        public void initTask2()
        {
            Console.WriteLine("主线程启动");
            //ThreadPool.QueueUserWorkItem(StartCode, 5);

            new Task(StartCode, 5).Start();

            Console.WriteLine("主线程运行到此！");
            Thread.Sleep(1000);
        }

        private static void StartCode(object i)
        {
            Console.WriteLine("开始执行子线程...{0}", i);
            Thread.Sleep(1000);//模拟代码操作
            Console.WriteLine("子线程运行完毕...{0}", i);
        }
    }
}
