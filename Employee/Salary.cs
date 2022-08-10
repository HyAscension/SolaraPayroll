using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Salary : Employee
    {
        private decimal amount;

        public decimal Amount
        {
            get => amount; set => amount = value;
        }

        public Salary(string s) : base(s)
        {

        }

        public Salary(string s, string f, string l) : base(s, f, l)
        {

        }

        public Salary(string s, string f, string l, decimal a) : base(s, f, l)
        {
            if (a > 215000)
            {
                base.OnHighWageInput(EventArgs.Empty);
                Amount = a;
            }
            Amount = a;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override decimal Bonus() => 0;

        public override decimal CalculatePay() => Math.Round(Amount / 26, 2);
    }
}
