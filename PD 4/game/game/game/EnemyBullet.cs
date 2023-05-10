using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class EnemyBullet
    {
        public int[] bullet3X = new int[1000];
        public int[] bullet3Y = new int[1000];
        public bool[] isBulletActiveEnemy2 = new bool[1000];
        public int bulletCounter2 = 0;
        public int[] bullet2X = new int[1000];
        public int[] bullet2Y = new int[1000];
        public bool[] isBulletActiveEnemy = new bool[1000];
        public int bulletCounter = 0;

        public void generateBulletEnemy2(Enemy enePos)
        {
            bullet3X[bulletCounter2] = enePos.enemyY - 1;
            bullet3Y[bulletCounter2] = enePos.enemyX;
            isBulletActiveEnemy2[bulletCounter2] = true;
            Console.SetCursorPosition(enePos.enemyY - 1, enePos.enemyX);
            Console.Write("*");
            bulletCounter2++;
        }
        public void makeBulletInactiveEnemy2(int index)
        {
            isBulletActiveEnemy2[index] = false;
        }

        public void generateBulletEnemy(Enemy enePos)
        {
            bullet2X[bulletCounter] = enePos.enemyY + 1;
            bullet2Y[bulletCounter] = enePos.enemyX;
            isBulletActiveEnemy[bulletCounter] = true;
            Console.SetCursorPosition(enePos.enemyY + 1, enePos.enemyX);
            Console.Write("*");
            bulletCounter++;
        }
        public void makeBulletInactiveEnemy(int index)
        {
            isBulletActiveEnemy[index] = false;
        }

    }
}
