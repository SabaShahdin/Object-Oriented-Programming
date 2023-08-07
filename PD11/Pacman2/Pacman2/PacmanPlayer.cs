using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman2
{
    public class PacmanPlayer : GameObject
    {
        public PacmanPlayer(char displayCharacter, GameCell startCell) : base(GameObjectType.PLAYER, displayCharacter)
        {
            this.currentCell = startCell;
        }
        public GameCell move(GameDirection gameDirection)
        {
            return this.currentCell.nextCell(gameDirection);
        }
        public GameCell GetGameCell()
        {
            return this.currentCell;
        }
    }
}
