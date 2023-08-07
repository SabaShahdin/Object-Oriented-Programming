using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman2
{
    public class RandomGhost : Ghost
    {
        public RandomGhost(char displayCharacter, GameCell startCell) : base(displayCharacter, startCell)
        {
            this.currentCell = startCell;

        }
        public  int ghostDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
        public override GameCell Move(GameCell currentCell)
        {
            GameDirection currentDirection = CurrentDirection;
            GameCell Cell = currentCell;
            int value = ghostDirection();
            if (value == 0)
            {
                if (Cell == currentCell || Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    currentDirection = GameDirection.Left;
                    Cell = currentCell.nextCell(currentDirection);
                 }
            }
            if (value == 1)
            {
                if (Cell == currentCell || Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    currentDirection = GameDirection.Right;
                    Cell = currentCell.nextCell(currentDirection);
                }
            }
            if (value == 2)
            {
                if (Cell == currentCell || Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    currentDirection = GameDirection.Up;
                    Cell = currentCell.nextCell(currentDirection);
                }
            }
            if (value == 3)
            {
                if (Cell == currentCell || Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    currentDirection = GameDirection.Down;
                    Cell = currentCell.nextCell(currentDirection);
                }
            }
            return Cell;
        }
    }
}
