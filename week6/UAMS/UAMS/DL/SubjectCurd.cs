using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using System.IO;
namespace UAMS.DL
{
    public class SubjectCurd
    {
        public static List<Subject> sub = new List<Subject>();
        public static void AddSubjectIntoList(Subject s )
        {
            sub.Add(s);
        }
        public static bool  readFromFile(string path)
        {
            StreamReader file = new StreamReader (path);
            string record;
            if(File.Exists (path))
            {
                while((record = file.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int creditHour = int.Parse(splittedRecord[2]);
                    int subjectFees = int.Parse(splittedRecord[3]);
                    Subject s = new Subject (code , type , creditHour , subjectFees);
                    AddSubjectIntoList(s);
                }
                file.Close();
                return true;
            }
            else
            {
                return false ;
            }
        }
        public static void storeDataInFile(string path , Subject s)
        {
            StreamWriter file = new StreamWriter (path , true);
            file.WriteLine (s.code + "," + s.type + "," + s.creditHours + "," + s.subjectFees);
            file.Flush();
            file.Close();
        }
        public static Subject isSubjectExists(string type)
        {
            foreach(Subject s in sub)
            {
                if(s.type == type)
                {
                    return s ;
                }
            }
            return null;
        }
    }
}
