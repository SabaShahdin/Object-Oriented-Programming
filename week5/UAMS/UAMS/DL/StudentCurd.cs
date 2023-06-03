using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    public class StudentCurd
    {
        public static List<Student> students = new List<Student>();

        public static Student StudentPresent(string name)
        {
            foreach (Student s1 in students)
            {
                if (s1.name == name && s1.regDegree != null)
                {
                    return s1;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public static void CalculateFeeForAll()
        {
            foreach (Student s1 in students)
            {
                if (s1.regDegree != null)
                {
                    Console.WriteLine(s1.name + " has " + s1.calculateFees() + "fees");
                }
            }
        }
        public static List<Student> sortStudentsByMerit()
        {
            List<Student> sortStudentList = new List<Student>();
            foreach (Student s in students)
            {
                s.calculatemerit();
            }
            sortStudentList = students.OrderByDescending(o => o.merit).ToList();
            return sortStudentList;
        }
        public static void giveAdmission(List<Student> sortStudentList)
        {
            foreach (Student s in sortStudentList)
            {
                foreach (Degree d in s.preferences)
                {
                    if (d.seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }

            }
        }
       
       
       
        public static void AddStudentIntoList(Student s1)
        {
            students.Add(s1);
        }
        public static  void viewSubjects()
        {
            foreach(Student s1 in students)
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
