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


        /*This test tests adding any account to a bank.*/
        [TestMethod()]
        public void AddBankAccountTest()
        {
            Bank newBank = new Bank("Additional Bank");
            BankAccount newCheckingAccount = new BankAccount(new Customer("Larry"), AccountType.Checking, 1500.0M);
            newBank.AddBankAccount(newCheckingAccount);
        }

        /*This test tests removing of bankaccount from bank.*/
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveBankAccountTest()
        {



            Bank newBank = new Bank("New Bank");
            BankAccount newCheckingAccount = new BankAccount(new Customer("Harry"), AccountType.Checking, 500.0M);
            string newCheckingAccountNumber = newCheckingAccount.AccountNumber;
            newBank.AddBankAccount(newCheckingAccount);
            newBank.RemoveBankAccount(newCheckingAccountNumber);
            string trialBankAccountNumber = newCheckingAccountNumber + "123";
            newBank.RemoveBankAccount(trialBankAccountNumber);



        }


    }
}