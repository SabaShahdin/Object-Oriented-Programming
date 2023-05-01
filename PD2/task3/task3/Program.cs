


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using EZInput;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Player position = new Player();
            position.x = 6;
            position.y = 14;
            int ascii5 = 1;
            int health1 = 100;
            int energy = 0;
            int enemyX = 10;
            int enemyY = 50;
            char previous = ' ';
            string direction = "Down";
            int ascii1 = 219;
            char defender3 = Convert.ToChar(ascii1);
            char[,] maze = new char[36, 114];
            char baller = Convert.ToChar(ascii5);
            char ball = baller;
            int[] bulletX = new int[1000];
            int[] bulletY = new int[1000];
            bool[] isBulletActive = new bool[1000];
            int bulletCount = 0;
            int[] bulletRX = new int[1000];
            int[] bulletRY = new int[1000];
            bool[] isBulletActiveR = new bool[1000];
            int bulletCountR = 0;
            int[] bulletLX = new int[1000];
            int[] bulletLY = new int[1000];
            bool[] isBulletActiveL = new bool[1000];
            int bulletCountL = 0;
            int[] bulletDX = new int[1000];
            int[] bulletDY = new int[1000];
            bool[] isBulletActiveD = new bool[1000];
            int bulletCountD = 0;
            int[] bullet3X = new int[1000];
            int[] bullet3Y = new int[1000];
            bool[] isBulletActiveEnemy2 = new bool[1000];
            int bulletCounter2 = 0;
            int[] bullet2X = new int[1000];
            int[] bullet2Y = new int[1000];
            bool[] isBulletActiveEnemy = new bool[1000];
            int bulletCounter = 0;
            int score = 0;
            readData(maze);
            printMaze(maze);
            print(ref score,ref  health1 , ref energy);
            Console.SetCursorPosition(position.y, position.x);
            Console.Write(ball);
            while (true)
            {
                Thread.Sleep(100);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveUp(maze, position ,  ball, ref score , ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveDown(maze, position , ball, ref score , ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveLeft(maze, position, ball, ref score , ref energy );
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveRight(maze, position , ball, ref score , ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    generateBullet(bulletX, bulletY, ref bulletCount, position, isBulletActive);
                }
                if (Keyboard.IsKeyPressed(Key.Num0))
                {
                    generateBulletLeft(bulletRX, bulletRY, ref bulletCountR, position , isBulletActiveR);
                }
                if (Keyboard.IsKeyPressed(Key.Num1))
                {
                    generateBulletUP(bulletLX, bulletLY, ref bulletCountL,position ,  isBulletActiveL);
                }
                if (Keyboard.IsKeyPressed(Key.Num2))
                {
                    generateBulletDOWN(bulletDX, bulletDY, ref bulletCountD, position , isBulletActiveD);
                }
                moveBullet(bulletX, bulletY, ref bulletCount, isBulletActive, maze);
                moveBulletLeft(bulletRX, bulletRY, ref bulletCountR, isBulletActiveR, maze);
                moveBulletUP(bulletLX, bulletLY, ref bulletCountL, isBulletActiveL, maze);
                moveBulletDOWN(bulletDX, bulletDY, ref bulletCountD, isBulletActiveD, maze);
                defender2(ref direction, maze, ref enemyX, ref enemyY, ref previous, ref defender3);
                generateBulletEnemy2(bullet3X, bullet3Y, ref enemyX, ref enemyY, ref bulletCounter2, isBulletActiveEnemy2);
                moveBulletEnemy2(ref bulletCounter2, isBulletActiveEnemy2, bullet3X, bullet3Y, maze);
                generateBulletEnemy(bullet2X, bullet2Y, ref enemyX, ref enemyY, ref bulletCounter, isBulletActiveEnemy);
                moveBulletEnemy(ref bulletCounter, isBulletActiveEnemy, bullet2X, bullet2Y, maze);
                bulletCollisionWithEnemy(ref bulletCount, isBulletActive, bulletX, bulletY,  enemyX, enemyY, ref score);
                bulletCollisionWithEnemyLeft(ref bulletCountR, isBulletActiveR, bulletRX, bulletRY, enemyX, enemyY, ref score);
                bulletCollisionWithEnemyUp(ref bulletCountL, isBulletActiveL, bulletLX, bulletLY, enemyX,  enemyY, ref score);
                bulletCollisionWithEnemyDown(ref bulletCountD, isBulletActiveD, bulletDX, bulletDY, enemyX,  enemyY, ref score);
                bulletCollisionWithPlayerLeft(ref bulletCounter2, isBulletActiveEnemy2, bullet3X, bullet3Y, position, ref health1);
                bulletCollisionWithPlayer(ref bulletCounter, isBulletActiveEnemy, bullet2X, bullet2Y, position, ref health1);
                playerCollision(position, ref enemyX, ref enemyY, ref health1);
                }
            }
        static void printMaze(char[,] maze)
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
        static void readData(char[,] maze)
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
        static void moveUp(char[,] maze, Player position ,  char ball, ref int score , ref int energy)
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
        static void moveDown(char[,] maze, Player position ,  char ball, ref int score , ref int energy)
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
        static void moveLeft(char[,] maze, Player position, char ball, ref int score , ref int energy)
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
        static void moveRight(char[,] maze, Player position, char ball, ref int score, ref int energy)
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
         static void generateBullet(int[] bulletX, int[] bulletY, ref int bulletCount, Player position , bool[] isBulletActive)
         {
                bulletX[bulletCount] = position.y + 1;
                bulletY[bulletCount] = position.x;
                isBulletActive[bulletCount] = true;
                Console.SetCursorPosition(position.y + 1, position.x);
                Console.Write("-");
                bulletCount++;
         }
        static void moveBullet(int[] bulletX, int[] bulletY, ref int bulletCount, bool[] isBulletActive, char[,] maze)
        {
            for (int x = 0; x < bulletCount - 1; x++)
            {
                if (isBulletActive[x] == true)
                {
                    if (maze[bulletY[x] , bulletX[x] + 1 ] != ' ')
                    {
                        eraseBullet(bulletX[x] , bulletY[x] );
                        makeBulletInactive(x, isBulletActive);
                    }
                    else
                    {
                        eraseBullet(bulletX[x] , bulletY[x] );
                        bulletX[x] = bulletX[x] + 1;
                        printBullet(bulletX[x] , bulletY[x] );
                    }
                }
            }

        }
        static void printBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }
        static void eraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        static void makeBulletInactive(int index, bool[] isBulletActive)
        {
            isBulletActive[index] = false;

        }
        static void generateBulletLeft(int[] bulletRX, int[] bulletRY, ref int bulletCountR, Player position , bool[] isBulletActiveR)
        {
            bulletRX[bulletCountR] = position.y - 1;
            bulletRY[bulletCountR] = position.x;
            isBulletActiveR[bulletCountR] = true;
            Console.SetCursorPosition(position.y - 1, position.x);
            Console.Write("-");
            bulletCountR++;
        }
        static void moveBulletLeft(int[] bulletRX, int[] bulletRY, ref int bulletCountR, bool[] isBulletActiveR, char[,] maze)
        {
            for (int x = 0; x < bulletCountR; x++)
            {
                if (isBulletActiveR[x] == true)
                {

                    if (maze[bulletRY[x] , bulletRX[x] - 1 ] != ' ')
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
        static void printBulletLeft(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }
        static void eraseBulletLeft(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        static void makeBulletInactiveLeft(int index, bool[] isBulletActiveR)
        {
            isBulletActiveR[index] = false;
        }

        static int addScore(ref int score)
        {
            score = score + 1;
            return score;
        }
        static void generateBulletUP(int[] bulletLX, int[] bulletLY, ref int bulletCountL, Player position , bool[] isBulletActiveL)
        {
            bulletLX[bulletCountL] = position.y;
            bulletLY[bulletCountL] = position.x - 1;
            isBulletActiveL[bulletCountL] = true;
            Console.SetCursorPosition(position.y, position.x - 1);
            Console.Write("-");
            bulletCountL++;
        }
        static void moveBulletUP(int[] bulletLX, int[] bulletLY, ref int bulletCountL, bool[] isBulletActiveL, char[,] maze)
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
        static void printBulletUP(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }
        static void eraseBulletUP(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        static void makeBulletInactiveUP(int index, bool[] isBulletActiveL)
        {
            isBulletActiveL[index] = false;
        }
        static int addEnergy(ref int energy)
        {
            energy = energy + 1;
            return energy;
        }
    static void generateBulletDOWN(int[] bulletDX, int[] bulletDY, ref int bulletCountD, Player position , bool[] isBulletActiveD)
    {
        bulletDX[bulletCountD] = position.y;
        bulletDY[bulletCountD] = position.x + 1;
        isBulletActiveD[bulletCountD] = true;
        Console.SetCursorPosition(position.y, position.x + 1);
        Console.Write("-");
        bulletCountD++;
    }
        static void moveBulletDOWN(int[] bulletDX, int[] bulletDY, ref int bulletCountD, bool[] isBulletActiveD, char[,] maze)
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
        static void printBulletDOWN(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }
        static void eraseBulletDOWN(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        static void makeBulletInactiveDOWN(int index, bool[] isBulletActiveD)
        {
            isBulletActiveD[index] = false;
        }
        static void printDefender(int x, int y, ref char defender3)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(defender3);
        }
        static void eraseDefender(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
        }
        static void defender2(ref string direction, char[,] maze, ref int enemyX, ref int enemyY, ref char previous, ref char defender3)
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
        static void generateBulletEnemy2(int[] bullet3X, int[] bullet3Y, ref int enemyX, ref int enemyY, ref int bulletCounter2, bool[] isBulletActiveEnemy2)
        {
            bullet3X[bulletCounter2] = enemyY - 1;
            bullet3Y[bulletCounter2] = enemyX;
            isBulletActiveEnemy2[bulletCounter2] = true;
            Console.SetCursorPosition(enemyY - 1, enemyX);
            Console.Write("*");
            bulletCounter2++;
        }
        static void makeBulletInactiveEnemy2(int index, bool[] isBulletActiveEnemy2)
        {
            isBulletActiveEnemy2[index] = false;
        }
        static void printBulletEnemy2(int enemyX, int enemyY)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write("*");
        }
        static void eraseBulletEnemy2(int enemyX, int enemyY)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write(" ");
        }
        static void moveBulletEnemy2(ref int bulletCounter2, bool[] isBulletActiveEnemy2, int[] bullet3X, int[] bullet3Y, char[,] maze)
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
        static void generateBulletEnemy(int[] bullet2X, int[] bullet2Y, ref int enemyX, ref int enemyY, ref int bulletCounter, bool[] isBulletActiveEnemy)
        {
            bullet2X[bulletCounter] = enemyY + 1;
            bullet2Y[bulletCounter] = enemyX;
            isBulletActiveEnemy[bulletCounter] = true;
            Console.SetCursorPosition(enemyY + 1, enemyX);
            Console.Write("*");
            bulletCounter++;
        }
        static void makeBulletInactiveEnemy(int index, bool[] isBulletActiveEnemy)
        {
            isBulletActiveEnemy[index] = false;
        }
        static void printBulletEnemy(int enemyX, int enemyY)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write("*");
        }
        static void eraseBulletEnemy(int enemyX, int enemyY)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write(" ");
        }
        static void moveBulletEnemy(ref int bulletCounter, bool[] isBulletActiveEnemy, int[] bullet2X, int[] bullet2Y, char[,] maze)
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
        static void print(ref int score, ref int health1 , ref int energy )
        {
            Console.SetCursorPosition(110, 38);
            Console.Write("Score: " + score);
            Console.SetCursorPosition(110, 39);
            Console.Write("Health: " + health1);
            Console.SetCursorPosition(110, 40);
            Console.Write("Energy: " + energy);
        }
        static void bulletCollisionWithEnemy(ref int bulletCount, bool[] isBulletActive, int[] bulletX, int[] bulletY, int enemy2X, int enemy2Y, ref int score)
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
        static void bulletCollisionWithEnemyLeft(ref int bulletCountR, bool[] isBulletActiveR, int[] bulletRX, int[] bulletRY,  int enemy2X,  int enemy2Y, ref int score)
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
        static void bulletCollisionWithEnemyUp(ref int bulletCountL, bool[] isBulletActiveL, int[] bulletLX, int[] bulletLY,  int enemy2X,  int enemy2Y, ref int score)
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
        static void bulletCollisionWithEnemyDown(ref int bulletCountD, bool[] isBulletActiveD, int[] bulletDX, int[] bulletDY,  int enemy2X, int enemy2Y, ref int score)
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
        static void bulletCollisionWithPlayerLeft(ref int bulletCounter2, bool[] isBulletActiveEnemy2, int[] bullet3X, int[] bullet3Y, Player position, ref int health1)
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
                    if (position.x + 1 == bullet3X[x] && position.y + 1 == bullet3Y[x])
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                }
            }
        }
        static int health(ref int health1)
        {
            health1 = health1 - 1;
            return health1;
        }
        static void bulletCollisionWithPlayer(ref int bulletCounter, bool[] isBulletActiveEnemy, int[] bullet2X, int[] bullet2Y, Player position, ref int health1)
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
                    if (position.x + 1 == bullet2X[x] && position.y + 1 == bullet2Y[x])
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                }
            }
        }
        static void playerCollision(Player position ,  ref int enemyX, ref int enemyY, ref int health1)
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
