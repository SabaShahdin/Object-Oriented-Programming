using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Defender
    {
       public  int enemy2X ;
       public int enemy2Y;

        public Defender()
        {

        }
        public Defender(int x , int y)
        {
            this.enemy2X = x;
            this.enemy2Y = y; 
        }
    }
}
