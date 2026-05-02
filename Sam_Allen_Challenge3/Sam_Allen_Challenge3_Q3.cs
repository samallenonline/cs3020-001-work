/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #3 - Question #3

Objective: Build a bank account management system and 
handle invalid operations using exceptions.
*/

using System;
using System.Collections.Generic;

namespace BankAccountManagement
{
    public class BankAccount
    {
        /*
        This class represents a bank account for 
        an individual.
        */
        public string AccountHolder {get; set;}
        public decimal Balance {get; private set;}

        public BankAccount(string accountHolder, decimal initialBalance = 0)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            /*
            This method allows the account owner to deposit funds 
            to their bank account.
            */

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount is negative.");
            }
            else
            {
                Balance += amount;
                Console.WriteLine($"${amount} has been deposited.");
            }
        }

        public void Withdraw(decimal amount)
        {
            /*
            This method allows the account owner to withdraw funds 
            from their bank account. 
            */

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount is negative.");
            }
            else if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"${amount} has been withdrawn.");
            }
        }

        public void DisplayAccountInfo()
        {
            /*
            This method displays all account information for a 
            given bank account.
            */
            Console.WriteLine($"Holder: {AccountHolder}, Balance: {Balance:C}");
        }
    }

    public class Bank
    {
        /*
        This class represents a banking entity.
        */
        private List<BankAccount> accounts = new List<BankAccount>();

        public void AddAccount(BankAccount account)
        {
            /*
            This method adds a banking account to the bank.
            */
            foreach (var a in accounts)
            {
                if (a.AccountHolder == account.AccountHolder) // account already exists
                {
                    throw new InvalidOperationException("Account already exists.");
                }
            }

            // new account, add to list 
            accounts.Add(account);
        }

        public BankAccount GetAccountByHolder(string holder)
        {
            /*
            This method finds a banking account using the 
            holder name.
            */
            foreach (var a in accounts)
            {
                if (a.AccountHolder == holder)
                {
                    return a;
                }
            }

            throw new KeyNotFoundException("Account not found.");    
        }

        public void DisplayAccounts()
        {
            /*
            This method displays all information for every account 
            in the bank system.
            */

            if (accounts.Count == 0)
            {
                throw new InvalidOperationException("No accounts exist.");
            }
            else
            {
                foreach (var a in accounts)
                {
                    a.DisplayAccountInfo();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTASK 3:\n");
            
            // create bank and bank account objects 
            var myBank = new Bank();
            var myBankAccount1 = new BankAccount("Sam", 50);
            var myBankAccount2 = new BankAccount("Noah", 80);

            // add bank accounts to bank
            myBank.AddAccount(myBankAccount1);
            myBank.AddAccount(myBankAccount2);

            // use try-catch to test various scenarios 
            try // depositing a negative amount
            {
                myBankAccount1.Deposit(-20);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try // withdrawing more than the current balance
            {
                myBankAccount2.Withdraw(85);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try // accessing a non-existant account
            {
                myBank.GetAccountByHolder("Amy");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // make valid operations 
            myBankAccount1.Deposit(20);
            myBankAccount1.Withdraw(5);

            myBankAccount2.Deposit(10);
            myBankAccount2.Withdraw(30);

            var holder = myBank.GetAccountByHolder("Sam");
            if (holder != null) {Console.WriteLine($"Account found: {holder.AccountHolder}"); }
        }
    }
}