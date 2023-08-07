using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman2
{
    public class Horizontal_Ghost : Ghost 
    {
         public Horizontal_Ghost(char displayCharacter, GameCell startCell  ) : base (displayCharacter , startCell )
          {
            this.currentCell = startCell;
            this.CurrentDirection = GameDirection.Right;
             
          }
        
        public override GameCell Move(GameCell currentCell)
        {
            GameDirection currentDirection = CurrentDirection;
            GameCell nextCell = null;

            if (currentDirection == GameDirection.Left)
            {
                nextCell = currentCell.nextCell(GameDirection.Left);
                if (nextCell == currentCell || nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                {
                    CurrentDirection = GameDirection.Right;
                    nextCell = currentCell.nextCell(GameDirection.Right);
                }
            }
            else if (currentDirection == GameDirection.Right)
            {
                nextCell = currentCell.nextCell(GameDirection.Right);
                if (nextCell == currentCell || nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                {
                    CurrentDirection = GameDirection.Left;
                    nextCell = currentCell.nextCell(GameDirection.Left);
                }
            }

            return nextCell;
        }
    }
}
