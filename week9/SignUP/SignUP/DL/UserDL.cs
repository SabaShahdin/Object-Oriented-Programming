
using SignUP.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUP.DL
{
    public class UserDL
    {
        public static List<User> users = new List<User>();

        public static bool readData(string path)
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
                    storeDataInList( user);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        public static string parseData(string record, int field)
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
        public static  void storeDataInList(User user)
        {
            users.Add(user);
        }
        public static void storeDataInFile(User user, string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.getUserName()  + "," + user.getPassword() + "," + user.getRole());
            file.Flush();
            file.Close();
        }
        public static User signIn(User user)
        {
            foreach (User storedUser in users)
            {
                if (user.getUserName() == storedUser.getUserName() && user.getPassword() == storedUser.getPassword())
                {
                    return storedUser;
                }
            }
            return null;
        }
    }
}
