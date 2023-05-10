using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class User
    {
        public string name;
        public string password;
        public string role;
        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public User(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        public string isAdmin()
        {
            string roles;
            if (role == "Admin")
            {
                roles = "Admin";
            }
            else if(role == "Employee")
            {
                roles = "Employee";
            }
            else if (role == "Manager")
            {
                roles = "Manager";
            }
            else
            {
                roles = null;
            }
            return roles;
        }
    }
}
