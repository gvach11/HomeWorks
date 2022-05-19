using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    public class TaskChooser
    {
        string input { get; set; }

        public static void Chooser(string input) 
        {
            if (input == "1")
            {
                Console.WriteLine("Please enter the file extension");
                var extension = Console.ReadLine();
                Console.WriteLine("Please enter max size");
                var maxSize = Convert.ToInt32(Console.ReadLine());
                FileWorkerExecute.Read(extension, maxSize);
                FileWorkerExecute.Write(extension, maxSize);
                FileWorkerExecute.Edit(extension, maxSize);
                FileWorkerExecute.Delete(extension, maxSize);
            }

            if(input == "2")
            {
                Console.WriteLine("Please select [1] for Bank or [2] for Microfinance");
                var financechoice = Console.ReadLine();
                if(financechoice == "1") 
                {
                    Bank bank = new Bank();
                    bool historyCheck = bank.CheckUserHistory();
                    Console.WriteLine($"History check returned {historyCheck}");
                    if (historyCheck)
                    {
                        Console.WriteLine("Please enter the loan amount");
                        var amount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please enter the number of months");
                        var months = Convert.ToInt32(Console.ReadLine());
                        bank.CalculateLoanPercent(amount, months);

                    }
                    
                }
                else if (financechoice == "2")
                {
                    Microfinance microfinance = new Microfinance();
                    Console.WriteLine($"History check returned {microfinance.CheckUserHistory()}");
                    Console.WriteLine("Please enter the loan amount");
                    var amount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the number of months");
                    var months = Convert.ToInt32(Console.ReadLine());
                    microfinance.CalculateLoanPercent(amount, months);
                }
                

                
                
            }
        }
    }
}
