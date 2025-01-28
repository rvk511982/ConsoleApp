using InventoryManagemenet.API.Models;

namespace InventoryManagemenet.API.Repositories
{
    public interface IDataRepository
    {
        void AddItem(ItemsDto item);
        void UpdateItem(ItemsDto item);
        ItemsDto GetItemByName(string itemName);
        IEnumerable<ItemsDto> GetItems();
        IEnumerable<SupplierDto> GetSuppliers();

        SupplierDto AddSupplier(SupplierDto supplierDto);

        SupplierDto UpdateSupplier(SupplierDto supplierDto);

        SupplierDto GetSupplierByName(string supplier);
    }
}
