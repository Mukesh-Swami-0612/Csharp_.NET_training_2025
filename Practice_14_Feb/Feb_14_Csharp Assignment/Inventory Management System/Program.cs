using System;
using System.Collections.Generic;

public abstract class Product
{
    public string Name;
    public decimal Price;
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
    public abstract void Display();
}
public class Electronics : Product
{
    public string Brand;
    public string Model;
    public int WarrantyPeriod;
    public int PowerUsage;
    public DateTime ManufacturingDate;

    public Electronics(string name, decimal price, string brand, string model,
        int warranty, int power, DateTime mfgDate)
        : base(name, price)
    {
        Brand = brand;
        Model = model;
        WarrantyPeriod = warranty;
        PowerUsage = power;
        ManufacturingDate = mfgDate;
    }

    public override void Display()
    {
        Console.WriteLine("\n--- Electronics Product ---");
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Price: " + Price);
        Console.WriteLine("Brand: " + Brand);
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Warranty: " + WarrantyPeriod + " months");
        Console.WriteLine("Power Usage: " + PowerUsage + " watts");
        Console.WriteLine("Manufacturing Date: " + ManufacturingDate.ToShortDateString());
    }
}

public class Grocery : Product
{
    public DateTime ExpiryDate;
    public double Weight;
    public bool IsOrganic;
    public double StorageTemperature;

    public Grocery(string name, decimal price, DateTime expiry,
        double weight, bool organic, double temp)
        : base(name, price)
    {
        ExpiryDate = expiry;
        Weight = weight;
        IsOrganic = organic;
        StorageTemperature = temp;
    }

    public override void Display()
    {
        Console.WriteLine("\n--- Grocery Product ---");
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Price: " + Price);
        Console.WriteLine("Expiry Date: " + ExpiryDate.ToShortDateString());
        Console.WriteLine("Weight: " + Weight + " kg");
        Console.WriteLine("Organic: " + IsOrganic);
        Console.WriteLine("Storage Temp: " + StorageTemperature + "°C");
    }
}


public class Clothing : Product
{
    public string Size;
    public string FabricType;
    public string Gender;
    public string Color;

    public Clothing(string name, decimal price, string size,
        string fabric, string gender, string color)
        : base(name, price)
    {
        Size = size;
        FabricType = fabric;
        Gender = gender;
        Color = color;
    }

    public override void Display()
    {
        Console.WriteLine("\n--- Clothing Product ---");
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Price: " + Price);
        Console.WriteLine("Size: " + Size);
        Console.WriteLine("Fabric: " + FabricType);
        Console.WriteLine("Gender: " + Gender);
        Console.WriteLine("Color: " + Color);
    }
}



class Program
{
    static void Main()
    {
        List<Product> inventory = new List<Product>();
        int choice;

        do
        {
            Console.WriteLine("\n===== Inventory Menu =====");
            Console.WriteLine("1. Add Electronics");
            Console.WriteLine("2. Add Grocery");
            Console.WriteLine("3. Add Clothing");
            Console.WriteLine("4. Show All Products");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddElectronics(inventory);
                    break;

                case 2:
                    AddGrocery(inventory);
                    break;

                case 3:
                    AddClothing(inventory);
                    break;

                case 4:
                    ShowAll(inventory);
                    break;

                case 5:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 5);
    }


    static void AddElectronics(List<Product> inventory)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Brand: ");
        string brand = Console.ReadLine();

        Console.Write("Enter Model: ");
        string model = Console.ReadLine();

        Console.Write("Enter Warranty (months): ");
        int warranty = int.Parse(Console.ReadLine());

        Console.Write("Enter Power Usage (watts): ");
        int power = int.Parse(Console.ReadLine());

        Console.Write("Enter Manufacturing Date (yyyy-mm-dd): ");
        DateTime mfg = DateTime.Parse(Console.ReadLine());

        Electronics e = new Electronics(name, price, brand, model, warranty, power, mfg);
        inventory.Add(e);

        Console.WriteLine("Electronics product added successfully!");
    }



    static void AddGrocery(List<Product> inventory)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Expiry Date (yyyy-mm-dd): ");
        DateTime expiry = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter Weight (kg): ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Is Organic (true/false): ");
        bool organic = bool.Parse(Console.ReadLine());

        Console.Write("Enter Storage Temperature: ");
        double temp = double.Parse(Console.ReadLine());

        Grocery g = new Grocery(name, price, expiry, weight, organic, temp);
        inventory.Add(g);

        Console.WriteLine("Grocery product added successfully!");
    }



    static void AddClothing(List<Product> inventory)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Size (S/M/L/XL): ");
        string size = Console.ReadLine();

        Console.Write("Enter Fabric Type: ");
        string fabric = Console.ReadLine();

        Console.Write("Enter Gender (Men/Women/Unisex): ");
        string gender = Console.ReadLine();

        Console.Write("Enter Color: ");
        string color = Console.ReadLine();

        Clothing c = new Clothing(name, price, size, fabric, gender, color);
        inventory.Add(c);

        Console.WriteLine("Clothing product added successfully!");
    }



    static void ShowAll(List<Product> inventory)
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("Inventory is empty!");
            return;
        }

        foreach (Product p in inventory)
        {
            p.Display();
        }
    }
}
