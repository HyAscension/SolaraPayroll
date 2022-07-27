using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SoftwareDev : Salary
    {
        private decimal bi_weekly;

        public decimal Bi_Weekly
        {
            get => bi_weekly;
            set => bi_weekly = decimal.TryParse(value.ToString(), out decimal isWage) ? value : 0;
        }

        public SoftwareDev(string s, decimal b) : base(s)
        {
            bi_weekly = b;
        }

        public override decimal Bonus() => Math.Round(Bi_Weekly * 0.05m, 2);

        public override decimal CalculatePay() => Math.Round(Bi_Weekly, 2);
    }
}
