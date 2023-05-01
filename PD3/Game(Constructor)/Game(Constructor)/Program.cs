using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EZInput;
using System.Threading;


namespace Game_Constructor_
{
    class Program
    {
        static void Main(string[] args)
        {
            Player pos = new Player();
            int x = 6;
            int y = 14;
            Player position = new Player(x, y);
            char[,] maze = new char[36, 114];
            int ascii5 = 1;
            int enemyX = 10;
            int enemyY = 50;
            int health1 = 100;
            char previous = ' ';
            string direction = "Down";
            int ascii1 = 219;
            char defender3 = Convert.ToChar(ascii1);
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
            int energy = 0;
            pos.readData(maze);
            pos.printMaze(maze);
            Console.SetCursorPosition(position.y, position.x);
            Console.Write(ball);
            while (true)
            {
                Thread.Sleep(100);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    pos.moveUp(maze, position, ball, ref score, ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    pos.moveDown(maze, position, ball, ref score, ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    pos.moveLeft(maze, position, ball, ref score, ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    pos.moveRight(maze, position, ball, ref score, ref energy);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    pos.generateBullet(bulletX, bulletY, ref bulletCount, position, isBulletActive);
                }
                if (Keyboard.IsKeyPressed(Key.Num0))
                {
                    pos.generateBulletLeft(bulletRX, bulletRY, ref bulletCountR, position, isBulletActiveR);
                }
                if (Keyboard.IsKeyPressed(Key.Num1))
                {
                    pos.generateBulletUP(bulletLX, bulletLY, ref bulletCountL, position, isBulletActiveL);
                }
                if (Keyboard.IsKeyPressed(Key.Num2))
                {
                    pos.generateBulletDOWN(bulletDX, bulletDY, ref bulletCountD, position, isBulletActiveD);
                }
               pos. moveBullet(bulletX, bulletY, ref bulletCount, isBulletActive, maze);
               pos. moveBulletLeft(bulletRX, bulletRY, ref bulletCountR, isBulletActiveR, maze);
               pos. moveBulletUP(bulletLX, bulletLY, ref bulletCountL, isBulletActiveL, maze);
               pos. moveBulletDOWN(bulletDX, bulletDY, ref bulletCountD, isBulletActiveD, maze);
                pos.defender2(ref direction, maze, ref enemyX, ref enemyY, ref previous, ref defender3);
                pos.generateBulletEnemy2(bullet3X, bullet3Y, ref enemyX, ref enemyY, ref bulletCounter2, isBulletActiveEnemy2);
                pos.moveBulletEnemy2(ref bulletCounter2, isBulletActiveEnemy2, bullet3X, bullet3Y, maze);
                pos.generateBulletEnemy(bullet2X, bullet2Y, ref enemyX, ref enemyY, ref bulletCounter, isBulletActiveEnemy);
                pos.moveBulletEnemy(ref bulletCounter, isBulletActiveEnemy, bullet2X, bullet2Y, maze);
                pos. bulletCollisionWithEnemy(ref bulletCount, isBulletActive, bulletX, bulletY,  enemyX, enemyY, ref score);
                pos.bulletCollisionWithEnemyLeft(ref bulletCountR, isBulletActiveR, bulletRX, bulletRY, enemyX, enemyY, ref score);
                pos.bulletCollisionWithEnemyUp(ref bulletCountL, isBulletActiveL, bulletLX, bulletLY, enemyX,  enemyY, ref score);
                pos.bulletCollisionWithEnemyDown(ref bulletCountD, isBulletActiveD, bulletDX, bulletDY, enemyX,  enemyY, ref score);
                pos.bulletCollisionWithPlayerLeft(ref bulletCounter2, isBulletActiveEnemy2, bullet3X, bullet3Y, position, ref health1);
                 pos. bulletCollisionWithPlayer(ref bulletCounter, isBulletActiveEnemy, bullet2X, bullet2Y, position, ref health1);
                pos.playerCollision(position, ref enemyX, ref enemyY, ref health1);
                //  Console.ReadKey();
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
    }
}
