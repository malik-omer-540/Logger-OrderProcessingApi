using Logger_OrderProcessingApi.Models;
using Logger_OrderProcessingApi.Services.Interfaces;
using Serilog;

namespace Logger_OrderProcessingApi.Services
{
    public class OrderService : IOrderService
    {
        public async Task<string> ProcessOrderAsync(OrderRequest request)
        {
            // Simulate processing
            await Task.Delay(500);

            // Log structured success
            Log.Information("Order processed for UserId: {UserId}, ProductId: {ProductId}, Quantity: {Quantity}",
                request.UserId, request.ProductId, request.Quantity);

            return $"Order for {request.ProductId} submitted.";
        }
    }
}
