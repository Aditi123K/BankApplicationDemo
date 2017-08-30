using BankApplicationDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoBank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Bank newBank = new Bank("Additional Bank");
            //BankAccount newCheckingAccount = new BankAccount(new Customer("Larry"), AccountType.Checking, 1500.0M);
            //newBank.AddBankAccount(newCheckingAccount);

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
                // if (StringAssert.Equals(e.Message, Constants.BankAccountNotPresentMsg))
                if (ex is ArgumentNullException)
                    throw new ArgumentNullException (Constants.BankAccountNotPresentMsg,ex.InnerException);

                throw ex;
            }
        }
    }
}
