using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinelProject

   
{
       public class User
        {
            protected string username;
            protected string password;
            protected Address address;

            public virtual string GetUserName()
            {
                return username;
            }
            public virtual string GetPassword()
            {
                return password;
            }
            public virtual Address GetAddress()
            {
                return address;
            }
        public virtual bool SetUserName(string username)
        {
            this.username = username;
            return true;
        }
        public virtual bool SetPassword(string password)
        {
            this.password = password;
            return true;
        }

        public  void SetAddress(Address address)
            {
                this.address = new Address(address);
            }
            public virtual void SetAddress(int adressNum, string state, string city, string streetNames)
            {
                this.address = new Address(address);
            }
            public User(string username, string password, Address address)
            {
                this.username = username;
                this.password = password;
                this.address = address;
            }
            public User()
            {
            username = "";
            password = "";
            address = null;
        
            }

       }

}


