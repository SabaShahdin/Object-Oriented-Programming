using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class GameGrid
    {
        public GameCell[,] GameCells;
        public int rows;
        public int columns;

        public GameGrid(string filename, int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            GameCells = new GameCell[rows, columns];
            loadGrid(filename);
        }
        private void loadGrid(string filename)
        {
            StreamReader file = new StreamReader(filename);
            string line = " ";
            for (int row = 0; row < rows; row++)
            {
                line = file.ReadLine();
                for (int col = 0; col < columns; col++)
                {
                    GameCell cell = new GameCell(row, col, this);
                    char displayCharacter = line[col];
                    GameObjectType type = GameObject.GetGameObjectType(displayCharacter);
                    GameObject gameObject = new GameObject(type, displayCharacter);
                    cell.currentGameObject = gameObject;
                    GameCells[row, col] = cell;
                }
            }
            file.Close();
        }
        public GameCell GetCell(int x, int y)
        {
            return GameCells[x, y];
        }
    }
}
