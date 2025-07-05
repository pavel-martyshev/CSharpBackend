using VectorTask;

namespace UnitTests;

public class VectorTests
{
    [Theory]
    [InlineData(new double[] { 1, 2 }, new double[] { 5, 6, 7 }, new double[] { 6, 8, 7 })]
    [InlineData(new double[] { 53, 78.1, 104.54, 8003.123 }, new double[] { 64, 2.5 }, new double[] { 117, 80.6, 104.54, 8003.123 })]
    public void Add_TwoVectors_ReturnsVectorWithSummedComponents(double[] components1, double[] components2, double[] correctComponents)
    {
        var testVector1 = new Vector(components1);
        var testVector2 = new Vector(components2);
        var correctVector = new Vector(correctComponents);

        testVector1.Add(testVector2);

        Assert.True(correctVector.Equals(testVector1));
    }

    [Theory]
    [InlineData(new double[] { 5, 6, 7 }, 2.5, new[] {12.5, 15, 17.5})]
    [InlineData(new double[] { 0.42, 17.623, 24 }, 3.69, new[] { 1.5497999999999998, 65.02887, 88.56 })]
    [InlineData(new double[] { 0.2, 321.43, 1, 24.42, 6.7 }, 1.44, new[] { 0.288, 462.8592, 1.44, 35.1648, 9.648 })]
    public void MultiplyByScalar_VectorMultiplyScalar_ReturnsMultipliedVector(double[] components, double scalar, double[] correctComponents)
    {
        var testVector = new Vector(components);
        var correctVector = new Vector(correctComponents);

        testVector.MultiplyByScalar(scalar);

        Assert.True(correctVector.Equals(testVector));
    }
}
