using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman2
{
    public class SmartGhost :Ghost
    {
        public SmartGhost(char displayCharacter, GameCell startCell) : base(displayCharacter, startCell)
        {
            this.currentCell = startCell;
        }
        public  double calculateDistance(GameCell cell , GameCell pacman)
        {
            PacmanPlayer p = new PacmanPlayer('P', currentCell);
            pacman = p.GetGameCell();
            return Math.Sqrt(Math.Pow((pacman.X - cell.X), 2) + Math.Pow((pacman.Y - cell.Y), 2));
        }
        public override GameCell Move(GameCell currentCell)
        {
            GameDirection currentDirection = CurrentDirection;
            PacmanPlayer p = new PacmanPlayer('P', currentCell);
            GameCell Cell = currentCell;
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };

            if (Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                GameCell nextCell = Cell.nextCell(GameDirection.Left);
                GameCell pacman = p.GetGameCell();
                distance[0] = calculateDistance(nextCell, pacman);
            }

            if (Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                GameCell nextCell = Cell.nextCell(GameDirection.Right);
                GameCell pacman = p.GetGameCell();
                distance[1] = calculateDistance(nextCell, pacman);
            }

            if (Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                GameCell nextCell = Cell.nextCell(GameDirection.Down);
                GameCell pacman = p.GetGameCell();
                distance[2] = calculateDistance(nextCell, pacman);
            }

            if (Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                GameCell nextCell = Cell.nextCell(GameDirection.Up);
                GameCell pacman = p.GetGameCell();
                distance[3] = calculateDistance(nextCell, pacman);
            }

            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                currentDirection = GameDirection.Left;
                Cell = Cell.nextCell(currentDirection);
            }
            else if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                currentDirection = GameDirection.Right;
                Cell = Cell.nextCell(currentDirection);
            }
            else if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                currentDirection = GameDirection.Down;
                Cell = Cell.nextCell(currentDirection);
            }
            else
            {
                currentDirection = GameDirection.Up;
                Cell = Cell.nextCell(currentDirection);
            }

            return Cell;
        }


    }
}
