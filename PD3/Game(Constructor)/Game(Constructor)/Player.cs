using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game_Constructor_
{
    class Player
    {
        public int x;
        public int y;

        public Player ()
        {

        }
        public Player(int x , int y)
        {
            this.x = x;
            this.y = y;
        }
        public void printMaze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }
        public  void readData(char[,] maze)
        {
            StreamReader fp = new StreamReader("mazes.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 114; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            fp.Close();
        }
        public  void moveUp(char[,] maze, Player position, char ball, ref int score, ref int energy)
        {
            if (maze[position.x - 1, position.y] == ' ' || maze[position.x - 1, position.y] == '>' || maze[position.x - 1, position.y] == '$')
            {
                maze[position.x, position.y] = ' ';
                Console.SetCursorPosition(position.y, position.x);
                Console.Write(" ");
                position.x = position.x - 1;
                Console.SetCursorPosition(position.y, position.x);
                maze[position.x, position.y] = ball;
                Console.Write(ball);
                if (maze[position.x - 1, position.y] == '>')
                {
                    score = addScore(ref score);
                    Console.SetCursorPosition(110, 38);
                    Console.Write("Score: " + score);
                }
                if (maze[position.x - 1, position.y] == '$')
                {
                    energy = addEnergy(ref energy);
                    Console.SetCursorPosition(110, 40);
                    Console.Write("Energy: " + energy);
                }
            }
        }
        public void moveDown(char[,] maze, Player position, char ball, ref int score, ref int energy)
        {
            if (maze[position.x + 1, position.y] == ' ' || maze[position.x + 1, position.y] == '>' || maze[position.x + 1, position.y] == '$')
            {
                maze[position.x, position.y] = ' ';
                Console.SetCursorPosition(position.y, position.x);
                Console.Write(" ");
                position.x = position.x + 1;
                Console.SetCursorPosition(position.y, position.x);
                maze[position.x, position.y] = ball;
                Console.Write(ball);
                if (maze[position.x + 1, position.y] == '>')
                {
                    score = addScore(ref score);
                    Console.SetCursorPosition(110, 38);
                    Console.Write("Score: " + score);
                }
                if (maze[position.x + 1, position.y] == '$')
                {
                    energy = addEnergy(ref energy);
                    Console.SetCursorPosition(110, 40);
                    Console.Write("Energy: " + energy);
                }
            }
        }
        public  void moveLeft(char[,] maze, Player position, char ball, ref int score, ref int energy)
        {
            if (maze[position.x, position.y - 1] == ' ' || maze[position.x, position.y - 1] == '>' || maze[position.x, position.y - 1] == '$')
            {
                maze[position.x, position.y] = ' ';
                Console.SetCursorPosition(position.y, position.x);
                Console.Write(" ");
                position.y = position.y - 1;
                Console.SetCursorPosition(position.y, position.x);
                maze[position.x, position.y] = ball;
                Console.Write(ball);
                if (maze[position.x, position.y - 1] == '>')
                {
                    score = addScore(ref score);
                    Console.SetCursorPosition(110, 38);
                    Console.Write("Score: " + score);
                }
                if (maze[position.x, position.y - 1] == '$')
                {
                    energy = addEnergy(ref energy);
                    Console.SetCursorPosition(110, 40);
                    Console.Write("Energy: " + energy);
                }

            }

        }
        public  void moveRight(char[,] maze, Player position, char ball, ref int score, ref int energy)
        {
            if (maze[position.x, position.y + 1] == ' ' || maze[position.x, position.y + 1] == '>' || maze[position.x, position.y + 1] == '$')
            {
                maze[position.x, position.y] = ' ';
                Console.SetCursorPosition(position.y, position.x);
                Console.Write(" ");
                position.y = position.y + 1;
                Console.SetCursorPosition(position.y, position.x);
                maze[position.x, position.y] = ball;
                Console.Write(ball);
                if (maze[position.x, position.y + 1] == '>')
                {
                    score = addScore(ref score);
                    Console.SetCursorPosition(110, 38);
                    Console.Write("Score: " + score);
                }
                if (maze[position.x, position.y + 1] == '$')
                {
                    energy = addEnergy(ref energy);
                    Console.SetCursorPosition(110, 40);
                    Console.Write("Energy: " + energy);
                }
            }
        }
        public  int addScore(ref int score)
        {
            score = score + 1;
            return score;
        }
        public  int addEnergy(ref int energy)
        {
            energy = energy + 1;
            return energy;
        }
        public void generateBullet(int[] bulletX, int[] bulletY, ref int bulletCount, Player position, bool[] isBulletActive)
        {
            bulletX[bulletCount] = position.y + 1;
            bulletY[bulletCount] = position.x;
            isBulletActive[bulletCount] = true;
            Console.SetCursorPosition(position.y + 1, position.x);
            Console.Write("-");
            bulletCount++;
        }
        public void moveBullet(int[] bulletX, int[] bulletY, ref int bulletCount, bool[] isBulletActive, char[,] maze)
        {
            for (int x = 0; x < bulletCount - 1; x++)
            {
                if (isBulletActive[x] == true)
                {
                    if (maze[bulletY[x], bulletX[x] + 1] != ' ')
                    {
                        eraseBullet(bulletX[x], bulletY[x]);
                        makeBulletInactive(x, isBulletActive);
                    }
                    else
                    {
                        eraseBullet(bulletX[x], bulletY[x]);
                        bulletX[x] = bulletX[x] + 1;
                        printBullet(bulletX[x], bulletY[x]);
                    }
                }
            }

        }
        public void printBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }
        public void eraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public void makeBulletInactive(int index, bool[] isBulletActive)
        {
            isBulletActive[index] = false;

        }
        public void generateBulletLeft(int[] bulletRX, int[] bulletRY, ref int bulletCountR, Player position, bool[] isBulletActiveR)
        {
            bulletRX[bulletCountR] = position.y - 1;
            bulletRY[bulletCountR] = position.x;
            isBulletActiveR[bulletCountR] = true;
            Console.SetCursorPosition(position.y - 1, position.x);
            Console.Write("-");
            bulletCountR++;
        }
        public void moveBulletLeft(int[] bulletRX, int[] bulletRY, ref int bulletCountR, bool[] isBulletActiveR, char[,] maze)
        {
            for (int x = 0; x < bulletCountR; x++)
            {
                if (isBulletActiveR[x] == true)
                {

                    if (maze[bulletRY[x], bulletRX[x] - 1] != ' ')
                    {
                        eraseBulletLeft(bulletRX[x], bulletRY[x]);
                        makeBulletInactiveLeft(x, isBulletActiveR);
                    }
                    else
                    {
                        eraseBulletLeft(bulletRX[x], bulletRY[x]);
                        bulletRX[x] = bulletRX[x] - 1;
                        printBulletLeft(bulletRX[x], bulletRY[x]);
                    }
                }
            }
        }
        public void printBulletLeft(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }
        public void eraseBulletLeft(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void makeBulletInactiveLeft(int index, bool[] isBulletActiveR)
        {
            isBulletActiveR[index] = false;
        }
        public void generateBulletUP(int[] bulletLX, int[] bulletLY, ref int bulletCountL, Player position, bool[] isBulletActiveL)
        {
            bulletLX[bulletCountL] = position.y;
            bulletLY[bulletCountL] = position.x - 1;
            isBulletActiveL[bulletCountL] = true;
            Console.SetCursorPosition(position.y, position.x - 1);
            Console.Write("-");
            bulletCountL++;
        }
        public void moveBulletUP(int[] bulletLX, int[] bulletLY, ref int bulletCountL, bool[] isBulletActiveL, char[,] maze)
        {
            for (int x = 0; x < bulletCountL; x++)
            {
                if (isBulletActiveL[x] == true)
                {
                    if (maze[bulletLY[x] - 1, bulletLX[x]] != ' ')
                    {
                        eraseBulletUP(bulletLX[x], bulletLY[x]);
                        makeBulletInactiveUP(x, isBulletActiveL);
                    }
                    else
                    {
                        eraseBulletUP(bulletLX[x], bulletLY[x]);
                        bulletLY[x] = bulletLY[x] - 1;
                        printBulletUP(bulletLX[x], bulletLY[x]);
                    }
                }
            }
        }
        public void printBulletUP(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }
        public void eraseBulletUP(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public void makeBulletInactiveUP(int index, bool[] isBulletActiveL)
        {
            isBulletActiveL[index] = false;
        }
        public void generateBulletDOWN(int[] bulletDX, int[] bulletDY, ref int bulletCountD, Player position, bool[] isBulletActiveD)
        {
            bulletDX[bulletCountD] = position.y;
            bulletDY[bulletCountD] = position.x + 1;
            isBulletActiveD[bulletCountD] = true;
            Console.SetCursorPosition(position.y, position.x + 1);
            Console.Write("-");
            bulletCountD++;
        }
        public  void moveBulletDOWN(int[] bulletDX, int[] bulletDY, ref int bulletCountD, bool[] isBulletActiveD, char[,] maze)
        {
            for (int x = 0; x < bulletCountD; x++)
            {
                if (isBulletActiveD[x] == true)
                {

                    if (maze[bulletDY[x] + 1, bulletDX[x]] != ' ')
                    {
                        eraseBulletDOWN(bulletDX[x], bulletDY[x]);
                        makeBulletInactiveDOWN(x, isBulletActiveD);
                    }
                    else
                    {
                        eraseBulletDOWN(bulletDX[x], bulletDY[x]);
                        bulletDY[x] = bulletDY[x] + 1;
                        printBulletDOWN(bulletDX[x], bulletDY[x]);
                    }
                }

            }
        }
        public  void printBulletDOWN(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }
        public void eraseBulletDOWN(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public void makeBulletInactiveDOWN(int index, bool[] isBulletActiveD)
        {
            isBulletActiveD[index] = false;
        }
        public void printDefender(int x, int y, ref char defender3)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(defender3);
        }
         public void eraseDefender(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
        }
        public void defender2(ref string direction, char[,] maze, ref int enemyX, ref int enemyY, ref char previous, ref char defender3)
        {
            if (direction == "Up")
            {
                if (maze[enemyX - 1, enemyY] == ' ' || maze[enemyX - 1, enemyY] == '>' || maze[enemyX - 1, enemyY] == '$')
                {
                    eraseDefender(enemyX, enemyY);
                    enemyX--;
                    printDefender(enemyX, enemyY, ref defender3);
                }
                if (maze[enemyX - 1, enemyY] == '#' || maze[enemyX - 1, enemyY] == '%')
                {
                    direction = "Down";
                    eraseDefender(enemyX, enemyY);
                    enemyX = 10;
                    printDefender(enemyX, enemyY, ref defender3);
                }
            }
            if (direction == "Down")
            {
                if (maze[enemyX + 1, enemyY] == ' ' || maze[enemyX + 1, enemyY] == '>' || maze[enemyX + 1, enemyY] == '$')
                {
                    eraseDefender(enemyX, enemyY);
                    enemyX++;
                    printDefender(enemyX, enemyY, ref defender3);
                }
                if (maze[enemyX + 1, enemyY] == '#' || maze[enemyX + 1, enemyY] == '%')
                {
                    direction = "Up";
                    eraseDefender(enemyX, enemyY);
                    enemyX = 10;
                    printDefender(enemyX, enemyY, ref defender3);

                }
            }
        }
        public void generateBulletEnemy2(int[] bullet3X, int[] bullet3Y, ref int enemyX, ref int enemyY, ref int bulletCounter2, bool[] isBulletActiveEnemy2)
        {
            bullet3X[bulletCounter2] = enemyY - 1;
            bullet3Y[bulletCounter2] = enemyX;
            isBulletActiveEnemy2[bulletCounter2] = true;
            Console.SetCursorPosition(enemyY - 1, enemyX);
            Console.Write("*");
            bulletCounter2++;
        }
        public void makeBulletInactiveEnemy2(int index, bool[] isBulletActiveEnemy2)
        {
            isBulletActiveEnemy2[index] = false;
        }
       public void printBulletEnemy2(int enemyX, int enemyY)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write("*");
        }
        public void eraseBulletEnemy2(int enemyX, int enemyY)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write(" ");
        }
       public void moveBulletEnemy2(ref int bulletCounter2, bool[] isBulletActiveEnemy2, int[] bullet3X, int[] bullet3Y, char[,] maze)
        {
            for (int x = 0; x < bulletCounter2; x++)
            {
                if (isBulletActiveEnemy2[x] == true)
                {
                    if (maze[bullet3Y[x], bullet3X[x] - 1] != ' ')
                    {
                        eraseBulletEnemy2(bullet3X[x], bullet3Y[x]);
                        makeBulletInactiveEnemy2(x, isBulletActiveEnemy2);

                    }
                    else
                    {
                        eraseBulletEnemy2(bullet3X[x], bullet3Y[x]);
                        bullet3X[x] = bullet3X[x] - 1;
                        printBulletEnemy2(bullet3X[x], bullet3Y[x]);
                    }
                }
            }
        }
       public void generateBulletEnemy(int[] bullet2X, int[] bullet2Y, ref int enemyX, ref int enemyY, ref int bulletCounter, bool[] isBulletActiveEnemy)
        {
            bullet2X[bulletCounter] = enemyY + 1;
            bullet2Y[bulletCounter] = enemyX;
            isBulletActiveEnemy[bulletCounter] = true;
            Console.SetCursorPosition(enemyY + 1, enemyX);
            Console.Write("*");
            bulletCounter++;
        }
       public void makeBulletInactiveEnemy(int index, bool[] isBulletActiveEnemy)
        {
            isBulletActiveEnemy[index] = false;
        }
        public void printBulletEnemy(int enemyX, int enemyY)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write("*");
        }
        public void eraseBulletEnemy(int enemyX, int enemyY)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write(" ");
        }
        public void moveBulletEnemy(ref int bulletCounter, bool[] isBulletActiveEnemy, int[] bullet2X, int[] bullet2Y, char[,] maze)
        {
            for (int x = 0; x < bulletCounter; x++)
            {
                if (isBulletActiveEnemy[x] == true)
                {
                    if (maze[bullet2Y[x], bullet2X[x] + 1] != ' ')
                    {
                        eraseBulletEnemy(bullet2X[x], bullet2Y[x]);
                        makeBulletInactiveEnemy(x, isBulletActiveEnemy);

                    }
                    else
                    {
                        eraseBulletEnemy(bullet2X[x], bullet2Y[x]);
                        bullet2X[x] = bullet2X[x] + 1;
                        printBulletEnemy2(bullet2X[x], bullet2Y[x]);
                    }
                }
            }
        }
        public void bulletCollisionWithEnemy(ref int bulletCount, bool[] isBulletActive, int[] bulletX, int[] bulletY, int enemy2X, int enemy2Y, ref int score)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (isBulletActive[x] == true)
                {
                    if ((bulletX[x] + 1 == enemy2Y && (bulletY[x]  == enemy2X)))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((enemy2Y - 1 == bulletX[x] && enemy2X +1 == bulletY[x])))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        public void bulletCollisionWithEnemyLeft(ref int bulletCountR, bool[] isBulletActiveR, int[] bulletRX, int[] bulletRY,  int enemy2X,  int enemy2Y, ref int score)
        {
            for (int x = 0; x < bulletCountR; x++)
            {
                if (isBulletActiveR[x] == true)
                {
                    if ((bulletRX[x] - 1 == enemy2Y && (bulletRY[x] == enemy2X)))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((enemy2Y + 1 == bulletRX[x] && enemy2X + 1 == bulletRY[x])))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        public void bulletCollisionWithEnemyUp(ref int bulletCountL, bool[] isBulletActiveL, int[] bulletLX, int[] bulletLY,  int enemy2X,  int enemy2Y, ref int score)
        {
            for (int x = 0; x < bulletCountL; x++)
            {
                if (isBulletActiveL[x] == true)
                {
                    if ((bulletLX[x] == enemy2Y && (bulletLY[x] - 1 == enemy2X)))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((enemy2Y + 1 == bulletLX[x] && enemy2X - 1 == bulletLY[x])))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        public void bulletCollisionWithEnemyDown(ref int bulletCountD, bool[] isBulletActiveD, int[] bulletDX, int[] bulletDY,  int enemy2X, int enemy2Y, ref int score)
        {
            for (int x = 0; x < bulletCountD; x++)
            {
                if (isBulletActiveD[x] == true)
                {
                    if ((bulletDX[x] == enemy2Y && (bulletDY[x] - 1 == enemy2X)))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((enemy2Y + 1 == bulletDX[x] && enemy2X + 1 == bulletDY[x])))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        public void bulletCollisionWithPlayerLeft(ref int bulletCounter2, bool[] isBulletActiveEnemy2, int[] bullet3X, int[] bullet3Y, Player position, ref int health1)
        {
            for (int x = 0; x < bulletCounter2; x++)
            {
                if (isBulletActiveEnemy2[x] == true)
                {
                    if (bullet3Y[x] == position.y && bullet3X[x] + 1 == position.x)
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                    if (position.x + 1 == bullet3X[x] && position.y - 1 == bullet3Y[x])
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                }
            }
        }
        public int health(ref int health1)
        {
            health1 = health1 - 1;
            return health1;
        }
        public void bulletCollisionWithPlayer(ref int bulletCounter, bool[] isBulletActiveEnemy, int[] bullet2X, int[] bullet2Y, Player position, ref int health1)
        {
            for (int x = 0; x < bulletCounter; x++)
            {
                if (isBulletActiveEnemy[x] == true)
                {
                    if (bullet2Y[x] == position.y && bullet2X[x] - 1 == position.x)
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                    if (position.x + 1 == bullet2X[x] && position.y - 1 == bullet2Y[x])
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                }
            }
        }
        public void playerCollision(Player position ,  ref int enemyX, ref int enemyY, ref int health1)
        {
            if (position.x  == enemyX || position.y == enemyY)
            {
                health1 = health(ref health1);
                Console.SetCursorPosition(110, 39);
                Console.Write("Health : " + health1);
            }
        }
    }
}
