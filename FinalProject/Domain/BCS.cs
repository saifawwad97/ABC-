using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.TechnicalServices;

namespace FinalProject.Domain
{
    public class BCS
    {
        
      
        public List<Item> AddToCart(string ItemCode, int Quantity)
        {

            Items item = new Items();
            List<Item> addtocart = new List<Item>();


            addtocart = item.AddtoCart(ItemCode, Quantity);


            return addtocart;
        }

        ///////////////////////////////////////////////////////////////////
        public bool CreateNewCustomer(string CustomerID, string CustomerName, string Addresses, string City , string Province, string PostalCode)
        {
            bool confirmation = true;
            Customers cus = new Customers();

            confirmation = cus.AddCustomer(CustomerID, CustomerName, Addresses,City,Province,PostalCode);

            return confirmation;
        }

        public bool UpdateCustomer(string CustomerID, string CustomerName, string Addresses, string City, string Province, string PostalCode)
        {
            
            bool confirmation = true;
            Customers cus = new Customers();

            confirmation = cus.Updatecustomer(CustomerID, CustomerName, Addresses, City, Province, PostalCode);

                return confirmation;
        }

       public bool DeleteCustomer(string CustomerID)
       {
                
                    bool confirmation = true;
                    Customers cus = new Customers();

                    confirmation = cus.deleteCustomer(CustomerID);

                    return confirmation;
                
       }

            /// <summary>
            /// //////////// Item Section ///////////////////////////////////////////////////////////
            /// </summary>
            /// <param name="ItemCode"></param>
            /// <param name="Description"></param>
            /// <param name="UnitPrice"></param>
            /// <returns></returns>
        public  bool CreateNewItem(string ItemCode, string Description , int  UnitPrice , int Quantity)
        {
            bool confirmation = true;
            Items item = new Items();

            confirmation = Items.AddItem(ItemCode, Description,UnitPrice, Quantity);

            return confirmation;
        }
        

      
        public  bool updateItem(string ItemCode, string Description, int UnitPrice, int Quantity)
        {
            bool confirmation = true;
            Items item = new Items();

            confirmation = Items.UpdateItem(ItemCode, Description, UnitPrice, Quantity);

            return confirmation;
        }

        public  bool deleteItem(string ItemCode)
        {
            
                bool confirmation = true;
                Items item = new Items();

                confirmation = Items.DeleteItem(ItemCode);

                return confirmation;
            
        }

        public List<Item> GetItem(string ItemCode)
        {

            Items item = new Items();
            List<Item> getitem = new List<Item>();


            getitem = item.ReturnItem(ItemCode);


            return getitem;
        }



    }
}
