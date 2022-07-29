using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace PayrollApp
{
    public class CalculatePayroll<T> 
    {
        private List<Employee> eList = new List<Employee>();

        public DateTime PayDate { get; set; }

        public string TotalAll
        {
            get
            {
                int totalEmp = 0;
                decimal totalPay = 0;
                decimal totalBonus = 0;
                decimal totalDeductions = 0;
                foreach (Employee emps in eList)
                {
                    totalEmp++;
                    totalPay += emps.CalculatePay();
                    totalBonus += emps.Bonus();
                    totalDeductions += emps.IncomeTax(emps.CalculatePay());
                }

                return $"Employee Count: {totalEmp} | Net Pay: ${Math.Round(totalPay, 2)} | Net Bonus: ${Math.Round(totalBonus, 2)} | Net Deductions: ${Math.Round(totalDeductions, 2)}";
            }
        }

        public CalculatePayroll(DateTime current, List<Employee> emps)
        {
            PayDate = current;
            eList = emps;
        }

        public List<string> ProcessPayRoll()
        {
            List<string> fullInfo = new List<string>();
            foreach (Employee emps in eList)
            {
                fullInfo.Add($"{emps.Sin} {emps.FirstName} {emps.LastName} - Net: ${Math.Round(emps.CalculatePay(), 2)} - Bonus: ${Math.Round(emps.Bonus(), 2)} - Deductions: ${Math.Round(emps.IncomeTax(emps.CalculatePay()), 2)}");
            }
            return fullInfo;
        }
    }
}
