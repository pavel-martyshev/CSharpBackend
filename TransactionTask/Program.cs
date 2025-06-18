using Microsoft.Data.SqlClient;

namespace TransactionTask
{
    internal class Program
    {
        private const string ConnectionString =
            "Data Source=.;Initial Catalog=Shop;Integrated Security=true;Encrypt=False";

        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var transaction = connection.BeginTransaction();

            try
            {
                const string sql = """
                                   INSERT INTO Categories (Name)
                                   VALUES (N'Smartphones')
                                   """;

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex);
            }

            try
            {
                const string sql = """
                                   INSERT INTO Categories (Name)
                                   VALUES (N'Smartphones')
                                   """;

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex);
            }
        }
    }
}