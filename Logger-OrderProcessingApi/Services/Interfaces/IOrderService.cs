using Logger_OrderProcessingApi.Models;

namespace Logger_OrderProcessingApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task<string> ProcessOrderAsync(OrderRequest request);
    }
}
