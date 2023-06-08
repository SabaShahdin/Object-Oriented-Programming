using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firetruck
{
    public class HosePipe
    {
        public string type;
        public string shape;
        public int diameter;

        public HosePipe(string type, string shape, int diameter)
        {
            this.type = type;
            this.shape = shape;
            this.diameter = diameter;
        }
    }
}
