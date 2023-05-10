using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Angle
    {
        public int degree;
        public float min;
        public char direction;

        public Angle ()
        {

        }
        public Angle(int degree , float min , char direction )
        {
            this.degree = degree;
            this.min = min;
            this.direction = direction ;
        }
        public void ChangeValues(int degree , float Min , char Direction )
        {
            this.degree = degree;
            this.min = Min;
            this.direction = Direction;
        }
        public void printAngle ()
        {          
            Console.WriteLine (degree.ToString() +  "\u00b0" + min.ToString() +  " ' " +  direction);
        }
      
    }
}
