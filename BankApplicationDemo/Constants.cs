using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationDemo
{
    public sealed class Constants
    {

        private Constants() { }

        public const string BankCustomerCompulsoryMsg = "Bank account must have a owner.";
        public const string BankCreationFailedMsg = "Bank account creation failed.";
        public const string BankAccountNotPresentMsg = "Bank account not found";

        public const string WithdrawLimitRuleMsg = "Individual Investment accounts can withdraw up to $1,000 at a time.";
        public const string WithdrawFailed = "Withdraw transaction failed!";

        public const string OverDraftRuleMsg = "It is not permissible to overdraft an account.";

        public const string DepositMinAmountMsg = "Minimum amount deposited should be > 0";
        public const string DepositFailedMsg = "Deposit transaction failed!";


        public const string TransferFailed = "TransferMoney transaction failed!";

        public const string NoExceptionMsg = "No Exception was thrown.";
    }
}
