using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman2
{ 
    public class GameCell
    {
        private int x;
        private int y;
        private GameObject currentGameObject;
        private GameGrid gameGrid;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public GameObject CurrentGameObject { get => currentGameObject; set => currentGameObject = value; }
        public GameGrid GameGrid { get => gameGrid; set => gameGrid = value; }

        public GameCell()
        {

        }
        public GameCell(int x, int y, GameGrid gameGrid)
        {
            this.X = x;
            this.Y = y;
            this.GameGrid = gameGrid;
        }
        public GameCell nextCell(GameDirection direction)
        {
            if (direction == GameDirection.Left)
            {
                if (this.Y > 0)
                {
                    GameCell cell = GameGrid.GetCell(this.x , this.y - 1);
                    if (cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return cell;
                    }
                }
            }
            else if (direction == GameDirection.Right)
            {
                if (this.Y < GameGrid.columns - 1)
                {
                    GameCell cell = GameGrid.GetCell(this.x, this.y+ 1);
                    if (cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return cell;
                    }
                }
            }
            else if (direction == GameDirection.Up)
            {
                if (this.X > 0)
                {
                    GameCell cell = GameGrid.GetCell(this.x - 1, this.y);
                    if (cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return cell;
                    }
                }
            }
            else if (direction == GameDirection.Down)
            {
                if (this.X < GameGrid.rows - 1)
                {
                    GameCell cell = GameGrid.GetCell(this.x + 1, this.y);
                    if (cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return cell;
                    }
                }
            }
            return this;
        }
        public void moveHorizontal( GameCell cell)
        {
           GameDirection direction = GameDirection.Left;
            if (direction == GameDirection.Left)
            {
                if (cell.Y > 0)
               {
                    cell = GameGrid.GetCell(cell.x, cell.y - 1);
                    if (cell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                    {
                        direction = GameDirection.Right;
                    }
                }
            }
            if (direction == GameDirection.Right)
            {
                if (cell.Y < GameGrid.columns - 1)
                {                   
                    cell = GameGrid.GetCell(cell.x, cell.y + 1);
                     if (cell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                     {
                        direction = GameDirection.Left;
                     }
                }

            }
        }
    }
}
