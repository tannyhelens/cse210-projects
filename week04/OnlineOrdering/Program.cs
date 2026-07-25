using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Spanish Fork",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer("Maria Santos", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(
            new Product("Wireless Mouse", "WM101", 24.99, 2)
        );

        order1.AddProduct(
            new Product("Keyboard", "KB205", 49.99, 1)
        );

        order1.AddProduct(
            new Product("USB Cable", "USB310", 8.50, 3)
        );


        Address address2 = new Address(
            "45 Avenida Central",
            "Rio de Janeiro",
            "RJ",
            "Brazil"
        );

        Customer customer2 = new Customer("João Silva", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(
            new Product("Laptop Stand", "LS440", 35.00, 1)
        );

        order2.AddProduct(
            new Product("Webcam", "WC550", 59.99, 2)
        );


        DisplayOrder(order1, 1);
        DisplayOrder(order2, 2);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine($"========== ORDER {orderNumber} ==========");
        Console.WriteLine();

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine(
            $"Total Price: ${order.CalculateTotalPrice():F2}"
        );

        Console.WriteLine();
    }
}