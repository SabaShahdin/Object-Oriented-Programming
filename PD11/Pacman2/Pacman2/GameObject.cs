using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman2
{
    public class GameObject 
    {
        private char displayCharacter;
        private GameObjectType gameObjectType;
        private GameCell CurrentCell;
        
        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value; }
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }

        public GameObject(GameObjectType type, char DisplayCharacter) 
        {
            GameObjectType = type;
            this.DisplayCharacter = DisplayCharacter;
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
        public GameCell currentCell
        {
            get => CurrentCell;
            set
            {
                CurrentCell = value;
                CurrentCell.CurrentGameObject = this;
            }
        }
    }
}
