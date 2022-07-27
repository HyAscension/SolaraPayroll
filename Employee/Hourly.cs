using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Hourly : Employee
    {
        private decimal rate;
        private decimal hours;

        public decimal Rate
        {
            get => rate; set => rate = value;
        }
        public decimal Hours
        {
            get => hours; set => hours = value;
        }

        public Hourly(string s) : base(s)
        {

        }

        public Hourly(string s, string f, string l) : base(s, f, l)
        {

        }

        public Hourly(string s, string f, string l, decimal r, decimal h) : base(s, f, l)
        {
            Rate = r;
            Hours = h;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override decimal Bonus() => 0;

        public override decimal CalculatePay() => Math.Round(Hours * Rate * 2, 2);
    }
}
