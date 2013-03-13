using System;

namespace BankSystem
{
    class MortageAccount : Account, IDepositable
    {
        //Constructor
        public MortageAccount(CustomerType type, decimal balance, decimal interestRate)
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
        public override void ProcessBearIneterest(uint period)
        {
            if (this.Type == CustomerType.company)
            {
                if (this.Existance > 12)
                {
                    BearInterest(period);
                }
                else
                {
                    if (period + this.Existance <= 12)
                    {
                        BearInterest(period, 0);
                    }
                    else
                    {
                        BearInterest(period - this.Existance, 0.5m);
                        BearInterest(period + this.Existance - 12);
                    }
                }
            }
            if (this.Type == CustomerType.indidual)
            {
                if (this.Existance > 6)
                {
                    BearInterest(period);
                }
                else
                {
                    if (period + this.Existance <= 6)
                    {
                        BearInterest(period, 0);
                    }
                    else
                    {
                        BearInterest(period - this.Existance, 0);
                        BearInterest(period + this.Existance - 6);
                    }
                }
            }
        }
    }
}


