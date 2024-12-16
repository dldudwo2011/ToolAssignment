namespace ABCHardware_YoungjaeLee.Domain
{
    public class SalesItem
    {
        public int SaleNumber { get; set; } // Not required to pass for new sale; auto-generated in the DB

        public string ItemCode { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty; // Description of the item

        public int Quantity { get; set; }

        public decimal ItemTotal { get; set; }
    }
}
