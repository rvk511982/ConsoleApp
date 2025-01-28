using InventoryManagemenet.API.Models;
using InventoryManagemenet.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagemenet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost("addItem")]
        public IActionResult AddItem([FromBody] ItemsDto item)
        {
            _inventoryService.AddItem(item);
            return Ok("New Item Added Successfully!");
        }

        [HttpPut("updateStock/{itemName}")]
        public IActionResult UpdateStock(string itemName, [FromBody] int newStockLevel)
        {
            _inventoryService.UpdateStockLevel(itemName, newStockLevel);
            return Ok($"Stock Updated for {itemName} with new stock level {newStockLevel}");
        }

        [HttpGet("itemsByCategory/{category}")]
        public IActionResult GetItemsByCategory(string category)
        {
            var items = _inventoryService.GetItemsByCategory(category);
            return Ok(items);
        }

        [HttpGet("averagePrice")]
        public IActionResult GetAveragePrice()
        {
            var averagePrice = _inventoryService.CalculateAveragePrice();
            return Ok(averagePrice);
        }

        [HttpGet("itemsToReorder")]
        public IActionResult GetItemsToReorder()
        {
            var items = _inventoryService.GetItemsToReorder();
            return Ok(items);
        }

        [HttpGet("suppliersReport")]
        public IActionResult GetSuppliersReport()
        {
            var report = _inventoryService.GetSuppliersReport();
            return Ok(report);
        }

        [HttpPost("autoReorder")]
        public IActionResult AutoReorderItems()
        {
            _inventoryService.AutoReorderItems();
            return Ok("Auto Reorder Completed!");
        }

        [HttpGet("totalInventoryValue")]
        public IActionResult GetTotalInventoryValue()
        {
            var totalValue = _inventoryService.CalculateTotalInventoryValue();
            return Ok(totalValue);
        }

        [HttpPost("addSupplier")]
        public IActionResult AddNewSupplier(SupplierRequestDto supplierRequestDto)
        {
            var response = _inventoryService.AddSupplierData(supplierRequestDto);
            return Ok(response);
        }

        [HttpPut("updateSupplier")]
        public IActionResult UpdateSupplier(SupplierRequestDto supplierRequestDto)
        {
            var response = _inventoryService.UpdateSupplierData(supplierRequestDto);
            return Ok(response);
        }

        [HttpGet("supplierByName/{supplierName}")]
        public IActionResult GetSupplierByName(string supplierName)
        {
            var response = _inventoryService.GetSupplierInfoByName(supplierName);
            return Ok(response);
        }
    }
}
