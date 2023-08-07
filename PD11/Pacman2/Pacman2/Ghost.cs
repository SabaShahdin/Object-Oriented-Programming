using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman2
{
    public abstract class Ghost : GameObject
    {
        private GameCell CurrentCell;
        private GameGrid gameGrid;
        private GameDirection currentDirection;
        public GameDirection CurrentDirection { get => currentDirection; set => currentDirection = value; }

        public Ghost(char displayCharacter, GameCell startCell) : base(GameObjectType.ENEMY, displayCharacter)
        {

            this.CurrentCell = startCell;
            
        }
        public GameGrid GameGrid { get => gameGrid; set => gameGrid = value; }
        public GameCell CurrentCell1 { get => this.CurrentCell; set => this.CurrentCell = value; }

        public abstract GameCell Move(GameCell cell);
    }
}
