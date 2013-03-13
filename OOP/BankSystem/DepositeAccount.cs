using System;

namespace BankSystem
{
    class DepositeAccount:Account,IDepositable,IWithdraw
    {
        //Constructor
        public DepositeAccount(CustomerType type, decimal balance, decimal interestRate)
            : base(type, balance, interestRate)
        {
        }

        //Methods
        public void Deposite(decimal sum)
        {
            if (sum > 0)
            {
                this.Balance += sum;
            }
            else
            {
                throw new IndexOutOfRangeException("sum");
            }
        }
        public void Withdraw(decimal sum)
        {
            if (sum > 0)
            {
                this.Balance -= sum;
            }
            else
            {
                throw new IndexOutOfRangeException("sum");
            }
        }
        public override void ProcessBearIneterest(uint period)
        {
            if (this.Balance > -1000)
            {
                BearInterest(period, 0);
            }
            else
            {
                BearInterest(period);
            }
        }
    }
}
