using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Ship
    {
        public string number;
        public Angle Longitude;
        public Angle Latitude;

        public Ship ()
        {

        }
        public Ship (string number , Angle Longitude , Angle Latitude  )
        {
            this.number = number ;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }
        public void PrintSerialNumber()
        {
              Console.WriteLine("Ship's serial number is " + number);
        }
        public void printAngle ()
        {
            Longitude.printAngle();
            Latitude.printAngle();
        }
       
    }
}
