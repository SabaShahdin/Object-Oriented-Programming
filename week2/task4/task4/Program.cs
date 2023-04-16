using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Credentials[] s1 = new Credentials[10];
            int count = 0;         
            string path = "C:\\Users\\hp\\OneDrive\\Documents\\semester2\\oop(lab)\\week2\\Users.txt";
          
            char choice;
            do
            {
                count =  readFile(path  , s1);
                Console.Clear();
                choice = menu();
                if (choice == '1')
                {
                    s1[count] = addUser();
                 
                    count = count + 1;
                    writeFile(path, count, s1);
                     
                }
                if(choice =='2')
                {
                   // count = readFile(path , count , s1);
                    viewUser(s1 , count);
                    
                }
                if(choice == '3')
                {
                    Console.Clear();
                    Console.WriteLine("Entre username  ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Entre password  ");
                    string passes = Console.ReadLine();
                    bool flag = signIn(s1, count, name, passes);
                    if(flag == true)
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
        static char menu ()
        {

            Console.Clear();
            char option;
            Console.WriteLine("Press 1 to sign up ");
            Console.WriteLine("Press 2 to view user");
            Console.WriteLine("Press 3 to sign in");
            Console.WriteLine("Press 4 to exit");
            Console.WriteLine("Entre your option ");
            option = char.Parse(Console.ReadLine());
            return option;
        }
        static Credentials addUser ()
        {
            Console.Clear();
            Credentials c1 = new Credentials();
            Console.WriteLine("Entre username  ");
            c1.userName = Console.ReadLine();
            Console.WriteLine("Entre password  ");
            c1.password = Console.ReadLine();
            return c1;
        }
        static void viewUser (Credentials[] s1 , int count)
        {
            Console.Clear();
            for (int x = 0; x < count; x ++)
            {
                Console.WriteLine("userName  {0}   password {1} ", s1[x].userName, s1[x].password);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static bool signIn(Credentials[] s1 , int count , string name , string passes)
        {
            bool flag = false;
            for (int x = 0; x < count; x++)
            {
                if (s1[x].userName == name && s1[x].password == passes)
                {
                    flag = true;
                    break;
                }
            }
            return flag; 
        }
        static void writeFile(string path  , int count , Credentials[] s1)
        {
            
            StreamWriter file = new StreamWriter(path , false);
            for (int x  = 0; x <count; x++)
            {
                file.WriteLine(s1[x].userName +  ","  + s1[x].password);
            }               
                file.Flush();
                file.Close();            
        }
        static int  readFile(string path  ,   Credentials[] s1)
        {
           int x =0 ;
               
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                      Credentials c1 = new Credentials ();
                    c1.userName = parseData(record, 1);
                    c1.password = parseData(record, 2);
                    s1[x++] = c1;
                   
                }
                fileVariable.Close();
            return x ;
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
