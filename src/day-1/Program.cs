// day 1 aoc 2024

const string path = @"input.txt";
string[] lines = File.ReadAllLines(path);
List<int> lSide = [];
List<int> rSide = [];

Dictionary<int, int> foundCount = new Dictionary<int, int>();
foreach (string line in lines)
{
    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    int l = int.Parse(parts[0]);
    int r = int.Parse(parts[1]);
    lSide.Add(l);
    rSide.Add(r);
    if (foundCount.ContainsKey(r))
    {
        foundCount[r]++;
    }
    else
    {
        foundCount[r] = 1;
    }

}

lSide.Sort();
rSide.Sort();

int result = 0;
for (int i = 0; i < lSide.Count; i++)
{
    result += Math.Abs(lSide[i] - rSide[i]);
}

Console.WriteLine($"result: {result}");

int total = 0;
for (int i = 0; i < lSide.Count; i++)
{
    if (foundCount.ContainsKey(lSide[i]))
    {
        total += lSide[i] * foundCount[lSide[i]];
    }
}

Console.WriteLine($"total: {total}");