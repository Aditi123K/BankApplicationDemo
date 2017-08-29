using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationDemo
{
    public interface ITransactions
    {

        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        decimal CheckBalance();
        void TransferMoney(decimal amount, BankAccount ac);
        bool isOverDraftCase(decimal amount);
       
    }
}
