using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Student
    {
        public Student (string n)
        {
            name = n ; 
        }
        public Student(string n, float matric , float inter , float ecat , float agg)
        {
            name = n;
            matricMarks = matric;
            fscMarks = inter;
            ecatMarks = ecat;
            aggregates = agg;
        }
        public string name;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregates;
    }
}
