using Logger_OrderProcessingApi.Models;
using Logger_OrderProcessingApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logger_OrderProcessingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        /// <summary>
        /// Bad logging – exposes sensitive info & floods logs
        /// </summary>
        [HttpPost("bad-log")]
        public async Task<IActionResult> BadLog([FromBody] OrderRequest request)
        {
            _logger.LogInformation("Processing order...");
            _logger.LogInformation($"User Email: {request.UserEmail}");
            _logger.LogInformation($"Product ID: {request.ProductId}, Quantity: {request.Quantity}");

            await Task.Delay(500); // Simulate processing

            _logger.LogInformation("Order processed successfully.");
            return Ok("Order submitted.");
        }

        /// <summary>
        /// Good logging – structured & safe
        /// </summary>
        [HttpPost("good-log")]
        public async Task<IActionResult> GoodLog([FromBody] OrderRequest request)
        {
            try
            {
                _logger.LogInformation("Received order for UserId: {UserId}", request.UserId);

                var result = await _orderService.ProcessOrderAsync(request);

                _logger.LogInformation("Successfully processed order for UserId: {UserId}", request.UserId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to process order for UserId: {UserId}", request.UserId);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
