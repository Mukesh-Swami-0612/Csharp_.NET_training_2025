
using System;
using System.Collections.Generic;
using System.Linq;

// Base product interface
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        // Rule: Product ID must be unique
        // Rule: Price must be positive
        // Rule: Name cannot be null or empty
        // Add to collection if validation passes

        if (product == null)
            throw new ArgumentNullException("Product is null");

        if (string.IsNullOrEmpty(product.Name))
            throw new Exception("Name cannot be empty");

        if (product.Price <= 0)
            throw new Exception("Price must be positive");

        if (_products.Any(p => p.Id == product.Id))
            throw new Exception("Duplicate ID");

        _products.Add(product);
    }

    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        return _products.Where(predicate);
    }

    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        return _products.Sum(p => p.Price);
    }

    public List<T> GetAll() => _products;
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// Simple Clothing Product
public class ClothingProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Clothing;
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100

        if (product == null)
            throw new Exception("Product is null");

        if (discountPercentage < 0 || discountPercentage > 100)
            throw new Exception("Invalid discount");

        _product = product;
        _discountPercentage = discountPercentage;
    }

    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

    // TODO: Override ToString to show discount details
    public override string ToString()
    {
        return $"{_product.Name} | Original: {_product.Price} | Discount: {_discountPercentage}% | Final: {DiscountedPrice}";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        Console.WriteLine("\nAll Products:");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price}");
        }

        // b) Find the most expensive product
        var max = products.OrderByDescending(p => p.Price).FirstOrDefault();
        Console.WriteLine("\nMost Expensive: " + max?.Name);

        // c) Group products by category
        Console.WriteLine("\nGrouped By Category:");
        var groups = products.GroupBy(p => p.Category);

        foreach (var g in groups)
        {
            Console.WriteLine(g.Key);
            foreach (var p in g)
            {
                Console.WriteLine("  " + p.Name);
            }
        }

        // d) Apply 10% discount to Electronics over $500
        Console.WriteLine("\nDiscounted Electronics:");

        foreach (var p in products)
        {
            if (p.Category == Category.Electronics && p.Price > 500)
            {
                var d = new DiscountedProduct<T>(p, 10);
                Console.WriteLine(d);
            }
        }
    }

    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        // Apply priceAdjuster to each product
        // Handle exceptions gracefully

        foreach (var p in products)
        {
            try
            {
                decimal newPrice = priceAdjuster(p);

                if (newPrice <= 0)
                    throw new Exception("Invalid price");

                // Using reflection to update price (since interface is readonly)
                var prop = p.GetType().GetProperty("Price");
                prop.SetValue(p, newPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

// ================= TEST =================

class Program
{
    static void Main()
    {
        var repo = new ProductRepository<IProduct>();

        // b) Create a sample inventory with at least 5 products

        repo.AddProduct(new ElectronicProduct { Id = 1, Name = "Laptop", Price = 70000, Brand = "HP" });
        repo.AddProduct(new ElectronicProduct { Id = 2, Name = "Mobile", Price = 40000, Brand = "Samsung" });

        repo.AddProduct(new ClothingProduct { Id = 3, Name = "T-Shirt", Price = 800 });
        repo.AddProduct(new ClothingProduct { Id = 4, Name = "Jeans", Price = 2000 });
        repo.AddProduct(new ClothingProduct { Id = 5, Name = "Jacket", Price = 3000 });

        // Finding by brand
        Console.WriteLine("\nSamsung Products:");
        var samsung = repo.FindProducts(p => p is ElectronicProduct e && e.Brand == "Samsung");

        foreach (var s in samsung)
        {
            Console.WriteLine(s.Name);
        }

        // Total value
        Console.WriteLine("\nTotal Value: " + repo.CalculateTotalValue());

        var manager = new InventoryManager();

        manager.ProcessProducts(repo.GetAll());

        // Bulk update
        manager.UpdatePrices(repo.GetAll(), p => p.Price + 100);

        Console.WriteLine("\nAfter Price Update:");
        manager.ProcessProducts(repo.GetAll());
    }
}
