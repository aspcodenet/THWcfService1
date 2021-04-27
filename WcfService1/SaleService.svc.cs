using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SaleService : ISaleService
    {
        public static List<Customer> cutomerList = new List<Customer>()
        {
            new Customer {CustomerID = 1, CustomerName="Kalle Karlsson",
                Address="Stockholm", EmailId="kalle@yahoo.com" },
            new Customer {CustomerID = 2, CustomerName="Lisa Larsson",
                Address="Örebro", EmailId="lisa@yahoo.com" },
            new Customer {CustomerID = 3, CustomerName="Mia Mårtensson",
                Address="Göteborg", EmailId="Mia@yahoo.com"}
        };

        public bool InsertCustomer(Customer customer)
        {
            cutomerList.Add(customer);
            return true;
        }

        public List<Customer> GetAllCustomer()
        {
            return cutomerList;
        }

        public bool DeleteCustomer(int id)
        {
            var item = cutomerList.First(x => x.CustomerID == id);

            cutomerList.Remove(item);
            return true;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var existing = cutomerList.FirstOrDefault(r => r.CustomerID == customer.CustomerID);
            existing.Address = customer.Address;
            existing.EmailId = customer.EmailId;
            return true;
        }

    }
}
