using Assignment5.Models;
using Assignment5.TechnicalServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment5.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryToDecimalController : Controller
    {
        int BinaryNumberToDecimal(int binaryInput)
        {
            if (binaryInput < 0)
            {
                Console.WriteLine("Error: Input must be a non-negative binary number.");
                return -1; // Error code for invalid input
            }

            int decimalValue = 0;
            int baseValue = 1; // Represents 2^0 initially

            // Validate the input to ensure it is a valid binary number
            int temp = binaryInput;
            while (temp > 0)
            {
                int digit = temp % 10;
                if (digit != 0 && digit != 1)
                {
                    Console.WriteLine("Error: Input is not a valid binary number.");
                    return -1; // Error code for invalid input
                }
                temp /= 10; // Move to the next digit
            }

            // Convert binary to decimal
            while (binaryInput > 0)
            {
                int lastDigit = binaryInput % 10; // Extract the last digit
                decimalValue += lastDigit * baseValue; // Add to decimal value
                baseValue *= 2; // Move to the next power of 2
                binaryInput /= 10; // Remove the last digit
            }

            return decimalValue;
        }

        [HttpGet("{binaryNumber}")]
        public int Get(int binaryNumber)
        {
            int ResultedDecimalNumber = BinaryNumberToDecimal(binaryNumber);
            return ResultedDecimalNumber;
        }
    }
}
