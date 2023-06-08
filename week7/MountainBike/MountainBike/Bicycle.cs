using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainBike
{
    public class Bicycle
    {
        protected int cadence;
        protected int gear;
        protected int speed;

        public Bicycle(int cadence, int speed, int gear)
        {
            this.cadence = cadence;
            this.speed = speed;
            this.gear = gear;
        }

        public void SetCadence(int cadence)
        {
            this.cadence = cadence;
        }

        public void SetGear(int gear)
        {
            this.gear = gear;
        }

        public void ApplyBrake(int decrement)
        {
            speed = speed -  decrement;
        }

        public void SpeedUp(int increment)
        {
            speed  = speed +  increment;
        }

    }
}
