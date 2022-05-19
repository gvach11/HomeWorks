using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    public interface IFinanceOperations
    {
        void CalculateLoanPercent(int month);
        bool CheckUserHistory();


    }
}
