using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Line
{
    public class Program
    {
        static void Main(string[] args)
        {
            {
                int option;
                MyPoint p1 = new MyPoint();
                MyLine l = new MyLine();
                do
                {
                    option = menu();
                    if (option == 1)
                    {
                        p1 = GiveLine();
                        l = GivePoint();
                    }
                    else if (option == 2)
                    {                       
                        Console.WriteLine("Entre x coordinate");
                         int x= int.Parse(Console.ReadLine());
                        Console.WriteLine("Entre y coordinate");
                        int y = int.Parse(Console.ReadLine());
                        MyPoint begin = new MyPoint(x, y);
                        l.setBegin(begin);                       
                    }
                    else if(option ==3)
                    {
                        Console.WriteLine("Entre x coordinate");
                        int x = int.Parse(Console.ReadLine());
                        Console.WriteLine("Entre y coordinate");
                        int y = int.Parse(Console.ReadLine());
                        MyPoint end = new MyPoint(x, y);
                        l.setEnd(end);                        
                    }
                    else if(option ==4 )
                    {
                        l.getBegin();
                        Console.WriteLine("Begin points are ");
                        Console.WriteLine("Entre x coordinate" + l.begin.x);
                        Console.WriteLine("Entre y coordinate" + l.begin.y);                      
                    }
                    else if(option ==5)
                    {
                        l.getEnd();
                        Console.WriteLine("End points are ");
                        Console.WriteLine("Entre x coordinate" + l.end.x);
                        Console.WriteLine("Entre y coordinate" + l.end.y);
                    }
                    if(option ==6)
                    {
                        double length = l.GetLength();
                        Console.WriteLine("The length of the line is " + length);
                    }
                    if(option == 7)
                    {
                        double gradiant = l.GetGradiant();
                        Console.WriteLine("The gradiant of the line is " + gradiant );
                    }
                    if(option ==8)
                    {
                        double originCoordinate = p1.distanceWithOrigin(l.begin);
                        Console.WriteLine("the distance of begin point fom origin is " + originCoordinate);
                    }
                    if(option == 9 )
                    {
                        double originCoordinateEnd = p1.distanceWithOrigin(l.end);
                        Console.WriteLine("the distance of end point fom origin is " + originCoordinateEnd);
                    }
                    Console.ReadKey();
                    Console.Clear();
                } while (option != 10);
            }
        }
            static MyPoint GiveLine()
            {
                Console.WriteLine("Entre x coordinate");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Entre y coordinate");
                int y = int.Parse(Console.ReadLine());
                MyPoint p1 = new MyPoint(x, y);
                return p1;
            }
        static MyLine GivePoint()
        {
            Console.WriteLine("Entre x coordinate of begin point ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre y coordinate  of begin point ");
            int y = int.Parse(Console.ReadLine());
            MyPoint begin = new MyPoint(x, y);
            Console.WriteLine("Entre x coordinate  of end point ");
            int x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre y coordinate  of end  point ");
            int y1 = int.Parse(Console.ReadLine());
            MyPoint end = new MyPoint(x1, y1);
            MyLine p1 = new MyLine(begin, end);
            return p1;
        }
            static int menu()
            {
                int option;
                Console.WriteLine("1. Make a Line ");
                Console.WriteLine("2.Update the begin point");
                Console.WriteLine("3.Update the end point");
                Console.WriteLine("4.Show the begin Point");
                Console.WriteLine("5.Show the end point");
                Console.WriteLine("6.Get the Length of the line");
                Console.WriteLine("7.Get the Gradient of the Line");
            Console.WriteLine("8.Find the distance of begin point from zero coordinates");
            Console.WriteLine("9.Find the distance of end point from zero coordinates");
            Console.WriteLine("10.Exit");
            Console.WriteLine("Entre your option");
            option = int.Parse(Console.ReadLine());
            return option;
         }
    }
}
