using System;
using System.Collections.Generic;

namespace MvcSalesApp.Web.Models
{
    public class Customer
    {
        public Customer()
        {
            FirstName = "";
            LastName = "";
            DateOfBirth = DateTime.Today;
            Orders = new List<Order>();
            Addresses = new List<Address>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ContactDetail ContactDetails { get; set; }

        public List<Order> Orders { get; set; }
        public List<Address> Addresses { get; set; }

        public string FullNamed
        {
            get
            {
                return LastName.Trim() + ", " + FirstName; 
            }
        }
    }
}