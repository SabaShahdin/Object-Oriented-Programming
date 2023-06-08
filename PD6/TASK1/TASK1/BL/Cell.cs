using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TASK1.BL
{
    public class Cell
    {
        public char value;
        public int x ;
        public int y;
        public Cell(int x , int y)
        {
            this.x = x;
            this.y = y;
        }
       public Cell(int x , int y , char value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
        }
        public char getValue()
        {
            return value;
        }
        public char setValue(char Value)
        {
            this.value = Value;
            return value;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public bool IsPacmanPresent()
        {
           return value == 'P';
        }
        public bool IsGhostPresent(char character)
        {
           return value == character;
        }
    }
}
