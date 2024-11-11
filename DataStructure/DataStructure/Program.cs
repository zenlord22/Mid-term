using System;
using System.Collections.Generic;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Dictionary<int, int> numberMap = new Dictionary<int, int>();
            Stack<int> numberStack = new Stack<int>();
            Queue<int> numberQueue = new Queue<int>();

            Console.WriteLine("Enter numbers (type 'done' to finish):");

            string input;
            int index = 1;
            while ((input = Console.ReadLine()) != "done")
            {
                if (int.TryParse(input, out int number))
                {
                    numbers.Add(number);
                    numberMap[index] = number;
                    numberStack.Push(number);
                    numberQueue.Enqueue(number);
                    index++;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            // Convert List to Array
            int[] numberArray = numbers.ToArray();

            // Display the contents of each data structure
            Console.WriteLine("\nArray:");
            foreach (var num in numberArray)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\n\nDictionary (Map):");
            foreach (var kvp in numberMap)
            {
                Console.WriteLine($"Index: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine("\nStack:");
            foreach (var num in numberStack)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\n\nQueue:");
            foreach (var num in numberQueue)
            {
                Console.Write(num + " ");
            }
        }
    }
}
