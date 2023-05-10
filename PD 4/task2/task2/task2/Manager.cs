using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Manager
    {
        public string managerName;
        public int managerAge;
        public string managerCity;

        public Manager()
        {

        }
        public Manager(string managerName, int managerAge, string managerCity)
        {
            this.managerName = managerName;
            this.managerAge = managerAge;
            this.managerCity = managerCity;
        }
        public int GetAgemanager()
        {
            return managerAge;
        }
        public string GetNamemanager()
        {
            return managerName;
        }
        public string GetCitymanager()
        {
            return managerCity;
        }
        public int searchManager(List<Manager> mana, string newManager)
        {
            for (int x = 0; x < mana.Count; x++)
            {
                if (mana == null)
                {
                        return -1;
                }
               else  if (newManager == mana[x].managerName)
                {
                    return x;
                }
            }
            return -1;
        }
    }
}
