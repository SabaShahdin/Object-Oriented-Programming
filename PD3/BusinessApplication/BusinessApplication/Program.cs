using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Admin> products = new List<Admin>();
            User user1 = new User();
            Admin pro = new Admin();
            string path = "textfile.txt";
            string path1 = "Admin.txt";
            int option;
            bool check = user1.readData(path, users);
            bool readFile = pro.read(path1, products);
            if (check)
            {
                Console.WriteLine("Data Loaded SuccessFully");
            }
            else
            {
                Console.WriteLine("Data Not Loaded");
            }
            if (readFile)
            {
                Console.WriteLine("Data Loaded SuccessFully");
            }
            else
            {
                Console.WriteLine("Data Not Loaded");
            }
            Console.ReadKey();
            do
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    User user = user1.takeInputWithoutRole();
                    if (user != null)
                    {
                        user = user1.signIn(user, users);
                        if (user == null)
                        {
                            Console.WriteLine("Invalid User");
                        }
                        else if (user.isAdmin())
                        { 
                            pro.adminChoice(products, path1 , pro);
                        }
                    }
                }
                else if (option == 2)
                {
                    User user = user1.takeInputWithRole();
                    if (user != null)
                    {
                        user1.storeDataInFile(path, user);
                        user1.storeDataInList(users, user);
                    }
                }
                Console.ReadKey();
            }
            while (option < 3);
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }
       
    }
}
