using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;

namespace BestBuyBestPractices
{
    public class Schedule
    {


        private readonly IDbConnection _conn;
        private string ActiveMenu = "main";
        private string LastMenu = "main";
        private string MenuSubTitle = "";
        private int MenuCount = 0;
        private int minIntAnswer = 0;
        private int maxIntAnswer = 5;

        public List<string> YouSayYes = new List<string>() { "yes", "yeah", "true", "T", "1", "sure" };
        public List<string> YouSayNo = new List<string>() { "no", "nah", "false", "F", "0", "nope" };


        public Schedule(IDbConnection conn)
        {
            _conn = conn;
            Console.Write("generating database management options");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
        }

        public void DisplayMenu()
        {
            switch (ActiveMenu.ToLower())
            {
                case "main":
                    Console.Clear();
                    MenuSubTitle = "MAIN MENU\n" +
                        "\nSelect an option to continue:" +
                        "\n\t0: exit/return" +
                        "\n\t1: view/edit products" +
                        "\n\t2: view/edit departments";
                    minIntAnswer = 0;
                    maxIntAnswer = 2;
                    break;
                case "terminate":
                    MenuSubTitle = "TERMINATE APPLICATION\n" +
                        "\nAre You Sure" +
                        "\n\t1: No" +
                        "\n\t2: Yes";
                    minIntAnswer = 1;
                    maxIntAnswer = 2;
                    break;
                case "continue":
                    MenuSubTitle = "CONTINUE\n" +
                        "\npress enter to continue...\n";
                    maxIntAnswer = -1;
                    MenuSubTitle = "";
                    break;

                case "product_options":
                    Console.Clear();
                    MenuSubTitle = "PRODUCT OPTIONS\n" +
                        "\nSelect an option to continue:" +
                        "\n\t0: exit/return" +
                        "\n\t1: view products" +
                        "\n\t2: edit products";
                    minIntAnswer = 0;
                    maxIntAnswer = 2;
                    break;
                case "product_view":
                    Console.Clear();
                    MenuSubTitle = "VIEW PRODUCTS\n" +
                        "\n\t0: exit/return" +
                        "\n\t1: view single product" +
                        "\n\t2: view all products";
                    minIntAnswer = 0;
                    maxIntAnswer = 2;
                    break;
                case "product_edit":
                    Console.Clear();
                    MenuSubTitle = "EDIT PRODUCT\n" +
                        "\n\t0: exit/return" +
                        "\n\t1: add product" +
                        "\n\t2: delete product";
                    minIntAnswer = 0;
                    maxIntAnswer = 2;
                    break;
                case "product_add":
                    Console.Clear();
                    MenuSubTitle = "ADD PRODUCT\n" +
                        "\nenter 0: exit/return\n";
                    minIntAnswer = 0;
                    maxIntAnswer = -1;
                    break;
                case "product_delete":
                    Console.Clear();
                    MenuSubTitle = "DELETE PRODUCT\n" +
                        "\nenter 0: exit/return" +
                        "\nenter product id to delete";
                    minIntAnswer = 0;
                    maxIntAnswer = -1;
                    break;
                case "department_options":
                    Console.Clear();
                    MenuSubTitle = "DEPARTMENT OPTIONS\n" +
                        "\nSelect an option to continue:\n" +
                        "\n\t0: exit/return" +
                        "\n\t1: view departments" +
                        "\n\t2: edit departments";
                    minIntAnswer = 0;
                    maxIntAnswer = 2;
                    break;
                case "department_view":
                    Console.Clear();
                    MenuSubTitle = "VIEW DEPARTMENTS\n" +
                        "\n\t0: exit/return" +
                        "\n\t1: view single departments" +
                        "\n\t2: view all departments";
                    minIntAnswer = 0;
                    maxIntAnswer = 2;
                    break;
                case "department_edit":
                    Console.Clear();
                    MenuSubTitle = "EDIT DEPARTMENT\n" +
                        "\n\t0: exit/return" +
                        "\n\t1: add department" +
                        "\n\t2: delete department";
                    minIntAnswer = 0;
                    maxIntAnswer = 99999;
                    break;
                case "department_add":
                    Console.Clear();
                    MenuSubTitle = "ADD DEPARTMENT\n" +
                        "\nenter 0: exit/return" +
                        "\nenter department name to add";
                    minIntAnswer = 0;
                    maxIntAnswer = -1;
                    break;
                case "department_delete":
                    Console.Clear();
                    MenuSubTitle = "DELETE DEPARTMENT\n" +
                        "\nenter 0: exit/return" +
                        "\nenter department id to delete";
                    minIntAnswer = 0;
                    maxIntAnswer = -1;
                    break;
                default:
                    MenuSubTitle = "whoops!";
                    break;
            }
            Console.WriteLine("********** Best Buy Best Management Service **********\n");
            Console.WriteLine(MenuSubTitle);
        }

