using Assignment5.Models;
using Assignment5.TechnicalServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment5.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PrimeController : Controller
    {
        bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        [HttpGet("{number}")]
        public bool Get(int number)
        {
            bool CheckIfPrime = IsPrime(number);
            return CheckIfPrime;
        }
    }


}
