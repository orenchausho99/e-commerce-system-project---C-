using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinelProject
{
    internal class Store
    {
        string name;
        List<Seller> listOfSellers;
        List<Buyer> listOfBuyers;

        public string GetName()
        {
            return name;
        }
        public List<Seller> GetListOfSellers()
        {
            return listOfSellers;
        }
        public List<Buyer> GetListOFBuyer()
        {
            return listOfBuyers;
        }
        public bool SetName(string name)
        {
            if (name != null)
            {
                this.name = name;
                return true;
            }
            return false;
        }
        public bool SetListOfSellers(List<Seller> sellers)
        {
            if (sellers != null)
            {
                listOfSellers = sellers;
                return true;
            }
            return false;
        }

        public bool SetListOfBuyer(Buyer buyer, int index)
        {
            if (buyer != null && (index >= 0 && index <= listOfBuyers.Count))
            {
                listOfBuyers[index] = buyer;
                return true;
            }
            return false;
        }

        public void AddUserBuyer(Buyer ub)
        {
            listOfBuyers.Add(ub);
        }
        public static Store operator +(Store store,Buyer ub)
        {
            store.listOfBuyers.Add(ub);
            return store;
        }
        public static Store operator +(Store store, Seller us)
        {
            store.listOfSellers.Add(us);
            return store;
        }

        public void AddUserSeller(Seller us)
        {
            listOfSellers.Add(us);
        }

        public Store(string name, List<Seller> listOfSellers, List<Buyer> listOfBuyers)
        {
            this.name = name;
            this.listOfSellers = new List<Seller>();
            this.listOfBuyers = new List<Buyer>();
        }
        public Store()
        {
            name = "";
            listOfBuyers = new List<Buyer>();
            listOfSellers = new List<Seller>();
        }
        public void DisplayAllBuyers()
        {
            Console.WriteLine(name + "shop buyers:");

            Console.WriteLine("\n List of Buyers");
            if (listOfBuyers.Count != 0)
            {
                for (int j = 0; j < listOfBuyers.Count; j++)
                {
                   
                        Console.WriteLine("Buyer " + (j + 1) + ":");
                        listOfBuyers[j].ToString();
                        Console.WriteLine("\n------------\n");
                }

            }
            else
            {
                Console.WriteLine("There are no buyers!");
            }
        }
        public void DisplayAllSellers()
        {
            listOfSellers.Sort((p1, p2) => p2.GetNumOfProducts().CompareTo(p1.GetNumOfProducts()));
            Console.WriteLine(" Shop Data:");

            Console.WriteLine("List of Sellers:");
            if (listOfSellers == null || listOfSellers.Count == 0)
            {
                Console.WriteLine("There are no sellers");
                return;
            }
            for (int i = 0; i < listOfSellers.Count; i++)
            {
             
                    Console.WriteLine("Seller " + (i + 1) + ":");
                    listOfSellers[i].ToString();
                    Console.WriteLine("\n------------\n");
                
            }

        }
        public void Tostring()
        {        
            Console.WriteLine("\n List of Buyers");
            for (int j = 0; j < listOfBuyers.Count; j++)
            {
                Console.WriteLine("Buyer " + (j + 1) + ":");
                listOfBuyers[j].ToString();
            }
        }
    }
}
