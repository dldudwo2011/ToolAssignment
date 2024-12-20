﻿namespace ABCHardware_YoungjaeLee.Domain
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Province { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;
    }
}
