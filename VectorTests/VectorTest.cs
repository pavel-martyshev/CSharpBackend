using VectorTask;

namespace VectorTests;

[TestClass]
public sealed class VectorTest
{
    [TestMethod]
    public void TestAdd()
    {
        var vector1 = new Vector(2)
        {
            [0] = 1,
            [1] = 2
        };

        var vector2 = new Vector(3)
        {
            [0] = 5,
            [1] = 6,
            [2] = 7
        };

        vector1.Add(vector2);

        Assert.AreEqual(3, vector1.Size);

        Assert.AreEqual(6, vector1[0]);
        Assert.AreEqual(8, vector1[1]);
        Assert.AreEqual(7, vector1[2]);
    }

    [TestMethod]
    public void TestMultiplyByScalar()
    {
        var vector = new Vector(3)
        {
            [0] = 5,
            [1] = 6,
            [2] = 7
        };

        const double scalar = 2.5;

        vector.MultiplyByScalar(scalar);

        Assert.AreEqual(12.5, vector[0]);
        Assert.AreEqual(15, vector[1]);
        Assert.AreEqual(17.5, vector[2]);
    }
}
