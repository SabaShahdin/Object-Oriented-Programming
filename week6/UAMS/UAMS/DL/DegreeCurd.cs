using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using System.IO;
namespace UAMS.DL
{
    public class DegreeCurd
    {
        public static List<Degree> degrees = new List<Degree>();
        
        public static void AddDataIntoDegreeList (Degree d)
        {
            degrees.Add(d);
        }
        public static Degree isDegreeExists(string degname)
        {
            foreach(Degree d in degrees)
            {
                if(d.tittle == degname)
                {
                    return d ;
                }
            }
            return null;
        }
        public static bool readFile(string path)
        {
            StreamReader file = new StreamReader (path);
            string record ;
            if(File.Exists (path))
            {
                while ((record = file.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string degName = splittedRecord[0];
                    float degDuration = float.Parse (splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordForSubject = record.Split(';');
                    Degree d = new Degree(degName , degDuration , seats);
                    for(int x =0 ; x < splittedRecordForSubject.Length ; x++)
                    {
                        Subject s = SubjectCurd.isSubjectExists(degName);
                        if(s != null)
                        {
                            d.AddSubject(s);
                        }
                    }
                    AddDataIntoDegreeList(d);
                }
                 file.Close();
                 return true;
            }
            else
            {
                return false ;
            }

        }
        public static  void StoreInFile (string path , Degree d)
        {
            StreamWriter file = new StreamWriter(path , true);
            string SubjectName = "";
            for(int x = 0 ; x < d.subjects.Count  -1 ; x++)
            {
                SubjectName = SubjectName + d.subjects[x].type + ";";
            }
            SubjectName = SubjectName + d.subjects[d.subjects.Count-1].type;
            file.WriteLine(d.tittle + "," + d.duration + "," + d.seats + "," + SubjectName);
            file.Flush();
            file.Close();
        }
    }
}
