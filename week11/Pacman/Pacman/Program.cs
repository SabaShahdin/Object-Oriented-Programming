using EZInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            GameGrid grid = new GameGrid("maze.txt", 24 , 71);
            GameCell start = new GameCell(12, 22, grid);
            PacmanPlayer pacman = new PacmanPlayer('P', start);
            printMaze(grid);
            printGameObject(pacman);
            Console.ReadKey();

            bool gameRunning = true;
            while (gameRunning)
            {
                Thread.Sleep(90);
               if (Keyboard.IsKeyPressed(Key.UpArrow))
               {
                 moveGameObject(pacman, GameDirection.Up);
                }

               if (Keyboard.IsKeyPressed(Key.DownArrow))
               {
                    moveGameObject(pacman, GameDirection.Down);
               }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveGameObject(pacman, GameDirection.Right);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                   moveGameObject(pacman, GameDirection.Left);
                }
            }
        }
        public static void clearGameCellContent(GameCell gameCell, GameObject newGameObject)
        {
            gameCell.currentGameObject = newGameObject;
            Console.SetCursorPosition(gameCell.y, gameCell.x);
            Console.Write(newGameObject.displayCharacter);

        }
        public static void printGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.CurrentCell.y, gameObject.CurrentCell.x);
            Console.Write(gameObject.displayCharacter);

        }

        public  static void moveGameObject(GameObject gameObject, GameDirection direction)
        {
            GameCell nextCell = gameObject.CurrentCell.nextCell(direction);
            if (nextCell != null)
            {
                GameObject newGO = new GameObject(GameObjectType.NONE, ' ');
                GameCell currentCell = gameObject.CurrentCell;
                clearGameCellContent(currentCell, newGO);
                gameObject.CurrentCell = nextCell;
                printGameObject(gameObject);
           }
        }

        public static void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.rows; x++)
            {
                for (int y = 0; y < grid.columns; y++)
                {
                    GameCell cell = grid.GetCell(x, y);
                    printCell(cell);
                }

            }
        }

        public static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.y, cell.x);
            Console.Write(cell.currentGameObject.displayCharacter);
        }

    }
}