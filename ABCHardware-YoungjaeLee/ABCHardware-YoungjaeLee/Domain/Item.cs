﻿namespace ABCHardware_YoungjaeLee.Domain
{
    public class Item
    {
        public string ItemCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
