using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    class Clock
    {
        public int hours;
        public int min;
        public int sec;
        public int  elapsedS;
        public int elapsedH;
        public int elapsedM;
        public int remainH;
        public int remainM;
        public int remainS;
        public int remain;
       
        public Clock()
        {
            hours = 0;
            min = 0;
            sec = 0;
        }
        public Clock(int h, int m, int s)
        {
            hours = h;
            min = m;
            sec = s;
        }
        public void printTime()
        {
            Console.WriteLine(hours + " " + min + " " + sec);
        }
        public void   elapsedHours()
        {
            elapsedH = hours - 0;           
            elapsedM = min- 0;
            elapsedS = sec - 0;
        }
     
        public void printElapsed ()
        {
            Console.WriteLine(elapsedH + " " + elapsedM + " " + elapsedS);
        }
        public void Convert()
        {
            sec = hours * 3600 + min * 60 + sec;
        }
        public int  Seconds()
        {
            int remainSec;
            remainSec = 24 * 3600;
            return remainSec;
        }
        public void Remaing()
        {
           int  remaining = Seconds();
           Convert();
           remain = remaining - sec;
        }
        public void Remaining  ()
        {
            remainH = remain / 3600;
            remainM = (remain - (3600 * remainH)) / 60;
            remainS = remain - 3600 * remainH - 60 * remainM; 
        }
        public void printRemian()
        {
            Console.WriteLine(remainH + " " + remainM + " " + remainS);
        }
        public void ConvertE()
        {
            elapsedS = elapsedH * 3600 + elapsedM * 60 + elapsedS;
        }
    }
}
