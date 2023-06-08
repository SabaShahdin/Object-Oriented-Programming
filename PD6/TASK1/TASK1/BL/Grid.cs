using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.IO;
namespace TASK1.BL
{
    public class Grid
    {
        public Cell[,] maze;
        public int rowSize;
        public int columnSize;
        public List<Cell> location = new List<Cell>() ;
        public Grid(int rowSize, int columnSize, string path)
        {
            this.rowSize = rowSize;
            this.columnSize = columnSize;
            maze = new Cell[rowSize , columnSize ];

            readMenuFile(path);         
        }
        public Cell GetLeftCell(Cell c)
        {
            int x = c.getX();
            int y = c.getY();
             return maze[x   , y - 1];
        }
        public Cell GetRightCell(Cell c)
        {
           int x = c.getX();
            int y = c.getY();
             return maze[x, y +  1];
        }
        public Cell GetUpCell(Cell c)
        { 
            int x = c.getX();
            int y = c.getY();
            return maze[x - 1 , y  ];
        }
        public Cell GetDownCell(Cell c)
        {
           int x = c.getX();
            int y = c.getY();
            return maze[x + 1  ,y ];
        }
        public Cell findPacman()
        {
           for (int x = 0; x < rowSize; x++)
           {
              for (int y = 0; y < columnSize; y++)
              {
                if (maze[x , y ].IsPacmanPresent())
                {
                    return maze[x , y ];
                }
              }
           }
           return null ;
        }
        public Cell FindGhost(char ghostCharacter)
        {
           for (int x = 0; x < rowSize; x++)
           {
              for (int y = 0; y < columnSize; y++)
              {
                if (maze[x, y].value == ghostCharacter)
                {
                    return maze[x, y];
                }
              }
           }
           return null ; 
        }
        public bool isStoppingCondition()
        {
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void draw()
        {
            for (int x = 0; x < rowSize; x++)
            {
                for (int y = 0; y < columnSize; y++)
                {
                    Console.Write(maze[x, y].value);
                }
                Console.WriteLine();
            }
        }
        public void readMenuFile(string path)
        {
            StreamReader file = new StreamReader(path);
            string record;

            if (File.Exists(path))
            {
                for (int x =0; x < rowSize ; x++)
                {
                       record = file.ReadLine(); 
                     for(int y = 0; y < columnSize ; y ++)
                     {
                            char value = record[y];
                            Cell cell = new Cell(x, y, value);
                            maze[x, y] = cell;
                     }
                }
            }
            file.Close();
        }
    }
}
