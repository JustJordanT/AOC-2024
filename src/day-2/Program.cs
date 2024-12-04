// See https://aka.ms/new-console-template for more information
string filePath = @"input.txt";
//string[] lines = File.ReadAllLines(path);

List<int[]> data = new List<int[]>();

void Aoc(string filePath)
{
    using (StreamReader sr = new StreamReader(filePath))
    {
        string? line;
        int safereports = 0;
        while ((line = sr.ReadLine()) != null)
        {
            int[] row = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            data.Add(row);

            if (IsSafe(row))
            {
                safereports++;
            }
        }

        Console.WriteLine($"Total safe reports: {safereports}");
    }
}

bool IsSafe(int[] levels)
{
    bool increasing = levels[0] < levels[^1];
    for (int i = 0; i < levels.Length - 1; i++)
    {
        int diff = levels[i + 1] - levels[i];
        Console.WriteLine(diff);
        Console.WriteLine($"Abs: {Math.Abs(diff)}");
        if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3 || (increasing && diff <= 0) || (!increasing && diff >= 0))
        {
            return false;
        }

    }
    return true;
}

Aoc(filePath);