namespace InventoryManagemenet.API.Models
{
    public class ItemsDto
    {
        public string ItemName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
    }
}
