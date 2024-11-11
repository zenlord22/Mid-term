using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        // Used an input Array to generate diffrent results in the Algorithm. Array size varies to show Algorithm works.
        Console.WriteLine("Enter the elements of the array separated by spaces:");
        string input = Console.ReadLine();

        string[] inputArray = input.Split(' ');

        int[] numbers = Array.ConvertAll(inputArray, int.Parse);

        Console.WriteLine("You entered the following array:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();

        int firstElement = GetFirstElement(numbers);
        Console.WriteLine("First element: " + firstElement);

        int sum = SumArray(numbers);
        Console.WriteLine("Sum of array: " + sum);

        PrintAllPairs(numbers);
    }

    // O(1) - Constant Time. Program searches for the first element in the array.
    static int GetFirstElement(int[] array)
    {
        return array[0];
    }

    // O(n) - Linear Time. Program outputs the Sum of Arrary.
    static int SumArray(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum;
    }

    // O(n^2) - Quadratic Time. Program outputs all the pairs in the array.
    static void PrintAllPairs(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length; j++)
            {
                Console.WriteLine($"Pair: ({array[i]}, {array[j]})");
            }
        }
    }
}

