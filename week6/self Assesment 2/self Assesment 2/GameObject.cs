using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using self_Assesment_2.BL;

namespace self_Assesment_2
{
     public class GameObject
    {
        public char[,] shape;
        public Point starting;
        public Boundary primeses;
        public string Direction;

        public GameObject ()
        {
            shape = new char[1, 3] { { '-', '-', '-' } };
          starting = new Point();
          primeses = new Boundary();
         Direction = "LeftToRight";
        }
        public GameObject(char[,] shape , Point starting  , string Direction , Boundary primeses )
        {
            this.shape = shape;
            this.starting = starting;
           this.Direction = Direction;
            this.primeses = primeses;
        }
        public  void move ()
        {           
            if(Direction == "LefttoRight")
            {
                if ((starting.x > primeses.TopLeft.x  && starting.x  < primeses.TopRight.y ))
                {
                      erase();
                      starting.x = starting.x + 1;
                      draw();
                }
                else if (starting.x  <=  primeses.TopRight.y)
                {                    
                      Direction = "RighttoLeft";
                }
            }
            else if(Direction == "RighttoLeft")
            {
                if ((starting.x > primeses.TopLeft.x  && starting.x  > primeses.TopRight.x))
                {
                      erase();
                      starting.x = starting.x - 1;
                      draw();
                }
                else if( starting.x  <=  primeses.TopRight.x)
                {
                   starting.x =  primeses.TopLeft.x + 1 ;
                     Direction = "LefttoRight";
                }
            }
            else if(Direction == "Projectile")
            {
                if ((starting.x >= primeses.TopLeft.x  && starting.x  < primeses.TopRight.y )  &&  (starting.y >= primeses.BottomLeft.y  && starting.y < primeses.BottomRight.y ))  //&& (starting.y >= primeses.BottomLeft.y  && starting.y <= primeses.BottomRight.y ))
                {
                    starting.y = starting.y - 5 ;
                    
                    starting.x = starting.x + 2 ;
                    starting.y = starting.y + 4 ;
                     starting.x = starting.x + 4 ;
                }
                else if (starting.x  <=  primeses.TopRight.y)
                {                    
                      Direction = "RighttoLeft"; 
                }
            }
            else if(Direction == "Diagonal")
            {
                 if(starting.x <= primeses.BottomRight.x)
                 {
                    starting.x = starting.x + 1 ;
                     starting.y = starting.y + 1;
                 }
            }
        }
        public void draw ()
        {
            for(int row  =0 ; row < shape.GetLength(0); row ++ )
            {
                 Console.SetCursorPosition(starting.x , starting.y +  row + 1 );  
                for(int col = 0 ; col < shape.GetLength(1) ; col++)
                {
                    
                     Console.Write(shape[row , col]);
                }
                  
                Console.WriteLine();
            
            }

        }
        public void erase ()
        {
            for(int row  =0 ; row < shape.GetLength(0) ; row ++ )
            {
                  Console.SetCursorPosition(starting.x , starting.y + row + 1 );
                for(int col = 0 ; col < shape.GetLength(1)  ; col++)
                {
                     Console.Write(" ");
                }
                
                   
                Console.WriteLine();
               
            }
        }
    }
}
