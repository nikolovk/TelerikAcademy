using System;


namespace BankSystem
{
    public abstract class Account
    {
        //Fields
        private CustomerType type = CustomerType.company;
        private decimal balance;
        private decimal interestRate;
        private uint existance;

        //Constructors
        public Account(CustomerType type, decimal balance, decimal interestRate)
        {
            this.Type = type;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.existance = 0;
        }

        //Properties
        public decimal InterestRate
        {
            get { return this.interestRate; }
            protected set { this.interestRate = value; }
        }
        public decimal Balance
        {
            get { return this.balance; }
            protected set { this.balance = value; }
        }
        protected uint Existance
        {
            get { return this.existance; }
            set { this.existance = value; }
        }
        protected CustomerType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }


        //Methods
        protected decimal CalculateInterestRate(uint period)
        {
            return period * this.InterestRate;
        }
        protected void BearInterest(uint period, decimal constrains=1)
        {
            // Add period to existance
            this.Existance += period;
            // Add interest to balance
            this.Balance -= CalculateInterestRate(period) * constrains;
        }
        public abstract void ProcessBearIneterest(uint period);
    }
}
