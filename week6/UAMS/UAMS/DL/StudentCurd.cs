using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using System.IO;

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
            }
            return null;
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
        public static void  StoreInFile (string path , Student s )
        {
            StreamWriter file = new StreamWriter(path , true);
            string DegreeName = "";
            for(int x = 0 ; x < s.preferences.Count  -1 ; x++)
            {
                DegreeName = DegreeName + s.preferences[x].tittle + ";";
            }
            DegreeName = DegreeName + s.preferences[s.preferences.Count-1].tittle;
            file.WriteLine(s.name + "," + s.age + "," + s.fsc + "," + s.ecat + "," + DegreeName);
            file.Flush();
            file.Close();
        }
        public static bool ReadFile (string path)
        {
            StreamReader file = new StreamReader (path);
            string record;
            if(File.Exists (path))
            {
                while((record = file.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    int fsc = int.Parse(splittedRecord[2]);
                    int ecat = int.Parse(splittedRecord[3]);
                    string[] splittedRecordForPrefernces = record.Split(';');
                    List<Degree> prefernces = new List<Degree>();
                    for(int x =0 ; x < splittedRecordForPrefernces.Length ; x++)
                    {
                        Degree d = DegreeCurd.isDegreeExists(splittedRecordForPrefernces[x]) ;
                        if(d != null)
                        {
                            if(!(prefernces.Contains(d)))
                            {
                                prefernces.Add(d);
                            }
                        }
                    }
                    Student s1 = new Student(name , age , fsc , ecat , prefernces);
                    students.Add (s1);
                }
                file.Close();
                return true;
            }
            else
            {
                return false ;
            }
        }
    }
}
