using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ABCHardware_YoungjaeLee.Domain;

namespace ABCHardware_YoungjaeLee.Pages.Item
{
    public class AddItemModel : PageModel
    {


        [BindProperty]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Unit Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit Price must be greater than 0.")]
        public decimal UnitPrice { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Quantity On Hand is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity On Hand cannot be negative.")]
        public int QuantityOnHand { get; set; }

        public bool Confirmation { get; set; } = false;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Create an Item object from the input data
                Domain.Item newItem = new Domain.Item
                {
                    Description = Description,
                    UnitPrice = UnitPrice,
                    QuantityOnHand = QuantityOnHand
                };

                // Call the BCS layer to add the item
                BCS RequestDirector = new();
                Confirmation = RequestDirector.CreateItem(newItem);
            }
        }
    }
}

