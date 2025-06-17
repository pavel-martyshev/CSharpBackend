using VectorTask;

namespace UnitTests;

public class TestVector
{
    [Fact]
    public void Add_TwoVectors_ReturnsVectorWithSummedComponents()
    {
        var correctVector = new Vector(3)
        {
            [0] = 6,
            [1] = 8,
            [2] = 7,
        };

        var testVector1 = new Vector(2)
        {
            [0] = 1,
            [1] = 2
        };

        var testVector2 = new Vector(3)
        {
            [0] = 5,
            [1] = 6,
            [2] = 7
        };

        testVector1.Add(testVector2);

        Assert.True(correctVector.Equals(testVector1));
    }

    [Theory]
    [InlineData(5, 6, 7, 2.5)]
    [InlineData(0.42, 17.623, 24, 3.69)]
    public void MultiplyByScalar_VectorMultiplyScalar_ReturnsMultipliedVector(double component1, double component2, double component3, double scalar)
    {
        var correctVector = new Vector(3)
        {
            [0] = component1 * scalar,
            [1] = component2 * scalar,
            [2] = component3 * scalar
        };

        var testVector = new Vector(3)
        {
            [0] = component1,
            [1] = component2,
            [2] = component3
        };

        testVector.MultiplyByScalar(scalar);

        Assert.True(correctVector.Equals(testVector));
    }
}
