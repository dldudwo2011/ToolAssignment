using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using ABCHardware_YoungjaeLee.Domain;
using Microsoft.Data.SqlClient;
using System.Data;

public class AddSaleModel : PageModel
{
    private readonly string _connectionString = "YourConnectionStringHere";

    public List<Item> Items { get; set; } = new List<Item>();

    [BindProperty]
    [Required(ErrorMessage = "Sale Date is required.")]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "1/1/1753", "12/31/9999", ErrorMessage = "Sale Date must be between 1/1/1753 and 12/31/9999.")]
    public DateTime SaleDate { get; set; }


    [Required]
    [BindProperty]
    [Range(1, int.MaxValue, ErrorMessage = "Salesperson ID must be a positive number.")]
    public int SalespersonID { get; set; }

    [Required]
    [BindProperty]
    [Range(1, int.MaxValue, ErrorMessage = "Customer ID must be a positive number.")]
    public int CustomerID { get; set; }

    [Required]
    [BindProperty]
    public string SalesItemsJson { get; set; }

    [BindProperty]
    public decimal SubTotal { get; set; }

    [BindProperty]
    public decimal GST { get; set; }

    [BindProperty]
    public decimal SaleTotal { get; set; }


    public int SaleNumber { get; set; }

    public void OnGet()
    {
    // Fetch items for dropdown
      
        BCS RequestDirector = new();
        Items = RequestDirector.GetItems();

    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            // Parse sales items from JSON
            List<SalesItem> salesItems = JsonSerializer.Deserialize<List<SalesItem>>(SalesItemsJson);

            // Prepare the sale object
            Sale newSale = new()
            {
                SaleDate = SaleDate,
                SalespersonID = SalespersonID,
                CustomerID = CustomerID,
                SubTotal = SubTotal,
                GST = GST,
                SaleTotal = SaleTotal,
                SalesItems = salesItems
            };

            // Call the BCS layer
            BCS RequestDirector = new();
            SaleNumber = RequestDirector.CreateSale(newSale);
        }
       
    }
}
