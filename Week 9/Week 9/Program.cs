using System;
using System.Collections.Generic;
using System.Linq;

namespace Week_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter the number of task from 1 to 3, or 0 to exit");
                var taskNumber = Console.ReadLine();
                if (taskNumber == "1" || taskNumber == "2" || taskNumber == "3")
                {
                    taskChooser(taskNumber);
                }
                if (taskNumber == "0") { break; }
            }
        }

        static void taskChooser(string input)
        {
            //Task 1
            if (input == "1")
            {
                Employee employee = new Employee();
                Employee.SalaryChecker(employee);
                if (employee.totalPay != 0)
                {
                    Console.WriteLine("Is the company local? Y/N");
                    var localCheckInput = Console.ReadLine();
                    Console.WriteLine($"Total Tax is {Company.TaxChecker(Company.LocalChecker(localCheckInput), employee.totalPay)}");
                }
            }
            //Task 2
            if (input == "2")
            {
                Student student = new Student();
                Teacher teacher = new Teacher();
                string subjectContainer = Student.RandomSubject();
                Console.WriteLine($"Random subject is {subjectContainer}");
                Teacher.getResult<string>(subjectContainer);
                Console.WriteLine("Please enter the starting year");
                student.startYear = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Student.YearsToGrad(student.startYear));
                
                

            }
        }
    }

    public class Company
        {
            public bool isLocal { get; set; }

            public static bool LocalChecker(string input)
            {
                Company company = new Company();
                if (input == "Y") { company.isLocal = true; }
                if (input == "N") { company.isLocal = false; }
                return company.isLocal;



            }
            public static double TaxChecker(bool islocal, double salary)
            {
                if (islocal) { return salary * 0.18; }
                else { return salary * 0.05; }
            }

        }

    public class Employee
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public int age { get; set; }
            public string position { get; set; }
            public int[] hoursWorked { get; set; }
            public double totalPay { get; set; }
            public static void SalaryChecker(Employee employee)
            {

                Console.WriteLine("Enter the employee's position - [1] Manager, [2] Developer, [3] Tester, or other");
                int pisitionInput = Convert.ToInt32(Console.ReadLine());
                if (pisitionInput == 1) { employee.position = "Manager"; }
                else if (pisitionInput == 2) { employee.position = "Developer"; }
                else if (pisitionInput == 3) { employee.position = "Tester"; }
                else { employee.position = "Other"; }
                employee.hoursWorked = new int[7];
                double totalPay = 0;
                bool dayInputCheck = true;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Please enter hours worked on day {i + 1}");
                    var dayInput = Console.ReadLine();
                    dayInputCheck = int.TryParse(dayInput, out employee.hoursWorked[i]);
                    if (dayInputCheck is false)
                    {
                        Console.WriteLine("Please enter a whole number");
                        break;
                    }
                    //Weekdays for Manager
                    if (employee.position == "Manager")
                    {
                        if (employee.hoursWorked[i] <= 8) { totalPay += employee.hoursWorked[i] * 40; }
                        if (employee.hoursWorked[i] > 8) { totalPay += 320 + ((employee.hoursWorked[i] - 8) * 45); }
                    }
                    //Weekdays for Developer
                    if (employee.position == "Developer")
                    {
                        if (employee.hoursWorked[i] <= 8) { totalPay += employee.hoursWorked[i] * 30; }
                        if (employee.hoursWorked[i] > 8) { totalPay += 240 + ((employee.hoursWorked[i] - 8) * 35); }
                    }
                    //Weekdays for Tester
                    if (employee.position == "Tester")
                    {
                        if (employee.hoursWorked[i] <= 8) { totalPay += employee.hoursWorked[i] * 20; }
                        if (employee.hoursWorked[i] > 8) { totalPay += 160 + ((employee.hoursWorked[i] - 8) * 25); }
                    }
                    //Weekdays for Other
                    if (employee.position == "Other")
                    {
                        if (employee.hoursWorked[i] <= 8) { totalPay += employee.hoursWorked[i] * 10; }
                        if (employee.hoursWorked[i] > 8) { totalPay += 80 + ((employee.hoursWorked[i] - 8) * 15); }
                    }

                }
                if (dayInputCheck is true)
                {
                    for (int i = 5; i < 7; i++)
                    {
                        Console.WriteLine($"Please enter hours worked on day {i + 1}");
                        var dayInput = Console.ReadLine();
                        dayInputCheck = int.TryParse(dayInput, out employee.hoursWorked[i]);
                        if (dayInputCheck is false)
                        {
                            Console.WriteLine("Please enter a whole number");
                            break;
                        }
                        //Weekend for Manager
                        if (employee.position == "Manager")
                        {
                            if (employee.hoursWorked[i] <= 8) { totalPay += employee.hoursWorked[i] * 40; }
                            if (employee.hoursWorked[i] > 8) { totalPay += 640 + ((employee.hoursWorked[i] - 8) * 90); }

                        }
                        //Weekend for Developer
                        if (employee.position == "Developer")
                        {
                            if (employee.hoursWorked[i] <= 8) { totalPay += employee.hoursWorked[i] * 60; }
                            if (employee.hoursWorked[i] > 8) { totalPay += 480 + ((employee.hoursWorked[i] - 8) * 70); }
                        }
                        //Weekend for Tester
                        if (employee.position == "Tester")
                        {
                            if (employee.hoursWorked[i] <= 8) { totalPay += employee.hoursWorked[i] * 40; }
                            if (employee.hoursWorked[i] > 8) { totalPay += 320 + ((employee.hoursWorked[i] - 8) * 50); }
                        }
                        //Weekend for Other
                        if (employee.position == "Other")
                        {
                            if (employee.hoursWorked[i] <= 8) { totalPay += employee.hoursWorked[i] * 20; }
                            if (employee.hoursWorked[i] > 8) { totalPay += 160 + ((employee.hoursWorked[i] - 8) * 30); }
                        }

                    }
                    if (dayInputCheck is true)
                    {
                        if (employee.hoursWorked.Sum() > 50) { totalPay += (totalPay * 0.2d); }
                        Console.WriteLine($"Total Pay is {totalPay}");
                        employee.totalPay = totalPay;
                    }
                }
            }
        }

    public class Student
    {
        public string name { get; set; }
        public int age { get; set; }
        public int startYear { get; set; }

        public static string RandomSubject()
        {
            var subjectList = new string[5] {"Math", "Chemistry", "English", "Geography", "Physics" };
            Random randnum = new Random();
            int randomSubjectIndex = randnum.Next(subjectList.Length);
            return subjectList[randomSubjectIndex];
        }

        public static string YearsToGrad(int year)
        {
            Student student = new Student();
            if (year < 2018) { return "Already Graduated";}
            else if (year > 2022) { return "Start date is in in the future"; }
            else { return $"Will graduate in {Convert.ToString(year+4-2022)} years"; }
        }
    }

    public class Teacher
    {
        public string name { get; set; }
        public bool isCertified { get; set; }

        public static void getResult<T>( string studentData)
        {
            if (studentData == "Math")
            {
                Random r = new Random();
                var x = r.Next(1, 100);
                var y = r.Next(1, 100);
                Console.WriteLine($"{x} + {y} = {x + y}");
            }
            else if (studentData == "Chemistry")
            {
                var formulaList = new string[5] { "Na2O", "H2SO4", "NaCl", "C6H12O6", "H2O" };
                Random randnum = new Random();
                int randomFormulaIndex = randnum.Next(formulaList.Length);
                Console.WriteLine($"Random chemical is: {formulaList[randomFormulaIndex]}");
            }

            else if (studentData == "English")
            {
                Console.WriteLine("Here is some random text in English");
            }

            else { Console.WriteLine($"The teacher is not competent in {studentData}"); }
        }
    }
    


}
