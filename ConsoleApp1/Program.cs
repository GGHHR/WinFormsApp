using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        // 创建一个新的线程并指定要执行的方法
        Thread thread = new Thread(DoWork);

        // 启动线程
        thread.Start();

        // 主线程继续执行其他任务
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Main thread: " + i);
            Thread.Sleep(1000); // 暂停1秒钟
        }
    }

    public static void DoWork()
    {
        // 在新线程中执行的工作
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Worker thread: " + i);
            Thread.Sleep(1000); // 暂停1秒钟
        }
    }
}