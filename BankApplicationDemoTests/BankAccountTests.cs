using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApplicationDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationDemo.Tests
{
    
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void BankAccountTest()
        {

            Bank abcBank = new Bank("ABC");
            try
            {
                abcBank.AddBankAccount(new BankAccount(new Customer("Angie"), AccountType.Checking, 850.0M));
            }
            catch (Exception ex)
            {
                if (StringAssert.Equals(ex.Message, Constants.BankAccountCreationFailedMsg))
                    return;

            }
           
        }

        //Regular withdraw
        [TestMethod()]
        public void WithdrawTest()
        {

            BankAccount corporateInvestmentAccount = new BankAccount(new Customer("RCN"), AccountType.CorporateInvestment, 5000.0M);
            corporateInvestmentAccount.Withdraw(2000.0M);
            Assert.AreEqual(3000.0M, corporateInvestmentAccount.Balance);
        }

        // Individual Investment Constraint
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WithdrawLimitTest()
        {
                BankAccount investmentAccount = new BankAccount(new Customer("Alex"), AccountType.IndividualInvestment, 5000.0M);
                investmentAccount.Withdraw(2000.0M);
        }

        //Overdraft Withdraw
        
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WithdrawOverdraftTest()
        {
                BankAccount investmentAccount = new BankAccount(new Customer("Alex"), AccountType.IndividualInvestment, 5000.0M);
                investmentAccount.Withdraw(7000.0M);
        }


        [TestMethod()]
        public void DepositTest()
        {

            try
            {
                BankAccount checkingAccount = new BankAccount(new Customer("Joe"), AccountType.Checking, 1000.0M);
                checkingAccount.Deposit(1000.0M);
                Assert.AreEqual(2000.0M, checkingAccount.Balance);
            }
            catch (Exception ex)
            {

                if (StringAssert.Equals(ex.Message, Constants.DepositFailedMsg))
                    return;
                throw new Exception(Constants.DepositFailedMsg, ex.InnerException);
            }



         
        }
        [TestMethod()]
        public void TransferMoneyTest()
        {

            try
            {

            }
            catch (Exception ex)
            {

                if (StringAssert.Equals(ex.Message, "Bank account creation failed."))
                    return;
            }
            
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BankAccountTestOwnerCompulsory()
        {
            BankAccount b = new BankAccount(AccountType.CorporateInvestment, 123344.990M);
        }
    }
   
}