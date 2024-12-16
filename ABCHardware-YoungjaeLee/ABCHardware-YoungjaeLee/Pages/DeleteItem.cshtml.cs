using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ABCHardware_YoungjaeLee.Domain;

namespace ABCHardware_YoungjaeLee.Pages.Inventory
{
    public class DeleteItemModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Item Code is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Item Code must be greater than 0.")]
        public string ItemCode { get; set; } = string.Empty;


        public bool Confirmation { get; set; } = false;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Call the BCS layer to add the item
                BCS RequestDirector = new();
                Confirmation = RequestDirector.RemoveItem(ItemCode);
            }
        }
    }
}
