namespace Day05;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2024 - Day 5\n");
        
        // read and parse input
        
        var lines = File.ReadAllLines("input.txt");

        List<(int,int)> rules = [];
        List<int[]> updates = [];

        var breakLine = false;        
        foreach (var line in lines)
        {
            if (line == "")
                breakLine = true;
            else
                if (!breakLine)                            
                    rules.Add((int.Parse(line.Split("|")[0]), int.Parse(line.Split("|")[1])));            
                else
                    updates.Add(line.Split(",").Select(x => int.Parse(x)).ToArray());
        }

        // part 1
        Console.WriteLine("Part 1\n");

        var result = 0;

        foreach (var update in updates)
        {
            var valid = true;
            //Console.WriteLine($"{string.Join(',', update)}");            
                
            foreach (var rule in rules)            
            {
                // rule applies?
                if (update.Contains(rule.Item1) && update.Contains(rule.Item2))
                {
                    if (Array.IndexOf(update, rule.Item1) > Array.IndexOf(update, rule.Item2))
                    {
                        //Console.Write($" !!! {rule} {Array.IndexOf(update, rule.Item1)} > {Array.IndexOf(update, rule.Item2)}");
                        valid = false;
                    }
                }
            }
            //Console.WriteLine($" -- {valid}");

            if (valid)
            {
                var middle = update[(update.Length - 1) / 2];
                result += middle;
                //Console.Write($"  {middle}");
            }
            //Console.WriteLine($" --> {valid}");
        }
        
        Console.WriteLine($"Result: {result}\n");
        
        // part 2
        Console.WriteLine("Part 2\n");
        
        result = 0;

        foreach (var update in updates)
        {
            var sorted = update.ToList();
            
            var valid = true;
            var fix = false;
            
            do
            {
                valid = true;

                foreach (var rule in rules)
                {
                    if (sorted.Contains(rule.Item1) && sorted.Contains(rule.Item2))
                    {
                        if (sorted.IndexOf(rule.Item1) > sorted.IndexOf(rule.Item2))
                        {
                            valid = false;
                            break;
                        }
                    }
                }

                if (!valid)
                {
                    fix = true;
                    Console.WriteLine($"{string.Join(',', update)} -> ");                    

                    //// reorder
                    foreach (var rule in rules)
                    {
                        if (sorted.Contains(rule.Item1) && sorted.Contains(rule.Item2))
                        {
                            if (sorted.IndexOf(rule.Item1) > sorted.IndexOf(rule.Item2))
                            {
                                Console.WriteLine($" {rule.Item1}|{rule.Item2} -> {sorted.IndexOf(rule.Item1)} > {sorted.IndexOf(rule.Item2)}");
                                sorted.RemoveAt(sorted.IndexOf(rule.Item1));
                                sorted.Insert(sorted.IndexOf(rule.Item2), rule.Item1);
                                Console.WriteLine($"  {string.Join(',', sorted)}");
                            }
                        }
                    }
                }
            
            } while (!valid);

            if (fix)
            {
                var middle = sorted[(sorted.Count - 1) / 2];
                Console.WriteLine($"{string.Join(',', sorted)} -> {middle}\n");
                result += middle;
            }
            
            //Console.WriteLine($" --> {valid}");
        }

        Console.WriteLine($"Result: {result}");
    }
}