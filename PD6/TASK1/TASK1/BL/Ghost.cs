using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK1.BL
{
    public class Ghost
    {
        public int gx ;
        public int gy ;
        public string ghostDirection ;
        public char ghostCharcater;
        public float speed;
        public char previousItem ;
        public float deltaChange ;
        public Grid mazegrid;

        public Ghost(int x , int y , char ghostCharacter ,  string ghostDirection ,float speed , char previousItem , Grid maze)
        {
            this.gx = x ;
            this.gy = y ;
            this.ghostDirection = ghostDirection;
            this.ghostCharcater = ghostCharacter;
            this.speed = speed;
            this.previousItem = previousItem;
            this.deltaChange = deltaChange;
            this.mazegrid = maze ;
        }
        public void SetGhostDirection (string GhostDirection)
        {
            this.ghostDirection  = GhostDirection ;
        }
        public string GetDirection ()
        {
           return this.ghostDirection ; 
        }
        public char  GetCharacter ()
        {
           return this.ghostCharcater ; 
        }
        public void draw()
        {
            char character = GetCharacter();
           Console.SetCursorPosition(gy, gx);
           Console.Write(character);
        }
        public void ChangeDelta()
        {
            deltaChange = deltaChange + speed ;
        }
        public float getDelta ()
        {
            return deltaChange ;
        }
        public void SetDeltaZero()
        {
            deltaChange = 0 ;
        }
        public void move (Grid mazeGrid)
        {
            ChangeDelta ();
            if(Math.Floor(getDelta()) == 1)
            {
                if(ghostCharcater == 'V')
                {
                    moveVertical( );
                }
                else  if(ghostCharcater == 'H')
                {
                    moveHorizontal( );
                } 
                else if(ghostCharcater == 'S')
                {
                    moveSmart();
                }
                else if(ghostCharcater == 'R')
                {
                    moveRandom();
                }
               SetDeltaZero();
            }

        }
        public void remove()
        {
            Console.SetCursorPosition(gy , gx);
            Console.Write(previousItem);
            if (mazegrid.maze[gx, gy].getValue() == 'P')
            {
               mazegrid.maze[gx, gy].setValue(' ');
            }
            else
            {
                mazegrid.maze[gx, gy].setValue(previousItem);
            }
        }
        public void moveVertical ( )
        {
           if (ghostDirection == "up")
           {              
               if (mazegrid.maze[gx-1 , gy].getValue() == ' ' || mazegrid.maze[gx-1 , gy].getValue() == '.' )
               {
                   remove();                 
                   gx --;
                   draw();
               }
               else
               {
                    ghostDirection = "down";
               }
           }
           if (ghostDirection == "down")
           {
               if (mazegrid.maze[gx+ 1 , gy].getValue() == ' ' || mazegrid.maze[gx+1 , gy].getValue() == '.'  )
               {
                   remove();                
                    gx++;
                    draw();
               }
               else 
               {
                    ghostDirection = "up";
               }
            }
           
        }
        public void moveHorizontal ( )
        {
           if (ghostDirection == "right")
           {              
               if (mazegrid.maze[gx, gy + 1 ].getValue() == ' '  || mazegrid.maze[gx, gy + 1 ].getValue() == '.' )
               {
                   remove();                 
                   gy ++;
                   draw();
               }
               else
               {
                    ghostDirection = "left";
               }
           }
           if (ghostDirection == "left")
           {
               if (mazegrid.maze[gx, gy - 1].getValue() == ' ' || mazegrid.maze[gx, gy - 1].getValue() == '.' )
               {
                   remove();                
                    gy--;
                    draw();
               }
               else 
               {
                    ghostDirection = "right";
               }
            }
        }
        public void moveSmart()
        {
            Cell c = new Cell(gx, gy , ghostCharcater);
            double[] distance = new double[4] {1000000,1000000,1000000,1000000};
            if (mazegrid.maze[gx , gy - 1].getValue() != '|' || mazegrid.maze[gx , gy - 1].getValue() != '%' )
            {
                distance[0] = (calculateDistance(mazegrid.GetLeftCell(c) , mazegrid.findPacman()));
            }
            if (mazegrid.maze[gx , gy + 1].getValue()  != '|' || mazegrid.maze[gx , gy + 1].getValue()  != '%'  )
            {
                distance[1] = (calculateDistance(mazegrid.GetRightCell(c) , mazegrid.findPacman()));
            }
            if (mazegrid.maze[gx + 1, gy ].getValue() != '|' || mazegrid.maze[gx + 1, gy ].getValue() != '%'  ||  mazegrid.maze[gx + 1, gy ].getValue() != '#'  )
            {
                distance[2] = (calculateDistance(mazegrid.GetDownCell(c) , mazegrid.findPacman()));
            }
            if (mazegrid.maze[gx - 1, gy ].getValue() != '|' || mazegrid.maze[gx - 1, gy ].getValue() != '%' ||  mazegrid.maze[gx - 1, gy ].getValue() != '#')
            {
                distance[3] = (calculateDistance(mazegrid.GetUpCell(c)  , mazegrid.findPacman()));
            }
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                string direction = "left";
                moveHorizontal();
            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                string direction = "right";
                moveHorizontal();
            }
            if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                string direction = "down";
                moveVertical();
            }
            else
            {
                string direction = "up";
                moveVertical();
            }
        }
        public double calculateDistance(Cell current, Cell pacmanLocation)
        {
            double distance = Math.Sqrt((Math.Pow(pacmanLocation.getX() - current.getX(), 2) + (Math.Pow(pacmanLocation.getY() - current.getY(), 2))));
            return distance;
        }
        public int ghostdirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
        public void  moveRandom()
        {
            int value = ghostdirection();
            if (value == 0)
            {
                if (mazegrid.maze[gx, gy - 1].getValue() == '.'|| mazegrid.maze[gx, gy - 1].getValue() == ' '|| mazegrid.maze[gx, gy - 1].getValue() == 'P')
                {
                    remove();                
                    gy--;
                    draw();
                }
            }
            else if (value == 1)
            {
                if (mazegrid.maze[gx, gy + 1].getValue() == '.'|| mazegrid.maze[gx, gy + 1].getValue() == ' '|| mazegrid.maze[gx, gy + 1].getValue() == 'P')
                {
                   remove();                
                    gy++;
                    draw();
                }
            }
            else if (value == 2)
            {
                if (mazegrid.maze[gx - 1, gy ].getValue() == '.'|| mazegrid.maze[gx -1 , gy ].getValue() == ' '|| mazegrid.maze[gx - 1, gy].getValue() == 'P')
                {
                    remove();                
                    gx--;
                    draw();
                }
            }
            else if (value == 3)
            {
                if (mazegrid.maze[gx + 1, gy ].getValue() == '.'|| mazegrid.maze[gx + 1 , gy ].getValue() == ' '|| mazegrid.maze[gx + 1, gy].getValue() == 'P')
                {
                    remove();                
                    gx++;
                    draw();
                }
            }
        }

    }
}
