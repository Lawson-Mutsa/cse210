using System;

class Program
{
    static void Main()
    {
    
        var product1 = new Product("Laptop", 101, 800, 2);
        var product2 = new Product("Mouse", 102, 20, 3);

        
        var address1 = new Address("123 Main St", "New York", "NY", "USA");

        
        var customer1 = new Customer("John Doe", address1);

        
        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        
        var address2 = new Address("456 Oak Rd", "Vancouver", "BC", "Canada");
        var customer2 = new Customer("Jane Smith", address2);
        var order2 = new Order(customer2);
        order2.AddProduct(new Product("Keyboard", 103, 50, 1));
        order2.AddProduct(new Product("Headphones", 104, 150, 1));


        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}\n");
    }
}
