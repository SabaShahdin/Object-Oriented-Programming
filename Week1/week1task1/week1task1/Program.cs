using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task11();
            Task12();
            Task13();
            Task14();
            Task15();
            Task16();
            Console.ReadKey();
        }
        static void Task11()
        {
            float marks;
            string str;
            Console.Write("Entre your marks  ");
            str = Console.ReadLine();
            marks = float.Parse(str);
            if (marks > 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have passed !");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Failed ");
            }
        }
        static void Task12()
        {
            for (int x = 0; x < 5; x++)
            {
                Console.WriteLine(" Welcome Jack ");
            }
        }
        static void Task13()
        {
            int num;
            int sum = 0;

            Console.Write(" Entre the number ");
            num = int.Parse(Console.ReadLine());
            while (num != -1)
            {
                sum = sum + num;
                Console.Write(" Entre the number ");
                num = int.Parse(Console.ReadLine());

            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(" Sum is  ");
            Console.WriteLine(sum);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Task14()
        {
            int num;
            int sum = 0;
            do
            {
                Console.Write(" Entre the number ");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            while (num != -1);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(" Sum is  {0 } ", sum);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Task15()
        {
            int[] number = new int[3];
            int largest = 0;
            for (int idx = 0; idx < 3; idx++)
            {
                Console.Write("Entre the values of array ");
                number[idx] = int.Parse(Console.ReadLine());
            }
            for (int idx = 0; idx < 3; idx++)
            {
                if (number[idx] > largest)
                {
                    largest = number[idx];
                }
            }
            Console.WriteLine("The largest number is {0} ", largest);
        }
        static void Task16()
        {
            float totalPrice;
            float totalPriceOfToys;
            float brotherTook;
            float counter = 0;
            float counter2 = 0;
            float priceMoneyOfOneYear;
            float priceMoneyOfAgeYears;
            float sum = 0;
            float age;
            float priceOfWashingMachine;
            float priceOfToy;
            float priceAfterMachine;
            Console.Write("Entre your age  ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Entre price of washing machine ");
            priceOfWashingMachine = int.Parse(Console.ReadLine());
            Console.Write("Entre price of TOY ");
            priceOfToy = int.Parse(Console.ReadLine());
            for (int year = 1; year <= age; year = year + 1)
            {
                if (year % 2 != 0)
                {
                    counter = counter + 1;
                }
            }
            for (int years = 2; years <= age; years = years + 2)
            {
                if (years % 2 == 0)
                {
                    counter2 = counter2 + 1;
                    priceMoneyOfOneYear = 10;
                    priceMoneyOfAgeYears = priceMoneyOfOneYear * counter2;
                    sum = sum + priceMoneyOfAgeYears;

                }

            }
            totalPriceOfToys = priceOfToy * counter;
            brotherTook = sum - counter2;
            totalPrice = totalPriceOfToys + brotherTook;
            if (totalPrice >= priceOfWashingMachine)
            {
                priceAfterMachine = totalPrice - priceOfWashingMachine;

                Console.WriteLine("Yes!");

            }
            else if (totalPrice < priceOfWashingMachine)
            {
                priceAfterMachine = priceOfWashingMachine - totalPrice;
                Console.WriteLine(" No! ");
            }

        }
    }
}
