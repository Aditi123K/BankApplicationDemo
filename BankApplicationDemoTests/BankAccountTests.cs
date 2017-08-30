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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DepositZeroAmountTest()
        {
            BankAccount investmentAccount = new BankAccount(new Customer("Mike"), AccountType.IndividualInvestment, 5000.0M);
            investmentAccount.Deposit(0.0M);
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TransferMoneyTest()
        {

                BankAccount LuisCheckingAccount = new BankAccount(new Customer("Luis"), AccountType.Checking, 8000.0M);
                BankAccount HealyCheckingAccount = new BankAccount(new Customer("Healy"), AccountType.Checking, 1000.0M);
                LuisCheckingAccount.TransferMoney(9000.0M, HealyCheckingAccount);
                Assert.AreEqual(6000.0M, LuisCheckingAccount.Balance);
                Assert.AreEqual(3000.0M, HealyCheckingAccount.Balance);
            
        }
        [TestMethod()]
        public void TransferMoneyPassTest()
        {
            try
            {
                BankAccount LuisCheckingAccount = new BankAccount(new Customer("Luis"), AccountType.Checking, 8000.0M);
                BankAccount HealyCheckingAccount = new BankAccount(new Customer("Healy"), AccountType.Checking, 1000.0M);
                LuisCheckingAccount.TransferMoney(2000.0M, HealyCheckingAccount);
                Assert.AreEqual(6000.0M, LuisCheckingAccount.Balance);
                Assert.AreEqual(3000.0M, HealyCheckingAccount.Balance);
            }
            catch (ArgumentOutOfRangeException ex)
            {

                    throw new ArgumentOutOfRangeException(Constants.TransferFailed, ex.InnerException);
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