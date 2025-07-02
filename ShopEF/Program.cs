using ShopEF.Database;
using ShopEF.Database.Model;

namespace ShopEF;

internal class Program
{
    private static void CreateCategoriesAndProducts(ShopContext db)
    {
        var categories = new List<Category>
        {
            new() { Name = "Процессоры" },
            new() { Name = "Мониторы" },
            new() { Name = "Видеокарты" },
            new() { Name = "Смартфоны" },
            new() { Name = "Периферия" },
            new() { Name = "Мыши" }
        };

        var products = new List<Product>
        {
            new()
            {
                Name = "AMD Ryzen Threadripper 2970WX BOX",
                Price = 91499,
                Categories = [categories[0]]
            },
            new()
            {
                Name = "Intel Core i9-10940X OEM",
                Price = 87799,
                Categories = [categories[0]]
            },
            new()
            {
                Name = "ASUS ProArt Display PA32UCG черный",
                Price = 543999,
                Categories = [categories[1], categories[4]]
            },
            new()
            {
                Name = "Lenovo ThinkVision 27 3D серый",
                Price = 299999,
                Categories = [categories[1], categories[4]]
            },
            new()
            {
                Name = "ASUS GeForce RTX 5090 ROG Astral OC Edition",
                Price = 435999,
                Categories = [categories[2]]
            },
            new()
            {
                Name = "MSI GeForce RTX 5080 GAMING TRIO OC",
                Price = 161999,
                Categories = [categories[2]]
            },
            new()
            {
                Name = "HUAWEI Mate XT 1024 ГБ черный",
                Price = 269999,
                Categories = [categories[3]]
            },
            new()
            {
                Name = "Samsung Galaxy Z Fold6 1024 ГБ синий",
                Price = 174999,
                Categories = [categories[3]]
            },
            new()
            {
                Name = "ASUS ROG Spatha X",
                Price = 17199,
                Categories = [categories[4], categories[5]]
            },
            new()
            {
                Name = "Logitech G PRO X SUPERLIGHT 2",
                Price = 16999,
                Categories = [categories[4], categories[5]]
            }
        };

        foreach (var product in products)
        {
            db.Products.Add(product);
        }

        db.SaveChanges();
    }

