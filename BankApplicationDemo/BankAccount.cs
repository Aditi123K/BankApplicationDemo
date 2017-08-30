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
        public string AccountNumber { get; set; }

        

        public BankAccount(Customer custOwner,AccountType accountType,decimal amount)
        {
            _accountType = accountType;
            _balance = amount;
            _custOwner = custOwner;
            try
            {
                AccountNumber = new Random().Next(10000, 999999).ToString();
            }
            catch (Exception ex)
            {

                throw new Exception(Constants.BankCreationFailedMsg);
            }
            
            
        }
        public void Withdraw(decimal amount)
        {

            try
            {
                if (!(IsOverDraftCase(amount))) /*Implementing Business Rule:•	It is not permissible to overdraft an account.*/
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
            catch (ArgumentOutOfRangeException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("Withdraw transaction failed!");
            }
            
        }
        public void Deposit(decimal amount)
        {
            try
            {
                /*This validation is useful so user does not deposit 0 or negative amount. */
                if (amount <= 0.0M)
                    throw new ArgumentOutOfRangeException("Deposit of 0 or negative amount not valid.");
                _balance += amount;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;

            }
            catch (Exception e)
            {

                throw new Exception ("Deposit transaction failed!");

            }
            

        }
        public void TransferMoney(decimal amount, BankAccount ac)
        {
            try
            {
                this.Withdraw(amount);
                ac.Deposit(amount);
            }

            catch (ArgumentOutOfRangeException ex)
            {

                throw ex;
            }
            catch (Exception e)
            {

                throw new Exception("TransferMoney transaction failed!");
            }
            
        }
        public bool IsOverDraftCase(decimal amount)
        {
            if (_balance <= 0.0M || (amount > _balance))
                return true;
            return false;
        }
        public decimal CheckBalance()
        {
            return _balance;
        }
    }

    // Declaring enum for different types of accounts.
    public enum AccountType
    {
        Checking, CorporateInvestment, IndividualInvestment
    }

    
}
