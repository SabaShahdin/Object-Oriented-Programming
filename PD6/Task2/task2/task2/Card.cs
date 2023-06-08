using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Card
    {
        private int theValue;
        private int  theSuit;

        public Card(int theValue, int  theSuit)
        {
            this.theValue = theValue;
            this.theSuit = theSuit;
        }
        public int getValue()
        {
            return this.theValue;
        }
        public int getSuit()
        {
            return this.theSuit;
        }
        public string getSuitAsString()
        {
           
            if(theSuit == 1)
            {
                return  "Club";
            }
            else if (theSuit == 2)
            {
                return  "Diamond";
            }
            else if (theSuit == 3)
            {
                return "Spades";
            }
            else if (theSuit == 4)
            {
                return  "Heart";
            }
            return null ;
        }
        public String getValueAsString()
        {
            
            if (theValue == 1)
            {
                return  "Ace";
            }
            else if (theValue == 11)
            {
                return "Jack";
            }
            else if (theValue == 12)
            {
                return  "Queen";
            }
            else if (theValue == 13)
            {
                return "King";
            }
            else
            {
                return theValue.ToString ();
            }
            
        }
        public String toString()
        {
            return  getValueAsString() +  " of " + getSuitAsString();
           
        }
    }
}
