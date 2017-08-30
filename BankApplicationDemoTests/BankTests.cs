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
    public class BankTests
    {
        /*This test tests that the bank must have a owner*/
        [TestMethod()]
        public void BankNoOwnerTest()
        {

            try
            {
                Bank b = new Bank();
            }
            catch (Exception ex)
            {

                if (StringAssert.Equals(ex.Message, Constants.BankCustomerCompulsoryMsg ))
                    return;
               
            }
           
          
            Assert.Fail(Constants.NoExceptionMsg);
        }
        [TestMethod()]
        public void BankTest()
        {

            try
            {
                Bank b = new Bank("ABC");
            }
            catch (Exception ex)
            {

                if (StringAssert.Equals(ex.Message, Constants.BankCustomerCompulsoryMsg))
                    return;

            }


            Assert.Fail(Constants.NoExceptionMsg);

        }


        [TestMethod()]
        public void AddBankAccountTest()
        {
            try
            {
                Bank newBank = new Bank("Additional Bank");
                BankAccount newCheckingAccount = new BankAccount(new Customer("Larry"), AccountType.Checking, 1500.0M);
                newBank.AddBankAccount(newCheckingAccount);
            }
            catch (Exception)
            {

                throw;
            }
            Assert.Fail(Constants.NoExceptionMsg);

        }

        [TestMethod()]
        public void RemoveBankAccountTest()
        {


            try
            {
                Bank newBank = new Bank("New Bank");
                BankAccount newCheckingAccount = new BankAccount(new Customer("Harry"), AccountType.Checking, 500.0M);
                string newCheckingAccountNumber = newCheckingAccount.AccountNumber;
                newBank.AddBankAccount(newCheckingAccount);
                newBank.RemoveBankAccount(newCheckingAccountNumber);
                string trialBankAccountNumber = newCheckingAccountNumber + "123";
                newBank.RemoveBankAccount(trialBankAccountNumber);

            }
            catch (Exception ex)
            {
                //  "Bank Account Not Found";
                if (StringAssert.Equals(ex.Message, Constants.BankAccountNotPresentMsg))
                    return;
            }
            catch (Exception e)
            {

                return;
            }
            
            Assert.Fail(Constants.NoExceptionMsg);

        }


    }
}