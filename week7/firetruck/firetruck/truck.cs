using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firetruck
{
    public class truck
    {
        public Ladder lad = new Ladder();
        public HosePipe hose;
        public List<FireFighter> fire = new List<FireFighter>();

        public void SetHosePipe(HosePipe p)
        {
            hose = p;
        }
        public truck(Ladder lad)
        {
            this.lad = lad;

        }
    }
}
