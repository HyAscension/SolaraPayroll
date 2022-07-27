using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IDeduction
    {
        decimal IncomeTax(decimal income);
        decimal Pension();
        decimal UnionDues();
        decimal Insurance();
    }
}
