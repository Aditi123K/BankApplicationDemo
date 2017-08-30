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
            try
            {
                _bankName = bankName;
                BankAccounts = new List<BankAccount>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public void AddBankAccount(BankAccount bankAccountObj)
        {
            try
            {
                BankAccounts.Add(bankAccountObj);
            }
            catch (Exception ex)
            {

                throw new Exception(Constants.AddBankAccountFailedMsg);
            }
           
        }
        public void RemoveBankAccount(string accountNumber)
        {

            
                bool isRemoved = false;
                foreach (BankAccount bankAccountToBeRemoved in this.BankAccounts)
                {
                    if (String.Equals(bankAccountToBeRemoved.AccountNumber,accountNumber))
                    {
                        this.BankAccounts.Remove(bankAccountToBeRemoved);
                        isRemoved = true;
                        break;
                    }
                }
                if (!isRemoved)
                    throw new ArgumentNullException(Constants.BankAccountNotPresentMsg);
            
            
        }
    }
}
