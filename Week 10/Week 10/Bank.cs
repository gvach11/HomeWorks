using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    public class Bank : IFinanceOperations
    {

        public bool CheckUserHistory()
        {
            Random r = new Random();
            if (r.Next(100) >= 50) { return true; }
            else { return false; }
        }
        public void CalculateLoanPercent(int month)
        {
        }

        public void CalculateLoanPercent(int totalAmount, int month)
        {
            var result = totalAmount * (0.05 * month);
            Console.WriteLine($"The total percent to pay is {result}");


        }

    }
}
