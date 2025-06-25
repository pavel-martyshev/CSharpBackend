using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNet;

internal class Program
{
    private const string ConnectionString = "Data Source=.;Initial Catalog=Shop;Integrated Security=true;Encrypt=False";

    private static int GetTotalProductsCount(SqlConnection connection)
    {
        const string sql = "SELECT COUNT(*) FROM Products";
        using var command = new SqlCommand(sql, connection);
        return (int)command.ExecuteScalar();
    }

    private static void InsertNewCategory(string categoryName, SqlConnection connection)
    {
        const string sql = """
                           INSERT INTO Categories (Name)
                           VALUES (@categoryName)
                           """;
        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("categoryName", categoryName);
        command.ExecuteNonQuery();
    }

    private static int GetCategoryIdByName(string categoryName, SqlConnection connection)
    {
        const string sql = """
                           SELECT Id 
                           FROM Categories 
                           WHERE Name = @categoryName
                           """;
        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("categoryName", categoryName);
        return (int)command.ExecuteScalar();
    }

    private static void InsertNewProduct(string productName, int categoryId, double price, SqlConnection connection)
    {
        const string sql = """
                           INSERT INTO Products (Name, Price, CategoryId)
                           VALUES (@productName, @price, @categoryId)
                           """;
        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("productName", productName);
        command.Parameters.AddWithValue("categoryId", categoryId);
        command.Parameters.AddWithValue("price", price);

        command.ExecuteNonQuery();
    }

    private static void DeleteProductById(int productId, SqlConnection connection)
    {
        const string sql = """
                           DELETE FROM Products
                           WHERE Id = @productId
                           """;
        var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("productId", productId);
        command.ExecuteNonQuery();
    }

    private static SqlDataReader GetAllProductsReader(SqlConnection connection)
    {
        const string sql = """
                           SELECT p.Id, p.Name, c.Name, p.Price
                           FROM Products p
                           INNER JOIN Categories c
                               ON p.CategoryId = c.Id
                           """;
        using var command = new SqlCommand(sql, connection);

        return command.ExecuteReader(); ;
    }

    private static DataTable GetAllProductsDataSet()
    {
        const string sql = """
                           SELECT p.Id, p.Name, c.Name, p.Price
                           FROM Products p
                           INNER JOIN Categories c
                               ON p.CategoryId = c.Id
                           """;

        using var adapter = new SqlDataAdapter(sql, ConnectionString);
        var dataSet = new DataSet();

        adapter.Fill(dataSet, "Products");
        var table = dataSet.Tables["Products"];

        ArgumentNullException.ThrowIfNull(table);

        return table;
    }

    public static void Main(string[] args)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        try
        {
            Console.WriteLine($"Общее количество товаров: {GetTotalProductsCount(connection)}");
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при получении общего количества товаров{Environment.NewLine}{ex}");
        }

        try
        {
            InsertNewCategory("Smartphones", connection);
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при записи данных в БД{Environment.NewLine}{ex}");
        }

        try
        {
            var categoryId = GetCategoryIdByName("smartphones", connection);
            InsertNewProduct("HUAWEI Mate XT 1024 ГБ", categoryId, 150000, connection);
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при добавлении новогог товара{Environment.NewLine}{ex}");
        }

        try
        {
            DeleteProductById(2, connection);
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при удалении товара{Environment.NewLine}{ex}");
        }

        Console.WriteLine();
        Console.WriteLine("Список всех товаров через reader:");

        try
        {
            using var reader = GetAllProductsReader(connection);

            while (reader.Read())
            {
                Console.WriteLine($"""
                                   Товар #{reader[0]}:
                                     - name: {reader[1]}
                                     - category: {reader[2]}
                                     - price: {reader[3]}{Environment.NewLine}
                                   """);
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при получении списка товаров{Environment.NewLine}{ex}");
        }

        Console.WriteLine();
        Console.WriteLine("Список всех товаров через DataSet:");

        try
        {
            var table = GetAllProductsDataSet();

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"""
                                   Товар #{row[0]}:
                                     - name: {row[1]}
                                     - category: {row[2]}
                                     - price: {row[3]}{Environment.NewLine}
                                   """);
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при получении списка товаров{Environment.NewLine}{ex}");
        }
    }
}