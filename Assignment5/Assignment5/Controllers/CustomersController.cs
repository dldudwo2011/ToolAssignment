using Microsoft.AspNetCore.Mvc;
using Assignment5.Models;
using Assignment5.TechnicalServices;

namespace Assignment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        [HttpGet]
        public List<Customer> Get()
        {
            Customers CustomerManager = new();
            List<Customer> Customers = CustomerManager.GetCustomers();
            return Customers;
        }

        [HttpGet("{customerID}")]
        public Customer Get(string customerID)
        {
            Customers CustomerManager = new();
            Customer Customer = CustomerManager.GetCustomer(customerID);
            return Customer;
        }
    }
}
