namespace InventoryManagemenet.API.Models
{
    public class SupplierDto
    {
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty ;
        public List<ItemsDto> ItemsSupplied { get; set; } = new List<ItemsDto>();

        public void AddItem(ItemsDto item)
        {
            ItemsSupplied.Add(item);
        }

        public void RemoveItem(ItemsDto item)
        {
            ItemsSupplied.Remove(item);
        }

        public void UpdateContactInfo(string newContactInfo)
        {
            ContactInfo = newContactInfo;
        }

        public bool SuppliesItem(string itemName)
        {
            return ItemsSupplied.Any(i => i.ItemName == itemName);
        }
    }
}
