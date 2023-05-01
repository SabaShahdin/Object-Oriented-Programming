using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockType
{
    class Clock
    {
        public int hours;
        public int min;
        public int sec;
        public Clock ()
        {
            hours = 0;
            min = 0;
            sec = 0;
        }
        public Clock(int h)
        {
           hours = h ;
        }
        public Clock(int h , int m)
        {
            hours = h ;
            min =  m;
        }
        public Clock (int h , int m , int s)
        {
            hours = h;
            min = m;
            sec = s;
        }
        public void incrementSecond ()
        {
            sec++;
        }
        public void incrementMin()
        {
            min++;
        }
        public void incrementHours()
        {
            hours++;
        }
        public void printTime ()
        {
            Console.WriteLine(hours + " " +  min + " " + sec);
        }
        public bool isEqual (int h , int m , int s)
        {
            if(h == hours && m == min && s == sec)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEqual (Clock c1)
        {
            if(hours == c1.hours && min == c1.min && sec == c1.sec )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
