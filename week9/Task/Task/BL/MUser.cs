using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BL
{
    public class MUser
    {
        private string name;
        private string password;
        private string role;

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }

        public MUser()
        {

        }
        public MUser(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
        public MUser(string name, string password, string role)
        {
            this.Name = name;
            this.Password = password;
            this.Role = role;
        }
        public bool isAdmin()
        {
            if (Role == "Admin")
            {
                return true;
            }
            return false;
        }
        public string getUserName()
        {
            return Name;
        }
        public string getPassword()
        {
            return Password;
        }
        public string getRole()
        {
            return Role;
        }
    }
}
