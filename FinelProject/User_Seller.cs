using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinelProject
{
    internal class Seller : User
    {
        int numOfProducts = 0;
        List<Product> itemList;


        public int GetNumOfProducts()
        { return numOfProducts; }

        public List<Product> GetItemList()
        {
            return itemList;
        }

        public bool SetItemList(List<Product> itemList)
        {
            if (itemList != null)
            {
                this.itemList = itemList;
                return true;
            }
            return false;
        }
        public bool SetOneItem(Product item, int index)
        {
            if (item != null && (index >= 0 && index <= itemList.Count))
            {
                itemList[index] = item;
                return true;
            }
            return false;
        }
        public void AddItem(Product theitem)
        {
            itemList.Add(theitem);
            numOfProducts++;
        }

           

        
        public Seller(string username, string password, Address address, List<Product> itemList, int numOfProducts)
            :base (username, password, address)
        {
            this.numOfProducts = numOfProducts;
            this.itemList = itemList;
        }
        public Seller() : base ()
        {
            numOfProducts = 0;
            itemList = new List<Product>();
        }

        public void  ToString()
        {
            Console.WriteLine("The format:[Name][Password]");
            Console.WriteLine("Username: " + username + "  Password: " + password);
            address.ToString();
            Console.WriteLine("Num of products: " + numOfProducts + "\nSeller item list :");
            if (itemList != null)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i] != null)
                    {
                        Console.WriteLine($"Product {i+1} : ");

                        itemList[i].ToString();
                    }

                }
            }
            else
                Console.WriteLine("There are no items");
        }
    }
}

