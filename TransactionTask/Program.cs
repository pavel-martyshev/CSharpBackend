using Microsoft.Data.SqlClient;

namespace TransactionTask
{
    internal class Program
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=Shop;Integrated Security=true;Encrypt=False";

        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var transaction = connection.BeginTransaction();

            try
            {
                const string sql = """
                                   INSERT INTO Products (Name, Price, CategoryId)
                                   VALUES (N'Asus', 4599, 1)
                                   """;

                using var command = new SqlCommand(sql, connection);
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                throw new InvalidOperationException("Что-то пошло не так при вставке с транзакцией.");

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Ошибка вставки данных:{Environment.NewLine}{ex}");
            }

            try
            {
                const string sql = """
                                   INSERT INTO Products (Name, Price, CategoryId)
                                   VALUES (N'Not Asus', 999999, 1)
                                   """;

                using var command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                throw new InvalidOperationException("Что-то пошло не так при вставке без транзакции.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка вставки данных:{Environment.NewLine}{ex}");
            }
        }
    }
}