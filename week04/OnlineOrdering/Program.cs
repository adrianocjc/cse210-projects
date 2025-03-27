using System;
using System.Collections.Generic;

class Address
{
    private string _street;
    private string _city;
    private string _zipCode;

    public Address(string street, string city, string zipCode)
    {
        _street = street;
        _city = city;
        _zipCode = zipCode;
    }

    public string GetFullAddress()
    {
        return $"{_street}, {_city}, {_zipCode}";
    }
}

class Product
{
    private string _productName;
    private decimal _price;
    private int _stockQuantity;

    public Product(string productName, decimal price, int stockQuantity)
    {
        _productName = productName;
        _price = price;
        _stockQuantity = stockQuantity;
    }

    public string GetDetails()
    {
        return $"Product: {_productName}, Price: {_price:C}, Stock: {_stockQuantity}";
    }

    public decimal GetPrice()
    {
        return _price;
    }
}

class Customer
{
    private string _name;
    private Address _address;
    private string _contactInfo;

    public Customer(string name, Address address, string contactInfo)
    {
        _name = name;
        _address = address;
        _contactInfo = contactInfo;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetContactInfo()
    {
        return _contactInfo;
    }

    public string GetShippingAddress()
    {
        return _address.GetFullAddress();
    }
}

class Order
{
    private int _orderID;
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(int orderID, Customer customer)
    {
        _orderID = orderID;
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in _products)
        {
            total += product.GetPrice();
        }
        return total;
    }

    public string GetPackingLabel()
    {
        return $"Packing Label:\nOrder ID: {_orderID}\nCustomer: {_customer.GetName()}\nProducts:\n{string.Join("\n", _products.ConvertAll(p => p.GetDetails()))}";
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetShippingAddress()}\nContact: {_customer.GetContactInfo()}";
    }
}

class Payment
{
    private string _paymentType;
    private string _transactionID;
    private string _status;

    public Payment(string paymentType, string transactionID)
    {
        _paymentType = paymentType;
        _transactionID = transactionID;
        _status = "Unprocessed";
    }

    public void ProcessPayment(decimal amount)
    {
        _status = "Processed";
        Console.WriteLine($"Payment of {amount:C} processed via {_paymentType}. Transaction ID: {_transactionID}");
    }

    public string GetPaymentStatus()
    {
        return _status;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create Address Objects
        var address1 = new Address("123 Main St", "Parnamirim", "59150-000");
        var address2 = new Address("456 Elm St", "Natal", "59020-300");

        // Create Customer Objects
        var customer1 = new Customer("Adriano", address1, "adriano@example.com");
        var customer2 = new Customer("Maria", address2, "maria@example.com");

        // Create Product Objects
        var product1 = new Product("Laptop", 1500m, 10);
        var product2 = new Product("Mouse", 20m, 50);
        var product3 = new Product("Keyboard", 30m, 25);

        // Create Order Objects
        var order1 = new Order(1, customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(2, customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product2);

        // Process Orders
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order1.CalculateTotal():C}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order2.CalculateTotal():C}\n");

        // Process Payments
        var payment1 = new Payment("Credit Card", "TXN1001");
        payment1.ProcessPayment(order1.CalculateTotal());

        var payment2 = new Payment("PayPal", "TXN1002");
        payment2.ProcessPayment(order2.CalculateTotal());
    }
}