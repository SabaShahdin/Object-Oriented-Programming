using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Student
    {
        public string name;
        public int rollNo;
        public int marks;

        public Student(string name , int rollNo , int marks)
        {
            this.name = name;
            this.rollNo = rollNo;
            this.marks = marks;
        }
    }
}
