using System;
using System.Collections.Generic;

class Product
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Description { get; set; }

    public void UpdateStock(int amount)
    {
        StockQuantity += amount;
        Console.WriteLine($"Stock updated. New stock quantity for {ProductName}: {StockQuantity}");
    }

    public void ApplyDiscount(decimal discountPercentage)
    {
        Price -= Price * discountPercentage / 100;
        Console.WriteLine($"Discount applied. New price for {ProductName}: {Price:C}");
    }

    public void GetDetails()
    {
        Console.WriteLine($"Product: {ProductName}\nPrice: {Price:C}\nStock: {StockQuantity}\nDescription: {Description}");
    }
}

class Order
{
    public int OrderID { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
    public decimal TotalAmount { get; private set; }
    public string Status { get; set; } = "Pending";

    public void AddProduct(Product product)
    {
        Products.Add(product);
        Console.WriteLine($"Added {product.ProductName} to order {OrderID}");
        CalculateTotal();
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
        Console.WriteLine($"Removed {product.ProductName} from order {OrderID}");
        CalculateTotal();
    }

    public void CalculateTotal()
    {
        TotalAmount = 0;
        foreach (var product in Products)
        {
            TotalAmount += product.Price;
        }
        Console.WriteLine($"Order {OrderID} total amount: {TotalAmount:C}");
    }

    public void TrackOrder()
    {
        Console.WriteLine($"Order {OrderID} is currently: {Status}");
    }
}

class Customer
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactInfo { get; set; }
    public string PaymentInfo { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();

    public void UpdateDetails(string name, string address, string contactInfo)
    {
        Name = name;
        Address = address;
        ContactInfo = contactInfo;
        Console.WriteLine("Customer details updated.");
    }

    public void AddPaymentInfo(string paymentInfo)
    {
        PaymentInfo = paymentInfo;
        Console.WriteLine("Payment information updated.");
    }

    public void ViewOrders()
    {
        Console.WriteLine($"Orders for {Name}:");
        foreach (var order in Orders)
        {
            Console.WriteLine($"- Order ID: {order.OrderID}, Total: {order.TotalAmount:C}, Status: {order.Status}");
        }
    }
}

class Payment
{
    public string PaymentType { get; set; }
    public string TransactionID { get; set; }
    public string Status { get; set; } = "Unprocessed";

    public void ProcessPayment(decimal amount)
    {
        Status = "Processed";
        Console.WriteLine($"Payment of {amount:C} processed via {PaymentType}. Transaction ID: {TransactionID}");
    }

    public void Refund()
    {
        Status = "Refunded";
        Console.WriteLine($"Payment with Transaction ID: {TransactionID} has been refunded.");
    }

    public void ValidatePayment()
    {
        Console.WriteLine($"Payment status: {Status}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage
        var product1 = new Product { ProductName = "Laptop", Price = 1000m, StockQuantity = 10, Description = "High-performance laptop." };
        var product2 = new Product { ProductName = "Mouse", Price = 20m, StockQuantity = 50, Description = "Wireless mouse." };

        var customer = new Customer { Name = "Adriano", Address = "123 Main St", ContactInfo = "adriano@example.com" };
        customer.AddPaymentInfo("Credit Card");

        var order = new Order { OrderID = 1 };
        order.AddProduct(product1);
        order.AddProduct(product2);
        order.TrackOrder();

        customer.Orders.Add(order);
        customer.ViewOrders();

        var payment = new Payment { PaymentType = "Credit Card", TransactionID = "TXN12345" };
        payment.ProcessPayment(order.TotalAmount);
        payment.ValidatePayment();
    }
}