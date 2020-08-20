using System;

namespace threads {
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