using System.Collections;

namespace Day02;

static class Program
{
    static void Main()
    {
        Console.WriteLine("Advent of Code 2024 - Day 2");
        
        // read and parse input
        
        var lines = File.ReadAllLines("input.txt");

        var reports = new List<int[]>();
        foreach (var line in lines)
        {
            var report = line.Split(' ').Select(s => int.Parse(s)).ToArray();
            reports.Add(report);
        }
        
        // part 1
        Console.WriteLine("Part 1");

        var result = reports.Count(IsSafe);
        Console.WriteLine($"Result: {result}");

        // part 2
        Console.WriteLine("Part 2");
        
        result = 0;
        foreach (var report in reports)
        {
            // Console.WriteLine(string.Join(' ', report));
            
            if (!IsSafe(report))
            {
                for (var i = 0; i < report.Length; i++)
                {
                    var r1 = report.ToList();
                    r1.RemoveAt(i);
                    // Console.Write("  " + string.Join(' ', r1));
                    // Console.WriteLine($" safe = {IsSafe(r1.ToArray())}");
                    if (IsSafe(r1.ToArray()))
                    {
                        result++;
                        break;
                    }
                }
            }
            else
            {
                result++;
            }
        }
        Console.WriteLine($"Result: {result}");
    }

    private static bool IsSafe(int[] report)
    {
        // Console.Write(string.Join(' ', report));
        
        var d  = report[1] - report[0];
        var s = d < 0 ? -1 : 1;
            
        var safe = true;
        for (var i = 1; i < report.Length; i++)
        {
            var diff = Math.Abs(report[i] - report[i - 1]);
            var sign = report[i] - report[i - 1] < 0 ? -1 : 1;
            safe &= diff >= 1 & diff <= 3 & sign == s;
        }
        
        // Console.WriteLine($" safe = {safe}");
        return safe;
    }
}