using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task2
{
    class Program
    {      
        static  List<Product> product = new List<Product>();
        static  List<User> users = new List<User>();
        static  List<Product1> product1 = new List<Product1>();
        static  List<Employee> employees = new List<Employee>();
        static  List<Manager> mana = new List<Manager>();     
        static void Main(string[] args)
        {
            Product p1 = new Product () ;
            Product1 p = new Product1 ();
            Employee e1 = new Employee ();
            Manager m1 =  new Manager () ;
            string path = "User.txt";
            string path1 = "Product.txt";
            string path2 = "Repair.txt";
            string path3 = "Employee.txt";
            string path4 = "Manager.txt";
            int option;
            bool check = readData(path );
            read(path1);
            read1 (path2);
            readEmployee (path3);
            readManager(path4);
            if (check)
            {
                Console.WriteLine("Data Loaded SuccessFully");
            }
            else
            {
                Console.WriteLine("Data Not Loaded");
            }
            Console.Clear();
            do
            {
                printMainScreen();

                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    printMainScreen();
                    openRootMenu("Login");
                    User user = takeInputWithoutRole();
                    if (user != null)
                    {
                        user = signIn(user);
                        if (user.isAdmin() == "Admin")
                        {
                            clearScreen();
                            printMainScreen();
                            openRootMenu("Admin");
                            adminPanel(p1 ,  m1, p , path1 , path2,path4);

                        }
                        else if (user.isAdmin() == "Employee")
                        {
                            clearScreen();
                            printMainScreen();
                            openRootMenu("Employee");
                            EmployeePanel();
                        }
                        else if (user.isAdmin() == "Manager")
                        {
                            clearScreen();
                            printMainScreen();
                            openRootMenu("Manager");
                            ManagerPanel( e1 , path3);
                        }
                        else
                        {
                            Console.WriteLine("Invalid User");
                        }
                    }
                }
                else if (option == 2)
                {
                    printMainScreen();
                    openRootMenu("Sign up");
                    User user = takeInputWithRole();
                    if (user != null)
                    {
                        storeDataInFile(path, user);
                        storeDataInList( user);
                    }
                }
                Console.ReadKey();
            }
            while (option != 3);
        }
        static bool readData(string path)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    User user = new User(name, password, role);
                    storeDataInList(user);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length;
           x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void storeDataInList(User user)
        {
            users.Add(user);
        }
        static User takeInputWithoutRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                User user = new User(name, password);
                return user;
            }
            else
            {
                Console.WriteLine("Invalid user");
            }
            return null;
        }
        static User takeInputWithRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role: ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                User user = new User(name, password, role);
                return user;
            }
            return null;
        }
        static void storeDataInFile(string path, User user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.name + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }
        static User signIn(User user)
        {
            foreach (User storedUser in users)
            {
                if (user.name == storedUser.name && user.password == storedUser.password)
                {
                    return storedUser;
                }
            }
            return null;
        }
        static int menu()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("    Main Menu                                                                        ");
            Console.WriteLine("    1. Sign in to get access                                                         ");
            Console.WriteLine("    2. Sign up to view your data                                                     ");
            Console.WriteLine("    3. logout                                                                        ");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            int option;
            Console.WriteLine("Entre any option ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void printMainScreen()
        {
            Console.SetCursorPosition(20, 2);
            Console.WriteLine("-----------------------------------------------------------------------------------         ");
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("------***------------------------------------------------------------ *** ---------    ");
            Console.SetCursorPosition(20, 4);
            Console.WriteLine("----- ***------------------------------------------------------------ *** ---------      ");
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("-- ********** --------------------------------------------------- ********** ------      ");
            Console.SetCursorPosition(20, 6);
            Console.WriteLine("-- ********** ----------  AUTOMOTIVE   MANAGEMENT --------------- ********** ------      ");
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("----- *** ------------                         ---------------------- ***   -------       ");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("----- *** ---------------------   SYSTEM   -------------------------- ***   -------      ");
            Console.SetCursorPosition(20, 9);
            Console.WriteLine("-- ***    *** ---------------------------------------------------- ***   *** ------     ");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("-- ***    *** ---------------------------------------------------- ***   *** ------    ");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("-----------------------------------------------------------------------------------    ");
            Console.WriteLine(" ");
        }

        static void menuAdmin()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(" 1.\t\t View list of products and price");
            Console.WriteLine(" 2.\t\t Products  that can be  repair and their prices");
            Console.WriteLine(" 3.\t\t Add product  and their prices");
            Console.WriteLine(" 4.\t\t Add repair products and their prices");
            Console.WriteLine(" 5.\t\t Delete  selling product and their prices");
            Console.WriteLine(" 6.\t\t Delete  repairing products and their prices");
            Console.WriteLine(" 7.\t\t Update selling products and their prcices");
            Console.WriteLine(" 8.\t\t Update repairing products and their prcices");
            Console.WriteLine(" 9.\t\t Money earned in one day by selling");
            Console.WriteLine("10.\t\t Money earned in one day  by repairing");
            Console.WriteLine("11.\t\t View Employees record");
            Console.WriteLine("12.\t\t Add manager");
            Console.WriteLine("13.\t\t View manager ");
            Console.WriteLine("14.\t\t Remove manager ");
            Console.WriteLine("15.\t\t Update manager ");
            Console.WriteLine("16.\t\t Sort Product ");
            Console.WriteLine("17.\t\t Logout");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------");
        }

        static void menuEmployee()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(" 1.\t\t View list of  sell products and price");
            Console.WriteLine(" 2.\t\t Products  that can be  repair and their prices");
            Console.WriteLine(" 3.\t\t Add number of products sell in one day");
            Console.WriteLine(" 4.\t\tAdd  number of repair products in one day");
            Console.WriteLine(" 5.\t\t Add money earned in a day by selling products");
            Console.WriteLine(" 6.\t\t Add money earned in a day by repairing product");
            Console.WriteLine(" 7.\t\t Logout");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");
        }
        static void menuManager()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(" 1.\t\t View employee record");
            Console.WriteLine(" 2.\t\t View list of  sell products and price");
            Console.WriteLine(" 3.\t\t Products  that can be  repair and their prices");
            Console.WriteLine(" 4.\t\t Add employees ");
            Console.WriteLine(" 5.\t\t Remove employees ");
            Console.WriteLine(" 6.\t\t Update employees data");
            Console.WriteLine(" 7.\t\t Money earned in one day by selling");
            Console.WriteLine(" 8.\t\t Money earned in one day  by repairing");
            Console.WriteLine(" 9.\t\t Logout");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------");
        }
        static void openRootMenu(string submenu)
        {
            string message = submenu + " Menu";
            Console.WriteLine(message);
        }
        static void subMenu(string submenu)
        {
            string message = "Main Menu > " + submenu;
            Console.WriteLine(message);
            Console.WriteLine();
        }
        static void addProductForSelling()
        {
            string  takeInput ="1";
            while (takeInput ==  "1")
            {
                Console.WriteLine("Entre the name of product");
                string ProductName = Console.ReadLine();
                Console.WriteLine("Entre the price of product");
                int ProductPrice = int.Parse(Console.ReadLine());

                if (!string.IsNullOrEmpty(ProductName) && ProductPrice != 0)
                {
                    Product product = new Product(ProductName, ProductPrice);
                    storeInList(product);
                    Console.WriteLine("Product added successfully.");
                }
                else
                {
                    Console.WriteLine("Product has wrong format of iput");
                }
                  Console.WriteLine("Enter 1 to enter details for another product, otherwise enter 0:");
                  takeInput =  Console.ReadLine();
            }
        }
        static void  addProductForRepairing()
        {
            string takeInput = "1";
            while (takeInput == "1")
            {
                Console.WriteLine("Entre the name of product");
                string ProductName = Console.ReadLine();
                Console.WriteLine("Entre the price of product");
                int ProductPrice = int.Parse(Console.ReadLine());

                if (ProductName != null && ProductPrice != 0)
                {
                    Product1 product = new Product1(ProductName, ProductPrice);
                    storeInList1( product);
                    Console.WriteLine("Product added successfully.");
                }
                else
                {
                    Console.WriteLine("Wrong format of input ");
                }
                Console.WriteLine("Enter 1 to enter details for another product, otherwise enter 0:");
                takeInput = Console.ReadLine();
            }
        }
        static void  addEmployee()
        {
            string takeInput = "1";
            while (takeInput == "1")
            {
                Console.WriteLine("Entre the name of employee");
                string employeeName = Console.ReadLine();
                Console.WriteLine("Entre the age of employee");
                int employeeAge = int.Parse(Console.ReadLine());
                Console.WriteLine("Entre the city of employee");
                string employeeCity = (Console.ReadLine());
                if (employeeName != null && employeeAge != 0 && employeeCity != null)
                {
                    Employee e1 = new Employee(employeeName, employeeAge, employeeCity);
                    storeInListE(e1);
                    Console.WriteLine("Employee added successfully.");
                }
                else
                {
                    Console.WriteLine("Wrong format of input ");
                }
                Console.WriteLine("Enter 1 to enter details for another employee, otherwise enter 0:");
                takeInput = (Console.ReadLine());
            }
        }
        static void  addManager()
        {
            string takeInput = "1";
            while (takeInput == "1")
            {
            Console.WriteLine("Entre the name of manager");
            string managerName = Console.ReadLine();
            Console.WriteLine("Entre the age of manager");
            int managerAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre the city of manager");
            string managerCity = (Console.ReadLine());
            if (managerName != null && managerAge != 0 && managerCity != null)
            {
                Manager mana = new Manager(managerName, managerAge, managerCity);
                storeInListM( mana);
            }
            else
            {
                    Console.WriteLine("Wrong format of input ");
            }
            Console.WriteLine("Enter 1 to enter details for another employee, otherwise enter 0:");
            takeInput = Console.ReadLine();
        }
            }
        static void viewProductForSelling()
        { 
            foreach (Product store in product)
            { 
               if (!string.IsNullOrEmpty(store.productName) && store.productPrice != 0)
                {
                  Console.WriteLine("ProductName {0}  ProductPrice {1} ", store.productName, store.productPrice);
                }
          
            }
        }
        static void viewProductForRepairing()
        {
            foreach (Product1 store in product1)
            {
                if (!string.IsNullOrEmpty(store.productName1) && store.productPrice1 != 0)
                { 
                Console.WriteLine("ProductName {0}  ProductPrice {1} ", store.productName1, store.productPrice1);
                }
            }
        }
        static void viewEmployee()
        {
            foreach (Employee store in employees)
            {
                if (!string.IsNullOrEmpty(store.employeeName) && store.employeeAge != 0 && !string.IsNullOrEmpty(store.employeeCity))
                { 
                Console.WriteLine("EmployeeName {0}  EmployeeAge {1}  EmployeeCity {2} ", store.employeeName, store.employeeAge, store.employeeCity);
                }
            }
        }
        static void viewManager()
        {
            foreach (Manager store in mana)
            {
                if (!string.IsNullOrEmpty(store.managerName) && store.managerAge != 0 && !string.IsNullOrEmpty(store.managerCity))
                { 
                Console.WriteLine("ManagerName {0}  ManagerAge {1}  ManagerCity {2} ", store.managerName, store.managerAge, store.managerCity);
                }
            }
        }
        static void storeInList(Product pro)
        {
              if(pro != null)
              product.Add(pro);          
        }
        static void storeInList1(Product1 product)
        {
             if (product != null)
             {
                 product1.Add(product);
             }
        }
        static void storeInListE( Employee e1)
        {
            if(e1 != null)
            {
            employees.Add(e1);
            }
        }
        static void storeInListM( Manager m1)
        {
            if(m1 != null)
            { 
              mana.Add(m1);
            }
        }
        static bool deleteProductForSelling( string newProduct, Product p1)
        {
            int delete = p1.searchProduct(product, newProduct);
            bool flag = true;
            if (delete >= 0 && delete <= 4)
            {
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        static bool deleteProductForRepairing( string newProduct1, Product1 p1)
        {
            int delete = p1.searchProduct1(product1, newProduct1);
            bool flag = true;
            if (delete >= 0 && delete <= 4)
            {
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        static bool deleteManager(string newManager, Manager m1)
        {
            int delete = m1.searchManager(mana, newManager);
            bool flag = true;
            if (delete >= 0 && delete <= 4)
            {
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        static bool deleteEmployee( string newEmployee, Employee e1)
        {
            int delete = e1.searchEmployee(employees, newEmployee);
            bool flag = true;
            if (delete >= 0 && delete <= 4)
            {
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        static bool updateProductForSelling( string newProduct, Product p1)
        {
            int update = p1.searchProduct(product, newProduct);
            bool flag = true;
            if (update >= 0 && update <= 4)
            {
                Console.WriteLine("Product Found");
                Console.WriteLine("Enter the Updated price");
                int newPrice = int.Parse(Console.ReadLine());
                product[update].productPrice = newPrice;
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        static bool updateProductForRepairing(string newProduct1, Product1 p1)
        {
            int update = p1.searchProduct1(product1, newProduct1);
            bool flag = true;
            if (update >= 0 && update <= 4)
            {
                Console.WriteLine("Product Found");
                Console.WriteLine("Enter the Updated price");
                int newPrice = int.Parse(Console.ReadLine());
                product1[update].productPrice1= newPrice;
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        static bool updateEmployee(string newEmployee, Employee e1)
        {
            int update = e1.searchEmployee(employees, newEmployee);
            bool flag = true;
            if (update >= 0 && update <= 4)
            {
                Console.WriteLine("Product Found");
                Console.WriteLine("Enter the Updated age");
                int newAge = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Updated City");
                string newCity = (Console.ReadLine());
                employees[update].employeeAge = newAge;
                employees[update].employeeCity = newCity;
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        static bool updateManager( string newManager, Manager m1)
        {
            int update = m1.searchManager(mana, newManager);
            bool flag = true;
            if (update >= 0 && update <= 4)
            {
                Console.WriteLine("Manager Found");
                Console.WriteLine("Enter the Updated age");
                int newAge = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Updated City");
                string newCity = (Console.ReadLine());
                mana[update].managerAge = newAge;
                mana[update].managerCity = newCity;
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        static void adminPanel( Product p1,Manager m1 , Product1 p , string path1 , string path2,string path4)
        {
            bool flag = true;
            menuAdmin();
            while (flag == true)
            {
                string option;
                Console.WriteLine("Choose your option...");
                option = Console.ReadLine();
                if (option == "1")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  View  Selling  Products");
                    Console.WriteLine("---------------------------------------------");
                    viewProductForSelling();
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "2")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  View  Repairing Products");
                    Console.WriteLine("---------------------------------------------");
                    viewProductForRepairing();
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }

                else if (option == "3")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("   Add  Selling  Products");
                    Console.WriteLine("---------------------------------------------");
                    addProductForSelling();
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "4")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Add Repairing Products");
                    Console.WriteLine("---------------------------------------------");
                    addProductForRepairing();
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "5")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Delete Selling Products");
                    Console.WriteLine("---------------------------------------------");
                    viewProductForSelling();
                    Console.WriteLine("Enter Product Name you want to Delete: ");
                    string newProduct = Console.ReadLine();
                    bool check = deleteProductForSelling( newProduct, p1);
                    int delete = p1.searchProduct(product, newProduct);
                    if (check == true)
                    {
                        Console.WriteLine("Product Found");
                        product.RemoveAt(delete);
                        Console.WriteLine("Product deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Product not  Found");
                    }
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "6")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Delete Repairing Products");
                    Console.WriteLine("---------------------------------------------");
                    viewProductForRepairing();
                    Console.WriteLine("Enter Product Name you want to Delete: ");
                    string newProduct1 = Console.ReadLine();
                    bool check = deleteProductForRepairing(newProduct1, p);
                    int delete = p.searchProduct1(product1 , newProduct1);
                    if (check == true)
                    {
                        Console.WriteLine("Product Found");
                        product.RemoveAt(delete);
                        Console.WriteLine("Product deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Product not  Found");
                    }
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "7")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Update Selling Products");
                    Console.WriteLine("---------------------------------------------");
                    viewProductForSelling();
                    Console.WriteLine("Enter Product Name you want to Update: ");
                    string newProduct = Console.ReadLine();
                    bool check = updateProductForSelling( newProduct, p1);
                    if (check == true)
                    {
                        Console.WriteLine("Product Updated succefully Exists.");
                    }
                    else
                    {
                        Console.WriteLine("Product Does Not Exists.");
                    }
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "8")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Update Repairing Products");
                    Console.WriteLine("---------------------------------------------");
                    viewProductForRepairing();
                    Console.WriteLine("Enter Product Name you want to Update: ");
                    string newProduct1 = Console.ReadLine();
                    bool check = updateProductForRepairing(newProduct1, p);
                    if (check == true)
                    {
                        Console.WriteLine("Product Updated succefully Exists.");
                    }
                    else
                    {
                        Console.WriteLine("Product Does Not Exists.");
                    }
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "9")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Money earned in a day by selling");
                    Console.WriteLine("---------------------------------------------"); 
                    moneyEarnedBySelling();
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "10")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("   Money earned in a day by reapiring");
                    Console.WriteLine("---------------------------------------------");
                    moneyEarnedByRepairing();
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                if (option == "11")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("     View Employees             ");
                    Console.WriteLine("---------------------------------------------");
                    viewEmployee();
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "12")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Add Manager");
                    Console.WriteLine("---------------------------------------------");
                    addManager();
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "13")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  View Manager");
                    Console.WriteLine("---------------------------------------------");
                    viewManager();
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "14")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Remove Manager");
                    Console.WriteLine("---------------------------------------------");
                    viewManager();
                    Console.WriteLine("Enter manager Name you want to remove: ");
                    string newManager = Console.ReadLine();
                    bool check = deleteManager(newManager, m1);
                    int delete = m1.searchManager(mana, newManager);
                    if (check == true)
                    {
                        Console.WriteLine("manager Found");
                        mana.RemoveAt(delete);
                        Console.WriteLine("Manager removed  successfully");
                    }
                    else
                    {
                        Console.WriteLine("Manager not  Found");
                    }
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }

                else if (option == "15")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Update Manager");
                    Console.WriteLine("---------------------------------------------");
                    viewManager();
                    Console.WriteLine("Enter Manager Name you want to Update: ");
                    string newManager = Console.ReadLine();
                    bool check = updateManager(newManager, m1);
                    if (check == true)
                    {
                        Console.WriteLine("Manager record is  Updated succefully Exists.");
                    }
                    else
                    {
                        Console.WriteLine("Manager Does Not Exists.");
                    }
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Admin");
                    menuAdmin();
                }
                else if (option == "16")
                {
                  clearScreen();
                  printMainScreen();
                  openRootMenu("Admin");
                   Console.WriteLine( "---------------------------------------------" );
                  Console.WriteLine( "  Sorted Data" );
                  Console.WriteLine( "---------------------------------------------" );
                   sortedDataSelled( p1);
                  sortedDataRepaired( p);
                  clearScreen();
                  printMainScreen();
                  openRootMenu("Admin");
                  menuAdmin();
                 }
                else if (option == "17")
                {
                    flag = false;
                    clearScreen();
                    writeFile(path1);
                    writeFile1( path2);
                    writeFileManager( path4);
                    printMainScreen();
                    openRootMenu(" login ");
                }
            }
        }
        static void ManagerPanel( Employee e1 , string path3)
        {
            bool flag = true;
            menuManager();
            while (flag == true)
            {
                string option;
                Console.WriteLine("choose your option...");
                option = Console.ReadLine();
                if (option == "1")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("     View Employees             ");
                    Console.WriteLine("---------------------------------------------");
                    viewEmployee();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    menuManager();
                }
                else if (option == "2")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      View Selling products             ");
                    Console.WriteLine("---------------------------------------------");
                    viewProductForSelling();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    menuManager();
                }
                else if (option == "3")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      View Repairing products             ");
                    Console.WriteLine("---------------------------------------------");
                     viewProductForRepairing();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    menuManager();
                }
                else if (option == "4")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("  Add Employees                              ");
                    Console.WriteLine("---------------------------------------------");
                    addEmployee();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    menuManager();
                }
                else if (option == "5")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      Remove Employees             ");
                    Console.WriteLine("---------------------------------------------");
                    viewEmployee();
                    Console.WriteLine("Enter Employee Name you want to Delete: ");
                    string newEmployee = Console.ReadLine();
                    bool check = deleteEmployee(newEmployee, e1);
                    int delete = e1.searchEmployee(employees , newEmployee);
                    if (check == true)
                    {
                        Console.WriteLine("employee Found");
                        employees.RemoveAt(delete);
                        Console.WriteLine("Employee removed  successfully");
                    }
                    else
                    {
                        Console.WriteLine("Employee not  Found");
                    }
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    menuManager();
                }
                else if (option == "6")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      Upadate Employees             ");
                    Console.WriteLine("---------------------------------------------");
                    viewEmployee();
                    Console.WriteLine("Enter Product Name you want to Update: ");
                    string newEmployee = Console.ReadLine();
                    bool check = updateEmployee( newEmployee, e1);
                    if (check == true)
                    {
                        Console.WriteLine("Employee record is  Updated succefully Exists.");
                    }
                    else
                    {
                        Console.WriteLine("Employee Does Not Exists.");
                    }
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    menuManager();
                }
                else if (option == "7")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      View  money earned in one day by selling  ");
                    Console.WriteLine("---------------------------------------------");
                    moneyEarnedBySelling();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    menuManager();
                }
                else if (option == "8")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      View  money earned in one day by repairing  ");
                    Console.WriteLine("---------------------------------------------");
                     moneyEarnedByRepairing();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Manager ");
                    menuManager();
                }
                else if (option == "9")
                {
                    flag = false;
                    clearScreen();
                    writeFileEmployee( path3);
                    printMainScreen();
                    openRootMenu("Login ");
                }
            }
        }
        static void EmployeePanel()
        {
            bool flag = true;
            menuEmployee();
            while (flag == true)
            {
                string option;
                Console.WriteLine("Choose your option...");
                option = Console.ReadLine();
                if (option == "1")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      View Selling products             ");
                    Console.WriteLine("---------------------------------------------");
                    viewProductForSelling();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    menuEmployee();
                }
                else if (option == "2")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      View Repairing products             ");
                    Console.WriteLine("---------------------------------------------");
                    viewProductForRepairing();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    menuEmployee();
                }
                else if (option == "3")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      Add number of products sell              ");
                    Console.WriteLine("---------------------------------------------");
                    calculatePrice();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    menuEmployee();
                }
                else if (option == "4")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      Add number of products repair             ");
                    Console.WriteLine("---------------------------------------------");
                    calculatePrice1();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    menuEmployee();
                }
                else if (option == "3")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      View money earend by selling           ");
                    Console.WriteLine("---------------------------------------------");
                    moneyEarnedBySelling();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    menuEmployee();
                }
                else if (option == "4")
                {
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("      View money earend by repairing           ");
                    Console.WriteLine("---------------------------------------------");
                    moneyEarnedByRepairing();
                    clearScreen();
                    printMainScreen();
                    openRootMenu(" Employee  ");
                    menuEmployee();
                }
                else if (option == "5")
                {
                    flag = false;
                    clearScreen();
                    printMainScreen();
                    openRootMenu("Main ");
                }
            }
        }
        static void calculatePrice()
        {
            Console.WriteLine("Entre day ");
            string day = Console.ReadLine();
            Console.WriteLine("eNTRE NAME OF PRODUCT");
            string productName = Console.ReadLine();
            Console.Write("Enter the number of products: ");
            int numberOfProducts = int.Parse(Console.ReadLine());
            Product p1 = new Product(productName, numberOfProducts, day);
            product.Add(p1);
            int price = p1.searchPrice(product, p1);
            Console.WriteLine("Product price is " + product[price].productPrice);
            p1.oneDayRecord = numberOfProducts * product[price].productPrice;
            Console.WriteLine("One day record for " + p1.productName + " is " + p1.oneDayRecord);
        }
        static void calculatePrice1()
        {
            Console.WriteLine("Entre day ");
            string day1 = Console.ReadLine();
            Console.WriteLine("eNTRE NAME OF PRODUCT");
            string productName1 = Console.ReadLine();
            Console.Write("Enter the number of products: ");
            int numberOfProducts1 = int.Parse(Console.ReadLine());
            Product1 p1 = new Product1(productName1, numberOfProducts1, day1);
            product1.Add(p1);
            int price = p1.searchPrice1(product1, p1);
            Console.WriteLine("Product price is " + product1[price].productPrice1);
            p1.oneDayRecord1 = numberOfProducts1 * product1[price].productPrice1;
            Console.WriteLine("One day record for " + p1.productName1 + " is " + p1.oneDayRecord1);
        }
        static void moneyEarnedBySelling()
        {
            bool takeInput = true;
            while (takeInput == true)
            {
                Console.WriteLine("Entre day to which you want to see money   ");
                string days = Console.ReadLine();
                int count;
                int sum = 0;
                for (int idx = 0; idx < product.Count; idx++)
                {
                    if (days == product[idx].day)
                    {
                        count = idx;
                        sum = sum + product[idx].oneDayRecord;
                    }
                }
                Console.WriteLine("Money earned  is ...." + sum);
                Console.WriteLine("Entre 1 to get input for another day ....");
                takeInput = Convert.ToBoolean(Console.ReadLine());
            }
        }
        static void moneyEarnedByRepairing()
        {
            bool takeInput = true;
            while (takeInput == true)
            {
                Console.WriteLine("Entre day to which you want to see money   ");
                string days = Console.ReadLine();
                int count;
                int sum = 0;
                for (int idx = 0; idx < product1.Count; idx++)
                {
                    if (days == product1[idx].day1)
                    {
                        count = idx;
                        sum = sum + product1[idx].oneDayRecord1;
                    }
                }
                Console.WriteLine("Money earned  is ...." + sum);
                Console.WriteLine("Entre 1 to get input for another day ....");
                takeInput = Convert.ToBoolean(Console.ReadLine());
            }
        }
       static void sortedDataSelled( Product p)
      {
            for (int idx = 0; idx < product.Count; idx++)
            {
               for (int idx1 = idx + 1; idx1 < product.Count; idx1++)
               {
                   if (product[idx].productPrice > product[idx1].productPrice)
                   {
                        int temp;
                        temp = product[idx].productPrice;
                        product[idx].productPrice = product[idx+1].productPrice;
                        product[idx + 1].productPrice = temp;
                   }
               }
            }
            Console.WriteLine( "ProductName  \t  ProductPrice" );
            for (int idx = 0; idx < product.Count; idx++)
             {

               Console.WriteLine(product[idx].productName +  "\t"  + product[idx].productPrice);
            }
       }
        static void sortedDataRepaired(Product1 p1)
        {
             for (int idx = 0; idx < product1.Count; idx++)
             {
                for (int idx1 = idx + 1; idx1 < product1.Count; idx1++)
                {
                     if (product1[idx].productPrice1 > product1[idx1].productPrice1)
                     {
                           int temp;
                           temp = product1[idx].productPrice1;
                           product1[idx].productPrice1 = product1[idx+1].productPrice1;
                           product1[idx+1].productPrice1 = temp;
                     }
                 }
             }
             Console.WriteLine( "ProductName \t ProductPrice" );
             for (int idx = 0; idx < product1.Count; idx++)
             {
                Console.WriteLine( product1[idx].productName1  + "\t " +  product1[idx].productPrice1 );
             }
        }

        static void read (string path)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                  
                  string productName = parseData(record, 1);
                   int productPrice = int . Parse (parseData(record, 2));
                    Product c1 = new Product (productName , productPrice);
                   product.Add(c1);
                 }
               fileVariable.Close();
            }
            else
            {
                  Console.WriteLine("Not Exists");
            }
        }
        static string parseAdminData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length;
           x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void writeFile(string path)
        {
            StreamWriter file = new StreamWriter(path , false );
            for (int x  = 0; x < product.Count ; x++)
            {
                file.WriteLine(product[x].productName +  ","  + product[x].productPrice);
            }               
                file.Flush();
                file.Close(); 
        }
        static void read1 (string path)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                   string productName = parseData1(record, 1);
                   int productPrice = int . Parse (parseData1(record, 2));
                   Product1 c1 = new Product1 (productName , productPrice);
                   product1.Add(c1);
                 }
               fileVariable.Close();
            }
            else
            {
                  Console.WriteLine("Not Exists");
            }
        }
        static string parseData1(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
         static void writeFile1(string path)
         {
            StreamWriter file = new StreamWriter(path , false);
            for (int x  = 0; x < product1.Count ; x++)
            {
                file.WriteLine(product1[x].productName1 +  ","  + product1[x].productPrice1);
            }               
                file.Flush();
                file.Close(); 
        }
        static void readEmployee (string path)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                   string employeeName = parseDataEmployee(record, 1);
                   int employeeAge = int . Parse (parseDataEmployee(record, 2));
                   string employeeCity = parseDataEmployee(record, 3);
                    Employee e1 = new Employee (employeeName , employeeAge , employeeCity);
                   employees.Add(e1);
                 }
               fileVariable.Close();
            }
            else
            {
                  Console.WriteLine("Not Exists");
            }
        }
        static string parseDataEmployee(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
         static void writeFileEmployee(string path)
         {
            StreamWriter file = new StreamWriter(path , false);
            for (int x  = 0; x < employees.Count ; x++)
            {
                file.WriteLine( employees[x].employeeName + "," +  employees[x].employeeAge  +  ","  +  employees[x].employeeCity);
            }               
                file.Flush();
                file.Close(); 
        }
        static void readManager (string path)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {

                   string managerName = parseDataManager(record, 1);
                   int managerAge = int . Parse (parseDataManager(record, 2));
                   
                    string managerCity = parseDataManager(record, 3);
                    Manager m1 = new Manager (managerName , managerAge , managerCity);
                    mana.Add(m1);
                 }
               fileVariable.Close();
            }
            else
            {
                  Console.WriteLine("Not Exists");
            }
        }
        static string parseDataManager(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
         static void writeFileManager(string path)
         {
            StreamWriter file = new StreamWriter(path , false);
            for (int x  = 0; x < mana.Count ; x++)
            {
                file.WriteLine(mana[x].managerName + "," + mana[x].managerAge  +  ","  + mana[x].managerCity);
            }               
                file.Flush();
                file.Close(); 
         }
    }
}