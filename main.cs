using System;
using System.Linq;
using System.Threading;

namespace main 
{
  // comment in/out run functions to test scenarios. works cited various youtube videos on c# threading
  class Program {
    static void Main(string[] args) 
    {
      BankScenario.Run(); 
      // starts bank account with amount, deducts 1 in multiple threads until 0, and
      // has locked code from being accessed by other threads until each thread finished

      // PassArgumentToThread.Run(); 
      // passing argument into thread via lambda function
    }


  }
}