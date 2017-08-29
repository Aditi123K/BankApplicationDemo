using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationDemo
{
    public class BankAccount
    {
        AccountType _accountType;
        Customer _custOwner;
        decimal _balance;
        string _accountNumber;

        public BankAccount(Customer custOwner,AccountType accountType,decimal amount) {
            _accountType = accountType;
            _balance = amount;
            _accountNumber = new Random().Next(10000, 999999).ToString();
        }
        public void Withdraw(decimal amount,AccountType ac)
        {
            switch (ac)
            {
                case AccountType.Checking:
                    break;
                case AccountType.CorporateInvestment:
                    break;
                case AccountType.IndividualInvestment:


                    break;
            }
        }
        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public void TransferAmount(decimal amount, int accountNumber)
        {


        }
            
        public decimal Balance { get { return _balance; } }
    }

    public enum AccountType
    {

        Checking, CorporateInvestment, IndividualInvestment

    }
}
