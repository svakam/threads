using System;
using System.Threading;

namespace threads 
{
  class Program {
    static void Main(string[] args) 
    {
      // BankScenario.Run();

      Thread t = new Thread();

      Console.ReadLine();

    }

    static void CountTo(int maxNum)
    {
      for (int i = 0; i <= maxNum ; i++)
      {
        Console.WriteLine(i);
      }
    }

  }

  class BankScenario {
    public static void Run() {
      BankAcct acct = new BankAcct(10);
      Thread[] threads = new Thread[15];

      Thread.CurrentThread.Name = "main";

      for (int i = 0; i < 15; i++) 
      {
        Thread t = new Thread(new ThreadStart
        (acct.IssueWithdraw));
        t.Name = i.ToString();
        threads[i] = t;
      }

      for (int i = 0; i < 15; i++) 
      {
        Console.WriteLine("Thread {0} Alive : {1}",
          threads[i].Name,
          threads[i].IsAlive);

        threads[i].Start();

        Console.WriteLine("Thread {0} Alive : {1}",
          threads[i].Name,
          threads[i].IsAlive);
      }

      Console.WriteLine("Current Priority: {0}",
      Thread.CurrentThread.Priority);

      Console.WriteLine("Thread {0} Ending", 
        Thread.CurrentThread.Name);

      Console.ReadLine();
    }
  }


}