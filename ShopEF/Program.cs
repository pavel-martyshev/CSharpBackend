using Microsoft.EntityFrameworkCore;
using ShopEF.Database;
using ShopEF.Database.Models;
using ShopEF.Database.Repositories;
using ShopEF.Database.Repositories.Interfaces;

namespace ShopEF;

internal class Program
{
    private static void CreateCategoriesAndProducts(UnitOfWork uow)
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

        uow.BeginTransaction();

        foreach (var product in products)
        {
            uow.ProductRepository.Create(product);
        }

        uow.Save();
    }

    private static void CreateCustomersAndOrders(UnitOfWork uow)
    {
        var customers = new List<Customer>
        {
            new()
            {
                FirstName = "Иван",
                MiddleName = "Иванович",
                LastName = "Петров",
                PhoneNumber = "+7-912-345-67-89",
                Email = "ivan.petrov@example.com",
                BirthDate = new DateOnly(1978, 11, 23)
            },
            new()
            {
                FirstName = "Мария",
                MiddleName = "Сергеевна",
                LastName = "Иванова",
                PhoneNumber = "+7-903-876-54-32",
                Email = "maria.ivanova@example.com",
                BirthDate = new DateOnly(2005, 06, 26)
            },
            new()
            {
                FirstName = "Алексей",
                MiddleName = "Владимирович",
                LastName = "Соколов",
                PhoneNumber = "+7-925-123-45-67",
                Email = "a.sokolov@example.com",
                BirthDate = new DateOnly(1962, 01, 01)
            },
            new()
            {
                FirstName = "Екатерина",
                MiddleName = "Дмитриевна",
                LastName = "Смирнова",
                PhoneNumber = "+7-901-234-56-78",
                Email = "ekaterina.smirnova@example.com",
                BirthDate = new DateOnly(1994, 05, 15)
            },
            new()
            {
                FirstName = "Дмитрий",
                MiddleName = "Алексеевич",
                LastName = "Кузнецов",
                PhoneNumber = "+7-981-987-65-43",
                Email = "d.kuznetsov@example.com",
                BirthDate = new DateOnly(1999, 09, 09)
            }
        };

        var orders = new List<Order>
        {
            new()
            {
                Date = new DateTimeOffset(2024, 11, 3, 8, 15, 12, TimeSpan.FromHours(+1)),
                Customer = customers[2]
            },
            new()
            {
                Date = new DateTimeOffset(2023, 6, 20, 19, 47, 33, TimeSpan.FromHours(-4)),
                Customer = customers[0]
            },
            new()
            {
                Date = new DateTimeOffset(2025, 1, 15, 13, 5, 56, TimeSpan.FromHours(+9)),
                Customer = customers[4]
            },
            new()
            {
                Date = new DateTimeOffset(2022, 8, 29, 22, 10, 5, TimeSpan.FromHours(+3)),
                Customer = customers[1]
            },
            new()
            {
                Date = new DateTimeOffset(2024, 12, 31, 23, 59, 59, TimeSpan.FromHours(-2)),
                Customer = customers[3]
            },
            new()
            {
                Date = new DateTimeOffset(2025, 6, 1, 11, 11, 11, TimeSpan.FromHours(+5)),
                Customer = customers[2]
            },
            new()
            {
                Date = new DateTimeOffset(2023, 2, 14, 7, 30, 0, TimeSpan.Zero),
                Customer = customers[1]
            },
            new()
            {
                Date = new DateTimeOffset(2024, 7, 7, 17, 45, 30, TimeSpan.FromHours(-7)),
                Customer = customers[4]
            }
        };

        uow.BeginTransaction();

        foreach (var order in orders)
        {
            uow.OrderRepository.Create(order);
        }

        uow.Save();
    }

    private static void LinkProductsToOrder(UnitOfWork uow)
    {
        var products = uow.ProductRepository.GetAll();
        var orders = uow.OrderRepository.GetAll();

        var random = new Random();
        var orderProducts = new List<OrderProduct>();

        for (var i = 0; i < orders.Length; i++)
        {
            var allOrderProductsCount = random.Next(1, 3);

            for (var j = 0; j < allOrderProductsCount; j++)
            {
                orderProducts.Add(new OrderProduct
                {
                    OrderId = orders[i].Id,
                    ProductId = products[random.Next(0, 9)].Id,
                    ProductsCount = random.Next(1, 15),
                });
            }
        }

        foreach (var orderProduct in orderProducts)
        {
            uow.OrderProductRepository.Create(orderProduct);
        }

        uow.Save();
    }

    public static void Main(string[] args)
    {
        var db = new ShopContext();

        db.Database.EnsureDeleted();
        db.Database.Migrate();

        using var uow = new UnitOfWork(db);
        
        try
        {
            CreateCategoriesAndProducts(uow);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка при создании категорий и товаров{Environment.NewLine}{e}");
        }

        try
        {
            CreateCustomersAndOrders(uow);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка при создании покупателей и заказов{Environment.NewLine}{e}");
        }

        try
        {
            LinkProductsToOrder(uow);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка при привязке продуктов к заказам{Environment.NewLine}{e}");
        }

        var topProduct = uow.ProductRepository.GetTopProduct();

        if (topProduct is null)
        {
            Console.WriteLine("Невозможно определить самый популярный товар: список товаров пуст.");
        }
        else
        {
            Console.WriteLine($"Самый популярный товар - {topProduct.Name}. Количество заказов - {topProduct.OrdersQuantity}");
        }

        var customersSpending = uow.CustomerRepository.GetCustomersSpendings();

        Console.WriteLine();
        Console.WriteLine("Траты каждого клиента за все время:");

        foreach (var customerInfo in customersSpending)
        {
            Console.WriteLine($"{customerInfo.FirstName} {customerInfo.MiddleName} {customerInfo.LastName} - {customerInfo.SpendingSum}");
        }

        Console.WriteLine();

        var categories = uow.CategoryRepository.GetCategoriesWithSoldProducts();

        foreach (var category in categories)
        {
            Console.WriteLine($"Продано товаров в категории \"{category.Name}\" - {category.SoldProductsCount}");
        }
    }
}