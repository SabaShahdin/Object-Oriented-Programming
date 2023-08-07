using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    public class MuserDL
    {
        public static List<Muser> user = new List<Muser>();
        public static void Add()
        {
            user.Add(new Muser() { Username = "saba", Password = "879", Role = "Admin" });
            user.Add(new Muser() { Username = "ali", Password = "809", Role = "Admin" });
            user.Add(new Muser() { Username = "moaz", Password = "878", Role = "Admin" });
        }
        public static bool search(string username)
        {
            bool flag = false ;
            foreach(Muser u in user)
            {              
                if (username == u.Username)
                {
                    flag = true ;
                }
            }
            return flag ;
        }
        
    }
}
