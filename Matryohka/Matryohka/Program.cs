using System;
using System.Collections.Generic;

namespace Matryoshka
{
    class Program
    {
        static void Main(string[] args)
        {
            MatryoshkaDoll largestDoll = CreateDolls(24);

            List<MatryoshkaDoll> linedUpDolls = UnstackDolls(largestDoll);

            Console.WriteLine($"Total number of dolls: {CountDolls(linedUpDolls)}");

            // Find the largest doll in the lineup
            MatryoshkaDoll largestInLineup = FindLargestDoll(linedUpDolls);
            Console.WriteLine($"The largest doll in the lineup is: Matryoshka Doll {largestInLineup.Size}");

            // Assign a random signature to one of the dolls
            string signature = "UniqueSignature";
            AssignRandomSignature(linedUpDolls, signature);

            // Find the doll with the assigned signature
            MatryoshkaDoll dollWithSignature = FindDollBySignature(linedUpDolls, signature);
            if (dollWithSignature != null)
            {
                Console.WriteLine($"The doll with the signature '{signature}' is: Matryoshka Doll {dollWithSignature.Size}");
            }
            else
            {
                Console.WriteLine($"No doll found with the signature '{signature}'");
            }
        }

        static MatryoshkaDoll CreateDolls(int count)
        {
            MatryoshkaDoll largestDoll = null;
            MatryoshkaDoll currentDoll = null;

            for (int i = count; i >= 1; i--)
            {
                var newDoll = new MatryoshkaDoll(i);
                if (largestDoll == null)
                {
                    largestDoll = newDoll;
                }
                else
                {
                    currentDoll.SmallerDoll = newDoll;
                }
                currentDoll = newDoll;
            }

            return largestDoll;
        }

        static List<MatryoshkaDoll> UnstackDolls(MatryoshkaDoll largestDoll)
        {
            List<MatryoshkaDoll> dolls = new List<MatryoshkaDoll>();
            MatryoshkaDoll currentDoll = largestDoll;

            while (currentDoll != null)
            {
                dolls.Add(currentDoll);
                currentDoll = currentDoll.SmallerDoll;
            }

            return dolls;
        }

        static int CountDolls(List<MatryoshkaDoll> dolls)
        {
            return dolls.Count;
        }

        static MatryoshkaDoll FindLargestDoll(List<MatryoshkaDoll> dolls)
        {
            MatryoshkaDoll largestDoll = null;
            foreach (var doll in dolls)
            {
                if (largestDoll == null || doll.Size > largestDoll.Size)
                {
                    largestDoll = doll;
                }
            }
            return largestDoll;
        }

        static void AssignRandomSignature(List<MatryoshkaDoll> dolls, string signature)
        {
            Random random = new Random();
            int index = random.Next(dolls.Count);
            dolls[index].Signature = signature;
        }

        static MatryoshkaDoll FindDollBySignature(List<MatryoshkaDoll> dolls, string signature)
        {
            foreach (var doll in dolls)
            {
                if (doll.Signature == signature)
                {
                    return doll;
                }
            }
            return null;
        }
    }

    class MatryoshkaDoll
    {
        public int Size { get; private set; }
        public MatryoshkaDoll SmallerDoll { get; set; }
        public string Signature { get; set; }

        public MatryoshkaDoll(int size)
        {
            Size = size;
        }
    }
}
