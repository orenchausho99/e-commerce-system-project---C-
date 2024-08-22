using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinelProject
{
    public class Address
    {
        string streetName;
        string city;
        string state;
        int adressNum;

        public string getStreetName()
        {
            return streetName;
        }
        public string getCity()
        {
            return city;
        }
        public string getState()
        {
            return state;
        }
        public int getAdressNum()
        {
            return adressNum;
        }
        public bool SetStreetName(string str)
        {
            streetName = str;
            return true;
        }
        public bool SetCity(string str)
        {
            city = str;
            return true;
        }
        public bool SetState(string str)
        {

            state = str;
            return true;
        }
        public bool SetAdressNum(int n)
        {

            adressNum = n;
            return true;
        }
        public Address(int adressNum, string state, string city, string streetName)
        {
            Console.WriteLine("Creating a new adress...");
            while (!SetStreetName(streetName))
                streetName = Console.ReadLine();
            while (!SetCity(city))
                city = Console.ReadLine();
            while (!SetState(state))
                state = Console.ReadLine();
            while (!SetAdressNum(adressNum))
                adressNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Done!");
        }
        public Address(Address other)
        {
            streetName = other.streetName;
            city = other.city;
            adressNum = other.adressNum;
            state = other.state;
        }
        public Address()
        {
            adressNum = 0;
            city = "";
            state = "";
            streetName = "";
        }

        public void ToString()
        {
            Console.WriteLine("The address format:[Street][Number][City][State]");
            Console.WriteLine(streetName + " " + adressNum + " " + city + " " + state);
        }
    }
}