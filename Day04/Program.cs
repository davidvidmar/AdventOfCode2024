
using System.ComponentModel.DataAnnotations;

namespace Day04;

class Program
{
    static void Main()
    {
        Console.WriteLine("Advent of Code 2024 - Day 4");

        // read and parse input

        var lines = File.ReadAllLines("input.txt");

        // part 1
        Console.WriteLine("Part 1");

        var result = 0;
        foreach (var line in lines)
        {
            result += FindAllOccurences(line, "XMAS");
            result += FindAllOccurences(line, "SAMX");
        }

        var linesT = TransposeLines(lines);
        foreach (var line in linesT)
        {
            result += FindAllOccurences(line, "XMAS");
            result += FindAllOccurences(line, "SAMX");
        }

        result += FindDiagonalLROccurences(lines, "XMAS");
        result += FindDiagonalLROccurences(lines, "SAMX");

        result += FindDiagonalRLOccurences(lines, "XMAS");
        result += FindDiagonalRLOccurences(lines, "SAMX");

        //FindDiagonalOccurences(lines, "XMAS");
        //FindDiagonalOccurences(lines, "SAXS");

        Console.WriteLine($"Result: {result}");

        // part 2
        Console.WriteLine("Part 2");

        result = FindCross(lines, "MAS");
        result += FindCross(lines, "SAM");

        Console.WriteLine($"Result: {result}");
    }

    // Part 1

    
    private static int FindAllOccurences(string valueString, string searchString)
    {
        var occurences = 0;
        for (int i = 0; i < valueString.Length; i++)
        {
            if (valueString[i..].StartsWith(searchString)) occurences++;
        }
        //Console.WriteLine($"{valueString} {searchString} -> {occurences}");
        return occurences;
    }

    private static IEnumerable<string> TransposeLines(string[] lines)
    {
        var linesT = new List<string>();

        for (int i = 0; i < lines[0].Length; i++)
        {
            linesT.Add("");
        }

        for (int i = 0; i < lines[0].Length; i++)
        {
            for (int j = 0; j < lines.Length; j++)
                linesT[i] += lines[j][i];
        }

        return linesT;
    }

    private static int FindDiagonalLROccurences(string[] valueGrid, string searchString)
    {
        var occurences = 0;

        //Console.WriteLine("\n" + searchString + "\n");

        for (int y = 0; y < valueGrid.Length; y++)
        {            
            for (int x = 0; x < valueGrid[0].Length; x++)
            {                
                var found = true;                
                for (int i = 0; i < searchString.Length; i++)
                {                    
                    var c = searchString[i];

                    found &= (valueGrid.Length > y + i) &&
                             (valueGrid[0].Length > x + i);

                    if (!found) break;

                    found &= (valueGrid[y + i][x + i] == c);

                    //Console.Write($"{x + i}, {y + i} -> {valueGrid[y + i][x + i]} == {c};");
                    
                }
                if (found)
                {
                    occurences++;
                    //Console.Write(" BINGO! ");
                }
                //Console.WriteLine();
            }
        }

        return occurences;
    }

    private static int FindDiagonalRLOccurences(string[] valueGrid, string searchString)
    {
        var occurences = 0;

        //Console.WriteLine("\n" + searchString + "\n");

        for (int y = 0; y < valueGrid.Length; y++)
        {
            for (int x = valueGrid[0].Length - 1; x >= 0; x--)
            {
                var found = true;
                for (int i = 0; i < searchString.Length; i++)
                {
                    var c = searchString[i];

                    found &= (valueGrid.Length > y + i) &&
                             (x - i >= 0);

                    if (!found) break;

                    found &= (valueGrid[y + i][x - i] == c);

                    //Console.Write($"{x - i}, {y + i} -> {valueGrid[y + i][x - i]} == {c};");

                }
                if (found)
                {
                    occurences++;
                    //Console.Write(" BINGO! ");
                }
                //Console.WriteLine();
            }
        }

        return occurences;
    }

    // Part 2
    private static int FindCross(string[] valueGrid, string searchString)
    {
        var occurences = 0;

        var char0 = searchString[0];
        var charMid = searchString[1];
        var charL = searchString[2];

        Console.WriteLine("Mid char: " + charMid);

        for (int y = 1; y < valueGrid.Length - 1; y++)
        {
            //Console.WriteLine(valueGrid[y]);
            
            for (int x = 1; x < valueGrid[0].Length - 1; x++)            
            {
                if (valueGrid[y][x] == charMid)
                {
                    if ((valueGrid[y - 1][x - 1] == char0) & (valueGrid[y + 1][x + 1] == charL))
                    {
                        if ((valueGrid[y - 1][x + 1] == char0) & (valueGrid[y + 1][x - 1] == charL))
                        {
                            //Console.WriteLine($"{x},{y}");
                            occurences++;
                        }
                        if ((valueGrid[y + 1][x - 1] == char0) & (valueGrid[y - 1][x + 1] == charL))
                        {
                            //Console.WriteLine($"{x},{y}");
                            occurences++;
                        }
                    }
                                        
                }                
                //Console.WriteLine();
            }
        }

        return occurences;
    }

}