using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Square :Shape
    {
        private int length;

        public Square()
        {

        }
        public Square(int length , string name ) : base (name )
        {
            this.length = length;
            this.name = name;
        }
        public void setLength(int length)
        {
            this.length = length ;
        }
        public int getLength()
        {
            return length;

        }
        public override double getArea()
        {
            double area = length * length;
            return area;
        }
        public override string toString()
        {
            return   base.toString();
        }
    }
}
