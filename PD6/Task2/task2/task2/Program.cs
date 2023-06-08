using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Program
    {
        static void Main(string[] args)
        {
           
           int option = 0 ;
            do
            {
                Console.WriteLine("Entre 1 to play game ");
                Console.WriteLine("Entre 2 to exit the game ");
                option = int.Parse(Console.ReadLine());
                Console.Clear();

                if(option ==1 )
                {
                    bool gameRunning = true;
                    int score = 0 ;
                    Deck obj = new Deck();
                    obj.Shuffle();
                    Card card1 = obj.dealCard();
                    while(gameRunning)
                    {
                        int remain_check = obj.cardLeft();
                        Card card2 = obj.dealCard();
                        Console.WriteLine("*********************************");
                        Console.WriteLine(card1.toString());
                        Console.WriteLine("");
                        Console.WriteLine("***Remaing Cards  " + remain_check);
                        Console.WriteLine("Entre 1 if next card is higher");
                        Console.WriteLine("Entre 2 if next card isa lower");

                        int card_check = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if(card_check == 1)
                        {
                            if(card2.getValue() >= card1.getValue())
                            {
                                score++;
                                card1 = card2 ;
                            }
                            else
                            {
                              gameRunning = false ;
                              Console.WriteLine("YOU lose");
                              Console.WriteLine("the card is" + card2.toString() );
                              Console.WriteLine("Your score is " + score);
                                Console.ReadKey();
                                Console.Clear();
                            
                            }
                        }
                        if(card_check ==2)
                        {
                            if(card2.getValue() < card1.getValue())
                            {
                                score++ ;
                                card1 = card2;
                            }
                            else
                            {
                               gameRunning = false ;
                              Console.WriteLine("YOU lose");
                              Console.WriteLine("the card is" + card2.toString() );
                              Console.WriteLine("Your score is " + score);
                              Console.ReadKey();
                              Console.Clear();
                            }
                        } 
                        if(obj.cardLeft() == 0 && card2 == null)
                        {
                              gameRunning = false ;
                              Console.WriteLine("YOU scored is maximum");
                              Console.ReadKey();
                              Console.Clear();
                            break;
                        }
                    }
                }
            }
            while(option != 2);
        }
    }
}
