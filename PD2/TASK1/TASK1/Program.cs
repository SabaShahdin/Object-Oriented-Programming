using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TASK1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Credentials> users = new List<Credentials>();
            string path = "C:\\Users\\hp\\OneDrive\\Documents\\semester2\\oop(lab)\\PD\\PD2\\Users.txt";
             readFile(path, users);
            char choice;
            do
            {              
                Console.Clear();
                choice = menu();
                if (choice == '1')
                {
                    users.Add(addUser());
                    writeFile(path, users);

                }
                if(choice == '2')
                {
                    viewUser (users);
                }
                if (choice == '3')
                {
                    Console.Clear();
                    Console.WriteLine("Entre username  ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Entre password  ");
                    string passes = Console.ReadLine();
                    bool flag = signIn(users, name, passes);
                    if (flag == true)
                    {
                        Console.WriteLine("Valid User");

                    }
                    else
                    {
                        Console.WriteLine("User not found ");
                    }
                    Console.ReadKey();
                }
            }
            while (choice != '4');

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
    }
        static char menu()
        {

            Console.Clear();
            char option;
            Console.WriteLine("Press 1 to sign up ");
            Console.WriteLine("Press 2 to vieww users");
            Console.WriteLine("Press 3 to sign in");
            Console.WriteLine("Press 4 to exit");
            Console.WriteLine("Entre your option ");
            option = char.Parse(Console.ReadLine());
            return option;
        }
        static Credentials addUser()
        {
            Console.Clear();
            Credentials c1 = new Credentials();
            Console.WriteLine("Entre username  ");
            c1.userName = Console.ReadLine();
            Console.WriteLine("Entre password  ");
            c1.password = Console.ReadLine();
            return c1;
        }
        static bool signIn(List<Credentials> s1 , string name, string passes)
        {
            bool flag = false;
            for (int x = 0; x < s1.Count; x++)
            {
                if (s1[x].userName == name && s1[x].password == passes)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
         static void viewUser (List <Credentials> s1)
        {
            Console.Clear();
            for (int x = 0; x < s1.Count; x ++)
            {
                Console.WriteLine("userName  {0}   password {1} ", s1[x].userName, s1[x].password);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static void writeFile(string path, List<Credentials> s1 )
        {

            StreamWriter file = new StreamWriter(path, false);
            for (int x = 0; x < s1.Count ; x++)
            {
                file.WriteLine(s1[x].userName + "," + s1[x].password);
            }
            file.Flush();
            file.Close();
        }
        static void readFile(string path, List<Credentials> s)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Credentials s1 = new Credentials();
                    s1.userName = parseData(record, 1);
                    s1.password = parseData(record, 2);
                    s.Add(s1);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }


        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
    }
}
