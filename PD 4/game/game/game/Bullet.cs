using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Bullet
    {
        public int[] bulletX = new int[1000];
        public int[] bulletY = new int[1000];
        public bool[] isBulletActive = new bool[1000];
        public int bulletCount = 0;
        public int[] bulletRX = new int[1000];
        public int[] bulletRY = new int[1000];
        public bool[] isBulletActiveR = new bool[1000];
        public int bulletCountR = 0;
        public int[] bulletLX = new int[1000];
        public int[] bulletLY = new int[1000];
        public bool[] isBulletActiveL = new bool[1000];
        public int bulletCountL = 0;
        public int[] bulletDX = new int[1000];
        public int[] bulletDY = new int[1000];
        public bool[] isBulletActiveD = new bool[1000];
        public int bulletCountD = 0;

        public void generateBullet(Player position)
        {
            bulletX[bulletCount] = position.y + 1;
            bulletY[bulletCount] = position.x;
            isBulletActive[bulletCount] = true;
            Console.SetCursorPosition(position.y + 1, position.x);
            Console.Write("-");
            bulletCount++;
        }
        public void makeBulletInactive(int index)
        {
            isBulletActive[index] = false;
        }
        public void generateBulletLeft(Player position)
        {
            bulletRX[bulletCountR] = position.y - 1;
            bulletRY[bulletCountR] = position.x;
            isBulletActiveR[bulletCountR] = true;
            Console.SetCursorPosition(position.y - 1, position.x);
            Console.Write("-");
            bulletCountR++;
        }
        public void makeBulletInactiveLeft(int index)
        {
            isBulletActiveR[index] = false;
        }
        public void generateBulletUP(Player position)
        {
            bulletLX[bulletCountL] = position.y;
            bulletLY[bulletCountL] = position.x - 1;
            isBulletActiveL[bulletCountL] = true;
            Console.SetCursorPosition(position.y, position.x - 1);
            Console.Write("-");
            bulletCountL++;
        }
        public void makeBulletInactiveUP(int index)
        {
            isBulletActiveL[index] = false;
        }
        public void generateBulletDOWN(Player position)
        {
            bulletDX[bulletCountD] = position.y;
            bulletDY[bulletCountD] = position.x + 1;
            isBulletActiveD[bulletCountD] = true;
            Console.SetCursorPosition(position.y, position.x + 1);
            Console.Write("-");
            bulletCountD++;
        }
        public void makeBulletInactiveDOWN(int index)
        {
            isBulletActiveD[index] = false;
        }
    }
}

