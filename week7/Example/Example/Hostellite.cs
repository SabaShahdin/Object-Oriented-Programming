using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class Hostellite : Student
    {
        public int roomNumber;
        public bool isFridgeAvailable;
        public bool isInternetAvailable;

        public int getHostelFee()
        {
            int fee = 0;
            if(isFridgeAvailable == true && isInternetAvailable == true)
            {
                fee = 4500;

            }
            else
            {
                fee = 2000;
            }
            return fee; 
        }
    }
}