        public int AskForInt(string msg = "please enter an integer", int lowerLimit = 0, int upperLimit = 100)
        {
            bool gotInt = false;
            bool intGood = false;
            int userInt = 0;
            do
            {
                Console.WriteLine(msg);
                gotInt = int.TryParse(Console.ReadLine(), out userInt);
                intGood = (gotInt && lowerLimit <= userInt && userInt <= upperLimit) ? true : false;
            } while (!intGood);
            return userInt;
        }

        public double AskForDub(string msg = "please enter a value", int lowerLimit = 0, int upperLimit = 1000)
        {
            bool gotDub = false;
            bool dubGood = false;
            double userDub = 0;
            do
            {
                Console.WriteLine(msg);
                gotDub= double.TryParse(Console.ReadLine(), out userDub);
                dubGood = (gotDub && lowerLimit <= userDub&& userDub<= upperLimit) ? true : false;
            } while (!dubGood);
            return userDub;
        }

        public string AskForString(string msg = "please enter something", bool confirm = true)
        {
            string userString = "";
            Console.WriteLine(msg);
            userString = Console.ReadLine();
            if (confirm)
            {
                bool userConfirm = AskForBool($"youve entered: {userString}\nplease confirm by entering: Yes/1, No/0");
                while (!userConfirm)
                {
                    Console.WriteLine(msg);
                    userString = Console.ReadLine();
                    userConfirm = AskForBool($"youve entered: {userString}\nplease confirm by entering: Yes/1, No/0");
                }
            }
            return userString;
        }

        public int AskForMenuOption(){
            bool gotInt = false;
            bool intGood = false;
            int userInt = 0;
            if (maxIntAnswer >= 0)
            {
                do
                {
                    Console.WriteLine($"\nplease enter an option ({minIntAnswer}-{maxIntAnswer})");
                    gotInt = int.TryParse(Console.ReadLine(), out userInt);
                    intGood = (gotInt && minIntAnswer <= userInt && userInt <= maxIntAnswer) ? true : false;
                } while (!intGood);
            }
            return userInt;
        }

        public bool AskForBool(string msg = "please enter: yes/1 or no/0"){
            bool boolGood = false;
            string userInput;
            do
            {
                Console.WriteLine(msg);
                userInput = Console.ReadLine();
                if (YouSayYes.Contains(userInput) || YouSayNo.Contains(userInput))
                    boolGood = true;
            } while (!boolGood);
            return (YouSayYes.Contains(userInput));
        }

