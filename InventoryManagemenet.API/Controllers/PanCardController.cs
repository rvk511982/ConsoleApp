using InventoryManagemenet.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InventoryManagemenet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanCardController : ControllerBase
    {
        private readonly IPANCardService _cardService;
        private readonly ILogger<PanCardController> _logger;

        public PanCardController(IPANCardService cardService, ILogger<PanCardController> logger)
        {
            _cardService = cardService;
            _logger = logger;
        }

        [HttpGet("generate")]
        public IActionResult GeneratePAN()
        {
            _logger.LogInformation("Pan Card Geneation started!!!");
            var pan = _cardService.GeneratePAN();
            _logger.LogInformation($"Generated Pan Card Number == {pan}");
            return Ok(new { PAN = pan });
        }

        [HttpPost("validate")]
        public IActionResult ValidatePAN(string panNumber)
        {
            _logger.LogInformation("Pan Card Validation started!!!");
            if (string.IsNullOrWhiteSpace(panNumber))
            {
                return BadRequest("PAN number is required.");
            }

            bool isValid = _cardService.IsValidPAN(panNumber);
            _logger.LogInformation($"Is ValidatePAN Pan Card Number == {isValid}");
            return isValid ? Ok("Valid PAN") : BadRequest("Invalid PAN format");
        }
    }
}
