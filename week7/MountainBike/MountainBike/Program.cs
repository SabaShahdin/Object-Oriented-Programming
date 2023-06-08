using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainBike
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre cadence ");
            int cadence = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre gear ");
            int gear = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre speed ");
            int speed = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre speed ");
            int seatHeight = int.Parse(Console.ReadLine());
            MountainBike mountainBike = new MountainBike(cadence, gear, speed, seatHeight);
            mountainBike.SetSeatHeight(cadence);
            mountainBike.SetCadence(gear);
            mountainBike.SetGear(seatHeight);
         
           
            mountainBike.ApplyBrake(2);
            mountainBike.SpeedUp(4);
        }
    }
}
