using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1task2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* int n1;
             int n2;
             Console.Write("Entre the first number ....");
             n1 = int.Parse(Console.ReadLine());
             Console.Write("Entre the second number ....");
             n2 = int.Parse(Console.ReadLine());
             int answer = result(n1, n2);
             Console.Write("Sum of number is {0} ", answer);*/

            task3();
            task2();
            Console.ReadKey();
        }
        static int result(int n1, int n2)
        {
            int answer;
            answer = n1 + n2;
            return answer;
        }
        static void task2()
        {
            String path = "C:\\Users\\hp\\OneDrive\\Documents\\semester2\\oop(lab)\\week1\\my file.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    Console.Write(record);
                }
                file.Close();
            }
            else
            {
                Console.Write("File donot exist");
            }
        }
        static void task3()
        {

            String path = "C:\\Users\\hp\\OneDrive\\Documents\\semester2\\oop(lab)\\week1\\my file.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine("Hello ");
            file.Flush();
            file.Close();
        }
    }
}
