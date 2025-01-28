using InventoryManagemenet.API.Models;
using InventoryManagemenet.API.Repositories;

namespace InventoryManagemenet.API.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IDataRepository _dataRepository;

        public InventoryService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void AddItem(ItemsDto item)
        {
            _dataRepository.AddItem(item);
        }

        public void UpdateStockLevel(string itemName, int newStockLevel)
        {
            var item = _dataRepository.GetItemByName(itemName);
            if (item != null)
            {
                item.StockQuantity = newStockLevel;
                _dataRepository.UpdateItem(item);
            }
        }

        public void ReorderItems()
        {
            var itemsToReorder = _dataRepository.GetItems().Where(i => i.StockQuantity <= i.ReorderLevel).ToList();
            // Reorder logic here
            ReOrderToSupplier(itemsToReorder);
        }

        private void ReOrderToSupplier(IEnumerable<ItemsDto> itemsDtos)
        {
            foreach (var item in itemsDtos)
            {
                // Find suppliers that supply this item
                var suppliers = _dataRepository.GetSuppliers()
                    .Where(s => s.SuppliesItem(item.ItemName))
                    .ToList();

                if (suppliers.Any())
                {
                    // Assume the first supplier is the primary supplier for simplicity
                    var supplier = suppliers.First();

                    // Logic to reorder item
                    ReorderItemFromSupplier(item, supplier);
                }
                else
                {
                    Console.WriteLine($"No suppliers found for item {item.ItemName}");
                }
            }
        }

        private void ReorderItemFromSupplier(ItemsDto item, SupplierDto supplier)
        {
            // For example, place an order for the item with the supplier
            Console.WriteLine($"Reordering item {item.ItemName} from supplier {supplier.Name}");

            // Example logic: Increase stock quantity by a fixed amount or based on supplier's minimum order quantity
            int reorderQuantity = 100; // This can be dynamic based on business rules or we can put this in appSettings
            item.StockQuantity += reorderQuantity;

            // Update item in the repository
            _dataRepository.UpdateItem(item);

            Console.WriteLine($"Reordered {reorderQuantity} units of {item.ItemName} from {supplier.Name}");
        }

        public IEnumerable<ItemsDto> GetItemsByCategory(string category)
        {
            return _dataRepository.GetItems().Where(i => i.Category == category);
        }

        public decimal CalculateAveragePrice()
        {
            var items = _dataRepository.GetItems();
            return items.Average(i => i.Price);
        }

        public IEnumerable<ItemsDto> GetItemsToReorder()
        {
            return _dataRepository.GetItems().Where(i => i.StockQuantity <= i.ReorderLevel).ToList();
        }

        public IEnumerable<SupplierDto> GetSuppliersReport()
        {
            return _dataRepository.GetSuppliers();
        }

        public void AutoReorderItems()
        {
            var itemsToReorder = GetItemsToReorder();
            // Logic to reorder items from suppliers
            ReOrderToSupplier(itemsToReorder);
        }

        public decimal CalculateTotalInventoryValue()
        {
            var items = _dataRepository.GetItems();
            return items.Sum(i => i.Price * i.StockQuantity);
        }

        public SupplierResponseDto AddSupplierData(SupplierRequestDto requestDto)
        {
            var supplierDto = new SupplierDto
            {
                Name = requestDto.Name,
                ContactInfo = requestDto.ContactInfo
            };

            var newSupplier = _dataRepository.AddSupplier(supplierDto);
            var addedSupplier = new SupplierResponseDto
            {
                Name = newSupplier.Name,
                ContactInfo = newSupplier.ContactInfo
            };
            return addedSupplier;
        }

        public SupplierResponseDto UpdateSupplierData(SupplierRequestDto requestDto)
        {
            var supplierDto = new SupplierDto
            {
                Name = requestDto.Name,
                ContactInfo = requestDto.ContactInfo
            };
            var existingSupplier = _dataRepository.UpdateSupplier(supplierDto);
            var updatedSupplier = new SupplierResponseDto
            {
                Name = existingSupplier.Name,
                ContactInfo = existingSupplier.ContactInfo
            };
            return updatedSupplier;
        }

        public SupplierResponseDto GetSupplierInfoByName(string supplierName)
        {
            var supplierData = _dataRepository.GetSupplierByName(supplierName);
            var supplierInfo = new SupplierResponseDto
            {
                Name = supplierData.Name,
                ContactInfo = supplierData.ContactInfo
            };
            return supplierInfo;
        }
    }
}
