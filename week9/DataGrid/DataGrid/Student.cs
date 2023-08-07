using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public class Student
    {
        int id;
        string name;
        string registration;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Registration { get => registration; set => registration = value; }
    }
}
