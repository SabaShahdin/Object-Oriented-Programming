using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
namespace TASK1.BL
{
    public class Pacman
    {
        public int px ;
        public int py ;
        public int score  = 0 ;
        public Grid mazegrid;

        public Pacman(int x , int y , Grid mazeGrid)
        {
            this.px = x ;
            this.py = y ;
            this. mazegrid = mazeGrid;

        }
         public void remove()
        {
            Console.SetCursorPosition(py , px);
            Console.Write(" ");
            mazegrid.maze[px, py].setValue(' ');

        }
         public void draw()
        {
            Console.SetCursorPosition(py , px);
            Console.Write("P");
            mazegrid.maze[px, py].setValue('P');

        }
        public void moveLeft()
        {
            if (mazegrid.maze[px , py - 1].getValue() == ' ' ||mazegrid.maze[px , py - 1].getValue() == '.')
            {
                remove();
                py = py - 1;
                draw();
            }
            if(mazegrid.maze[px , py - 1].getValue() == '.')
            {
                calculateScore();
                printScore();
            }
        }
        public void moveRight()
        {
            if (mazegrid.maze[px , py + 1].getValue() == ' ' || mazegrid.maze[px , py + 1].getValue() == '.')
            {
                remove();
                py = py + 1;
                draw();
            }
            if(mazegrid.maze[px , py + 1].getValue() == '.')
            {
                calculateScore();
                printScore();
            }
        }
        public void moveUp()
        {
            if (mazegrid.maze[px- 1 , py].getValue() == ' ' || mazegrid.maze[px- 1 , py].getValue() == '.')
            {
                remove();
                px = px - 1;
                draw();
            }
            if(mazegrid.maze[px- 1 , py].getValue() == '.')
            {
                calculateScore();
                printScore();
            }
        }
        public void moveDown()
        {
            if (mazegrid.maze[px + 1 , py].getValue() == ' ' || mazegrid.maze[px + 1 , py].getValue() == '.')
            {
                remove();
                px = px + 1;
                draw();
            }
            if(mazegrid.maze[px+ 1 , py].getValue() == ' ')
            {
                calculateScore();
                printScore();
            }
        }
        public void printScore()
        {
            Console.SetCursorPosition(79, 12);
            Console.WriteLine("Score: " + score);
        }
        public void calculateScore()
        {
            score = score + 1;
        }
        public void move ()
        {                
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveUp();
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveDown();
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveLeft();
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveRight();
                }
        }

    }
}
