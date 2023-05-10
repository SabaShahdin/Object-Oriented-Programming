﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
   public  class Student
    {
        public string name;
        public int age;
        public float fsc;
        public float ecat;
        public float merit ;
        public List<Degree> preferences = new List<Degree> ();
        public List<Subject> regSubject =  new  List<Subject> () ;
        public Degree regDegree;

        public Student (string name , int age , float fsc , float ecat ,  List <Degree> prefernces)
        {          
            this.name = name;
            this.age = age;
            this.fsc = fsc;
            this.ecat = ecat;
            this.preferences = new List<Degree>();
        }
         public float calculatemerit()
        {
            float merits = ((fsc / 1100.0f) * (40.0f / 100.0f));
            float total = ((ecat / 400) * (60.0F / 100.0F));
            float merit1 = merits + total;
            merit = merit1 * 100;
            return merit;
        }
        public int getCreditHours()
        {
            int count = 0;
            foreach (Subject sub in regSubject)
            {
                count = count + sub.creditHours;
            }
              return count ;
        }
        public int calculateFees (List <Subject> sub)
        {
            int fees = 0 ;
            foreach(Subject s in sub)
            {
                fees  = fees + s.subjectFees;
            }
            return fees;
        }
        public bool regStudentSubject(Subject s , List <Subject> sub , string type)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExists(sub , s , type)  && stCH + s.creditHours <= 9)
            {
                 regSubject.Add(s);
                return true;
            }
            else
            {
               return false;
            }
        }
    }
}
