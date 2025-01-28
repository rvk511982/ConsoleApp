using InventoryManagemenet.API.Models;

namespace InventoryManagemenet.API.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly List<ItemsDto> _items;
        private readonly List<SupplierDto> _suppliers;

        public DataRepository()
        {
            _items = ItemsData_InMemory();
            _suppliers = SupplierData_InMemory();
        }

        public void AddItem(ItemsDto item)
        {
            _items.Add(item);
        }

        public void UpdateItem(ItemsDto item)
        {
            var existingItem = GetItemByName(item.ItemName);
            if (existingItem != null)
            {
                existingItem.Category = item.Category;
                existingItem.Price = item.Price;
                existingItem.StockQuantity = item.StockQuantity;
                existingItem.ReorderLevel = item.ReorderLevel;
            }
        }

        public ItemsDto GetItemByName(string itemName)
        {
            return _items.FirstOrDefault(i => i.ItemName == itemName);
        }

        public IEnumerable<ItemsDto> GetItems()
        {
            return _items;
        }

        public IEnumerable<SupplierDto> GetSuppliers()
        {
            return _suppliers;
        }

        public SupplierDto AddSupplier(SupplierDto supplierDto)
        {
            _suppliers.Add(supplierDto);
            return supplierDto;
        }

        public SupplierDto UpdateSupplier(SupplierDto supplierDto)
        {
            var existingSupplier = GetSupplierByName(supplierDto.Name);
            if (existingSupplier != null)
            {
                existingSupplier.Name = supplierDto.Name;
                existingSupplier.ContactInfo = supplierDto.ContactInfo;
            }
            return supplierDto;
        }

        public SupplierDto GetSupplierByName(string supplier)
        {
            return _suppliers.FirstOrDefault(i => i.Name.Equals(supplier));
        }

        private List<ItemsDto> ItemsData_InMemory()
        {
            var items = new List<ItemsDto>
            {
                new ItemsDto
                {
                    ItemName = "Laptop", Category = "Electronics", Price = 19000, StockQuantity = 5, ReorderLevel = 3
                },
                new ItemsDto
                {
                    ItemName = "Mouse", Category = "Accessories", Price = 100, StockQuantity = 15, ReorderLevel = 5
                },
                new ItemsDto
                {
                    ItemName = "Keyboard", Category = "Accessories", Price = 210, StockQuantity = 55, ReorderLevel = 12
                }
            };
            return items;
        }

        private List<SupplierDto> SupplierData_InMemory()
        {
            var suppliers = new List<SupplierDto>
            {
                new SupplierDto
                {
                    ContactInfo= "abc@ymail.com",
                    Name = "ABC Technology",
                    ItemsSupplied = new List<ItemsDto>
                    {
                        new ItemsDto
                        {
                            ItemName = "Laptop", Category = "Electronics", Price = 19000, StockQuantity = 5, ReorderLevel = 3
                        },
                        new ItemsDto
                        {
                            ItemName = "Mouse", Category = "Accessories", Price = 100, StockQuantity = 15, ReorderLevel = 5
                        }
                    }
                },
                new SupplierDto
                {
                    ContactInfo= "sai@ymail.com",
                    Name = "Sai Technology",
                    ItemsSupplied = new List<ItemsDto>
                    {
                        new ItemsDto
                        {
                            ItemName = "Laptop", Category = "Electronics", Price = 19000, StockQuantity = 5, ReorderLevel = 3
                        },
                        new ItemsDto
                        {
                            ItemName = "Mouse", Category = "Accessories", Price = 100, StockQuantity = 15, ReorderLevel = 5
                        }
                    }
                },
                new SupplierDto
                {
                    ContactInfo= "ram@ymail.com",
                    Name = "Ram Technology",
                    ItemsSupplied = new List<ItemsDto>
                    {
                        new ItemsDto
                        {
                            ItemName = "Laptop", Category = "Electronics", Price = 19000, StockQuantity = 5, ReorderLevel = 3
                        },
                        new ItemsDto
                        {
                            ItemName = "Mouse", Category = "Accessories", Price = 100, StockQuantity = 15, ReorderLevel = 5
                        }
                    }
                }
            };
            return suppliers;
        }
    }
}
