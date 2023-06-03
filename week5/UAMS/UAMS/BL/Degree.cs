using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    public class Degree
    {
        public string tittle;
        public int duration;
        public int seats;
        public List<Subject> subjects = new List<Subject>();

        public Degree(string title, int duration, int seats)
        {
            this.tittle = title;
            this.duration = duration;
            this.seats = seats;
            subjects = new List<Subject>();
        }
        public int calculateCreditHours()
        {
            int totalCreditHours = 0;
            foreach (Subject sub in subjects)
            {
                totalCreditHours = totalCreditHours + sub.creditHours;
            }
            return totalCreditHours;
        }
        public bool isSubjectExists(Subject sub)
        {
            bool flag = true;
            foreach (Subject s in subjects)
            {
                if (s.code == sub.code)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }
        public void AddSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if (creditHours + s.creditHours <= 20)
            {
                subjects.Add(s);
            }
            else
            {
                Console.WriteLine("20 credit hour limit exceeded");
            }
        }
    }
}
