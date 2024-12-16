using System.Collections.Generic;

namespace ABCHardware_YoungjaeLee.Domain
{
    public class Sale
    {
        public int SaleNumber { get; set; }

        public DateTime SaleDate { get; set; }

        public int SalespersonID { get; set; }

        public int CustomerID { get; set; }

        public decimal SubTotal { get; set; }

        public decimal GST { get; set; }

        public decimal SaleTotal { get; set; }

        // List of SalesItems associated with this sale
        public List<SalesItem> SalesItems { get; set; } = new List<SalesItem>();
    }
}
