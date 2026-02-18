using System;
using System.Collections.Generic;
using System.Linq;

public enum OrderStatus
{
    Pending,
    Shipped,
    Delivered,
    Cancelled
}

public class OutOfStockException : Exception
{
    public OutOfStockException(string message) : base(message) { }
}

public class OrderAlreadyShippedException : Exception
{
    public OrderAlreadyShippedException(string message) : base(message) { }
}

public class CustomerBlacklistedException : Exception
{
    public CustomerBlacklistedException(string message) : base(message) { }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsBlacklisted { get; set; }
}

public class OrderItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public decimal TotalPrice()
    {
        return Product.Price * Quantity;
    }
}

public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal total);
}

public class PercentageDiscount : IDiscountStrategy
{
    private decimal percentage;

    public PercentageDiscount(decimal percentage)
    {
        this.percentage = percentage;
    }

    public decimal ApplyDiscount(decimal total)
    {
        return total - (total * percentage / 100);
    }
}

public class FlatDiscount : IDiscountStrategy
{
    private decimal amount;

    public FlatDiscount(decimal amount)
    {
        this.amount = amount;
    }

    public decimal ApplyDiscount(decimal total)
    {
        return total - amount;
    }
}

public class FestivalDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal total)
    {
        return total * 0.8m;
    }
}

public class Order
{
    public int OrderId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }

    public decimal GetTotal()
    {
        return Items.Sum(i => i.TotalPrice());
    }

    public decimal GetTotalAfterDiscount(IDiscountStrategy strategy)
    {
        return strategy.ApplyDiscount(GetTotal());
    }

    public void AddItem(Product product, int quantity)
    {
        if (product.Stock < quantity)
            throw new OutOfStockException("Stock not sufficient");

        product.Stock -= quantity;

        Items.Add(new OrderItem
        {
            Product = product,
            Quantity = quantity
        });
    }

    public void CancelOrder()
    {
        if (Status == OrderStatus.Shipped)
            throw new OrderAlreadyShippedException("Order already shipped");

        Status = OrderStatus.Cancelled;
    }
}

public class ECommerceSystem
{
    public List<Product> Products = new List<Product>();
    public List<Customer> Customers = new List<Customer>();
    public List<Order> Orders = new List<Order>();
    public Dictionary<int, Product> ProductDictionary = new Dictionary<int, Product>();

    public Order PlaceOrder(Customer customer, List<(Product, int)> items)
    {
        if (customer.IsBlacklisted)
            throw new CustomerBlacklistedException("Customer is blacklisted");

        Order order = new Order
        {
            OrderId = Orders.Count + 1,
            Customer = customer,
            OrderDate = DateTime.Now,
            Status = OrderStatus.Pending
        };

        foreach (var item in items)
        {
            order.AddItem(item.Item1, item.Item2);
        }

        Orders.Add(order);
        return order;
    }

    public List<Order> OrdersLast7Days()
    {
        return Orders
            .Where(o => o.OrderDate >= DateTime.Now.AddDays(-7))
            .ToList();
    }

    public decimal TotalRevenue()
    {
        return Orders.Sum(o => o.GetTotal());
    }

    public Product MostSoldProduct()
    {
        return Orders
            .SelectMany(o => o.Items)
            .GroupBy(i => i.Product)
            .OrderByDescending(g => g.Sum(i => i.Quantity))
            .Select(g => g.Key)
            .FirstOrDefault();
    }

    public List<Customer> Top5Customers()
    {
        return Orders
            .GroupBy(o => o.Customer)
            .Select(g => new
            {
                Customer = g.Key,
                Total = g.Sum(o => o.GetTotal())
            })
            .OrderByDescending(x => x.Total)
            .Take(5)
            .Select(x => x.Customer)
            .ToList();
    }

    public IEnumerable<IGrouping<OrderStatus, Order>> GroupByStatus()
    {
        return Orders.GroupBy(o => o.Status);
    }

    public List<Product> LowStockProducts()
    {
        return Products
            .Where(p => p.Stock < 10)
            .ToList();
    }
}

public class Program
{
    public static void Main()
    {
        var system = new ECommerceSystem();

        var p1 = new Product { Id = 1, Name = "Laptop", Price = 50000, Stock = 20 };
        var p2 = new Product { Id = 2, Name = "Phone", Price = 20000, Stock = 5 };

        system.Products.AddRange(new[] { p1, p2 });
        system.ProductDictionary[p1.Id] = p1;
        system.ProductDictionary[p2.Id] = p2;

        var c1 = new Customer { Id = 1, Name = "Mukesh", IsBlacklisted = false };
        system.Customers.Add(c1);

        var order = system.PlaceOrder(c1, new List<(Product, int)>
        {
            (p1, 1),
            (p2, 1)
        });

        IDiscountStrategy discount = new PercentageDiscount(10);

        Console.WriteLine("Total After Discount: " + order.GetTotalAfterDiscount(discount));
        Console.WriteLine("Total Revenue: " + system.TotalRevenue());

        var mostSold = system.MostSoldProduct();
        Console.WriteLine("Most Sold Product: " + mostSold?.Name);

        Console.WriteLine("Low Stock Products:");
        foreach (var product in system.LowStockProducts())
        {
            Console.WriteLine(product.Name);
        }
    }
}
