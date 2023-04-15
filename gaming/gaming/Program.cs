using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using EZInput;

namespace gaming
{
    class Program
    {
        static void Main(string[] args)
        {
            int px = 6;
            int py = 14;
            int ascii1 = 219;
            int ascii5 = 1;
            char baller = Convert.ToChar(ascii5);
            char defender3 = Convert.ToChar(ascii1);
            char ball = baller;
            int enemyX = 10;
            int enemyY = 50;
            char previous = ' ';
            string direction = "Down";
            int score = 0;
            int health1 = 100;

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

            char[,] maze = new char[36, 114];

            readData(maze);
            printMaze(maze);
            print(score, health1);
            Console.SetCursorPosition(py, px);
            Console.Write(ball);
            while (true)
            {
                Thread.Sleep(90);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveUp(maze, ref px, ref py, ball, score);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveDown(maze, ref px, ref py, ball, score);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveLeft(maze, ref px, ref py, ball, score);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveRight(maze, ref px, ref py, ball, score);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    generateBullet(bulletX, bulletY, ref bulletCount, ref py, ref px, isBulletActive);
                }
                if (Keyboard.IsKeyPressed(Key.Num0))
                {
                    generateBulletLeft(bulletRX, bulletRY, ref bulletCountR, ref px, ref py, isBulletActiveR);
                }
                if (Keyboard.IsKeyPressed(Key.Num1))
                {
                    generateBulletUP(bulletLX, bulletLY, ref bulletCountL, ref px, ref py, isBulletActiveL);
                }
                if (Keyboard.IsKeyPressed(Key.Num2))
                {
                    generateBulletDOWN(bulletDX, bulletDY, ref bulletCountD, ref px, ref py, isBulletActiveD);
                }
                generateBulletEnemy2(bullet3X, bullet3Y, ref enemyX, ref enemyY, ref bulletCounter2, isBulletActiveEnemy2);
                moveBullet(bulletX, bulletY, ref bulletCount, isBulletActive, maze);
                moveBulletLeft(bulletRX, bulletRY, ref bulletCountR, isBulletActiveR, maze);
                moveBulletDOWN(bulletDX, bulletDY, ref bulletCountD, isBulletActiveD, maze);
                moveBulletUP(bulletLX, bulletLY, ref bulletCountL, isBulletActiveL, maze);
                defender2(ref direction, maze, ref enemyX, ref enemyY, ref previous, ref defender3);
                bulletCollisionWithEnemy(ref bulletCount, isBulletActive, bulletX, bulletY, ref enemyX, ref enemyY, ref score);
                bulletCollisionWithEnemyLeft(ref bulletCountR, isBulletActiveR, bulletRX, bulletRY, ref enemyX, ref enemyY, ref score);
                bulletCollisionWithEnemyUp(ref bulletCountL, isBulletActiveL, bulletLX, bulletLY, ref enemyX, ref enemyY, ref score);
                bulletCollisionWithEnemyDown(ref bulletCountD, isBulletActiveD, bulletDX, bulletDY, ref enemyX, ref enemyY, ref score);
                moveBulletEnemy2(ref bulletCounter2, isBulletActiveEnemy2, bullet3X, bullet3Y, maze);
                bulletCollisionWithPlayerLeft(ref bulletCounter2, isBulletActiveEnemy2, bullet3X, bullet3Y, ref py, ref px, health1);
                playerCollision(ref px, ref py, ref enemyX, ref enemyY, health1);
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
        static void moveUp(char[,] maze, ref int px, ref int py, char ball, int score)
        {
            if (maze[px - 1, py] == ' ' || maze[px - 1, py] == '>' || maze[px - 1, py] == '$')
            {
                maze[px, py] = ' ';
                Console.SetCursorPosition(py, px);
                Console.Write(" ");
                px = px - 1;
                Console.SetCursorPosition(py, px);
                maze[px, py] = ball;
                Console.Write(ball);
                if (maze[px - 1, py] == '>')
                {
                    score = addScore(score);
                    Console.SetCursorPosition(110, 38);
                    Console.Write("Score: " + score);
                }

            }
        }
        static void moveDown(char[,] maze, ref int px, ref int py, char ball, int score)
        {
            if (maze[px + 1, py] == ' ' || maze[px + 1, py] == '>' || maze[px + 1, py] == '$')
            {
                maze[px, py] = ' ';
                Console.SetCursorPosition(py, px);
                Console.Write(" ");
                px = px + 1;
                Console.SetCursorPosition(py, px);
                maze[px, py] = ball;
                Console.Write(ball);
                if (maze[px + 1, py] == '>')
                {
                    score = addScore(score);
                    Console.SetCursorPosition(110, 38);
                    Console.Write("Score: " + score);
                }

            }
        }

        static void moveLeft(char[,] maze, ref int px, ref int py, char ball, int score)
        {
            if (maze[px, py - 1] == ' ' || maze[px, py - 1] == '>' || maze[px, py - 1] == '$')
            {
                maze[px, py] = ' ';
                Console.SetCursorPosition(py, px);
                Console.Write(" ");
                py = py - 1;
                Console.SetCursorPosition(py, px);
                maze[px, py] = ball;
                Console.Write(ball);
                if (maze[px, py - 1] == '>')
                {
                    score = addScore(score);
                    Console.SetCursorPosition(110, 38);
                    Console.Write("Score: " + score);

                }

            }
        }

        static void moveRight(char[,] maze, ref int px, ref int py, char ball, int score)
        {
            if (maze[px, py + 1] == ' ' || maze[px, py + 1] == '>' || maze[px, py + 1] == '$')
            {
                maze[px, py] = ' ';
                Console.SetCursorPosition(py, px);
                Console.Write(" ");
                py = py + 1;
                Console.SetCursorPosition(py, px);
                maze[px, py] = ball;
                Console.Write(ball);
                if (maze[px, py + 1] == '>')
                {
                    score = addScore(score);
                    Console.SetCursorPosition(110, 38);
                    Console.Write("Score: " + score);
                }
            }
        }
        static void generateBullet(int[] bulletX, int[] bulletY, ref int bulletCount, ref int py, ref int px, bool[] isBulletActive)
        {
            bulletX[bulletCount] = py + 1;
            bulletY[bulletCount] = px;
            isBulletActive[bulletCount] = true;
            Console.SetCursorPosition(py + 1, px);
            Console.Write("-");
            bulletCount++;
        }
        static void moveBullet(int[] bulletX, int[] bulletY, ref int bulletCount, bool[] isBulletActive, char[,] maze)
        {
            for (int x = 0; x < bulletCount - 1; x++)
            {
                if (isBulletActive[x] == true)
                {
                    if (maze[bulletY[x] , bulletX[x] + 1] != ' ')
                    {
                        eraseBullet(bulletX[x] , bulletY[x] );
                        makeBulletInactive(x, isBulletActive);
                    }
                    else
                    {
                        eraseBullet(bulletX[x] , bulletY[x] );
                        bulletX[x] = bulletX[x] + 1;
                        printBullet(bulletX[x], bulletY[x]);
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
        static void generateBulletLeft(int[] bulletRX, int[] bulletRY, ref int bulletCountR, ref int px, ref int py, bool[] isBulletActiveR)
        {
            bulletRX[bulletCountR] = py - 1;
            bulletRY[bulletCountR] = px;
            isBulletActiveR[bulletCountR] = true;
            Console.SetCursorPosition(py - 1, px);
            Console.Write("-");
            bulletCountR++;
        }
        static void moveBulletLeft(int[] bulletRX, int[] bulletRY, ref int bulletCountR, bool[] isBulletActiveR, char[,] maze)
        {
            for (int x = 0; x < bulletCountR; x++)
            {
                if (isBulletActiveR[x] == true)
                {

                    if (maze[bulletRY[x] , bulletRX[x] - 1] != ' ')
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
        static void generateBulletUP(int[] bulletLX, int[] bulletLY, ref int bulletCountL, ref int px, ref int py, bool[] isBulletActiveL)
        {
            bulletLX[bulletCountL] = py;
            bulletLY[bulletCountL] = px - 1;
            isBulletActiveL[bulletCountL] = true;
            Console.SetCursorPosition(py, px - 1);
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
        static void generateBulletDOWN(int[] bulletDX, int[] bulletDY, ref int bulletCountD, ref int px, ref int py, bool[] isBulletActiveD)
        {
            bulletDX[bulletCountD] = py;
            bulletDY[bulletCountD] = px + 1;
            isBulletActiveD[bulletCountD] = true;
            Console.SetCursorPosition(py, px + 1);
            Console.Write("-");
            bulletCountD++;
            //  Console.Write(bulletDY);

        }
        static void moveBulletDOWN(int[] bulletDX, int[] bulletDY, ref int bulletCountD, bool[] isBulletActiveD, char[,] maze)
        {
            for (int x = 0; x < bulletCountD; x++)
            {
                if (isBulletActiveD[x] == true) //maze[py][px - 4]
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

        static void bulletCollisionWithEnemy(ref int bulletCount, bool[] isBulletActive, int[] bulletX, int[] bulletY, ref int enemy2X, ref int enemy2Y, ref int score)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (isBulletActive[x] == true)
                {
                    if ((bulletX[x] - 1 == enemy2Y && (bulletY[x] == enemy2X)))
                    {
                        score = addScore(score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((enemy2Y - 1 == bulletX[x] && enemy2X + 1 == bulletY[x])))
                    {
                        score = addScore(score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        static void bulletCollisionWithEnemyLeft(ref int bulletCountR, bool[] isBulletActiveR, int[] bulletRX, int[] bulletRY, ref int enemy2X, ref int enemy2Y, ref int score)
        {
            for (int x = 0; x < bulletCountR; x++)
            {
                if (isBulletActiveR[x] == true)
                {
                    if ((bulletRX[x] - 1 == enemy2Y && (bulletRY[x] == enemy2X)))
                    {
                        score = addScore(score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((enemy2Y + 1 == bulletRX[x] && enemy2X + 1 == bulletRY[x])))
                    {
                        score = addScore(score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        static void bulletCollisionWithEnemyUp(ref int bulletCountL, bool[] isBulletActiveL, int[] bulletLX, int[] bulletLY, ref int enemy2X, ref int enemy2Y, ref int score)
        {
            for (int x = 0; x < bulletCountL; x++)
            {
                if (isBulletActiveL[x] == true)
                {
                    if ((bulletLX[x] == enemy2Y && (bulletLY[x] - 1 == enemy2X)))
                    {
                        score = addScore(score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((enemy2Y + 1 == bulletLX[x] && enemy2X - 1 == bulletLY[x])))
                    {
                        score = addScore(score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        static void bulletCollisionWithEnemyDown(ref int bulletCountD, bool[] isBulletActiveD, int[] bulletDX, int[] bulletDY, ref int enemy2X, ref int enemy2Y, ref int score)
        {
            for (int x = 0; x < bulletCountD; x++)
            {
                if (isBulletActiveD[x] == true)
                {
                    if ((bulletDX[x] == enemy2Y && (bulletDY[x] - 1 == enemy2X)))
                    {
                        score = addScore(score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((enemy2Y + 1 == bulletDX[x] && enemy2X + 1 == bulletDY[x])))
                    {
                        score = addScore(score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        static int addScore(int score)
        {
            score = score + 1;
            return score;
        }
        static void print(int score, int health1)
        {
            Console.SetCursorPosition(110, 38);
            Console.Write("Score: " + score);
            Console.SetCursorPosition(110, 39);
            Console.Write("Health: " + health1);
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


                    if (maze[bullet3Y[x] - 1, bullet3X[x]] == ' ')
                    {
                        eraseBulletEnemy2(bullet3X[x], bullet3Y[x]);
                        bullet3X[x] = bullet3X[x] - 1;
                        printBulletEnemy2(bullet3X[x], bullet3Y[x]);
                    }
                    else
                    {
                        eraseBulletEnemy2(bullet3X[x], bullet3Y[x]);
                        makeBulletInactiveEnemy2(x, isBulletActiveEnemy2);
                    }
                }
            }
        }
        static void bulletCollisionWithPlayerLeft(ref int bulletCounter2, bool[] isBulletActiveEnemy2, int[] bullet3X, int[] bullet3Y, ref int py, ref int px, int health1)
        {
            for (int x = 0; x < bulletCounter2; x++)
            {
                if (isBulletActiveEnemy2[x] == true)
                {
                    if (bullet3Y[x] == py && bullet3X[x] + 1 == px)
                    {
                        health1 = health(health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                    if (py + 1 == bullet3X[x] && px + 1 == bullet3Y[x])
                    {
                        health1 = health(health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                }
            }

        }
        static void playerCollision(ref int px, ref int py, ref int enemyX, ref int enemyY, int health1)
        {
            if (px == enemyX || py == enemyY)
            {
                health1 = health(health1);
                Console.SetCursorPosition(110, 39);
                Console.Write("Health : " + health1);
            }
        }
        static int health(int health1)
        {
            health1 = health1 - 1;
            if (health1 == 990)
            {
                health1 = health1 % 10;
            }
            health1 = health1 - 1;
            return health1;
        }



    }
}
