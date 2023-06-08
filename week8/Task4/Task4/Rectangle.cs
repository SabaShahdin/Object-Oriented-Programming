using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Rectangle : Shape 
    {
        private int height;
        private int width;
        public Rectangle()
        {

        }
        public Rectangle (int height , int width  , string name ) : base(name)
        {
            this.height = height ;
            this.width = width;
            this.name = name;
        }
        public void setheight(int height)
        {
            this.height = height;
        }
        public int getHeight()
        {
            return height;
        }
        public void setWidth(int width)
        {
            this.width = width;
        }
        public int getWidth()
        {
            return width;
        }
        public override double getArea()
        {
            double area = height * width;
            return area;
        }
        public override string toString()
        {
            return   base.toString();
        }
    }
}
