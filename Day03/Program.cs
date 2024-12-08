using System.Text.RegularExpressions;

namespace Day03;

class Program
{
    static void Main()
    {
        // https://adventofcode.com/2024/day/3
        Console.WriteLine("Advent of Code 2024 - Day 3");
        
        // read and parse input
        
        var input = File.ReadAllText("input.txt");
        
        // part 1
        Console.WriteLine("Part 1");

        var result = 0;

        string pattern = @"(?:mul\((\d+),(\d+)\)|do\(\)|don't\(\))";
        var matches = Regex.Matches(input, pattern);

        var doMul = true; 

        Console.WriteLine($"Found {matches.Count} matches:");
        foreach (Match match in matches)
        {
            if (match.Value == @"do()")
                doMul = true;
            else
                if (match.Value == @"don't()") doMul = false;
            else
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                // Console.WriteLine($"X={x}, Y={y}");
                if (doMul) result += x * y;
            }
        }        
        
        Console.WriteLine($"Result: {result}");
        
        // part 2
        Console.WriteLine("Part 2");
        result = 0;
        
        Console.WriteLine($"Result: {result}");
    }
}