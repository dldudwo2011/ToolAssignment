using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ABCHardware_YoungjaeLee.Domain;

namespace ABCHardware_YoungjaeLee.Pages.Customer
{
    public class AddCustomerModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Customer Name is required.")]
        [StringLength(50, ErrorMessage = "Customer Name cannot exceed 50 characters.")]
        public string CustomerName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Province is required.")]
        public string Province { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Postal Code is required.")]
        public string PostalCode { get; set; } = string.Empty;

        public bool Confirmation { get; set; } = false;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Domain.Customer newCustomer = new Domain.Customer
                {
                    CustomerName = CustomerName,
                    Address = Address,
                    City = City,
                    Province = Province,
                    PostalCode = PostalCode
                };
                // Call stored procedure or logic to add customer
                BCS RequestDirector = new();
                Confirmation = RequestDirector.CreateCustomer(newCustomer);
            }
        }
    }
}
