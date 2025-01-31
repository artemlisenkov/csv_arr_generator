using System;
using System.IO;
using System.Diagnostics;

// File paths for different datasets
string basePath = @"C:\Users\notbad\RiderProjects\Algorithms.Assignment.1\InputGenerator.Assignment.1\bin\Debug\net8.0\";
string[] fileNames = { "random_arrays.csv", "sorted_arrays.csv", "reverse_sorted_arrays.csv" };

foreach (string fileName in fileNames)
{
    string filePath = Path.Combine(basePath, fileName);
    Console.WriteLine($"\nAttempting to load file: {filePath}");

    // Check if the file exists
    if (!File.Exists(filePath))
    {
        Console.WriteLine("Error: File not found!");
        continue;
    }

    // Load arrays from CSV
    int[][] datasets = LoadMultipleArraysFromCsv(filePath);
    Console.WriteLine($"Loaded {datasets.Length} arrays from {fileName}");

    // Sort and measure time using MergeSort
    Console.WriteLine($"\nSorting arrays from {fileName} using Merge Sort...");
    Stopwatch stopwatch = new();

    for (int i = 0; i < datasets.Length; i++)
    {
        stopwatch.Restart();
        MergeSort(datasets[i], 0, datasets[i].Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"Array {i + 1} ({datasets[i].Length} elements) sorted with MergeSort in {stopwatch.Elapsed.TotalSeconds:F6} seconds.");
    }

    // Sort and measure time using QuickSort
    Console.WriteLine($"\nSorting arrays from {fileName} using QuickSort...");
    for (int i = 0; i < datasets.Length; i++)
    {
        stopwatch.Restart();
        QuickSort(datasets[i], 0, datasets[i].Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"Array {i + 1} ({datasets[i].Length} elements) sorted with QuickSort in {stopwatch.Elapsed.TotalSeconds:F6} seconds.");
    }

    // Sort and measure time using InsertionSort
    Console.WriteLine($"\nSorting arrays from {fileName} using Insertion Sort...");
    for (int i = 0; i < datasets.Length; i++)
    {
        stopwatch.Restart();
        InsertionSort(datasets[i]);
        stopwatch.Stop();
        Console.WriteLine($"Array {i + 1} ({datasets[i].Length} elements) sorted with InsertionSort in {stopwatch.Elapsed.TotalSeconds:F6} seconds.");
    }

    // Sort and measure time using BubbleSort
    Console.WriteLine($"\nSorting arrays from {fileName} using Bubble Sort...");
    for (int i = 0; i < datasets.Length; i++)
    {
        stopwatch.Restart();
        BubbleSort(datasets[i]);
        stopwatch.Stop();
        Console.WriteLine($"Array {i + 1} ({datasets[i].Length} elements) sorted with BubbleSort in {stopwatch.Elapsed.TotalSeconds:F6} seconds.");
    }
}

// Function to load arrays from CSV
int[][] LoadMultipleArraysFromCsv(string filePath)
{
    string[] lines = File.ReadAllLines(filePath);
    int[][] arrays = new int[lines.Length][];
    for (int i = 0; i < lines.Length; i++)
    {
        string[] stringValues = lines[i].Split(','); // Split by commas
        arrays[i] = Array.ConvertAll(stringValues, int.Parse); // Convert to integers
    }
    return arrays;
}

// Merge Sort Algorithm
void MergeSort(int[] array, int left, int right)
{
    if (left < right)
    {
        int middle = (left + right) / 2;
        MergeSort(array, left, middle);
        MergeSort(array, middle + 1, right);
        Merge(array, left, middle, right);
    }
}

void Merge(int[] array, int left, int middle, int right)
{
    int leftSize = middle - left + 1;
    int rightSize = right - middle;

    int[] leftArray = new int[leftSize];
    int[] rightArray = new int[rightSize];

    Array.Copy(array, left, leftArray, 0, leftSize);
    Array.Copy(array, middle + 1, rightArray, 0, rightSize);

    int i = 0, j = 0, k = left;

    while (i < leftSize && j < rightSize)
    {
        if (leftArray[i] <= rightArray[j])
        {
            array[k] = leftArray[i];
            i++;
        }
        else
        {
            array[k] = rightArray[j];
            j++;
        }
        k++;
    }

    while (i < leftSize)
    {
        array[k] = leftArray[i];
        i++;
        k++;
    }

    while (j < rightSize)
    {
        array[k] = rightArray[j];
        j++;
        k++;
    }
}

// QuickSort Algorithm
void QuickSort(int[] array, int low, int high)
{
    if (low < high)
    {
        int pi = Partition(array, low, high);
        QuickSort(array, low, pi - 1);
        QuickSort(array, pi + 1, high);
    }
}

int Partition(int[] array, int low, int high)
{
    int pivot = array[high];
    int i = low - 1;

    for (int j = low; j < high; j++)
    {
        if (array[j] <= pivot)
        {
            i++;
            Swap(ref array[i], ref array[j]);
        }
    }
    Swap(ref array[i + 1], ref array[high]);
    return i + 1;
}

void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

// Insertion Sort Algorithm
void InsertionSort(int[] array)
{
    for (int i = 1; i < array.Length; i++)
    {
        int key = array[i];
        int j = i - 1;

        // Move elements of array[0..i-1], that are greater than key, to one position ahead of their current position
        while (j >= 0 && array[j] > key)
        {
            array[j + 1] = array[j];
            j--;
        }
        array[j + 1] = key;
    }
}

// Bubble Sort Algorithm
void BubbleSort(int[] array)
{
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                // Swap the elements
                Swap(ref array[j], ref array[j + 1]);
            }
        }
    }
}
