using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Enemy
    {
        public int enemyX;
        public int enemyY;
        public List<EnemyBullet> enemyBullet = new List<EnemyBullet>();

        public Enemy()
        {

        }
        public Enemy(int x, int y)
        {
            this.enemyX = x;
            this.enemyY = y;
        }
    }
}
