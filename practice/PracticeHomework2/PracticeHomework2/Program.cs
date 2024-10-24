using System;
using System.Collections.Generic;
namespace Practice;
public class Statistics
{
    public static void Main()
    {
        List<double> sampleValuesList = new List<double> { 9, 6, 8, 5, 7 };
        double sampleStdDev = ComputeSampleStandardDeviation(sampleValuesList);
        Console.WriteLine("Sample StdDev = " + sampleStdDev);
        // Writes "Sample StdDev=1.5811388300841898"

        List<double> populationValuesList = new List<double>
            { 9, 2, 5, 4, 12, 7, 8, 11, 9, 3, 7, 4, 12, 5, 4, 10, 9, 6, 9, 4 };
        double popStdDev = ComputePopulationStandardDeviation(populationValuesList);
        Console.WriteLine("Population StdDev = " + popStdDev);
        // Writes "Population StdDev=2.9832867780352594"
        
        
    }

    // Function to compute the mean (average) of a list of values
    public static double ComputeMean(List<double> valuesList)
    {
        if (valuesList.Count == 0)
            throw new ArgumentException("valuesList parameter cannot be null or empty");

        double sumAccumulator = 0;
        foreach (var value in valuesList)
        {
            sumAccumulator += value;
        }

        // Return the average (sum divided by the number of values)
        return sumAccumulator / valuesList.Count;
    }

    // Function to compute the sum of squared differences from the mean
    public static double ComputeSquareOfDifferences(List<double> valuesList, double mean)
    {
        if (valuesList.Count == 0)
            throw new ArgumentException("valuesList parameter cannot be null or empty");

        double squareAccumulator = 0;
        foreach (var value in valuesList)
        {
            double difference = value - mean;
            double squareOfDifference = difference * difference;
            squareAccumulator += squareOfDifference;
        }

        return squareAccumulator;
    }

    // Function to compute the variance based on squared differences
    public static double ComputeVariance(double squareOfDifferences, int numValues, bool isPopulation)
    {
        if (!isPopulation)
            numValues -= 1;

        // Test numValues after adjusting
        if (numValues < 1)
            throw new ArgumentException("numValues is too low (sample size must be >= 2, population size must be >= 1)");

        return squareOfDifferences / numValues;
    }

    // Function to compute the population or sample standard deviation from a list of values
    public static double ComputeStandardDeviation(List<double> valuesList, bool isPopulation)
    {
        if (valuesList.Count == 0)
            throw new ArgumentException("valuesList parameter cannot be null or empty");

        double mean = ComputeMean(valuesList);
        double squareOfDifferences = ComputeSquareOfDifferences(valuesList, mean);
        double variance = ComputeVariance(squareOfDifferences, valuesList.Count, isPopulation);

        return Math.Sqrt(variance); // Compute the square root of the variance
    }

    // Function to compute the sample standard deviation from a list of values
    public static double ComputeSampleStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, false); // false indicates sample
    }

    // Function to compute the population standard deviation from a list of values
    public static double ComputePopulationStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, true); // true indicates population
    }
    
    // Naive function to summarize a standard deviation value
    public static string InterpretStandardDeviation(double stdDev)
    {
        stdDev = Math.Round(stdDev, 1);

        if (stdDev > 2.0)
        {
            return "Above Average";
        }
        else if (stdDev < -2.0)
        {
            return "Below Average";
        }
        else if (stdDev == 0.0)
        {
            return "Exactly Average";
        }
        else
        {
            return "Near Average";
        }
    }
}
