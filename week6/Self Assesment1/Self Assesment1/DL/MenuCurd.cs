using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Self_Assesment1.BL;
using System.IO;

namespace Self_Assesment1.DL
{
    public class MenuCurd
    {
        public static  List<Menu> menu = new List<Menu>();

        public static List<Menu> viewDrinks()
        {
            List<Menu> drinksMenu = new List<Menu>();
           foreach(Menu m in menu)
           {
                if(m.type == "drink")
                {
                    drinksMenu.Add(m);
                }
           }
            return drinksMenu;
        }
        public static List<Menu> viewFood()
        {
            List<Menu> FoodMenu = new List<Menu>();
            foreach (Menu m in menu)
            {
                if (m.type == "food")
                {
                    FoodMenu.Add(m);
                }
            }
            return FoodMenu;
        }
        public static Menu viewCheapestItem()
        {
            List<Menu> sorted = new List<Menu>();
            sorted = menu.OrderBy(o => o.price).ToList();
            if(sorted != null)
            {
                return sorted[0];
            }
            return null;
        }
        public static void AddIntoList (Menu m )
        {
            menu.Add(m);
        }
        public static void writeMenuFile(string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            foreach(Menu m in menu)
            {
                file.WriteLine(m.name + "," + m.type + "," + m.price);
            }
          
            file.Flush();
            file.Close();
        }
        public static bool readMenuFile(string path)
        {
            StreamReader file = new StreamReader(path);
            string record;
            bool flag = false;
            if (File.Exists(path))
            {
                while ((record = file.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    string type = splittedRecord[1];
                    int price = int.Parse(splittedRecord[2]);
                    Menu m = new Menu(name, type, price);
                }
                file.Close();
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
    }
}
