using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinelProject
{
    internal class Product
    {
        public enum Category
        {
            defult, kids, electronics, office, clothing
        }
        Category category;
        int CatalogNumber;
        static int nextCatalogNumber = 100000;
        string Product_Name;
        double Product_Price;
        bool special_packaging;

        public bool Setspecial_packaging(char special_packaging)
        {
            if (special_packaging == 'Y'|| special_packaging == 'y')
            {               
                this.special_packaging = true;
                Console.WriteLine($"Special packaging is set to {special_packaging}");
                return true;
            }
            if (special_packaging == 'N' || special_packaging == 'n')
            {
                this.special_packaging = false;
                return true;
            }

             return false;
        }
        public string GetProduct_Name()
        {

            return Product_Name;
        }
        public bool Getspecial_packaging()
        {

            return special_packaging;
        }

        public bool SetProduct_Name(string Product_Name)
        {
            this.Product_Name = Product_Name;
            return true;
        }

        public double GetProduct_Price()
        {

            return Product_Price;
        }


        public bool SetProduct_Price(double Product_Price)
        {
          
            this.Product_Price = Product_Price;
            return true;
        }


        public Category GetCategory()
        {
            return category;
        }




        public bool SetCategory(Category input)
        {
            category = input;
            return true;
        }



        public Product()
        {
            Product_Name = "";
            Product_Price = 0;
            category = 0;
            special_packaging = false;
            CatalogNumber = nextCatalogNumber++;
        }
        public Product(Product other)
        {
            Product_Name = other.Product_Name;
            Product_Price = other.Product_Price;
            category = other.category;
            special_packaging = other.special_packaging;
            CatalogNumber = nextCatalogNumber++;
        }


        public void ToString()
        {
            Console.WriteLine("The product format:[Catalog Number][Name][Price][Category][Special packaging]");
            Console.WriteLine(CatalogNumber + ": " + Product_Name + " " + Product_Price + " " + category + " " + special_packaging);
        }

    }

}
