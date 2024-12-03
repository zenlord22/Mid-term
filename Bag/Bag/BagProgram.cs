class Program
{
    static void Main()
    {
        Console.Write("Enter the size of the bag: ");
        if (int.TryParse(Console.ReadLine(), out int size))
        {
            Bag<int> bag = new Bag<int>();

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int element))
                {
                    bag.Add(element);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    i--; // Decrement i to retry this iteration
                }
            }

            while (bag.Size() > 0)
            {
                Console.WriteLine("Size of bag: " + bag.Size());

                Console.Write("Enter the number you want to pull out: ");
                if (int.TryParse(Console.ReadLine(), out int numberToPull))
                {
                    int removedCount = bag.RemoveAll(numberToPull);
                    if (removedCount > 0)
                    {
                        Console.WriteLine($"Number {numberToPull} removed {removedCount} time(s) from the bag.");
                    }
                    else
                    {
                        Console.WriteLine($"Number {numberToPull} not found in the bag.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }

                if (bag.Size() == 0)
                {
                    Console.WriteLine("The bag is now empty.");
                }
                else
                {
                    Console.WriteLine("Updated size of bag: " + bag.Size());
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }
}
