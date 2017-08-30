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

        
        public BankAccount (AccountType accountType, decimal amount)
        {

            throw new ArgumentException(Constants.BankCustomerCompulsoryMsg);
        } // Creating of BankAccount without owner will throw exception.
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

                throw new Exception(Constants.BankAccountCreationFailedMsg);
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
                            throw new ArgumentOutOfRangeException(Constants.WithdrawLimitRuleMsg);
                    }
                    _balance -= amount;
                }
                else
                {
                    /*Implementing Business Rule:•	It is not permissible to overdraft an account.*/
                    throw new ArgumentOutOfRangeException(Constants.OverDraftRuleMsg);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException(Constants.WithdrawFailed,ex.InnerException);
               
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
            
        }
        public void Deposit(decimal amount)
        {
            try
            {
                /*This validation is useful so user does not deposit 0 or negative amount. */
                if (amount <= 0.0M)
                    throw new ArgumentOutOfRangeException(Constants.DepositMinAmountMsg);
                _balance += amount;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException(Constants.DepositMinAmountMsg,ex.InnerException);
            }
            catch (Exception e)
            {
                throw e;
                

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

                throw new Exception(Constants.TransferFailed,ex.InnerException);
            }
            catch (Exception ex1)
            {
                throw ex1;
                
            }
            
        }
        public bool IsOverDraftCase(decimal amount)
        {
            if (_balance <= 0.0M || (amount > _balance))
                return true;
            return false;
        }
        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }
    }

    // Declaring enum for different types of accounts.
    public enum AccountType
    {
        Checking, CorporateInvestment, IndividualInvestment
    }

    
}
