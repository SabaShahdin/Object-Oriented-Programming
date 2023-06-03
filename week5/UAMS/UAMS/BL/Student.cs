using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    public class Student
    {
        public string name;
        public int age;
        public float fsc;
        public float ecat;
        public float merit;
        public List<Degree> preferences = new List<Degree>();
        public List<Subject> regSubject = new List<Subject>();
        public Degree regDegree;

        public Student(string name, int age, float fsc, float ecat, List<Degree> prefernces)
        {
            this.name = name;
            this.age = age;
            this.fsc = fsc;
            this.ecat = ecat;
            this.preferences = new List<Degree>();
        }
        public void calculatemerit()
        {
           this. merit = (((fsc / 1100.0f) * 0.45F ) + ((ecat / 400.0F) * 0.55F)) * 100.0F;
        }
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExists(s) && stCH + s.creditHours <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getCreditHours()
        {
            int count = 0;
            foreach (Subject sub in regSubject)
            {
                count = count + sub.creditHours;
            }
            return count;
        }
        public int calculateFees()
        {
            int fees = 0;
            if(regDegree != null)
            { 
            foreach (Subject s in regSubject)
            {
                fees = fees + s.subjectFees;
            }
            }
            return fees;
        }

    }
}
