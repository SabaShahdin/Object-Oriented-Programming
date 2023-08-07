using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class PacmanPlayer : GameObject
    {
        public PacmanPlayer(char displayCharacter, GameCell startCell) : base(GameObjectType.PLAYER, displayCharacter)
        {
            this.CurrentCell = startCell;
        }
    }
}
