using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static FinelProject.Product;

namespace FinelProject
{

internal class Program
    {

        private static string GetStringInput(string prompt, string errorMessage)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException(errorMessage);
                    }
                    return input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private static int GetIntInput(string prompt, string nullErrorMessage, string intErrorMessage)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException(nullErrorMessage);
                    }
                    if (!int.TryParse(input, out int value) || value <= 0)
                    {
                        throw new ArgumentException(intErrorMessage);
                    }
                    return value;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private static double GetDoubleInput(string prompt, string nullErrorMessage, string doubleErrorMessage)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentNullException(nameof(input), nullErrorMessage);
                    }
                    if (!double.TryParse(input, out double value) || value <= 0)
                    {
                        throw new ArgumentException(doubleErrorMessage);
                    }
                    return value;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            int input = -1;
            Store store = new Store();
            store.SetName("Karnaf_Afula ");
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(exeDirectory, "Seller Data.txt");
            string format = store.GetName() + " Seller Data:\nFormat: Username, Password\nAdress\nList of items\n\n";
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
            }
            else
            {
                string fileContent = File.ReadAllText(filePath);
                string[] users = fileContent.Split(new[] { "&&" }, StringSplitOptions.RemoveEmptyEntries);
                Seller[] savedsellers = new Seller[users.Length];
                Address saveduseraddresse = new Address();
                Category category;
                for (int i = 1; i < users.Length; i++)
                {
                    savedsellers[i]= new Seller();
                    string[] parameters = users[i].Split(new[] { "**" }, StringSplitOptions.RemoveEmptyEntries);
                    savedsellers[i].SetUserName(parameters[0]);
                    savedsellers[i].SetPassword(parameters[1]);
                    saveduseraddresse.SetStreetName(parameters[2]);
                    saveduseraddresse.SetAdressNum(int.Parse(parameters[3]));
                    saveduseraddresse.SetCity(parameters[4]);
                    saveduseraddresse.SetState(parameters[5]);
                    savedsellers[i].SetAddress(saveduseraddresse);
                    for (int j = 6; j < parameters.Length; j += 4)
                    {
                        Product savedproduct = new Product();
                        savedproduct.SetProduct_Name(parameters[j]);
                        savedproduct.SetProduct_Price(double.Parse(parameters[j + 1]));
                        Enum.TryParse(parameters[j + 2], true, out category);
                        savedproduct.SetCategory(category);
                        if (parameters[j + 3] == "True")
                        {
                            savedproduct.Setspecial_packaging('t');
                        }
                        else
                        {
                            savedproduct.Setspecial_packaging('f');
                        }
                        savedsellers[i].AddItem(savedproduct);
                    }
                    store.AddUserSeller(savedsellers[i]);
                }
            }

            while (input != 9)
            {
                Console.WriteLine(" 1. Add a buyer \n 2. Add a seller \n 3. Add an item to a seller \n 4. Add" +
                    " an item to shopping cart \n 5. Checkout \n 6. Print All Buyer\n 7. Print all sellers \n 8. Compare two Buyers\n 9. Exit\n");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Buyer ub = new Buyer();


                            Console.WriteLine("Add buyer address");
                            Console.WriteLine("Format: [Street Name] [Number] [City] [State]");

                                                       
                          string streetName = GetStringInput( "Street Name: ", "String cannot be null or empty!");

                            int adressNum = GetIntInput("Adress Number: ", "Error input - a number cannot be null or empty!","Invalid int - must be a valid int that is bigger then zero!");
                         
                            string city = GetStringInput("City Name: ", "String cannot be null or empty!");
                         
                            string state = GetStringInput("State: ", "String cannot be null or empty!");

                            Address ubAddress = new Address(adressNum, state, city, streetName);

                            ub.SetAddress(ubAddress);
                            Console.WriteLine("User address added!\nAdd buyer details\nFormat: [User Name] [Password]");


                            string userName = GetStringInput("UserName:  ", "Invalid user name.");
 
                            
                            string password = GetStringInput("Password: ", "Invalid password.");
                            ub.SetUserName(userName);
                            ub.SetPassword(password);
                            store = store + ub;
                            Console.WriteLine("User details added successfully!");

                            break;
                        }
                    case 2:
                        {
                            Seller us = new Seller();

                            Console.WriteLine("Add seller address");
                            Console.WriteLine("Format: [Street Name] [Number] [City] [State]");

                            string streetName = GetStringInput("Street Name: ", "String cannot be null or empty!");

                            int adressNum = GetIntInput("Address Number: ", "Error input - a number cannot be null or empty!"
                                , "Invalid int - must be a valid int that is bigger then zero!");

                            string city = GetStringInput("City Name: ", "String cannot be null or empty!");

                            string state = GetStringInput("State: ", "String cannot be null or empty!");


                            Address usadress = new Address(adressNum, state, city, streetName);
                            us.SetAddress(usadress);
                            Console.WriteLine("User Address added!\nAdd Sellers details \nFormat: [User Name][Password]");


                            string userName = GetStringInput("UserName:  ", "Invalid user name.");


                            string password = GetStringInput("Password: ", "Invalid password.");
                            us.SetUserName(userName);
                            us.SetPassword(password);
                            store = store + us;
                            Console.WriteLine("User details added successfully!");


                            break;
                        }
                    case 3:
                        {
                            bool flag = false;
                            Product theitem = new Product();

                            string Product_Name = GetStringInput("Enter the item name:", "Invalid item name!");
                            
                         
                            double Product_Price = GetDoubleInput("Enter the item price:", "Error input - a number cannot be null or empty!"
                                , "Invalid item price - must be a valid number that is bigger then zero!");
                            theitem.SetProduct_Price(Product_Price);
                            theitem.SetProduct_Name(Product_Name);


                            
                            string input2 = GetStringInput("Enter item category (kids,electronics,office,clothing): ", "Category cannot be null or empty!") ;
                            Category category;


                            while (!Enum.TryParse(input2, true, out category) || !theitem.SetCategory(category))
                            {
                                Console.WriteLine("Invalid item category! Please enter a valid category (kids,electronics,office,clothing) :");
                                input2 = GetStringInput("Enter item category (kids,electronics,office,clothing): ", "Category cannot be null or empty!");
                            }

                            
                            string special_packaging = GetStringInput("Would you like to add a special packaging ?:" + "\n type : yes:Y ,no:N\n", "The special packaging cannot be null or empty!");
                                               
                                while ((theitem.Setspecial_packaging((char)special_packaging[0])== false)
                                ||special_packaging.Length!=1)
                                {
                                    Console.WriteLine("Invalid input");
                                    special_packaging = GetStringInput("Would you like to add a special packaging ?:" + "\n type : yes:Y ,no:N\n"
                                        , "The special packaging cannot be null or empty!");
                                }
                            
                                Console.WriteLine(" Write the seller username you want to add for him. ");
                                string uname = Console.ReadLine();
                                if (store.GetListOfSellers() != null)
                                {
                                    for (int i = 0; i < store.GetListOfSellers().Count; i++)
                                        if (store.GetListOfSellers()[i].GetUserName() == uname)
                                        {
                                            store.GetListOfSellers()[i].AddItem(theitem);
                                            flag = true;
                                            break;
                                        }
                                }

                                if (flag)
                                {
                                    Console.WriteLine("Item details added successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("No user found");
                                }
                            
                                break;
                        }
                        
                    case 4:
                { 
                        bool productFound = false;
                        bool buyerFound = false;
                        Console.WriteLine("Would you like to add new product or use order history?");                       
                       string c = GetStringInput("Use order history? Y/N\n" , "Input cannot be null or empty!") ;

                            char ch = c[0];

                            while ((c[0] != 'y' && c[0] != 'Y' && c[0] != 'n' && c[0] != 'N') || c.Length != 1)
                            {
                                Console.WriteLine("Error input - the input not in the currect format (Y/N)");
                                c = GetStringInput("Use order history? Y/N\n", "Input cannot be null or empty!");
                            }
                           
                        if (ch == 'Y' || ch == 'y')
                        {
                            Console.WriteLine("Write the buyer username you want to add for him:");
                            string uname = Console.ReadLine();
                            if (store.GetListOFBuyer() != null)
                            {

                                for (int l = 0; l < store.GetListOFBuyer().Count; l++)
                                {

                                    if (store.GetListOFBuyer()[l] != null
                                        && store.GetListOFBuyer()[l].GetUserName() == uname && store.GetListOFBuyer()[l].GetOrderList().Count != 0)
                                    {
                                        store.GetListOFBuyer()[l].OrdersToString();
                                        buyerFound = true;
                                        Console.WriteLine("Select which order to import , type the order number:");
                                        int input2 = int.Parse(Console.ReadLine());
                                        store.GetListOFBuyer()[l].UseOrderHistory(input2);
                                        productFound = true;
                                            Console.WriteLine("\nOrder history was successfully used!\n");
                                            break;
                                    }
                                    else if (store.GetListOFBuyer()[l].GetOrderList().Count ==0 )
                                        {
                                            Console.WriteLine("No order list were found.\n");
                                            buyerFound = true;
                                            productFound = true;
                                            break;
                                        }
                                }
                                
                                if (!buyerFound)
                                {
                                    Console.WriteLine("The buyer username you entered does not exist.");
                                }
                            }
                        }
                        else if (ch == 'N' || ch == 'n')
                        {
                            string Product_Name = GetStringInput("Enter the product name:", "The product name cannot be null or empty!");

                            if (store.GetListOfSellers() != null)
                            {

                                for (int i = 0; i < store.GetListOfSellers().Count; i++)
                                {

                                    if (store.GetListOfSellers()[i] != null && store.GetListOfSellers()[i].GetItemList() != null)
                                    {

                                        for (int j = 0; j < store.GetListOfSellers()[i].GetItemList().Count; j++)
                                        {

                                            if (store.GetListOfSellers()[i].GetItemList()[j] != null
                                                && store.GetListOfSellers()[i].GetItemList()[j].GetProduct_Name() == Product_Name)
                                            {
                                                Product theproduct = store.GetListOfSellers()[i].GetItemList()[j];
                                                productFound = true;
                                                Console.WriteLine("Write the buyer username you want to add for him:");
                                                string uname = Console.ReadLine();
                                                if (store.GetListOFBuyer() != null)
                                                {

                                                    for (int k = 0; k < store.GetListOFBuyer().Count; k++)
                                                    {

                                                        if (store.GetListOFBuyer()[k] != null
                                                            && store.GetListOFBuyer()[k].GetUserName() == uname)
                                                        {
                                                            store.GetListOFBuyer()[k].AddProduct(theproduct);
                                                            Console.WriteLine("Product details added successfully!");
                                                            buyerFound = true;
                                                            break;
                                                        }
                                                    }
                                                    if (!buyerFound)
                                                    {
                                                        Console.WriteLine("The buyer username you entered does not exist.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("There are no buyers in the system.");
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }

                        if (!productFound)
                        {
                            Console.WriteLine("The product you are looking for does not exist.");
                        }

                        break;
                }
                        
                    case 5:
                        {
                            bool flag = false;
                            Console.WriteLine("Write the username you want to check out");
                            string uname = Console.ReadLine();
                            if (store.GetListOFBuyer() != null)
                            {
                                for (int i = 0; i < store.GetListOFBuyer().Count; i++)
                                    if (store.GetListOFBuyer()[i].GetUserName() == uname)
                                    {
                                        try
                                        {
                                            if (store.GetListOFBuyer()[i].Checkout(store.GetListOFBuyer()[i]))
                                            {
                                                Console.WriteLine("Checkout done!");
                                                flag = true;
                                                break;

                                            }
                                        }
                                        catch(Exception e) 
                                        {
                                            flag = true;
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                if (flag != true)
                                    Console.WriteLine("Username does not exist");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("There are no users");
                                break;
                            }

                        }
                    case 6:
                        {
                            store.DisplayAllBuyers();
                            break;
                        }
                    case 7:
                        {
                            store.DisplayAllSellers();
                            break;
                        }
                    case 8:
                        {
                            store.DisplayAllBuyers();
                            Console.WriteLine("\nEnter two buyers usernames to compare:\n");
                            string buyer1_username = GetStringInput("The first  buyer username:\n", "Invalid user name.\n");
                            
                            string buyer2_username = GetStringInput("The second buyer username:\n", "Invalid user name.\n");
                            Buyer buyer1= null;
                            Buyer buyer2= null;
                            bool flag1 = false;
                            bool flag2 = false;

                            for (int i = 0; i< store.GetListOFBuyer().Count;i++)
                            {
                                if (store.GetListOFBuyer()[i].GetUserName() == buyer1_username)
                                {
                                    buyer1 = store.GetListOFBuyer()[i];
                                    flag1 = true;   
                                }

                                if (store.GetListOFBuyer()[i].GetUserName() == buyer2_username)
                                {
                                     buyer2 = store.GetListOFBuyer()[i];                                    
                                     flag2 = true;
                                }

                            }
                            if (!flag1&& !flag2)
                            {
                                Console.WriteLine("\nBoth buyers were not found.\n");
                                break;
                            }

                            if (!flag1)
                            {
                                Console.WriteLine("\nBuyer1 not found.\n");
                                break;
                            }

                            if (!flag2)
                            {
                                Console.WriteLine("\nBuyer2 not found.\n");
                                break;
                            }

                            if (buyer1.SetTotalShoppingCart() > buyer2.SetTotalShoppingCart())
                            {
                                Console.WriteLine("The total shopping cart price of buyer-" + buyer1_username
                                   + "\nis greater from the total shoping cart of buyer-" + buyer2_username +"\n");

                            }

                            if (buyer1.SetTotalShoppingCart() < buyer2.SetTotalShoppingCart())
                            {
                                Console.WriteLine("The total shopping cart price of buyer-" + buyer2_username
                                   + "\nis greater from the total shoping cart of buyer-" + buyer1_username + "\n");

                            }

                            if (buyer1.SetTotalShoppingCart() == buyer2.SetTotalShoppingCart())
                            {
                                Console.WriteLine("Both of the total shopping cart prices are equal!\n");
                            }
                       
                            break;
                        }
                    case 9:
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid input");
                            break;
                        }

                }
                StringBuilder output = new StringBuilder();
                output.Append(format);
                for (int i=0;i<store.GetListOfSellers().Count;i++)
                {
                    string sellerInfo = "&&**" + store.GetListOfSellers()[i].GetUserName() + "**" + store.GetListOfSellers()[i].GetPassword() +"**";
                    output.Append(sellerInfo);
                    string sellerAdressInfo = store.GetListOfSellers()[i].GetAddress().getStreetName() + "**" + store.GetListOfSellers()[i].GetAddress().getAdressNum() +"**"
                        + store.GetListOfSellers()[i].GetAddress().getCity() +"**" + store.GetListOfSellers()[i].GetAddress().getState() +"**";
                    output.Append(sellerAdressInfo);
                    for (int j = 0; j < store.GetListOfSellers()[i].GetItemList().Count;j++)
                    {
                        string itemInfo = store.GetListOfSellers()[i].GetItemList()[j].GetProduct_Name() +"**" + store.GetListOfSellers()[i].GetItemList()[j].GetProduct_Price() +"**"
                            + store.GetListOfSellers()[i].GetItemList()[j].GetCategory() +"**" + store.GetListOfSellers()[i].GetItemList()[j].Getspecial_packaging() +"**";
                        output.Append(itemInfo);
                    }
                    output.Append("&&");
                }
                File.WriteAllText(filePath, output.ToString());
                Console.WriteLine("");
            }
        }
    }
}
 