using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationDemo
{
    public class BankAccount :ITransactions
    {
        AccountType _accountType;
        Customer _custOwner;
        decimal _balance;
        //string _accountNumber;
        public string AccountNumber { get; set; }
        public BankAccount(Customer custOwner,AccountType accountType,decimal amount) {
            _accountType = accountType;
            _balance = amount;
            AccountNumber = new Random().Next(10000, 999999).ToString();
        }
        public void Withdraw(decimal amount)
        {

            if (!(isOverDraftCase(amount))) /*Implementing Business Rule:•	It is not permissible to overdraft an account.*/
            {

                /*Implementing Business Rule:•	Individual Investment accounts can withdraw up to $1,000 at a time.*/
                if (this._accountType == AccountType.IndividualInvestment)
                {
                    if (amount > 1000.0M)
                        throw new ArgumentOutOfRangeException("Individual Investment accounts can withdraw up to $1,000 at a time.");
                }
                _balance -= amount;
            }
            else
            {
                /*Implementing Business Rule:•	It is not permissible to overdraft an account.*/
                throw new ArgumentOutOfRangeException("It is not permissible to overdraft an account.");
            }
        }
        public void Deposit(decimal amount)
        {
            _balance += amount;
        }
        public decimal CheckBalance()
        {
            return _balance;
        }
        public void TransferMoney(decimal amount, BankAccount ac)
        {
            this.Withdraw(amount);
            ac.Deposit(amount);
        }

        /*Check if the withdraw transaction will result in a zero balance or negative balance amount.*/
        public bool isOverDraftCase(decimal amount)
        {

            if (_balance <= 0.0M || (_balance - amount <= 0.0M))
                return true;


            return false;
        }

       
    }

    // Declaring enum for different types of accounts.
    public enum AccountType
    {

        Checking, CorporateInvestment, IndividualInvestment

    }
}
