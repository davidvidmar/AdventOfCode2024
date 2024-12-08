namespace DayX;

class Program
{
    static void Main()
    {
        Console.WriteLine("Advent of Code 2024 - Day X");
        
        // read and parse input
        
        var lines = File.ReadAllLines("input.txt");
        
        // part 1
        Console.WriteLine("Part 1");

        var result = 0;
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine($"Result: {result}");
        
        // part 2
        Console.WriteLine("Part 2");
        result = 0;
        
        Console.WriteLine($"Result: {result}");
    }
}