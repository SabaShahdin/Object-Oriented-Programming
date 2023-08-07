using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class GameCell
    {
        public int x;
        public int y;
        public GameObject currentGameObject;
        public GameGrid gameGrid;

        public GameCell(int x, int y, GameGrid gameGrid)
        {
            this.x = x;
            this.y = y;
            this.gameGrid = gameGrid;
        }
        public GameCell nextCell(GameDirection direction)
        {
            if (direction == GameDirection.Left)
            {
                if (this.y > 0)
                {
                    GameCell cell = gameGrid.GetCell(x, y - 1);
                    if (cell.currentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return cell;
                    }
                }
            }
            else if (direction == GameDirection.Right)
            {
                if (this.y < gameGrid.columns - 1)
                {
                    GameCell cell = gameGrid.GetCell(x, y + 1);
                    if (cell.currentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return cell;
                    }
                }
            }
            else if (direction == GameDirection.Up)
            {
                if (this.x > 0)
                {
                    GameCell cell = gameGrid.GetCell(x - 1, y);
                    if (cell.currentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return cell;
                    }
                }
            }
            else if (direction == GameDirection.Down)
            {
                if (this.x < gameGrid.rows - 1)
                {
                    GameCell cell = gameGrid.GetCell(x + 1, y);
                    if (cell.currentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return cell;
                    }
                }
            }
            return null;
        }
    }
}
