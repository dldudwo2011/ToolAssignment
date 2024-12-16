using ABCHardware_YoungjaeLee.TechnicalServices;

namespace ABCHardware_YoungjaeLee.Domain
{
    public class BCS
    {

        // Create a new customer
        public bool CreateCustomer(Customer newCustomer)
        {
            bool success;
            Customers customerManager = new Customers();
            success = customerManager.AddCustomer(newCustomer);
            return success;
        }

        // Modify an existing customer
        public bool ModifyCustomer(Customer updatedCustomer)
        {
            bool success;
            Customers customerManager = new Customers();
            success = customerManager.UpdateCustomer(updatedCustomer);
            return success;
        }

        // Remove a customer by ID
        public bool RemoveCustomer(int customerID)
        {
            bool success;
            Customers customerManager = new Customers();
            success = customerManager.DeleteCustomer(customerID);
            return success;
        }


        // Add a new item
        public bool CreateItem(Item newItem)
        {
            bool success;
            Items itemManager = new();
            success = itemManager.AddItem(newItem);
            return success;
        }

        // Fetch all items
        public List<Item> GetItems()
        {
            List<Item> items;
            Items itemManager = new();
            items = itemManager.GetItems();
            return items;
        }

        // Update an item
        public bool ModifyItem(Item updatedItem)
        {
            bool success;
            Items itemManager = new();
            success = itemManager.UpdateItem(updatedItem);
            return success;
        }

        // Remove an item by ItemCode
        public bool RemoveItem(string itemCode)
        {
            bool success;
            Items itemManager = new();
            success = itemManager.DeleteItem(itemCode);
            return success;
        }

        public int CreateSale(Sale sale)
        {
            int SaleNumber;
            Sales saleManager = new();
            SaleNumber = saleManager.AddSale(sale);
            return SaleNumber;
        }
    }
}
