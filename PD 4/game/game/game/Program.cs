using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.IO;
using System.Threading;
namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Player pos = new Player();
            Bullet bul = new Bullet();
            DefenderBullet Dbul = new DefenderBullet();
            EnemyBullet enBul = new EnemyBullet();
            int x = 6;
            int y = 14;
            Player position = new Player(x, y);
            int ascii5 = 1;
            int enemyX = 10;
            int enemyY = 50;
            Enemy enemyPos = new Enemy(enemyX, enemyY);
            int enemy2X = 13;
            int enemy2Y = 20;
            Defender enemy = new Defender(enemy2X, enemy2Y);
            char previous = ' ';
            string direction = "Down";
            char previous2 = ' ';
            string direction2 = "Right";
            int ascii1 = 219;
            int ascii2 =  900;
            int health1 = 100;
            char defender3 = Convert.ToChar(ascii1);
            char defender4 = Convert.ToChar(ascii2);
            char[,] maze = new char[36, 114];
            char baller = Convert.ToChar(ascii5);
            char ball = baller;
            int score = 0;
            int energy = 0;
            readData(maze);
            printMaze(maze);
            Console.SetCursorPosition(position.y, position.x);
            Console.Write(ball);
            Console.ReadKey();
            while (true)
            {
                Thread.Sleep(100);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveUp(maze, position, ball, ref score, ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveDown(maze, position, ball, ref score, ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveLeft(maze, position, ball, ref score, ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveRight(maze, position, ball, ref score, ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    bul.generateBullet(position);
                }
                if (Keyboard.IsKeyPressed(Key.Num0))
                {
                    bul.generateBulletLeft(position);
                }
                if (Keyboard.IsKeyPressed(Key.Num1))
                {
                    bul.generateBulletUP(position);
                }
                if (Keyboard.IsKeyPressed(Key.Num2))
                {
                    bul.generateBulletDOWN(position);
                }
                moveBullet(bul, maze);
                moveBulletLeft(bul, maze);
                moveBulletUP(bul, maze);
                moveBulletDOWN(bul, maze);
                defender2(ref direction, maze, enemyPos, ref previous, ref defender3);
                defender(ref direction2, maze, enemy, ref previous2, ref defender4);
                enBul.generateBulletEnemy2(enemyPos);
                moveBulletEnemy2(enBul, maze);
                Dbul.generateBulletDefender2(enemy);
                moveBulletDefender(Dbul , maze);
                enBul.generateBulletEnemy(enemyPos);
                moveBulletEnemy(enBul, maze);
                Dbul.generateBulletDefender(enemy);
                 moveBulletDefender2(Dbul, maze);
                bulletCollisionWithEnemy(enemyPos, bul, score , enemy);
                bulletCollisionWithEnemyLeft(enemyPos, bul, enemy ,  ref score);
                bulletCollisionWithEnemyUp(enemyPos, bul, enemy ,  ref score);
                bulletCollisionWithEnemyDown(enemyPos, bul, enemy ,  ref score);
                bulletCollisionWithPlayerLeft(enBul, position, ref health1);
                bulletCollisionWithPlayer(enBul, position, ref health1);
                bulletCollisionWithPlayerUp(Dbul, position, ref health1);
                bulletCollisionWithPlayerDown(Dbul, position, ref health1);
                playerCollision(position, enemyPos, ref health1 , enemy);
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
        static void moveUp(char[,] maze, Player position, char ball, ref int score, ref int energy)
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
        static void moveDown(char[,] maze, Player position, char ball, ref int score, ref int energy)
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
        static void moveLeft(char[,] maze, Player position, char ball, ref int score, ref int energy)
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
        static int addScore(ref int score)
        {
            score = score + 1;
            return score;
        }
        static int addEnergy(ref int energy)
        {
            energy = energy + 1;
            return energy;
        }
        static void moveBullet(Bullet bul, char[,] maze)
        {
            for (int x = 0; x < bul.bulletCount - 1; x++)
            {
                if (bul.isBulletActive[x] == true)
                {
                    if (maze[bul.bulletY[x], bul.bulletX[x] + 1] != ' ')
                    {
                        eraseBullet(bul.bulletX[x], bul.bulletY[x]);
                        bul.makeBulletInactive(x);
                    }
                    else
                    {
                        eraseBullet(bul.bulletX[x], bul.bulletY[x]);
                        bul.bulletX[x] = bul.bulletX[x] + 1;
                        printBullet(bul.bulletX[x], bul.bulletY[x]);
                    }
                }
            }

        }
        static void moveBulletLeft(Bullet bul, char[,] maze)
        {
            for (int x = 0; x < bul.bulletCountR; x++)
            {
                if (bul.isBulletActiveR[x] == true)
                {

                    if (maze[bul.bulletRY[x], bul.bulletRX[x] - 1] != ' ')
                    {
                        eraseBullet(bul.bulletRX[x], bul.bulletRY[x]);
                        bul.makeBulletInactiveLeft(x);
                    }
                    else
                    {
                        eraseBullet(bul.bulletRX[x], bul.bulletRY[x]);
                        bul.bulletRX[x] = bul.bulletRX[x] - 1;
                        printBullet(bul.bulletRX[x], bul.bulletRY[x]);
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
        static void moveBulletUP(Bullet bul, char[,] maze)
        {
            for (int x = 0; x < bul.bulletCountL; x++)
            {
                if (bul.isBulletActiveL[x] == true)
                {
                    if (maze[bul.bulletLY[x] - 1, bul.bulletLX[x]] != ' ')
                    {
                        eraseBullet(bul.bulletLX[x], bul.bulletLY[x]);
                        bul.makeBulletInactiveUP(x);
                    }
                    else
                    {
                        eraseBullet(bul.bulletLX[x], bul.bulletLY[x]);
                        bul.bulletLY[x] = bul.bulletLY[x] - 1;
                        printBullet(bul.bulletLX[x], bul.bulletLY[x]);
                    }
                }
            }
        }
        static void moveBulletDOWN(Bullet bul, char[,] maze)
        {
            for (int x = 0; x < bul.bulletCountD; x++)
            {
                if (bul.isBulletActiveD[x] == true)
                {

                    if (maze[bul.bulletDY[x] + 1, bul.bulletDX[x]] != ' ')
                    {
                        eraseBullet(bul.bulletDX[x], bul.bulletDY[x]);
                        bul.makeBulletInactiveDOWN(x);
                    }
                    else
                    {
                        eraseBullet(bul.bulletDX[x], bul.bulletDY[x]);
                        bul.bulletDY[x] = bul.bulletDY[x] + 1;
                        printBullet(bul.bulletDX[x], bul.bulletDY[x]);
                    }
                }

            }
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
        static void defender2(ref string direction, char[,] maze, Enemy enePos, ref char previous, ref char defender3)
        {
            if (direction == "Up")
            {
                if (maze[enePos.enemyX - 1, enePos.enemyY] == ' ' || maze[enePos.enemyX - 1, enePos.enemyY] == '>' || maze[enePos.enemyX - 1, enePos.enemyY] == '$')
                {
                    eraseDefender(enePos.enemyX, enePos.enemyY);
                    enePos.enemyX--;
                    printDefender(enePos.enemyX, enePos.enemyY, ref defender3);
                }
                if (maze[enePos.enemyX - 1, enePos.enemyY] == '#' || maze[enePos.enemyX - 1, enePos.enemyY] == '%')
                {
                    direction = "Down";
                    eraseDefender(enePos.enemyX, enePos.enemyY);
                    enePos.enemyX = 10;
                    printDefender(enePos.enemyX, enePos.enemyY, ref defender3);
                }
            }
            if (direction == "Down")
            {
                if (maze[enePos.enemyX + 1, enePos.enemyY] == ' ' || maze[enePos.enemyX + 1, enePos.enemyY] == '>' || maze[enePos.enemyX + 1, enePos.enemyY] == '$')
                {
                    eraseDefender(enePos.enemyX, enePos.enemyY);
                    enePos.enemyX++;
                    printDefender(enePos.enemyX, enePos.enemyY, ref defender3);
                }
                if (maze[enePos.enemyX + 1, enePos.enemyY] == '#' || maze[enePos.enemyX + 1, enePos.enemyY] == '%')
                {
                    direction = "Up";
                    eraseDefender(enePos.enemyX, enePos.enemyY);
                    enePos.enemyX = 10;
                    printDefender(enePos.enemyX, enePos.enemyY, ref defender3);

                }
            }
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
        static void moveBulletEnemy2(EnemyBullet ene, char[,] maze)
        {
            for (int x = 0; x < ene.bulletCounter2; x++)
            {
                if (ene.isBulletActiveEnemy2[x] == true)
                {
                    if (maze[ene.bullet3Y[x], ene.bullet3X[x] - 1] != ' ')
                    {
                        eraseBulletEnemy2(ene.bullet3X[x], ene.bullet3Y[x]);
                        ene.makeBulletInactiveEnemy2(x);

                    }
                    else
                    {
                        eraseBulletEnemy2(ene.bullet3X[x], ene.bullet3Y[x]);
                        ene.bullet3X[x] = ene.bullet3X[x] - 1;
                        printBulletEnemy2(ene.bullet3X[x], ene.bullet3Y[x]);
                    }
                }
            }
        }
        
        static void moveBulletEnemy(EnemyBullet ene, char[,] maze)
        {
            for (int x = 0; x < ene.bulletCounter; x++)
            {
                if (ene.isBulletActiveEnemy[x] == true)
                {
                    if (maze[ene.bullet2Y[x], ene.bullet2X[x] + 1] != ' ')
                    {
                        eraseBulletEnemy2(ene.bullet2X[x], ene.bullet2Y[x]);
                        ene.makeBulletInactiveEnemy(x);

                    }
                    else
                    {
                        eraseBulletEnemy2(ene.bullet2X[x], ene.bullet2Y[x]);
                        ene.bullet2X[x] = ene.bullet2X[x] + 1;
                        printBulletEnemy2(ene.bullet2X[x], ene.bullet2Y[x]);
                    }
                }
            }
        }
        static void bulletCollisionWithEnemy(Enemy ene, Bullet b1, int score , Defender ene2)
        {
            for (int x = 0; x < b1.bulletCount; x++)
            {
                if (b1.isBulletActive[x] == true)
                {
                    if ((b1.bulletX[x] + 1 == ene.enemyY && (b1.bulletY[x] == ene.enemyX)) || (b1.bulletX[x] + 1 == ene2.enemy2Y && (b1.bulletY[x] == ene2.enemy2X)))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((ene.enemyY - 1 == b1.bulletX[x] && ene.enemyX + 1 == b1.bulletY[x]))  || ((ene2.enemy2Y - 1 == b1.bulletX[x] && ene2.enemy2X + 1 == b1.bulletY[x])))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        static void bulletCollisionWithEnemyLeft(Enemy ene, Bullet b1, Defender ene2 ,  ref int score)
        {
            for (int x = 0; x < b1.bulletCountR; x++)
            {
                if (b1.isBulletActiveR[x] == true)
                {
                    if ((b1.bulletRX[x] - 1 == ene.enemyY && (b1.bulletRY[x] == ene.enemyX)) || (b1.bulletRX[x] - 1 == ene2.enemy2Y && (b1.bulletRY[x] == ene2.enemy2X)))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((ene.enemyY + 1 == b1.bulletRX[x] && ene.enemyX + 1 == b1.bulletRY[x]))  || ((ene2.enemy2Y + 1 == b1.bulletRX[x] && ene2.enemy2X + 1 == b1.bulletRY[x])))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        static void bulletCollisionWithEnemyUp(Enemy ene, Bullet b1, Defender ene2  , ref int score)
        {
            for (int x = 0; x < b1.bulletCountL; x++)
            {
                if (b1.isBulletActiveL[x] == true)
                {
                    if ((b1.bulletLX[x] == ene.enemyY && (b1.bulletLY[x] - 1 == ene.enemyX)) || (b1.bulletLX[x] == ene2.enemy2Y && (b1.bulletLY[x] - 1 == ene2.enemy2X)))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((ene.enemyY + 1 == b1.bulletLX[x] && ene.enemyX - 1 == b1.bulletLY[x])  || ((ene2.enemy2Y + 1 == b1.bulletLX[x] && ene2.enemy2X - 1 == b1.bulletLY[x]))))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        static void bulletCollisionWithEnemyDown(Enemy ene, Bullet b1, Defender ene2  , ref int score)
        {
            for (int x = 0; x < b1.bulletCountD; x++)
            {
                if (b1.isBulletActiveD[x] == true)
                {
                    if ((b1.bulletDX[x] == ene.enemyY && (b1.bulletDY[x] - 1 == ene.enemyX)) || (b1.bulletDX[x] == ene2.enemy2Y && (b1.bulletDY[x] - 1 == ene2.enemy2X)))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                    if (((ene.enemyY + 1 == b1.bulletDX[x] && ene.enemyX + 1 == b1.bulletDY[x])) || ((ene2.enemy2Y + 1 == b1.bulletDX[x] && ene2.enemy2X + 1 == b1.bulletDY[x])))
                    {
                        score = addScore(ref score);
                        Console.SetCursorPosition(110, 38);
                        Console.Write("Score: " + score);
                    }
                }
            }
        }
        static void bulletCollisionWithPlayerLeft(EnemyBullet e1, Player position, ref int health1)
        {
            for (int x = 0; x < e1.bulletCounter2; x++)
            {
                if (e1.isBulletActiveEnemy2[x] == true)
                {
                    if (e1.bullet3Y[x] == position.y && e1.bullet3X[x] + 1 == position.x)
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                    if (position.x + 1 == e1.bullet3X[x] && position.y  == e1.bullet3Y[x])
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
        static void bulletCollisionWithPlayer(EnemyBullet e1, Player position, ref int health1)
        {
            for (int x = 0; x < e1.bulletCounter; x++)
            {
                if (e1.isBulletActiveEnemy[x] == true)
                {
                    if (e1.bullet2Y[x] == position.y && e1.bullet2X[x] - 1 == position.x)
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                    if (position.x + 1 == e1.bullet2X[x] && position.y == e1.bullet2Y[x])
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                }
            }
        }
        static void bulletCollisionWithPlayerUp(DefenderBullet e1, Player position,  ref int health1)
        {
            for (int x = 0; x < e1.bulletCounterDef2; x++)
            {
                if (e1.isBulletActiveDefEnemy[x] == true)
                {
                    if (e1.bulletDefY[x]  + 1 == position.y && e1.bulletDefX[x] == position.x)
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                    if (position.x + 1 == e1.bulletDefX[x] && position.y  == e1.bulletDefY[x])
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                }
            }
        }
        static void bulletCollisionWithPlayerDown(DefenderBullet e1, Player position, ref int health1)
        {
            for (int x = 0; x < e1.bulletCounterDef; x++)
            {
                if (e1.isBulletActiveDefEnemy1[x] == true)
                {
                    if (e1.bulletDef2Y[x] - 1 == position.y && e1.bulletDef2X[x] == position.x)
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                    if (position.x + 1 == e1.bulletDef2X[x] && position.y  == e1.bulletDef2Y[x])
                    {
                        health1 = health(ref health1);
                        Console.SetCursorPosition(110, 39);
                        Console.Write("Health : " + health1);
                    }
                }
            }
        }
        static void playerCollision(Player position, Enemy e1, ref int health1 , Defender e2)
        {
            if (position.x == e1.enemyX || position.y == e1.enemyY ||  position.x == e2.enemy2X || position.y == e2.enemy2Y )
            {
                health1 = health(ref health1);
                Console.SetCursorPosition(110, 39);
                Console.Write("Health : " + health1);
            }
        }
        static void printDefender2(int x, int y, ref char defender4)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(defender4);
        }
        static void eraseDefender2(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
        }
        static void defender(ref string direction, char[,] maze, Defender enemy , ref char previous, ref char defender4)
        {
            if (direction == "Right")
            {
                if (maze[enemy.enemy2X, enemy.enemy2Y -1 ] == ' ' || maze[enemy.enemy2X, enemy.enemy2Y - 1] == '>' || maze[enemy.enemy2X, enemy.enemy2Y - 1] == '$')
                {
                    eraseDefender2(enemy.enemy2X, enemy.enemy2Y);
                    enemy.enemy2Y--;
                    printDefender2(enemy.enemy2X, enemy.enemy2Y, ref defender4);
                }
                if (maze[enemy.enemy2X, enemy.enemy2Y - 1] == '#' || maze[enemy.enemy2X , enemy.enemy2Y -1 ] == '%' || maze[enemy.enemy2X, enemy.enemy2Y - 1] == '|')
                {
                    direction = "Left";
                    eraseDefender2(enemy.enemy2X, enemy.enemy2Y);
                    enemy.enemy2Y = 20;
                    printDefender2(enemy.enemy2X, enemy.enemy2Y, ref defender4);
                }
            }
            if (direction == "Left")
            {
                if (maze[enemy.enemy2X, enemy.enemy2Y +  1] == ' ' || maze[enemy.enemy2X, enemy.enemy2Y + 1] == '>' || maze[enemy.enemy2X, enemy.enemy2Y + 1] == '$')
                {
                    eraseDefender2(enemy.enemy2X, enemy.enemy2Y);
                    enemy.enemy2Y++;
                    printDefender(enemy.enemy2X, enemy.enemy2Y, ref defender4);
                }
                if (maze[enemy.enemy2X, enemy.enemy2Y + 1] == '#' || maze[enemy.enemy2X, enemy.enemy2Y  +  1] == '%' || maze[enemy.enemy2X, enemy.enemy2Y + 1] == '|')
                {
                    direction = "Left";
                    eraseDefender2(enemy.enemy2X, enemy.enemy2Y);
                    enemy.enemy2Y = 20;
                    printDefender2(enemy.enemy2X, enemy.enemy2Y, ref defender4);
                }
            }
        }
        static void printBulletDefender(int enemy2X, int enemy2Y)
        {
            Console.SetCursorPosition(enemy2X, enemy2Y);
            Console.Write("*");
        }
        static void eraseBulletDefender(int enemy2X, int enemy2Y)
        {
            Console.SetCursorPosition(enemy2X, enemy2Y);
            Console.Write(" ");
        }
        static void moveBulletDefender(DefenderBullet ene, char[,] maze)
        {
            for (int x = 0; x < ene.bulletCounterDef2; x++)
            {
                if (ene.isBulletActiveDefEnemy[x] == true)
                {
                    if (maze[ene.bulletDefY[x] -1  , ene.bulletDefX[x] ] != ' ')
                    {
                        eraseBulletDefender(ene.bulletDefX[x], ene.bulletDefY[x]);
                        ene.makeBulletInactiveDefender2(x);

                    }
                    else
                    {
                        eraseBulletDefender(ene.bulletDefX[x], ene.bulletDefY[x]);
                        ene.bulletDefY[x] = ene.bulletDefY[x] - 1;
                        printBulletDefender(ene.bulletDefX[x], ene.bulletDefY[x]);
                    }
                }
            }
        }
        static void moveBulletDefender2(DefenderBullet ene, char[,] maze)
        {
            for (int x = 0; x < ene.bulletCounterDef; x++)
            {
                if (ene.isBulletActiveDefEnemy1[x] == true)
                {
                    if (maze[ene.bulletDef2Y[x] + 1 , ene.bulletDef2X[x]] != ' ')
                    {
                        eraseBulletDefender(ene.bulletDef2X[x], ene.bulletDef2Y[x]);
                        ene.makeBulletInactiveDefender(x);

                    }
                    else
                    {
                        eraseBulletDefender(ene.bulletDef2X[x], ene.bulletDef2Y[x]);
                        ene.bulletDef2Y[x] = ene.bulletDef2Y[x] + 1;
                        printBulletDefender(ene.bulletDef2X[x], ene.bulletDef2Y[x]);
                    }
                }
            }
        }
    }
}
