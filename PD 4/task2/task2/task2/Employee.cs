using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
   public class Employee
    {
        public string employeeName;
        public int employeeAge;
        public string employeeCity;
        public string  day;

        public Employee()
        {

        }
        
        public Employee(string employeeName , int employeeAge , string employeeCity)
        {
            this.employeeName = employeeName;
            this.employeeAge = employeeAge;
            this.employeeCity = employeeCity;
        }
        public int GetAge ()
        {
            return employeeAge;
        }
        public string GetName()
        {
            return employeeName;
        }
        public string GetCity()
        {
            return employeeCity;
        }
        public int searchEmployee(List<Employee> empl, string newEmployee)
        {
            for (int x = 0; x < empl.Count; x++)
            {
                if (empl == null)
                {
                        return -1;
                }
              else   if (newEmployee == empl[x].employeeName)
                {
                    return x;
                }
            }
            return -1;
        }
    }
}
