using VectorTask;

namespace UnitTests;

public class VectorTests
{
    [Theory]
    [InlineData(new double[] { 1, 2 }, new double[] { 5, 6, 7 })]
    [InlineData(new double[] { 53, 78.1, 104.54, 8003.123 }, new double[] { 64, 2.5 })]
    public void Add_TwoVectors_ReturnsVectorWithSummedComponents(double[] components1, double[] components2)
    {
        var testVector1 = new Vector(components1);

        var testVector2 = new Vector(components2);

        if (components1.Length < components2.Length)
        {
            Array.Resize(ref components1, components2.Length);
        }

        for (var i = 0; i < components2.Length; i++)
        {
            components1[i] += components2[i];
        }

        var correctVector = new Vector(components1);
        testVector1.Add(testVector2);

        Assert.True(correctVector.Equals(testVector1));
    }

    [Theory]
    [InlineData(new double[] { 5, 6, 7 }, 2.5)]
    [InlineData(new double[] { 0.42, 17.623, 24 }, 3.69)]
    [InlineData(new double[] { 0.2, 321.43, 1, 24.42, 6.75 }, 1.44)]
    public void MultiplyByScalar_VectorMultiplyScalar_ReturnsMultipliedVector(double[] components, double scalar)
    {
        var testVector = new Vector(components);

        for (var i = 0; i < components.Length; i++)
        {
            components[i] *= scalar;
        }

        var correctVector = new Vector(components);

        testVector.MultiplyByScalar(scalar);

        Assert.True(correctVector.Equals(testVector));
    }
}
