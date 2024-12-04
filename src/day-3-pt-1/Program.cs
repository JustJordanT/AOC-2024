// TODO: Need parse out valid mul() instructions   mul(3,4) valid, mul(3,4,5), mul(7 invalid

using System.Text.RegularExpressions;

string filePath = @"input.txt";

using StreamReader sr = new StreamReader(filePath);
string line;
int total = 0;
while ((line = sr.ReadLine()) != null)
{
    //int[] row = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    //Console.WriteLine(line);


    var mulInstructions = FoundMul(line);
    //foreach (var instruction in mulInstructions)
    //{
    //    Console.WriteLine($"TOTAL: {total}");

    //}

    if (mulInstructions.Count > 0)
    {
        total += MultiMul(mulInstructions);
    }
    else
    {
        total = 0;
    }

}
Console.WriteLine($"TOTAL: {total}");

return;


List<int> FoundMul(string row)
{
    List<int> digits = new List<int>();
    Regex regex = new Regex(@"mul\(\d+,\d+\)");
    MatchCollection mulMatches = regex.Matches(row);

    foreach (Match match in mulMatches)
    {
        string[] numbers = match.Value.Substring(4, match.Value.Length - 5).Split(',');
        int num1 = int.Parse(numbers[0]);
        int num2 = int.Parse(numbers[1]);

        digits.Add(num1);
        digits.Add(num2);
    }
    return digits;
}


int MultiMul(List<int> numbers)
{
    int position = 0;
    int i = 0;
    while (position < numbers.Count)
    {
        i += numbers[position] * numbers[position + 1];
        //Console.WriteLine($"TOTAL: {total}");
        position += 2;
    }
    return i;
}

