using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainBike
{
    public class MountainBike : Bicycle
    {
        private int seatHeight;

        public MountainBike(int seatHeight, int cadence, int speed, int gear) : base(cadence, speed, gear)
        {
            this.seatHeight = seatHeight;
        }

        public void SetSeatHeight(int seatHeight)
        {
            this.seatHeight = seatHeight;
        }
    }
}
