using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinelProject
{
    internal class Buyer : User
    {

        List<Product> ShoppingCart;
        List<Order> OrderList;
        double TotalShoppingCart;
        public List<Order> GetOrderList()
        {
            return OrderList;
        }


        public bool SetOrderList(List<Order> OrderList)
        {
            if (OrderList == null)
                return false;

            this.OrderList = OrderList;

            return true;
        }


        public List<Product> GetShoppingCart()
        {
            return ShoppingCart;
        }


        public bool SetShoppingCart(List<Product> ShoppingCart)

        {
            if (ShoppingCart != null)
            {
                this.ShoppingCart = ShoppingCart;
                return true;
            }
            
            return false;


        }
        public bool SetOneItem(Product item, int index)
        {
            if (item != null && (index >= 0 && index <= ShoppingCart.Count))
            {
                ShoppingCart[index] = item;
                return true;
            }
            return false;
        }
        public void AddProduct(Product theproduct)
        {
            ShoppingCart.Add(theproduct);
        }
        public static bool operator <(Buyer count1, Buyer count2)
        {
            count1.SetTotalShoppingCart();
            count2.SetTotalShoppingCart();

            return (count1.GetTotalShoppingCart() < count2.GetTotalShoppingCart());
        }
        public static bool operator >(Buyer count1, Buyer count2)
        {
            count1.SetTotalShoppingCart();
            count2.SetTotalShoppingCart();

            return (count1.GetTotalShoppingCart() > count2.GetTotalShoppingCart());
        }
        public double GetTotalShoppingCart()
        {
            return TotalShoppingCart;
        }


        public double SetTotalShoppingCart()
        {
            double total = 0.0;
            for (int i = 0; i < ShoppingCart.Count; i++)
                total += ShoppingCart[i].GetProduct_Price();
            TotalShoppingCart = total;

            return TotalShoppingCart;
        }


        public void UseOrderHistory(int input)
        {
            if ((OrderList != null) && ((input - 1) <= OrderList.Count) && (input - 1 >= 0))
            {
                ShoppingCart = OrderList[input - 1].GetItem_List();
            }
        }

        public bool Checkout(Buyer buyer)
        {
            if (ShoppingCart.Count == 0)
            {
                throw new Exception("Error - shopping cart is empty!");

            }
            if (ShoppingCart.Count == 1)
            {
                throw new Exception("Error - can not checkout with only one item!");
            }
            double total = SetTotalShoppingCart();
            Order checkout = new Order(ShoppingCart, total, buyer);
            this.ShoppingCart = null;
            AddOrderToOrderList(checkout);
            return true;
        }

        public void AddOrderToOrderList(Order checkout)
        {
            OrderList.Add(checkout);
        }
        public Buyer(string username, string password, Address address, List<Product> ShoppingCart, List<Order> OrderList)
            : base(username, password, address)
        {
            SetShoppingCart(ShoppingCart);
            SetOrderList(OrderList);

        }

        public Buyer() : base()
        {

            ShoppingCart = new List<Product>();
            OrderList = new List<Order>();
        }

        public void OrdersToString()
        {
            Console.WriteLine("Order list:");
            if (OrderList == null)
            {

                Console.WriteLine("Order list is empty");
            }
            else
            {
                for (int j = 0; j < OrderList.Count; j++)
                {
                    if (OrderList[j] != null)
                    {
                        Console.WriteLine($"Order {j + 1} : ");
                        OrderList[j].ToString();
                    }

                }
            }
        }
        public void ToString()
        {
            Console.WriteLine("The format:[name][password]");
            Console.WriteLine($"Username: {username}, Password: {password}");
            address.ToString();          
            Console.WriteLine("\n Orders & shopping cart : \n");
            Console.WriteLine("Shopping cart:");
            if (ShoppingCart == null)
            {
                Console.WriteLine("Shopping cart is empty");
            }
            else
            {
                for (int i = 0; i < ShoppingCart.Count; i++)
                {
                    if (ShoppingCart[i] != null)
                    {
                        Console.WriteLine($"Product {i + 1} : ");
                        ShoppingCart[i].ToString();
                    }

                }
            }
            Console.WriteLine("\n");
            OrdersToString();
        }




    }
}




    
