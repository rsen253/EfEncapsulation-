using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcSalesApp.Data;
using MvcSalesApp.Domain;
using SharedKernel.Data;

namespace MvcSalesApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        private StringBuilder _logBuilder = new StringBuilder();
        private string _log;
        private OrderSystemContext _context;
        private GenericRepository<Customer> _customerRepository;

        [TestMethod]
        public void CanQueryWithSinglePredicate()
        {
            var result = _customerRepository.FindByKey(1);
            
            Assert.IsTrue(_log.Contains("FROM [dbo].[Customers]"));
        }
    }
}
