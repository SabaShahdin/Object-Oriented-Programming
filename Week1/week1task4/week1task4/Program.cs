using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOrders;
            int minOrderPrice;
            string path = "C:\\Users\\hp\\OneDrive\\Documents\\semester2\\oop(lab)\\week1\\customers.txt";
            Console.Write("Number of orders  ");
            numberOfOrders = int.Parse(Console.ReadLine());
            Console.Write("Minimum ordrer price ");
            minOrderPrice = int.Parse(Console.ReadLine());
            readFile(numberOfOrders, minOrderPrice, path);
            Console.ReadKey();
        }
        static void readFile(int numberOfOrders, int minOrderPrice, string path)
        { 
            string name;
            int order1;
            string orders;
            int count = 0;
            string price;
            if (File.Exists(path))
            {
                StreamReader readData = new StreamReader(path);
                string record;
                while ((record = readData.ReadLine()) != null)
                {
                     name  = parseData(record,1);
                     orders = parseData(record, 2);
                    order1 = int.Parse(orders); 
                    if (order1 >= numberOfOrders)
                    {
                        price = parseData(record, 3);
                        for (int idx = 1; idx <= order1; idx++)
                        {
                           int no_of_price = parseRecord(price, idx);
                            if (no_of_price >= minOrderPrice)
                            {
                                count = count + 1;
                            }
                        }
                        if (count >= order1)
                        {
                            Console.WriteLine("Name to get pizza is {0} " , name);
                        }
                        else
                        {
                            Console.WriteLine("no one is eligible ");
                        }
                    }
                }
            }
        }
        static string parseData(string record  , int field)
        {
            string item1 =  "";
            int comma= 1;
            for(int x = 0; x < record.Length; x++)
            {
                if (record[x] == ' ')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item1 = item1 + record[x];
                }
            }
            return item1;

        }
        static int parseRecord(string price, int field)
        {
            string item = "";
            int comma = 1;
            int price1 ;
            for (int x = 0; x < price.Length; x++)
            {
                if (price[x] == ',')
                {
                    comma++;
                }
                else if(comma == field)
                {
                    item = item + price[x];
                }
            }
            price1 = int.Parse(item);
            return price1 ;
        }
    }
}
