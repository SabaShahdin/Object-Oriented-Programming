using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1task
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
            Task10();

            Console.ReadKey();
        }
        static void Task1()
        {
            Console.Write("hello World !");
            Console.Write("Hello World!");
        }
        static void Task2()
        {
            Console.WriteLine("hello World !");
            Console.WriteLine("Hello World!");
        }
        static void Task3()
        {
            int varriable = 10;
            Console.WriteLine(" Entre the value ");
            Console.WriteLine("Value ");
            Console.Write(varriable);
        }
        static void Task4()
        {
            String varriable = "My name is Saba Shahdin";
            Console.WriteLine(" Entre the string value ");
            Console.WriteLine("String ");
            Console.Write(varriable);
        }
        static void Task5()
        {
            Char varriable = 'A';
            Console.WriteLine(" Entre the character ");
            Console.WriteLine("Character ");
            Console.Write(varriable);
        }
        static void Task6()
        {
            float varriable = 2.7F;
            Console.WriteLine(" Entre the flaot value ");
            Console.WriteLine("Float ");
            Console.Write(varriable);

        }
        static void Task7()
        {
            String str;
            Console.WriteLine(" Entre the string ");
            str = Console.ReadLine();
            Console.WriteLine("You have inputted ");
            Console.Write(str);
        }
        static void Task8()
        {
            String str;
            Console.WriteLine(" Entre the value ");
            str = Console.ReadLine();
            Console.WriteLine("You have inputted ");
            int num = int.Parse(str);
            Console.WriteLine("The number is ");
            Console.Write(num);
        }
        static void Task9()
        {
            String str;
            str = Console.ReadLine();
            Console.WriteLine("You have inputted ");
            float num = float.Parse(str);
            Console.WriteLine("The number is ");
            Console.Write(num);
        }
        static void Task10()
        {
            float length;
            String str;
            float area;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Entre the length of side ");
            str = Console.ReadLine();
            length = float.Parse(str);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(length);
            area = length * length;
            Console.Write("The Area is  ");
            Console.Write(area);
        }


    }
}
