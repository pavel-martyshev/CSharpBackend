using NLog;
using VectorTask;

namespace LogTask;

internal class Program
{
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    public static void Main(string[] args)
    {
        var vector1 = new Vector(6)
        {
            [0] = 1,
            [1] = 2,
            [2] = 3
        };

        Log.Info($"Вектор 1: {vector1}");
        Log.Info($"Длина вектора 1: {vector1.GetLength()}");

        Console.WriteLine();

        var vector2 = new Vector([4, 5, 6, 7, 8, 9]);

        Log.Info($"Вектор 2: {vector2}");
        Log.Info($"Длина вектора 2: {vector2.GetLength()}");

        Console.WriteLine();

        var vector3 = Vector.GetSum(vector1, vector2);
        Log.Info($"Результат сложения вектора 1 и вектора 2: {vector3}");

        Console.WriteLine();

        var vector4 = Vector.GetDifference(vector2, vector1);
        Log.Info($"Результат вычитания вектора 1 из вектора 2: {vector4}");

        Console.WriteLine();

        var dotProduct = Vector.GetDotProduct(vector1, vector2);
        Log.Info($"Скалярное произведение вектора 1 и вектора 2: {dotProduct}");

        try
        {
            var vector5 = new Vector(-3);
        }
        catch (Exception ex)
        {
            Log.Error(ex);
        }
    }
}
