using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

   
    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

   
    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

       
        double shippingCost = _customer.IsInUSA() ? 5 : 35;
        total += shippingCost;
        return total;
    }

    
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.Name}\n{_customer.Address.GetFullAddress()}\n";
    }
}
