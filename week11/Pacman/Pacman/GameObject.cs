using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class GameObject
    {
        public char displayCharacter;
        public GameObjectType GameObjectType;
        public GameCell CurrentCell;

        public GameObject(GameObjectType type, char DisplayCharacter)
        {
            GameObjectType = type;
            this.displayCharacter = DisplayCharacter;
        }
        public static GameObjectType GetGameObjectType(char displayCharacter)
        {
            if (displayCharacter == '|' || displayCharacter == '#' || displayCharacter == '%')
            {
                return GameObjectType.WALL;
            }
            if (displayCharacter == '.')
            {
                return GameObjectType.REWARD;
            }
            return GameObjectType.NONE;
        }
    }
}
