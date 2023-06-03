using Self_Assesment1.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Self_Assesment1.UI;
using System.IO;

namespace Self_Assesment1.DL
{
    public class OrderCurd
    {
        public static List<string> order = new List<string>();
        public static bool AddOrder(string name)
        {
            bool flag = false;
            foreach (Menu m1 in MenuCurd.menu)
            {
                if (name == m1.name)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public static void FullfillOrder(string name)
        {
            if (order.Contains(name))
            {
                Console.WriteLine("Your order " + name + " is fullfilled");
                OrderCurd.order.Remove(name);
            }
            else
            {
                Console.WriteLine("No order available ");
            }
        }
        public static void viewOrder()
        {
            if (order != null)
            {
                Console.WriteLine("the  orders are ");
                foreach (string m in order)
                {
                    Console.WriteLine(m);
                }
            }
            else
            {
                Console.WriteLine("No more order left ");
            }
        }
        public static void totalPayable()
        {
            int sum = 0;
            foreach (Menu m in MenuCurd.menu)
            {
                foreach (string o1 in order)
                {
                    if (o1 == m.name)
                    {
                        sum = sum + m.price;
                    }
                }
            }
            Console.WriteLine("The total payable amount is " + sum);
        }
        public static void writeFile(string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            foreach (string m in order)
            {
                file.WriteLine(m);
            }
            file.Flush();
            file.Close();
        }
        public static bool readFromFile(string path)
        {
            StreamReader file = new StreamReader(path);
            string record;
            bool flag = false;
            if (File.Exists(path))
            {
                while ((record = file.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name  = splittedRecord[0];
                  
                }
                file.Close();
                flag = true;
            }
            else
            {
                flag =  false;
            }
            return flag;
        }
    }
}
