using MvcSalesApp.Web.Models.Enums;
using System;

namespace MvcSalesApp.Web.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderSource OrderSource { get; set; }
        public int CustomerId { get; set; }
    }
}