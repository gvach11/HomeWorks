using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    public class Microfinance : IFinanceOperations
    {

        public bool CheckUserHistory()
        {
            return true;
        }
        public void CalculateLoanPercent(int month)
        {
        }

        public void CalculateLoanPercent(int totalAmount, int month)
        {
            var result = totalAmount + (totalAmount * (0.1 * month)) + (4*month);
            Console.WriteLine($"The total amount to pay is {result}");


        }

    }
}
