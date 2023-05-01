using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessApplication
{
    public class User
    {
        public string name;
        public string password;
        public string role;

        public User ()
        {

        }
        public User (string name , string password)
        {
            this.name = name;
            this.password = password;
        }
        public User (string name , string password , string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        public bool isAdmin()
        {
            if (role == "Admin")
            {
                return true;
            }
            return false;
        }
        public bool readData(string path, List<User> users)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    User user = new User(name, password, role);
                    storeDataInList(users, user);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length;
           x++)
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
        public  void storeDataInList(List<User> users, User user)
        {
            users.Add(user);
        }
        public  User takeInputWithoutRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                User user = new User(name, password);
                return user;
            }
            return null;
        }
        public  User takeInputWithRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role: ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                User user = new User(name, password, role);
                return user;
            }
            return null;
        }
        public  void storeDataInFile(string path, User user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.name + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }
        public  User signIn(User user, List<User> users)
        {
            foreach (User storedUser in users)
            {
                if (user.name == storedUser.name && user.password == storedUser.password)
                {
                    return storedUser;
                }
            }
            return null;
        }
    }

}
