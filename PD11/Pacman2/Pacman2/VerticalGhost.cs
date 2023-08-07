using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman2
{
    public class VerticalGhost : Ghost
    {
        public VerticalGhost(char displayCharacter, GameCell startCell) : base(displayCharacter, startCell)
        {
            this.currentCell = startCell;
            this.CurrentDirection = GameDirection.Up;

        }

        public override GameCell Move(GameCell currentCell)
        {
            GameDirection currentDirection = CurrentDirection;
            GameCell Cell = null;

            if (currentDirection == GameDirection.Up)
            {
                Cell = currentCell.nextCell(GameDirection.Up);
                if (Cell == currentCell || Cell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                {
                    CurrentDirection = GameDirection.Down;
                    Cell = currentCell.nextCell(GameDirection.Down);
                }
            }
            else if (currentDirection == GameDirection.Down)
            {
                Cell = currentCell.nextCell(GameDirection.Down);
                if (Cell == currentCell || Cell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                {
                    CurrentDirection = GameDirection.Up;
                    Cell = currentCell.nextCell(GameDirection.Up);
                }
            }

            return Cell;
        }
    }
}
