using System;
using System.Threading;

namespace main {
  class PassArgumentToThread {
    public static void Run() {
      Thread t = new Thread(() => CountTo(10));
      t.Start();

      new Thread(() => 
      {
        CountTo(5);
        CountTo(6);
      }).Start();

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
}