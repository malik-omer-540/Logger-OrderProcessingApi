# Logger-OrderProcessingApi (.NET 8 Web API)

A real-world .NET 8 Web API demonstrating good and bad logging practices using Serilog and structured logs.

## Key Concepts

✅ Structured logging  
✅ Appropriate logging levels  
✅ Avoiding sensitive data exposure  
✅ Logging context (user IDs, timestamps, etc.)

## Folder Structure

```plaintext
OrderProcessingApi/
│
├── OrderProcessingApi.sln
├── README.md
│
├── OrderProcessingApi/
│   ├── Controllers/
│   │   └── OrdersController.cs
│   ├── Models/
│   │   └── OrderRequest.cs
│   ├── Services/
│   │   ├── Interfaces/
│   │   │   └── IOrderService.cs
│   │   └── OrderService.cs
│   ├── Program.cs
│   └── OrderProcessingApi.csproj
│
├── SerilogConfig/
│   └── serilog.json
