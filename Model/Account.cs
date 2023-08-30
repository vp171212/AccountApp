using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp.Model
{
    [Serializable]
    internal class Account
    {
        int _accountNo;
        string _accountHolderName;
        string _bankName;
        double _balance;
        public int AccountNo { get;set; }
        public string AccountHolderName { get;set; }
        public string BankName { get;set; }
        public double Balance { get;set; }
        public Account() { }
        public Account(int accountNo, string accountHolderName, string bankName, double balance)
        {
            AccountNo = accountNo;
            AccountHolderName = accountHolderName;
            BankName = bankName;
            Balance = balance;
        }

        public void Deposit(double amount) 
        {
            Balance = Balance + amount;
        }
        public void Withdraw(double amount)
        {
            Balance -= amount;
        }
        public double CheckBalance()
        {
            return Balance;
        }
    }
}
