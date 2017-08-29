using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationDemo
{
    public class Bank
    {
        string _bankName;
        public List<BankAccount> BankAccounts { get; set; }


        public Bank(string bankName)
        {
            _bankName = bankName;
        }
        public void AddBankAccount(BankAccount bankAccountObj)
        {
            BankAccounts.Add(bankAccountObj);
        }
        public void RemoveBankAccount(string accountNumber)
        {

            var bankAccountToBeRemoved =(BankAccount) from BankAccount in BankAccounts where BankAccount.AccountNumber.Equals(accountNumber)
                              select BankAccount;
            BankAccounts.Remove(bankAccountToBeRemoved);
        }
    }
}
