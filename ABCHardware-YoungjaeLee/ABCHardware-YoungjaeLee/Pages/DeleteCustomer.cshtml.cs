using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ABCHardware_YoungjaeLee.Domain;

namespace ABCHardware_YoungjaeLee.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Customer ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "CustomerID must be greater than 0.")]
        public int CustomerID { get; set; }

        public bool Confirmation { get; set; } = false;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Call the BCS layer to add the item
                BCS RequestDirector = new();
                Confirmation = RequestDirector.RemoveCustomer(CustomerID);
            }
        }
    }
}
