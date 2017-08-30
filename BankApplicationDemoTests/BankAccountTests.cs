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
                if (StringAssert.Equals(ex.Message, "Bank account creation failed."))
                    return;

            }
            Assert.Fail("No exception while creating bank account.");
        }
        [TestMethod()]
        public void WithdrawTest()
        {

            try
            {

            }
            catch (ArgumentOutOfRangeException ex)
            {
                if (StringAssert.Equals(ex.Message, "Individual Investment accounts can withdraw up to $1,000 at a time."))
                    return;
                else if (StringAssert.Equals(ex.Message, "It is not permissible to overdraft an account."))
                    return;
            }
            catch (Exception ex)
            {

                if (StringAssert.Equals(ex.Message, "Bank account creation failed."))
                    return;
            }

            Assert.Fail();
        }
        [TestMethod()]
        public void DepositTest()
        {

            try
            {

            }
            catch (Exception ex)
            {

                if (StringAssert.Equals(ex.Message, "Bank account creation failed."))
                    return;
            }



            Assert.Fail();
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
            Assert.Fail();
        }

       
    }
}