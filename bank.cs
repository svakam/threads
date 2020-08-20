using System;
using System.Threading;

namespace main {
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

  class BankAcct {
    private Object acctLock = new object();
    double Balance { set; get; }

    public BankAcct(double bal)
    {
      Balance = bal;
    }

    public double Withdraw(double amt)
    {
      if((Balance - amt) < 0)
      {
        Console.WriteLine($"Sorry, ${Balance} in account");
        return Balance;
      }

      lock(acctLock) 
      {
        if(Balance >= amt)
        {
          Console.WriteLine("Removed {0} and {1} left in account",
            amt, (Balance - amt));
          
          Balance -= amt;  
        }

        return Balance;
      }
    }

    public void IssueWithdraw()
    {
      Withdraw(1);
    }
  }
}