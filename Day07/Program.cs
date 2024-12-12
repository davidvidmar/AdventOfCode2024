
using System.Globalization;

namespace Day07;

class Program
{
    

    static void Main()
    {
        Console.WriteLine("Advent of Code 2024 - Day 7");
        
        // read and parse input
        
        var lines = File.ReadAllLines("input.txt");

        List<long> results = [];
        List<List<long>> nums = [];
        
        foreach (var line in lines)
        {
            results.Add(long.Parse(line.Split(": ")[0]));
            nums.Add(line.Split(": ")[1].Split(' ').Select(x => long.Parse(x)).ToList());
        }        

        // part 1
        Console.WriteLine("Part 1");

        long result = 0;
        for (int i = 0; i < results.Count; i++)
        {
            //Console.WriteLine(lines[i]);
            if (TryOperations(results[i], nums[i], nums[i][0]))
            {
                //Console.WriteLine("  true");
                result += results[i];
            }
        }
        Console.WriteLine($"Result: {result}");
        
        // part 2
        Console.WriteLine("Part 2");
        result = 0;

        for (int i = 0; i < results.Count; i++)
        {
            //Console.WriteLine(lines[i]);
            if (TryOperations2(results[i], nums[i], nums[i][0]))
            {
                //Console.WriteLine("*true");
                result += results[i];
            }
        }

        Console.WriteLine($"Result: {result}");
    }

    private static bool TryOperations(long result, List<long> nums, long midResult, int i = 1)
    {        
        if (i == nums.Count - 1)
        {
            //Console.WriteLine($" {midResult}+{nums[i]} ");
            if (midResult + nums[i] == result)
            {
                
                return true;
            }
            //Console.WriteLine($" {midResult}*{nums[i]} ");
            if (midResult * nums[i] == result)
            {                
                return true;
            }
        } else {
            //Console.WriteLine($" {midResult}+{nums[i]} ");
            if (TryOperations(result, nums, midResult + nums[i], i + 1))
            {                
                return true;
            }
            //Console.WriteLine($" {midResult}*{nums[i]} ");
            if (TryOperations(result, nums, midResult * nums[i], i + 1))
            {                
                return true;
            }
        }        
        return false;
    }

    private static bool TryOperations2(long result, List<long> nums, long midResult, int i = 1)
    {
        if (i == nums.Count - 1)
        {
            //Console.WriteLine($" {midResult}+{nums[i]} ");
            if (midResult + nums[i] == result)
            {
                return true;
            }
            //Console.WriteLine($" {midResult}*{nums[i]} ");
            if (midResult * nums[i] == result)
            {
                return true;
            }
            //Console.WriteLine($" {midResult}{nums[i]} ");
            if (long.Parse(midResult.ToString() + nums[i].ToString()) == result)
            {
                return true;
            }
        }
        else
        {
            //Console.WriteLine($" {midResult}+{nums[i]} ");
            if (TryOperations2(result, nums, midResult + nums[i], i + 1))
            {
                return true;
            }
            //Console.WriteLine($" {midResult}*{nums[i]} ");
            if (TryOperations2(result, nums, midResult * nums[i], i + 1))
            {
                return true;
            }
            //Console.WriteLine($" {midResult}{nums[i]} ");            
            if (TryOperations2(result, nums, long.Parse(midResult.ToString() + nums[i].ToString()), i + 1))
            { 
                return true;
            }
        }
        return false;
    }
}