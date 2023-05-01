using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Student
    {
        public Student(Student s1 )
        {
            name = s1.name;
            matricMarks = s1.matricMarks;
            fscMarks = s1.fscMarks;
            ecatMarks = s1.ecatMarks;
            aggregates = s1.aggregates;
        }
        public Student()
        {
            Console.WriteLine("Default Constructor");
        }
        public string name;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregates;
    }
}
