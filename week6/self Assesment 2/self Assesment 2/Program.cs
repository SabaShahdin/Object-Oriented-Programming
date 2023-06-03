using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using self_Assesment_2.BL;
using System.Threading ;

namespace self_Assesment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            char[,]triangle = new char [5 , 3]  { { '@' , ' ',' '},{ '@' , '@' ,' '},{ '@' , '@' ,'@'} , { '@' ,'@' ,' '},{ '@' , ' ' ,' ' } } ;
            char[,]opTriangle1 = new char [5,3] {{ ' ' , ' ','P'},{ ' ' , 'P' ,'P'},{ 'P' , 'P' ,'P'} , { ' ' ,'P' ,'P'},{ ' ' , ' ' ,'P' }} ;
            char[,]opTriangle = new char [5,3] {{ ' ' , ' ','R'},{ ' ' , 'R' ,'R'},{ 'R' , 'R' ,'R'} , { ' ' ,'R' ,'R'},{ ' ' , ' ' ,'R' }} ;
             char[,]triangle2 = new char [5 , 3]  { { 'D' , ' ',' '},{ 'D' , 'D' ,' '},{ 'D' , 'D' ,'D'} , { 'D' ,'D' ,' '},{ 'D' , ' ' ,' ' } } ;
            Boundary b = new Boundary (new Point (0,0) , new Point (0,90) , new Point(90, 0) , new Point(90,90));   
            GameObject g1 = new GameObject(triangle , new Point(10,10) , "Projectile" , b);
             GameObject g2 = new GameObject(opTriangle , new Point(20,10) , "RighttoLeft" , b);
              GameObject g3 = new GameObject(opTriangle1 , new Point(20,20) , "RighttoLeft" , b);
              GameObject g4 = new GameObject(triangle2 , new Point(2,2) , "Diagonal" , b);
            List<GameObject> lst = new List<GameObject> ();
            lst.Add(g1);
            lst.Add(g2);
            lst.Add(g3);
            lst.Add(g4);
            while(true)
            {
                Thread.Sleep(50);  
                  
               foreach(GameObject g in lst)
               { 
                     Thread.Sleep(30);
                     g.erase();
                     g.move();
                     g.draw();                
               }
           }
           Console.ReadKey();
          }

}
}