        public void MenuHandler(int userDec){
            var prod = new DapperProductRepository(_conn);
            var dept = new DapperDepartmentRepository(_conn);
            switch (ActiveMenu.ToLower())
            {
                case "main":
                    LastMenu = "main";
                    MenuCount = 0;
                    switch (userDec){
                        default:
                        case 0:
                            ActiveMenu = "terminate";
                            break;
                        case 1:
                            ActiveMenu = "product_options";
                            MenuCount++;
                            break;
                        case 2:
                            ActiveMenu = "department_options";
                            MenuCount++;
                            break;
                    }
                    break;
                case "terminate":
                    ActiveMenu = (LastMenu != "terminate") ? LastMenu : ActiveMenu;
                    switch (userDec){
                        default: // no
                            break;
                        case 2: // yes
                            MenuCount--;
                            break;
                    }
                    break;
                case "continue":
                    ActiveMenu = (LastMenu != "continue") ? LastMenu : "main";
                    Console.WriteLine("\n press enter to continue...\n");
                    Console.ReadLine();
                    break;
                case "product_options":
                    switch (userDec){
                        default:
                        case 0:
                            MenuCount--;
                            ActiveMenu = "main";
                            break;
                        case 1:
                            ActiveMenu = "product_view";
                            MenuCount++;
                            break;
                        case 2:
                            ActiveMenu = "product_edit";
                            MenuCount++;
                            break;
                    }
                    break;
                case "product_view":
                    switch (userDec){
                        default:
                        case 0:
                            MenuCount--;
                            ActiveMenu = "product_options";
                            break;
                        case 1:
                            int userProduct = AskForInt("please enter the product ID to view\nenter 0 to exit/cancel",0, 99999);
                            LastMenu = ActiveMenu;
                            ActiveMenu = "continue";
                            if (userProduct > 0)
                            {
                                foreach (var singleProd in prod.GetSingleProduct(userProduct))
                                    Console.WriteLine($"{singleProd.ProductID}: {singleProd.Name} ${singleProd.Price}");
                            }
                            Thread.Sleep(1000);
                            break;
                        case 2:
                            Console.WriteLine("print all products");
                            LastMenu = ActiveMenu;
                            ActiveMenu = "continue";
                            prod = new DapperProductRepository(_conn);
                            var allProducts = prod.GetAllProducts();
                            foreach (var p in allProducts)
                                Console.WriteLine($"{p.ProductID}: {p.Name} ${p.Price}");
                            break;
                    }
                    break;
                case "product_edit":
                    switch (userDec)
                    {
                        default:
                        case 0:
                            MenuCount--;
                            ActiveMenu = "product_options";
                            break;
                        case 1:
                            MenuCount++;
                            ActiveMenu = "product_add";
                            break;
                        case 2:
                            MenuCount++;
                            ActiveMenu = "product_delete";
                            break;
                    }
                    break;
                case "product_add":
                    // ask for name, price, category id, then create product.
                    string prodName = AskForString("please enter product name");
                    double prodPrice = AskForDub("please enter product price");
                    int prodCatID = AskForInt("please enter product category ID");
                    prod.CreateProduct(prodName, prodPrice, prodCatID);
                    ActiveMenu = "product_edit";
                    MenuCount--;
                    Thread.Sleep(1000);
                    break;

                case "product_delete":
                    int userDel = AskForInt("please enter id of product to delete.\nenter 0 to exit/cancel\n", 0, 99999);
                    if (userDel > 0 && AskForBool($"\nare you sure you want to delete product id {userDel}?\nplease enter: Yes/1, No/0"))
                    {
                        prod.DeleteProduct(userDel);
                        Console.WriteLine($"productID #: {userDel}, has been deleted...");
                        Thread.Sleep(1000);
                    }
                    ActiveMenu = "product_edit";
                    MenuCount--;
                    break;

                case "department_options":
                    switch (userDec)
                    {
                        default:
                        case 0:
                            MenuCount--;
                            ActiveMenu = "main";
                            break;
                        case 1:
                            ActiveMenu = "department_view";
                            MenuCount++;
                            break;
                        case 2:
                            ActiveMenu = "department_edit";
                            MenuCount++;
                            break;
                    }
                    break;
                case "department_view":
                    switch (userDec)
                    {
                        default:
                        case 0:
                            MenuCount--;
                            ActiveMenu = "department_options";
                            break;
                        case 1:
                            Console.WriteLine("print single department");
                            LastMenu = ActiveMenu;
                            ActiveMenu = "continue";
                            Thread.Sleep(1000);
                            break;
                        case 2:
                            LastMenu = ActiveMenu;
                            ActiveMenu = "continue";
                            var allDepts = dept.GetDepartments();
                            foreach (var d in allDepts)
                                Console.WriteLine($"{d.DepartmentID}: {d.Name}");
                            break;
                    }
                    break;
                case "department_edit":
                    switch (userDec)
                    {
                        default:
                        case 0:
                            MenuCount--;
                            ActiveMenu = "department_options";
                            break;
                        case 1:
                            ActiveMenu = "department_add";
                            MenuCount++;
                            break;
                        case 2:
                            ActiveMenu = "department_delete";
                            MenuCount++;
                            break;
                    }
                    break;

                case "department_add":
                    if (AskForBool("are you sure you want to add a new department?\nenter yes/1 or no/0"))
                    {
                        //Console.WriteLine("please enter the new department name...");
                        //string newDept = Console.ReadLine();
                        string newDept = AskForString("please enter the new department name...");
                        dept.CreateDepartment(newDept);
                        Console.WriteLine($"added new daprtment, {newDept}");
                        Thread.Sleep(1000);
                    }
                    LastMenu = "department_edit";
                    ActiveMenu = "continue"; 
                    MenuCount--;
                    break;

                case "department_delete":
                    int userDeptDel = AskForInt("please enter department you wish to delete...\nenter 0 to exit", 0, 99);
                    if (userDeptDel > 0)
                    {
                        if (AskForBool($"are you sure you want to delete a department {userDeptDel}?\nenter yes/1 or no/0"))
                        {
                            Console.WriteLine("well too bad. you cant delete it.");
                            Thread.Sleep(1000);
                        }
                    }
                    LastMenu = "department_edit";
                    ActiveMenu = "continue";
                    MenuCount--;
                    break;

                default:
                    Console.WriteLine("whoops");
                    break;       
            }
        }

        public void Run(){
            do{
                DisplayMenu();
                MenuHandler(AskForMenuOption()); 
            } while (MenuCount >= 0);
        }
    }
}
