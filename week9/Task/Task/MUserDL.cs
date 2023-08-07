using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BL;

namespace Task
{
    public class MUserDL
    {
        private static List<MUser> users = new List<MUser>();

        public static List<MUser> Users { get => users; set => users = value; }

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
                    MUser user = new MUser(name, password, role);
                    storeDataInList(user);
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
        public static void storeDataInList(MUser user)
        {
            Users.Add(user);
        }
        public static void storeDataInFile(MUser user, string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.getUserName() + "," + user.getPassword() + "," + user.getRole());
            file.Flush();
            file.Close();
        }
        public static MUser signIn(MUser user)
        {
            foreach (MUser storedUser in Users)
            {
                if (user.getUserName() == storedUser.getUserName() && user.getPassword() == storedUser.getPassword())
                {
                    return storedUser;
                }
            }
            return null;
        }
        public static void deleteUserFromList(MUser user)
        {
            for(int index =0; index < users.Count ; index++  )
            {
                if(users[index].Name == user.Name  && users[index].Password == user.Password )
                {
                    users.RemoveAt(index);
                }
            }
        }
        public static void EditUserFromList(MUser previous , MUser update)
        {
            foreach(MUser  user in users)
            {
                if(user.Name == previous.Name  && user.Password == previous.Password)
                {
                    user.Name = update.Name;
                    user.Password = update.Password;
                    user.Role = update.Role;
                }
            }
        }
    }
}
