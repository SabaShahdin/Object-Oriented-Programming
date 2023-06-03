using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line
{
    public class MyLine
    {
        public MyPoint begin;
        public MyPoint end;

        public MyLine(MyPoint begin, MyPoint end)
        {
            this.begin = begin;
            this.end = end;
        }
        public MyLine()
        {

        }
        public MyPoint getBegin()
        {
            return begin;
        }
        public void setBegin(MyPoint begin)
        {
            this.begin = begin;
        }
        public MyPoint getEnd()
        {
            return end;
        }
        public void setEnd(MyPoint end)
        {
            this.end = end;
        }
        public double GetLength()
        {
            double d;
            d = begin.distanceWitHObject(end);
            return d;
        }
        public double GetGradiant()
        {
            double d = (end.getY()  - begin.getY() ) / (end.getX() - begin.getX());
            return d;
        }
    }
}
