﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSalesApp.Web.Models
{
    public class Category
    {
        private ICollection<Product> _products;
        public Category()
        {
            _products = new List<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
    }
}