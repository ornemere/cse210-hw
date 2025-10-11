using System;
using System.Collections.Generic;

/// <summary>
/// W04 Foundation #2 - Online Ordering Program
/// Demonstrates encapsulation by using private fields with public getters/setters and clear class responsibilities.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Create first customer and address
        Address address1 = new Address("123 Main Street", "Los Angeles", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        // Create second customer and address
        Address address2 = new Address("45 Queen Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emma Smith", address2);

        // Create first order
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "P001", 25.99, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "P002", 59.99, 1));
        order1.AddProduct(new Product("USB-C Cable", "P003", 9.99, 3));

        // Create second order
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop Stand", "P010", 39.99, 1));
        order2.AddProduct(new Product("Bluetooth Headphones", "P011", 89.99, 1));

        // Store orders in a list
        List<Order> orders = new List<Order> { order1, order2 };

        // Display information for each order
        foreach (Order order in orders)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}");
            Console.WriteLine("==============================================\n");
        }
    }
}
