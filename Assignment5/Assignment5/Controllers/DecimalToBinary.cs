using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecimalToBinaryController : Controller
    {
        int DecimalNumberToBinary(int number)
        {
            if (number == 0)
                return 0;

            int binary = 0;
            int placeValue = 1; // Represents 10^0 initially

            while (number > 0)
            {
                int remainder = number % 2; // Get the binary digit (0 or 1)
                binary += remainder * placeValue; // Add it to the binary result
                placeValue *= 10; // Move to the next place value (10^n)
                number /= 2; // Divide the number by 2
            }

            return binary;
        }
        [HttpGet("{decimalNumber}")]
        public int Get(int decimalNumber)
        {
            int ResultedBinaryNumber = DecimalNumberToBinary(decimalNumber);
            return ResultedBinaryNumber;
        }
    }
}
