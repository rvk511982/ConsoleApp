using InventoryManagemenet.API.Models;

namespace InventoryManagemenet.API.Services
{
    public interface IInventoryService
    {
        void AddItem(ItemsDto item);
        void UpdateStockLevel(string itemName, int newStockLevel);
        void ReorderItems();
        IEnumerable<ItemsDto> GetItemsByCategory(string category);
        decimal CalculateAveragePrice();
        IEnumerable<ItemsDto> GetItemsToReorder();
        IEnumerable<SupplierDto> GetSuppliersReport();
        void AutoReorderItems();
        decimal CalculateTotalInventoryValue();

        SupplierResponseDto AddSupplierData(SupplierRequestDto supplierDto);

        SupplierResponseDto UpdateSupplierData(SupplierRequestDto supplierDto);

        SupplierResponseDto GetSupplierInfoByName(string supplier);
    }
}
