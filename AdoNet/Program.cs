using System.Data;
using Microsoft.Data.SqlClient;

namespace AdoNet;

internal class Program
{
    private const string ConnectionString = "Data Source=.;Initial Catalog=shop;User ID=myUser;Integrated Security=true;Encrypt=False";

    private static int GetTotalGoodsCount(SqlConnection connection)
    {
        const string sql = "SELECT COUNT(*) FROM goods";

        try
        {
            using var command = new SqlCommand(sql, connection);
            return (int)command.ExecuteScalar();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при получении общего количества товаров{Environment.NewLine}{ex}");
            return 0;
        }
    }

    private static void InsertNewCategory(string categoryName, SqlConnection connection)
    {
        const string sql = "INSERT INTO categories (category) VALUES (@categoryName)";

        try
        {
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("categoryName", categoryName);
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при записи данных в БД{Environment.NewLine}{ex}");
        }
    }

    private static int GetCategoryIdByName(string categoryName, SqlConnection connection)
    {
        const string sql = "SELECT id FROM categories WHERE category = @categoryName";

        try
        {
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("categoryName", categoryName);
            return (int)command.ExecuteScalar();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при получении идентификатора категории \"{categoryName}\"{Environment.NewLine}{ex}");
            return 0;
        }
    }

    private static void InsertNewGood(string goodName, int categoryId, double price, SqlConnection connection)
    {
        const string sql = "INSERT INTO goods (name, category_id, price) VALUES (@goodName, @categoryId, @price)";

        try
        {
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("goodName", goodName);
            command.Parameters.AddWithValue("categoryId", categoryId);
            command.Parameters.AddWithValue("price", price);
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при записи данных в БД{Environment.NewLine}{ex}");
        }
    }

    private static void DeleteGoodById(int goodId, SqlConnection connection)
    {
        const string sql = "DELETE FROM goods WHERE id = @goodId";

        try
        {
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("goodId", goodId);
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Произошла ошибка при удалении товара с id = {goodId}{Environment.NewLine}{ex}");
        }
    }

    private static void PrintAllGoodsFromReader(SqlConnection connection)
    {
        const string sql = "SELECT g.id, g.name, c.category, g.price " +
                           "FROM goods g " +
                           "JOIN categories c ON g.category_id = c.id";

        try
        {
            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"Товар #{reader[0]}:{Environment.NewLine}" +
                    $"  - name: {reader[1]}{Environment.NewLine}" +
                    $"  - category: {reader[2]}{Environment.NewLine}" +
                    $"  - price: {reader[3]}{Environment.NewLine}"
                );
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void PrintAllGoodsFromDataSet()
    {
        const string sql = "SELECT g.id, g.name, c.category, g.price " +
                           "FROM goods g " +
                           "JOIN categories c ON g.category_id = c.id";

        using var adapter = new SqlDataAdapter(sql, ConnectionString);
        var dataSet = new DataSet();

        adapter.Fill(dataSet, "Goods");
        var table = dataSet.Tables["Goods"];

        ArgumentNullException.ThrowIfNull(table);

        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine(
                $"Товар #{row[0]}:{Environment.NewLine}" +
                $"  - name: {row[1]}{Environment.NewLine}" +
                $"  - category: {row[2]}{Environment.NewLine}" +
                $"  - price: {row[3]}{Environment.NewLine}"
            );
        }
    }

    public static void Main(string[] args)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        Console.WriteLine($"Общее количество товаров: {GetTotalGoodsCount(connection)}");

        InsertNewCategory("smartphones", connection);

        var categoryId = GetCategoryIdByName("smartphones", connection);
        InsertNewGood("HUAWEI Mate XT 1024 ГБ", categoryId, 150000, connection);

        DeleteGoodById(2, connection);

        PrintAllGoodsFromReader(connection);
        PrintAllGoodsFromDataSet();
    }
}
