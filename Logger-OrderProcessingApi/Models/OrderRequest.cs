namespace Logger_OrderProcessingApi.Models
{
    public class OrderRequest
    {
        public Guid UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string UserEmail { get; set; } // Demonstrates what not to log
    }
}
