using System;
using System.Collections.Generic;
using NUnit.Framework;
using Practice;
[TestFixture]
public class Tests2
{
    [Test]
    public void ComputeMean_ValidValues_ReturnsCorrectMean()
    {
        var values = new List<double> { 9, 6, 8, 5, 7 };
        double result = Statistics.ComputeMean(values);
        Assert.AreEqual(7.0, result);
    }

    [Test]
    public void ComputeMean_EmptyList_ThrowsArgumentException()
    {
        var values = new List<double>();
        Assert.Throws<ArgumentException>(() => Statistics.ComputeMean(values));
    }

    [Test]
    public void ComputeSquareOfDifferences_ValidValues_ReturnsCorrectSumOfSquares()
    {
        var values = new List<double> { 9, 6, 8, 5, 7 };
        double mean = Statistics.ComputeMean(values);
        double result = Statistics.ComputeSquareOfDifferences(values, mean);
        Assert.AreEqual(10.0, result);
    }

    [Test]
    public void ComputeSquareOfDifferences_EmptyList_ThrowsArgumentException()
    {
        var values = new List<double>();
        Assert.Throws<ArgumentException>(() => Statistics.ComputeSquareOfDifferences(values, 0));
    }

    [Test]
    public void ComputeVariance_ValidSample_ReturnsCorrectVariance()
    {
        double squareOfDifferences = 10.0;
        int numValues = 5; // sample size
        bool isPopulation = false;
        double result = Statistics.ComputeVariance(squareOfDifferences, numValues, isPopulation);
        Assert.AreEqual(2.5, result);
    }

    [Test]
    public void ComputeVariance_ValidPopulation_ReturnsCorrectVariance()
    {
        double squareOfDifferences = 10.0;
        int numValues = 5; // population size
        bool isPopulation = true;
        double result = Statistics.ComputeVariance(squareOfDifferences, numValues, isPopulation);
        Assert.AreEqual(2.0, result);
    }

    [Test]
    public void ComputeVariance_SampleSizeTooLow_ThrowsArgumentException()
    {
        double squareOfDifferences = 10.0;
        int numValues = 1; // sample size
        Assert.Throws<ArgumentException>(() => Statistics.ComputeVariance(squareOfDifferences, numValues, false));
    }

    [Test]
    public void ComputeVariance_PopulationSizeTooLow_ThrowsArgumentException()
    {
        double squareOfDifferences = 10.0;
        int numValues = 0; // population size
        Assert.Throws<ArgumentException>(() => Statistics.ComputeVariance(squareOfDifferences, numValues, true));
    }

    [Test]
    public void ComputeStandardDeviation_ValidSample_ReturnsCorrectStdDev()
    {
        var values = new List<double> { 9, 6, 8, 5, 7 };
        double result = Statistics.ComputeStandardDeviation(values, false);
        Assert.AreEqual(1.5811388300841898, result, 1e-9); // Allow for floating point precision
    }

    [Test]
    public void ComputeStandardDeviation_ValidPopulation_ReturnsCorrectStdDev()
    {
        var values = new List<double> { 9, 2, 5, 4, 12, 7, 8, 11, 9, 3, 7, 4, 12, 5, 4, 10, 9, 6, 9, 4 };
        double result = Statistics.ComputeStandardDeviation(values, true);
        Assert.AreEqual(2.3873223778831135, result, 1e-9);
    }

    [Test]
    public void ComputeStandardDeviation_EmptyList_ThrowsArgumentException()
    {
        var values = new List<double>();
        Assert.Throws<ArgumentException>(() => Statistics.ComputeStandardDeviation(values, false));
    }

    [Test]
    public void ComputeSampleStandardDeviation_ValidSample_ReturnsCorrectStdDev()
    {
        var values = new List<double> { 9, 6, 8, 5, 7 };
        double result = Statistics.ComputeSampleStandardDeviation(values);
        Assert.AreEqual(1.5811388300841898, result, 1e-9);
    }

    [Test]
    public void ComputePopulationStandardDeviation_ValidPopulation_ReturnsCorrectStdDev()
    {
        var values = new List<double> { 9, 2, 5, 4, 12, 7, 8, 11, 9, 3, 7, 4, 12, 5, 4, 10, 9, 6, 9, 4 };
        double result = Statistics.ComputePopulationStandardDeviation(values);
        Assert.AreEqual(2.3873223778831135, result, 1e-9);
    }
    
    
}
