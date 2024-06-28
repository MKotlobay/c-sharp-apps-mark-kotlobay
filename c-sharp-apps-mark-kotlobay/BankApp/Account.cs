using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.BankApp
{
    internal class Account
    {
        private Owner owner;
        private double balance;
        private int overdraft;
        private int MAX_OVERDRAFT;

        public Account(Owner owner, double balance, int overdraft)
        {
            this.owner = owner;
            this.balance = balance;
            this.overdraft = overdraft;
            this.MAX_OVERDRAFT = 90000;
        }

        public Owner GetOwner() { return this.owner; }
        public double GetBalance() { return this.balance; }
        public int GetOverDraft() { return this.overdraft; }

        public void SetOverdraft(int amount)
        {
            if (amount < this.MAX_OVERDRAFT && this.balance > -1 * amount)
            {
                this.overdraft = amount;
            }
            else
            {
                Console.WriteLine("Over amount that possible to set on over draft");
            }
        }

        public void Deposit(double amount) { this.balance += amount; }
        public void Withdraw(double amount)
        {
            if (this.balance - amount > -1 * overdraft)
            {
                this.balance -= amount;
            }
            else
            {
                Console.WriteLine("You have overdraft");
            }

        }
    }
}
