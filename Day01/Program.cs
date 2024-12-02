namespace Day01;

static class Program
{
    static void Main()
    {
        Console.WriteLine("Advent of Code 2024 - Day 1");
        
        // read and parse input
        
        var lines = File.ReadAllLines("input.txt");
        var first = lines.Select(line => Convert.ToInt32(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0])).OrderBy(x => x).ToArray();
        var second = lines.Select(line => Convert.ToInt32(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1])).OrderBy(x => x).ToArray();

        // part 1
        
        var result = first.Select((t, i) => Math.Abs(t - second[i])).Sum();
        Console.WriteLine($"Result - part 1: {result}");
        
        // part 2

        result = first.Sum(t => second.Count(x => x == t) * t);
        Console.WriteLine($"Result - part 2: {result}");
    }
}