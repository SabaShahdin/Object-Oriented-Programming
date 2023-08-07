using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUP.BL
{
    public class User
    { 
            private string name;
            private string password;
            private string role;

            public User()
            {

            }
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
            public bool isAdmin()
            {
                if (role == "Admin")
                {
                    return true;
                }
                return false;
            }
        public string getUserName()
        {
            return name;
        }
        public string getPassword()
        {
            return password;
        }
        public string getRole()
        {
            return role;
        }
    }
}
