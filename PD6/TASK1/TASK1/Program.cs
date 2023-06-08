using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK1.BL;
using System.Threading;

namespace TASK1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "maze.txt";
            
            Grid mazeGrid = new Grid(24, 70 , path);
            Pacman p1 = new Pacman (9 , 32 , mazeGrid);
            Ghost ghost1 = new Ghost (6, 22 , 'V', "up" , 0.1F ,' ',mazeGrid);
            Ghost ghost2 = new Ghost (15, 39 , 'H', "left" , 0.2F ,' ',mazeGrid);
            Ghost ghost3 = new Ghost (20, 12, 'S', "up" , 1F ,' ',mazeGrid);
            Ghost ghost4 = new Ghost (18, 21, 'R', "up" , 0.5F ,' ',mazeGrid);
            mazeGrid.draw();
            List<Ghost> ghost = new List<Ghost> ();
            ghost.Add(ghost1);
            ghost.Add(ghost2);
            ghost.Add(ghost3);
            ghost.Add(ghost4);
            p1.draw() ;
            bool gameRunning = true ;
            while(gameRunning)
            {
                Thread.Sleep (90);
                p1.remove ();
                p1.move();
                p1.draw();
                foreach(Ghost g in ghost)
                { 
                  g.remove();
                  g.move(mazeGrid);
                  g.draw();
                }
            if(mazeGrid.isStoppingCondition())
            {
                gameRunning = false ;
            }
              Console.ReadKey();
            }

           
        }
    }
}
