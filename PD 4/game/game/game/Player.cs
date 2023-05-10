using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Player
    {
        public int x;
        public int y;
        public List<Bullet> playerBullet = new List<Bullet>();

        public Player()
        {

        }
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
