﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;

namespace UAMS.UI
{
   public class UserUI
    {
         public static void CalculateFeeForAll()
         {
            foreach (Student s1 in StudentCurd.students)
            {
                if (s1.regDegree != null)
                {
                    Console.WriteLine(s1.name + " has " + s1.calculateFees() + "fees");
                }
            }
         }    
        public static Student takeInputForStudent()
        {
            Console.Clear();
            bool flag = false ;
            Console.WriteLine("Entre name of student");
            string name = Console.ReadLine();
            Console.WriteLine("Entre student age ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre student fsc  marks");
            int fsc = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre student ecat marks ");
            int ecat = int.Parse(Console.ReadLine());
            Console.WriteLine("Available degree program");
            DegreeUI.viewDegreeProgram();
            Console.WriteLine("Entre your  number of prefeernces");
            int pre = int.Parse(Console.ReadLine());
            List<Degree> preferences = new List<Degree>();
            for (int x = 0; x < pre; x++)
            {
                Console.WriteLine("Enter your preference:");
                string tittle = Console.ReadLine();
                foreach (Degree deg in DegreeCurd.degrees)
                {
                    if (deg.tittle == tittle)
                    {
                        Console.WriteLine("Degree  exists");
                        preferences.Add(deg);
                        flag = true;
                    }
                    else if(flag == false)
                    {
                        Console.WriteLine("Degree does not exists");
                        x--;
                    }
                }
            }
            Student s2 = new Student(name, age, fsc, ecat, preferences);
            return s2;
        }
        public static void printStudent()
        {
            foreach (Student s in StudentCurd.students)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "got admission is " + s.regDegree.tittle);
                }
                else
                {
                    Console.WriteLine(s.name + " did not admission  ");
                }
            }
        }
        public static void viewRegisteredStudents()
        {
            Console.WriteLine("name   \t   age     \t  fsc   \t   ecat ");
            foreach (Student s in StudentCurd.students)
            {
                Console.WriteLine(s.name + "\t" + s.age + "\t" + s.fsc + "\t" + s.ecat);
            }
        }
        public static void viewStudentInDegree(string degName)
        {
            Console.WriteLine("name   \t   age     \t  fsc   \t   ecat ");
            foreach (Student s in StudentCurd.students)
            {
                if (degName == s.regDegree.tittle)
                {
                    Console.WriteLine(s.name + s.age + s.fsc + s.ecat);
                }
            }
        }
       public static  void viewSubjects()
        {
            foreach(Student s1 in StudentCurd.students)
            {
                if(s1.regDegree!= null)
                {
                    Console.WriteLine("code  \t  creditHours \t    type  \t subjectFees");
                    foreach (Subject s in s1.regDegree.subjects)
                    {
                        Console.WriteLine(s.code + "\t" + s.creditHours + "\t" + s.type + "\t" + s.subjectFees);
                    }
                }
            }
        }
    }
}
