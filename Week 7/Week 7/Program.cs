using System;
using System.Linq;

namespace Week_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
        var arr = new int[] {3,5,67,8,3,34,15 };
            for (int i = 1; i < arr.Length; i++)
            {

                int temp = arr[i];
                int J = i - 1;
                while (J >= 0 && arr[J]>temp)
                {
                    arr[J + 1] = arr[J];
                    J =J-1;
                    
                    arr[J + 1] = temp;
                }
                
                Console.WriteLine(arr[i]);
                

            }


        }
    }
}
