using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class DefenderBullet
    {
        public int[] bulletDefX = new int[1000];
        public int[] bulletDefY = new int[1000];
        public bool[] isBulletActiveDefEnemy = new bool[1000];
        public int bulletCounterDef2 = 0;
        public int[] bulletDef2X = new int[1000];
        public int[] bulletDef2Y = new int[1000];
        public bool[] isBulletActiveDefEnemy1 = new bool[1000];
        public int bulletCounterDef = 0;

        public void generateBulletDefender2(Defender enemy)
        {
            bulletDefX[bulletCounterDef2] = enemy.enemy2Y;
            bulletDefY[bulletCounterDef2] = enemy.enemy2X - 1;
            isBulletActiveDefEnemy[bulletCounterDef2] = true;
            Console.SetCursorPosition(enemy.enemy2Y , enemy.enemy2X -  1 );
            Console.Write("*");
            bulletCounterDef2++;
        }
        public void makeBulletInactiveDefender2(int index)
        {
            isBulletActiveDefEnemy[index] = false;
        }
        public void generateBulletDefender(Defender enemy)
        {
            bulletDef2X[bulletCounterDef] = enemy.enemy2Y;
            bulletDef2Y[bulletCounterDef] = enemy.enemy2X + 1;
            isBulletActiveDefEnemy1[bulletCounterDef] = true;
            Console.SetCursorPosition(enemy.enemy2Y , enemy.enemy2X + 1);
            Console.Write("*");
            bulletCounterDef++;
        }
        public void makeBulletInactiveDefender(int index)
        {
            isBulletActiveDefEnemy1[index] = false;
        }
    }
}
