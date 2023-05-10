using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
             Angle Longitude = null;
             Angle Latitude = null;
            Ship s1  = null;
            int choice ;
            do
            {
                choice = menu();
                Console.Clear();
                if(choice == 1)
                {
                     Console.WriteLine ("entre Ship longitude  ");
                     Longitude = AddAngle();
                    Console.WriteLine ("entre Ship latitude  ");
                     Latitude = AddAngle();
                     s1 = AddShip(Longitude , Latitude);
                    AddDataInList(ships , s1);
                }
                if(choice == 2)
                {
                    Console.WriteLine("Entre the ship NUmber ...");
                    string shipNumber = Console.ReadLine();
                    bool flag = viewShip(ships , shipNumber);
                    if(flag == true)
                    {
                        Longitude.printAngle();
                        Latitude.printAngle();
                    }
                    else
                    {
                        Console.WriteLine("NO ship found");
                    }
                }
                if(choice == 3)
                {
                     Console.WriteLine("Entre the logitude  ...");
                     Angle log = AddAngle();
                     Console.WriteLine("Entre the latitude  ...");
                     Angle lat = AddAngle(); 
                     viewCode(log , lat , ships , s1);
                }
                if(choice == 4)
                {
                     Console.WriteLine("Entre the ship NUmber ...");
                    string shipNumber = Console.ReadLine();
                    bool flag = viewShip(ships , shipNumber);
                    if(flag == true)
                    {
                      Console.WriteLine("Entre the logitude  ...");
                     Angle log = AddAngle();
                     s1.Longitude.ChangeValues(log.degree , log.min , log.direction);
                     Console.WriteLine("Entre the latitude  ...");
                     Angle lat = AddAngle(); 
                     s1.Latitude.ChangeValues(lat.degree , lat.min , lat.direction);
                     s1.printAngle();
                    }
                    else
                    {
                        Console.WriteLine("NO ship found");
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (choice != 5);

        }
        static int menu ()
        {
            int option;
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Entre your option ");
            option = int.Parse (Console.ReadLine());
            return option ;
        }
        static Ship AddShip (Angle Longitude , Angle Latitude )
        {
             Console.WriteLine ("entre serial Number of ship ");
             string number = Console.ReadLine();  
             Ship s2 = new Ship (number , Longitude , Latitude);
            return s2;
        }
        static Angle AddAngle ()
        {
            Console.WriteLine ("entre degree:");
            int degree = int.Parse (Console.ReadLine());            
            Console.WriteLine ("entre minutes :");
            float min  = float.Parse (Console.ReadLine());
            Console.WriteLine ("entre direction  :");
            char direction  = char.Parse (Console.ReadLine());
            Angle a = new Angle (degree , min , direction);
            return a ;
        }
     
        static void AddDataInList(List <Ship> ship , Ship s1)
        {
            ship.Add(s1);
        }
        static  void   viewCode ( Angle log , Angle lat ,  List <Ship> ships , Ship s)
        { 
            if(log.degree == s.Longitude.degree  &&  log.min == s.Longitude.min && log.direction == s.Longitude.direction  && lat.degree == s.Latitude.degree && lat.min == s.Latitude.min &&  lat.direction == s.Latitude.direction )
            {
                     Console.WriteLine("The ship code is  " + s.number  );
            }
            else
            {
                  Console.WriteLine("nO RECOrd Found");
            }
        }
       static  bool viewShip (List<Ship> ship , string shipNumber)
       {
            bool flag = true ;
            for (int x = 0 ; x < ship.Count ; x ++)
            {
                if(ship[x].number == shipNumber)
                {
                    flag =  true;
                    break;
                }
                else
                {
                    flag =  false ;
                }
            }
            return flag ;
       }
    }
}
