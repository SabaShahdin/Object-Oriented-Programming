using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
              List<string> Chapters = new List<string>()  {"one" , "two" , "three" , "four" , "five" , "six" , "seven" , "eight" , "nine"};
            Book b1 = null;
            int option;
            do
            { 
                option =  menu ();
                if(option == 1)
                {
                     b1 = add();
                }
                if(option == 2)
                {
                      int mark = b1.GetBookMark();
                      Console.WriteLine("The book marked page is  {0}" , mark);
                }
                if(option == 3)
                {
                    Console.WriteLine("Entre page you want to be marked ");
                    int page = int.Parse (Console.ReadLine());
                    int marked = b1.setBookMark(page);
                    Console.WriteLine ("The book marked page is  {0}  " , marked);
                }
                if(option ==4)
                {
                     int mark = b1.GetPrice();
                     Console.WriteLine("The book price is  {0}" , mark);
                }
                if(option == 5)
                {
                    Console.WriteLine("Entre price you want to be set ");
                    int price = int.Parse (Console.ReadLine());
                    int marked = b1.setBookPrice(price);
                    Console.WriteLine ("The book marked page is  {0}  " , marked);
                }
                if(option == 6)
                {
                    Console.WriteLine("Entre number of chapter you want to get name ");
                    int chapterNumber = int.Parse (Console.ReadLine());
                    string chapter = b1. getChapter(chapterNumber , Chapters);
                     Console.WriteLine ("The chapter name  is  {0}  " , chapter);
                }
                }
                  while (option != 7);
        }
        static Book add ()
        {
          
            Console.WriteLine("Entre the author name...");
            string author = Console.ReadLine();
            Console.WriteLine("Entre the number of page ");
            int pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre the book mark ");
            int bookMark = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre the price ");
            int price = int.Parse(Console.ReadLine());
            Book b1 = new Book (author , pages , bookMark , price);
            return b1;
        }
        static int  menu()
        {
            int option;
            Console.WriteLine("1.Add book data");
            Console.WriteLine("2.Check book mark");
            Console.WriteLine("3.Set book mark");
            Console.WriteLine("4.Check book price");
            Console.WriteLine("5.Set book price");
            Console.WriteLine("6.Check chapter name");
            Console.WriteLine("Entre your chocie");
            option = int.Parse (Console.ReadLine());
            return option ;
        }
    }
}
