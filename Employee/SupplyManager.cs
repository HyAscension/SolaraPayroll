using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SupplyManager : Employee
    {
        private decimal salary;

        public decimal Salary
        {
            get => salary;
            set => salary = decimal.TryParse(value.ToString(), out decimal isWage) ? value : 0;
        }

        public SupplyManager(string s, decimal sal) : base(s)
        {
            salary = sal;
        }

        public override decimal Bonus() => Math.Round(Salary / 26 * 0.05m, 2);

        public override decimal CalculatePay() => Math.Round(Salary / 26, 2);
    }
}
