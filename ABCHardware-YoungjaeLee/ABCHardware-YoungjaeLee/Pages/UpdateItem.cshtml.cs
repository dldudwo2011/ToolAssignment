using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ABCHardware_YoungjaeLee.Pages.Inventory
{
    public class UpdateItemModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Item Code is required.")]
        public int ItemCode { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(50, ErrorMessage = "Description cannot exceed 50 characters.")]
        public string Description { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Unit Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit Price must be greater than zero.")]
        public decimal UnitPrice { get; set; }

        public bool Confirmation { get; set; } = false;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Call stored procedure or logic to update item
                Confirmation = true;
            }
        }
    }
}
