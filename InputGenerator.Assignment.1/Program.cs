using System;
using System.IO;

// Generate random array of specified size
int[] GenerateRandomArray(int size, int min = 1, int max = 1000)
{
    Random random = new Random();
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = random.Next(min, max);
    }
    return array;
}

// Generate a pre-sorted array
int[] GenerateSortedArray(int size, int min = 1, int max = 1000)
{
    int[] array = GenerateRandomArray(size, min, max);
    Array.Sort(array); // Sort the array
    return array;
}

// Generate a reverse-sorted array
int[] GenerateReverseSortedArray(int size, int min = 1, int max = 1000)
{
    int[] array = GenerateSortedArray(size, min, max);
    Array.Reverse(array); // Reverse the sorted array
    return array;
}

// Save multiple arrays to a CSV file
void SaveArraysToCsv(string filePath, int[][] arrays)
{
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        foreach (int[] array in arrays)
        {
            string csvLine = string.Join(",", array);
            writer.WriteLine(csvLine);
        }
    }
    Console.WriteLine($"Arrays saved to {filePath}");
}

// Load multiple arrays from a CSV file
int[][] LoadMultipleArraysFromCsv(string filePath)
{
    string[] lines = File.ReadAllLines(filePath);
    int[][] arrays = new int[lines.Length][];
    for (int i = 0; i < lines.Length; i++)
    {
        string[] stringValues = lines[i].Split(',');
        arrays[i] = Array.ConvertAll(stringValues, int.Parse);
    }
    return arrays;
}

// Generate predefined small and large datasets with 3 variations
int[][] GeneratePredefinedDatasets()
{
    int[][] datasets = new int[][]
    {
        // Random arrays for each size
        GenerateRandomArray(5),
        GenerateRandomArray(15),
        GenerateRandomArray(30),
        GenerateRandomArray(50),
        GenerateRandomArray(500),
        GenerateRandomArray(5000),

        // Sorted arrays for each size
        GenerateSortedArray(5),
        GenerateSortedArray(15),
        GenerateSortedArray(30),
        GenerateSortedArray(50),
        GenerateSortedArray(500),
        GenerateSortedArray(5000),

        // Reverse-sorted arrays for each size
        GenerateReverseSortedArray(5),
        GenerateReverseSortedArray(15),
        GenerateReverseSortedArray(30),
        GenerateReverseSortedArray(50),
        GenerateReverseSortedArray(500),
        GenerateReverseSortedArray(5000)
    };
    return datasets;
}

// File paths
string randomFilePath = "random_arrays.csv";
string sortedFilePath = "sorted_arrays.csv";
string reverseSortedFilePath = "reverse_sorted_arrays.csv";

// Generate and save predefined datasets
int[][] datasets = GeneratePredefinedDatasets();

// Separate the datasets into three variations
int[][] randomDatasets = new int[6][];
int[][] sortedDatasets = new int[6][];
int[][] reverseSortedDatasets = new int[6][];

for (int i = 0; i < 6; i++)
{
    randomDatasets[i] = datasets[i]; 
    sortedDatasets[i] = datasets[i + 6]; 
    reverseSortedDatasets[i] = datasets[i + 12]; 
}

// Save each set of arrays to its own file
SaveArraysToCsv(randomFilePath, randomDatasets);
SaveArraysToCsv(sortedFilePath, sortedDatasets);
SaveArraysToCsv(reverseSortedFilePath, reverseSortedDatasets);

// Load and display arrays
Console.WriteLine("Loaded arrays from random file:");
if (File.Exists(randomFilePath))
{
    int[][] loadedRandomDatasets = LoadMultipleArraysFromCsv(randomFilePath);
    for (int i = 0; i < loadedRandomDatasets.Length; i++)
    {
        Console.WriteLine($"Array {i + 1} ({loadedRandomDatasets[i].Length} elements):");
        Console.WriteLine(string.Join(", ", loadedRandomDatasets[i]));
    }
}

Console.WriteLine("Loaded arrays from sorted file:");
if (File.Exists(sortedFilePath))
{
    int[][] loadedSortedDatasets = LoadMultipleArraysFromCsv(sortedFilePath);
    for (int i = 0; i < loadedSortedDatasets.Length; i++)
    {
        Console.WriteLine($"Array {i + 1} ({loadedSortedDatasets[i].Length} elements):");
        Console.WriteLine(string.Join(", ", loadedSortedDatasets[i]));
    }
}

Console.WriteLine("Loaded arrays from reverse-sorted file:");
if (File.Exists(reverseSortedFilePath))
{
    int[][] loadedReverseSortedDatasets = LoadMultipleArraysFromCsv(reverseSortedFilePath);
    for (int i = 0; i < loadedReverseSortedDatasets.Length; i++)
    {
        Console.WriteLine($"Array {i + 1} ({loadedReverseSortedDatasets[i].Length} elements):");
        Console.WriteLine(string.Join(", ", loadedReverseSortedDatasets[i]));
    }
}
else
{
    Console.WriteLine($"File {reverseSortedFilePath} does not exist.");
}
