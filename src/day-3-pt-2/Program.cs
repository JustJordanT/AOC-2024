// TODO: Need parse out valid mul() instructions   mul(3,4) valid, mul(3,4,5), mul(7 invalid

using System.Text.RegularExpressions;

string filePath = @"input.txt";

using StreamReader sr = new StreamReader(filePath);
string line;
long total = 0;
while ((line = sr.ReadLine()) != null)
{
    Regex regex = new Regex(@"mul\((\d+),(\d+)\)|(do\(\)|don't\(\))");
    MatchCollection matches = regex.Matches(line);

    bool enabled = true;

    foreach (Match match in matches)
    {
        if (match.Value.Contains("do()"))
        {
            enabled = true;
        }
        if (match.Value.Contains("don't()"))
        {
            enabled = false;
        }
        if (enabled && match.Value.Contains("mul("))
        {
            Console.WriteLine($"MATCH: {match.Value}");
            string[] numbers = match.Value.Substring(4, match.Value.Length - 5).Split(',');
            total += (int.Parse(numbers[0]) * int.Parse(numbers[1]));
        }

    }
}

Console.WriteLine($"TOTAL: {total}");
return;
