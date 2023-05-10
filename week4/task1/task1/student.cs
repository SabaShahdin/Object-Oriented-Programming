using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class student
    {
        public string name;
        public int rollNo;
        public float cgpa;
        public float matric;
        public float fsc;
        public float ecat;
        public string homeTown;
        public bool isHostellite;
        public bool isTakingScholarship;

        public student (string name , int rollNo , float cgpa , float matric , float fsc ,  float ecat , string homeTown , bool isHostellite , bool isTakingScholarship)
        {
            this.name = name;
            this.rollNo = rollNo;
            this.cgpa = cgpa;
            this.matric = matric;
            this.fsc = fsc;
            this.ecat = ecat;
            this.homeTown = homeTown;
            this.isHostellite = isHostellite;
            this.isTakingScholarship = isTakingScholarship;

        }
        public float   calculateMerit()
        {
             float merit = ((fsc / 1100.0f) * (40.0f /100.0f)) ;
             float total = ((ecat / 400) * (60.0F /100.0F));
            float merit1 = merit + total;
            float meritPercentage = merit1 * 100.0F;
            return meritPercentage;
        }
        public bool isEligile()
        {
            bool flag = true;
            float meritPercentage = calculateMerit();
            if(meritPercentage >= 80)
            {
              flag = true;
            }
            else
            {
                 flag = false;
            }
            return flag ;
        }
    }
}
