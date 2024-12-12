using System.Runtime.InteropServices;

namespace Day06;

class Program
{
    static void Main()
    {
        Console.WriteLine("Advent of Code 2024 - Day X");
        
        // read and parse input
        
        var lines = File.ReadAllLines("input.txt");
        
        // part 1
        Console.WriteLine("Part 1");

        var x = 0;
        var y = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            string? line = lines[i];
            if (line.Contains('^'))
            {
                x = line.IndexOf('^');
                y = i;
                break;
            }
        }
        Console.WriteLine($"X = {x}, Y = {y}");

        var arrow = lines[y][x];
        var end = false;
        var result = 1;

        while (!end)
        {
            //Print(lines, x, y, arrow);
            
            var moveX = 0;
            var moveY = 0;

            switch (arrow)
            {
                case '<': { moveX = -1; moveY =  0; break; }
                case '>': { moveX =  1; moveY =  0; break; }
                case 'v': { moveX =  0; moveY = +1; break; }
                case '^': { moveX =  0; moveY = -1; break; }
                default: throw new Exception("strange arrow moving!");
            }

            if ((y + moveY < 0) || (x + moveX < 0) ||
                (y + moveY > lines.Length - 1) || (x + moveX > lines[0].Length - 1))
            {
                end = true;
            }
            else if (lines[y + moveY][x + moveX] == '#')
            {
                if (arrow == '^') arrow = '>';
                else if (arrow == '>') arrow = 'v';
                else if (arrow == 'v') arrow = '<';
                else if (arrow == '<') arrow = '^';
                else throw new Exception("strange arrow rotating!");
            }
            //else if (lines[y + moveY][x + moveX] == 'X') {
            //    end = true;
            //}
            else
            {
                if (lines[y][x] != 'X') {
                    lines[y] = lines[y].Insert(x, "X").Remove(x + 1, 1);
                    result++;
                }
                x += moveX;
                y += moveY;
            }
        }        
        Console.WriteLine($"Result: {result}");
        
        // part 2
        Console.WriteLine("Part 2");
        result = 0;
        
        Console.WriteLine($"Result: {result}");
    }

    private static void Print(string[] lines, int arrowX, int arrowY, char arrow)
    {
        (int x, int y) = Console.GetCursorPosition();
        lines.ToList().ForEach(Console.WriteLine);
        Console.SetCursorPosition(x + arrowX, y + arrowY);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(arrow);
        Console.ResetColor();
        Console.SetCursorPosition(x, y);
    }
}