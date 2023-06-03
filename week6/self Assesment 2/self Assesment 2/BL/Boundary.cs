using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_Assesment_2.BL
{
    public class Boundary
    {
        public Point TopLeft;
        public Point TopRight;
        public Point BottomLeft;
        public Point BottomRight;

        public Boundary()
        {

        }
        public Boundary(Point TopLeft  , Point TopRight , Point BottomLeft , Point BottomRight)
        {
            this.TopLeft = TopLeft;
            this.TopRight = TopRight;
            this.BottomLeft = BottomLeft;
            this.BottomRight = BottomRight;
        }
    }
}
