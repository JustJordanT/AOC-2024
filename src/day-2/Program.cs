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

            if (IsSafeReport(row))
            {
                safereports++;
            }
        }

        Console.WriteLine($"Total safe reports: {safereports}");
    }
}

bool IsSafeReport(int[] levels)
{
    bool isIncreasing = true;
    bool isDecreasing = true;


    for (int i = 1; i < levels.Length; i++)
    {
        int diff = levels[i] - levels[i - 1];
        if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
        {
            return false;
        }

        if (diff > 0)
        {
            isDecreasing = false;
        }
        else if (diff < 0)
        {
            isIncreasing = false;
        }

    }
    return isIncreasing || isDecreasing;
}

Aoc(filePath);