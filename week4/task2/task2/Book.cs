using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Book
    {
        public string author;
        public int page;
        List<string> Chapters = new List<string>();
        public int bookMarks;
        public int price;

        public Book(string a , int p , int b , int price)
        {
            this.author = a;
            this.page = p;
            this.bookMarks = b;
            this.price = price;
        }
        public int GetBookMark()
        {
            int marks ;
            marks = this.bookMarks;
            return marks;
        }
        public int setBookMark(int page)
        {
            this.bookMarks = page;
            return bookMarks;
        }
         public int GetPrice()
        {
            int marks ;
            marks = this.price;
            return marks;
        }
        public int setBookPrice(int page)
        {
            this.bookMarks = page;
            return bookMarks;
        }
        public string getChapter(int chapterNumber , List<string> Chapters)
        {
            string name = null;
            for (int i =0  ; i < Chapters.Count ; i++)
            {
                if(i == chapterNumber)
                {
                    name = Chapters[i] ;
                }
            }
            return name;
        }
    }
}
