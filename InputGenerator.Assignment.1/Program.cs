using System;
using System.IO;

// Generate random array of specified size
int[] GenerateRandomArray(int size, int min = 1, int max = 100)
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
int[] GenerateSortedArray(int size, int min = 1, int max = 100)
{
    int[] array = GenerateRandomArray(size, min, max);
    Array.Sort(array); // Sort the array
    return array;
}

// Generate a reverse-sorted array
int[] GenerateReverseSortedArray(int size, int min = 1, int max = 100)
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
        GenerateRandomArray(5),       // Random dataset with 5 elements
        GenerateRandomArray(15),      // Random dataset with 15 elements
        GenerateRandomArray(30),      // Random dataset with 30 elements
        GenerateRandomArray(50),      // Random dataset with 50 elements
        GenerateRandomArray(500),     // Random dataset with 500 elements

        // Sorted arrays for each size
        GenerateSortedArray(5),       // Sorted dataset with 5 elements
        GenerateSortedArray(15),      // Sorted dataset with 15 elements
        GenerateSortedArray(30),      // Sorted dataset with 30 elements
        GenerateSortedArray(50),      // Sorted dataset with 50 elements
        GenerateSortedArray(500),     // Sorted dataset with 500 elements

        // Reverse-sorted arrays for each size
        GenerateReverseSortedArray(5),       // Reverse-sorted dataset with 5 elements
        GenerateReverseSortedArray(15),      // Reverse-sorted dataset with 15 elements
        GenerateReverseSortedArray(30),      // Reverse-sorted dataset with 30 elements
        GenerateReverseSortedArray(50),      // Reverse-sorted dataset with 50 elements
        GenerateReverseSortedArray(500)      // Reverse-sorted dataset with 500 elements
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
int[][] randomDatasets = new int[5][];
int[][] sortedDatasets = new int[5][];
int[][] reverseSortedDatasets = new int[5][];

for (int i = 0; i < 5; i++)
{
    // Assign random arrays
    randomDatasets[i] = datasets[i]; 

    // Assign sorted arrays
    sortedDatasets[i] = datasets[i + 5]; 

    // Assign reverse-sorted arrays
    reverseSortedDatasets[i] = datasets[i + 10]; 
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

