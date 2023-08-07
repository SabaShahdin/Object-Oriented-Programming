using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class MuserDL
    {
        public static  List<Muser> user = new List<Muser>();
        public static void Add()
        {
            user.Add(new Muser() { Username = "saba", Password = "879", Role = "Admin" });
            user.Add(new Muser() { Username = "ali", Password = "809", Role = "Admin" });
            user.Add(new Muser() { Username = "moaz", Password = "878", Role = "Admin" });
        }       
       public static void deleteUserFromlist(Muser muser)
        {
            for(int idx = 0; idx < user.Count; idx++)
            {
                if(user[idx].Username == muser.Username && user[idx].Password == muser.Password)
                {
                    user.RemoveAt(idx);
                }
            }
        }
    }
}
