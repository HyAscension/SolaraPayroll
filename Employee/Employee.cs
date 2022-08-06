using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public abstract class Employee : IDeduction
    {
        private string sin;
        private string first;
        private string last;
        private DateTime hired;
        private DateTime birth;
        private string email;
        private string phone;
        private Address address;
        private bool status;

        public const string companyName = "Solara";

        public string Sin
        {
            get => sin;
            set => sin = value.Length == 9 ? value : "";
        }
        public string FirstName
        {
            get => first;
            set => first = value != "" && !int.TryParse(value, out int notName) ? value : "";
        }
        public string LastName
        {
            get => last;
            set => last = value != "" && !int.TryParse(value, out int notName) ? value : "";
        }
        public DateTime HireDate
        {
            get => hired;
            set => hired = value;
        }
        public DateTime BirthDate
        {
            get => birth;
            set => birth = value;
        }
        public string Email
        {
            get => email; set => email = value;
        }
        public string Phone
        {
            get => phone;
            set => phone = value.Length == 10 ? value : "";
        }
        public Address Address
        {
            get => address; set => address = value;
        }
        public bool Active
        {
            get => status; set => status = value;
        }

        public Employee(string s)
        {
            Sin = s;
        }
        
        public Employee(string s, string f, string l)
        {
            Sin = s;
            FirstName = f;
            LastName = l;
        }

        public override string ToString() => $"FullName: {FirstName} {LastName}. Phone: {Phone}. Birth date: {BirthDate.ToShortDateString()}";

        public virtual decimal Bonus() => 0;

        public abstract decimal CalculatePay();


        public decimal IncomeTax(decimal income)
        {
            if (income > 49000 && income <= 98000)
            {
                return income * 0.2m;
            }
            else if (income > 98000 && income <= 151000)
            {
                return income * 0.26m;
            }
            else if (income > 151000 && income <= 215000)
            {
                return income * 0.29m;
            }
            else if (income > 215000)
            {
                return income * 0.3m;
            }
            else
            {
                return income * 0.15m;
            }
        }

        public decimal Pension() => 0;

        public decimal UnionDues() => 0;

        public decimal Insurance() => 0;
    }
}
