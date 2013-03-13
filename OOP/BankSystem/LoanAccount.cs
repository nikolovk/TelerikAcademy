using System;

namespace BankSystem
{
    class LoanAccount : Account, IDepositable
    {
        //Constructor
        public LoanAccount(CustomerType type, decimal balance, decimal interestRate)
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
                if (this.Existance > 2)
                {
                    BearInterest(period);
                }
                else
                {
                    if (period + this.Existance <= 2)
                    {
                        BearInterest(period, 0);
                    }
                    else
                    {
                        BearInterest(period - this.Existance, 0);
                        BearInterest(period + this.Existance - 2);
                    }
                }
            }
            if (this.Type == CustomerType.indidual)
            {
                if (this.Existance > 3)
                {
                    BearInterest(period);
                }
                else
                {
                    if (period + this.Existance <= 3)
                    {
                        BearInterest(period, 0);
                    }
                    else
                    {
                        BearInterest(period - this.Existance, 0);
                        BearInterest(period + this.Existance - 3);
                    }
                }
            }
        }
    }
}

