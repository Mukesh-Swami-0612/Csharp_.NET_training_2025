using System;
using System.Collections.Generic;
using System.Linq;

public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; set; }
    Category Category { get; }
}

public enum Category
{
    Electronics,
    Clothing,
    Books,
    Groceries
}

public class ProductRepository<T> where T : class, IProduct
{
    private List<T> products = new();

    public void AddProduct(T product)
    {
        if (product == null)
            throw new Exception("Product cannot be null");

        if (string.IsNullOrWhiteSpace(product.Name))
            throw new Exception("Product name cannot be empty");

        if (product.Price <= 0)
            throw new Exception("Price must be positive");

        if (products.Any(p => p.Id == product.Id))
            throw new Exception("Product ID must be unique");

        products.Add(product);
        Console.WriteLine("Product added successfully.");
    }

    public List<T> GetAllProducts() => products;

    public decimal CalculateTotalValue()
    {
        return products.Sum(p => p.Price);
    }
}

public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

public class ClothingProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Clothing;
    public string Size { get; set; }
}

public class InventoryManager
{
    public void ProcessProducts<T>(List<T> products) where T : IProduct
    {
        Console.WriteLine("\nAll Products:");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - {p.Price}");
    }

    public void UpdatePrices<T>(List<T> products, Func<T, decimal> adjuster)
        where T : IProduct
    {
        foreach (var p in products)
            p.Price = adjuster(p);
    }
}

class Program
{
    static void Main()
    {
        var electronicRepo = new ProductRepository<ElectronicProduct>();

        Console.Write("How many electronic products? ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Enter Warranty Months: ");
            int warranty = int.Parse(Console.ReadLine());

            var product = new ElectronicProduct
            {
                Id = id,
                Name = name,
                Price = price,
                Brand = brand,
                WarrantyMonths = warranty
            };

            electronicRepo.AddProduct(product);
        }

        var manager = new InventoryManager();

        manager.ProcessProducts(electronicRepo.GetAllProducts());

        Console.WriteLine("\nApplying 5% Price Increase...");
        manager.UpdatePrices(electronicRepo.GetAllProducts(),
            p => p.Price * 1.05m);

        manager.ProcessProducts(electronicRepo.GetAllProducts());

        Console.WriteLine("\nTotal Value: " +
            electronicRepo.CalculateTotalValue());
    }
}
