// See https://aka.ms/new-console-template for more information
string filePath = @"input.txt";
//string[] lines = File.ReadAllLines(path);

List<int[]> data = new List<int[]>();

void Aoc(string filePath)
{
    using StreamReader sr = new StreamReader(filePath);
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
        else
        {
            for (int i = 0; i < row.Length; i++)
            {
                var levelsCopy = row.ToList();
                levelsCopy.RemoveAt(i);
                if (IsSafeReport(levelsCopy.ToArray()))
                {
                    safereports++;
                    break;
                }
            }
        }

    }
    Console.WriteLine($"Total safe reports: {safereports}");
}

bool IsSafeReport(int[] levels)
{
    bool isIncreasing = true;
    bool isDecreasing = true;

    for (int i = 1; i < levels.Length; i++)
    {
        int diff = levels[i] - levels[i - 1];

        // Check if the difference is outside the safe range
        if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
        {
            return false;
        }

        // Update increasing/decreasing flags
        if (diff > 0)
        {
            isDecreasing = false;
        }
        else if (diff < 0)
        {
            isIncreasing = false;
        }
    }

    // Allow either completely consistent or with one small inconsistency
    return isIncreasing || isDecreasing;
}

Aoc(filePath);