    private static void CreateCustomersAndOrders(ShopContext db)
    {
        var customers = new List<Customer>
        {
            new()
            {
                FirstName = "Иван",
                MiddleName = "Иванович",
                LastName = "Петров",
                PhoneNumber = "+7-912-345-67-89",
                Email = "ivan.petrov@example.com"
            },
            new()
            {
                FirstName = "Мария",
                MiddleName = "Сергеевна",
                LastName = "Иванова",
                PhoneNumber = "+7-903-876-54-32",
                Email = "maria.ivanova@example.com"
            },
            new()
            {
                FirstName = "Алексей",
                MiddleName = "Владимирович",
                LastName = "Соколов",
                PhoneNumber = "+7-925-123-45-67",
                Email = "a.sokolov@example.com"
            },
            new()
            {
                FirstName = "Екатерина",
                MiddleName = "Дмитриевна",
                LastName = "Смирнова",
                PhoneNumber = "+7-901-234-56-78",
                Email = "ekaterina.smirnova@example.com"
            },
            new()
            {
                FirstName = "Дмитрий",
                MiddleName = "Алексеевич",
                LastName = "Кузнецов",
                PhoneNumber = "+7-981-987-65-43",
                Email = "d.kuznetsov@example.com"
            }
        };

        var products = db.Products.ToArray();

        var orders = new List<Order>
        {
            new()
            {
                Date = new DateTimeOffset(2024, 11, 3, 8, 15, 12, TimeSpan.FromHours(+1)),
                Customer = customers[2],
                OrderProduct = [
                    new OrderProduct { Product = products[0], ProductCount = 3},
                    new OrderProduct { Product = products[5], ProductCount = 1}
                ]
            },
            new()
            {
                Date = new DateTimeOffset(2023, 6, 20, 19, 47, 33, TimeSpan.FromHours(-4)),
                Customer = customers[0],
                OrderProduct = [
                    new OrderProduct { Product = products[0], ProductCount = 1},
                    new OrderProduct { Product = products[3], ProductCount = 4},
                    new OrderProduct { Product = products[9], ProductCount = 1}
                ]
            },
            new()
            {
                Date = new DateTimeOffset(2025, 1, 15, 13, 5, 56, TimeSpan.FromHours(+9)),
                Customer = customers[4],
                OrderProduct = [
                    new OrderProduct { Product = products[2], ProductCount = 1}
                ]
            },
            new()
            {
                Date = new DateTimeOffset(2022, 8, 29, 22, 10, 5, TimeSpan.FromHours(+3)),
                Customer = customers[1],
                OrderProduct = [
                    new OrderProduct { Product = products[6], ProductCount = 2},
                    new OrderProduct { Product = products[7], ProductCount = 1},
                    new OrderProduct { Product = products[8], ProductCount = 2}
                ]
            },
            new()
            {
                Date = new DateTimeOffset(2024, 12, 31, 23, 59, 59, TimeSpan.FromHours(-2)),
                Customer = customers[3],
                OrderProduct = [
                    new OrderProduct { Product = products[4], ProductCount = 7}
                ]
            },
            new()
            {
                Date = new DateTimeOffset(2025, 6, 1, 11, 11, 11, TimeSpan.FromHours(+5)),
                Customer = customers[2],
                OrderProduct = [
                    new OrderProduct { Product = products[1], ProductCount = 1},
                    new OrderProduct { Product = products[2], ProductCount = 7}
                ]
            },
            new()
            {
                Date = new DateTimeOffset(2023, 2, 14, 7, 30, 0, TimeSpan.Zero),
                Customer = customers[1],
                OrderProduct = [
                    new OrderProduct { Product = products[0], ProductCount = 12},
                    new OrderProduct { Product = products[3], ProductCount = 1},
                    new OrderProduct { Product = products[5], ProductCount = 54}
                ]
            },
            new()
            {
                Date = new DateTimeOffset(2024, 7, 7, 17, 45, 30, TimeSpan.FromHours(-7)),
                Customer = customers[4],
                OrderProduct = [
                    new OrderProduct { Product = products[9], ProductCount = 22},
                    new OrderProduct { Product = products[8], ProductCount = 11}
                ]
            }
        };

        foreach (var order in orders)
        {
            db.Orders.Add(order);
        }

        db.SaveChanges();
    }

    public static void Main(string[] args)
    {
        using var db = new ShopContext();

        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        try
        {
            CreateCategoriesAndProducts(db);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при создании категорий и товаров{Environment.NewLine}{ex}");
        }

        try
        {
            CreateCustomersAndOrders(db);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при создании покупателей и заказов{Environment.NewLine}{ex}");
        }

        var topProduct = db.OrderProduct
            .GroupBy(op => op.Product.Name)
            .Select(g => new
            {
                Name = g.Key,
                ProductCount = g.Sum(op => op.ProductCount)
            })
            .OrderByDescending(x => x.ProductCount)
            .FirstOrDefault();

        if (topProduct is null)
        {
            Console.WriteLine("Невозможно определить самый популярный товар: список товаров пуст.");
        }
        else
        {
            Console.WriteLine(
                $"Самый популярный товар - {topProduct.Name}. Количество заказов - {topProduct.ProductCount}");
        }

        var customersSpending = db.Customers
            .Select(c => new
            {
                c.FirstName,
                c.MiddleName,
                c.LastName,
                SpendingSum = c.Orders
                    .SelectMany(o => o.Products)
                    .Sum(p => p.Price)
            })
            .ToList();

        Console.WriteLine();
        Console.WriteLine("Траты каждого клиента за все время:");

        foreach (var customerInfo in customersSpending)
        {
            Console.WriteLine(
                $"{customerInfo.FirstName} {customerInfo.MiddleName} {customerInfo.LastName} - {customerInfo.SpendingSum}");
        }

        Console.WriteLine();

        var categories = db.Categories
            .Select(c => new
            {
                c.Name,
                SoldProductsCount = c.Products
                    .SelectMany(p => p.OrderProduct)
                    .Sum(x => x.ProductCount)
            })
            .OrderByDescending(x => x.SoldProductsCount)
            .ToList();

        foreach (var category in categories)
        {
            Console.WriteLine($"Продано товаров в категории \"{category.Name}\" - {category.SoldProductsCount}");
        }
    }
}