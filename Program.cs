using AccountApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double minBalance = 500;
            string filePath = ConfigurationManager.AppSettings["AccountDetails"];
            Account accountDetails;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            long length=fileStream.Length;
            fileStream.Close();
            if (length==0)
            {
                Console.WriteLine("Welcome !\n"+ "Enter Account Details to create new Account: ");
                Console.WriteLine("Enter Account Number: ");
                int accountNum=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Account Holder Name: ");
                string name=Console.ReadLine();
                Console.WriteLine("Enter Bank Name: ");
                string bankName=Console.ReadLine();
                Console.WriteLine("Enter opening balance: ");
                double balance =Convert.ToDouble(Console.ReadLine());
                accountDetails = new Account(accountNum,name,bankName,balance);
                Console.WriteLine("Account Created Successfuly");
            }
            else
            {
                Console.WriteLine("Welcome Back !");
                accountDetails = DataSerializer.BinaryDeserialize(filePath);
                Console.WriteLine("Account Balance is: "+accountDetails.Balance);
            }
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("What do you wish to do?");
                Console.WriteLine("1.Deposit\n" +
                    "2.Withdraw\n3.DisplayBalance\n" +
                    "4.Exit");
                string command = Console.ReadLine();
                if (command == "1")
                {
                    Console.WriteLine("Enter the amount: ");
                    double amount= Convert.ToDouble(Console.ReadLine());
                    accountDetails.Deposit(amount);
                }
                else if (command == "2")
                {
                    Console.WriteLine("Enter the amount: ");
                    double amount=Convert.ToDouble(Console.ReadLine());
                    if(accountDetails.Balance<minBalance || accountDetails.Balance-amount<minBalance)
                        Console.WriteLine("Minimum balance 500INR is required");
                    else
                       accountDetails.Withdraw(amount);
                }
                else if (command == "3")
                {
                    Console.WriteLine("Your Balance is: " + accountDetails.Balance);
                }
                else if (command == "4")
                {
                    Console.WriteLine("Thank You!\n"+"Visit Again");
                    exit = 1;
                }
                else 
                {
                    Console.WriteLine("Please Give a Correct Command");
                }
            }
            DataSerializer.BinarySerializer(accountDetails, filePath);
        }
    }
}
