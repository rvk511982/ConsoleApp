namespace ConsolePractice.InventoryManagementSystem
{
    public class InventoryManagement
    {
        public void ShowInventory()
        {
            Console.WriteLine("Start of Inventory Management System");

            var repository = new InMemoryDataRepository();
            var inventoryService = new InventoryService(repository);

            // Adding data for testing purpose
            var item1 = new ItemSuppliedDto { ItemName = "Laptop", Category = "Electronics", Price = 1000, StockQuantity = 5, ReorderLevel = 3 };
            var item2 = new ItemSuppliedDto { ItemName = "Mouse", Category = "Accessories", Price = 20, StockQuantity = 15, ReorderLevel = 10 };
            var item3 = new ItemSuppliedDto { ItemName = "Keyboard", Category = "Accessories", Price = 210, StockQuantity = 55, ReorderLevel = 12 };

            var supplier = new SupplierDto { Name = "TechSupplier", ContactInfo = "techsupplier@example.com" };
            supplier.AddItem(item1);
            supplier.AddItem(item2);

            Console.WriteLine("ContactInfo before update : " + supplier.ContactInfo);
            Console.Write("Update Contact Info");
            supplier.UpdateContactInfo("info@example.org");
            Console.WriteLine("Updated ContactInfo: " + supplier.ContactInfo);

            Console.Write("Adding Item 1");
            repository.AddItem(item1);
            Console.WriteLine($"- Name: {item3.ItemName} , Category:  {item3.Category} , Price:  {item1.Price} , Stock:  {item1.StockQuantity} , Reorder Level:  {item1.ReorderLevel}");
            
            Console.Write("Adding Item 2");
            repository.AddItem(item2);
            Console.WriteLine($"- Name: {item2.ItemName}, Category: {item2.Category}, Price: {item2.Price}, Stock: {item2.StockQuantity}, Reorder Level: {item2.ReorderLevel}");
            
            Console.Write("Adding Item 3");
            repository.AddItem(item3);
            Console.WriteLine($"- Name: {item3.ItemName}, Category: {item3.Category}, Price: {item3.Price}, Stock: {item3.StockQuantity}, Reorder Level: {item3.ReorderLevel}");
            
            Console.WriteLine("Item Added successfully!");

            Console.WriteLine("Item being removed:");
            Console.WriteLine($"- Name: {item3.ItemName}, Category: {item3.Category}, Price: {item3.Price}, Stock: {item3.StockQuantity}, Reorder Level: {item3.ReorderLevel}");
            repository.RemoveItem(item3);
            Console.WriteLine("Item Removed successfully!");

            repository.AddSupplier(supplier);

            // Testing InventoryService methods
            Console.WriteLine("Items in Electronics:");
            foreach (var item in inventoryService.FindItemsByCategory("Electronics"))
            {
                Console.WriteLine($"- {item.ItemName}");
            }

            Console.WriteLine($"Average Price: {inventoryService.CalculateAveragePrice()}");

            Console.WriteLine("Reorder Items:");
            foreach (var item in inventoryService.GetReorderItems())
            {
                Console.WriteLine($"- {item.ItemName}");
            }

            Console.WriteLine("Total Inventory Value: " + inventoryService.CalculateTotalInventoryValue());

            Console.WriteLine("Reordering items...");
            inventoryService.ReorderItems();

            Console.WriteLine("Supplier Report:");
            foreach (var (supplierInfo, items) in inventoryService.GetSuppliersWithItems())
            {
                Console.WriteLine($"Supplier: {supplierInfo.Name}");
                foreach (var item in items)
                {
                    Console.WriteLine($"  - {item.ItemName}");
                }
            }

            Console.WriteLine("End of Inventory Management System ");
            Console.ReadKey();
        }
    }

    public class ItemSuppliedDto
    {
        public string ItemName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
    }

    public class SupplierDto
    {
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;

        public List<ItemSuppliedDto> ItemsSupplied { get; set; } = new List<ItemSuppliedDto>();

        public void AddItem(ItemSuppliedDto item)
        {
            ItemsSupplied.Add(item);
        }

        public void RemoveItem(ItemSuppliedDto item)
        {
            ItemsSupplied.Remove(item);
        }

        public void UpdateContactInfo(string newContactInfo)
        {
            ContactInfo = newContactInfo;
        }
    }

    public interface IDataRepository
    {
        List<ItemSuppliedDto> GetItems();
        List<SupplierDto> GetSuppliers();
    }

    public class InventoryService
    {
        private readonly IDataRepository _repository;

        public InventoryService(IDataRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ItemSuppliedDto> FindItemsByCategory(string category)
        {
            return _repository.GetItems().Where(item => item.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        public decimal CalculateAveragePrice()
        {
            var items = _repository.GetItems();
            return items.Any() ? items.Average(item => item.Price) : 0;
        }

        public IEnumerable<ItemSuppliedDto> GetReorderItems()
        {
            return _repository.GetItems().Where(item => item.StockQuantity < item.ReorderLevel);
        }

        public IEnumerable<(SupplierDto, List<ItemSuppliedDto>)> GetSuppliersWithItems()
        {
            return _repository.GetSuppliers()
                .Select(supplier => (supplier, supplier.ItemsSupplied));
        }

        public void ReorderItems()
        {
            foreach (var item in GetReorderItems())
            {
                var supplier = _repository.GetSuppliers().FirstOrDefault(s => s.ItemsSupplied.Contains(item));
                if (supplier != null)
                {
                    Console.WriteLine($"Reordering {item.ItemName} from {supplier.Name}");
                }
            }
        }

        public decimal CalculateTotalInventoryValue()
        {
            return _repository.GetItems().Sum(item => item.Price * item.StockQuantity);
        }
    }

    public class InMemoryDataRepository : IDataRepository
    {
        private readonly List<ItemSuppliedDto> _items;
        private readonly List<SupplierDto> _suppliers;

        public InMemoryDataRepository()
        {
            _items = new List<ItemSuppliedDto>();
            _suppliers = new List<SupplierDto>();
        }

        public List<ItemSuppliedDto> GetItems() => _items;

        public List<SupplierDto> GetSuppliers() => _suppliers;

        public void AddItem(ItemSuppliedDto item) => _items.Add(item);

        public void RemoveItem(ItemSuppliedDto item) => _items.Remove(item);

        public void AddSupplier(SupplierDto supplier) => _suppliers.Add(supplier);
    }
}
