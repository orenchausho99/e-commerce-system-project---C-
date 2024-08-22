using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinelProject
{
    internal class Order
    {
        List<Product> Item_List;
        double Total_Price;
        Buyer Buyer;


        public List<Product> GetItem_List()
        {
            return Item_List;
        }


        public bool SetItem_List(List<Product> Item_List)
        {
            if (Item_List == null)
            {
                return false;
            }
            this.Item_List = Item_List;


            return false;
        }

        public double GetTotal_Price()
        {

            return Total_Price;

        }

        public bool SetTotal_Price(double Total_Price)
        {
            if (Total_Price > 0)
            {
                this.Total_Price = Total_Price;
                return true;
            }
            else return false;

        }


        public Buyer getBuyer()
        {
            return Buyer;
        }

        public bool Setbuyer(Buyer Buyer)
        {
            if (Buyer == null)
            {
                return false;

            }
            this.Buyer = Buyer;
            return true;
        }

        public Order(List<Product> Item_List, double Total_Price, Buyer Buyer)

        {

            SetItem_List(Item_List);
            SetTotal_Price(Total_Price);
            Setbuyer(Buyer);


        }

        public Order(List<Product> shoppingCart, Order other)

        {
            SetItem_List(other.Item_List);
            SetTotal_Price(other.Total_Price);
            Setbuyer(other.Buyer);

        }

        public void ToString()
        {
            Console.WriteLine("Total order price " + Total_Price);
            Console.WriteLine("Shopping cart :");
            for (int i = 0; i < Item_List.Count; i++)
            {

                Console.WriteLine($"Product {i + 1} : ");
                Item_List[i].ToString();
                Console.WriteLine("");
            }
            Console.WriteLine("_______________");

        }
    }
}
