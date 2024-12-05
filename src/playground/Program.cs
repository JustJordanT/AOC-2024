using System.Text.RegularExpressions;

string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

List<int> FoundMul(string row)
{
    List<int> digits = new List<int>();
    Regex regex = new Regex(@"mul\(\d+,\d+\)");
    MatchCollection mulMatches = regex.Matches(row);
    Regex doRegex = new(@"do\(\)");
    Regex dontRegex = new(@"don\'t\(\)");
    MatchCollection doMatch = doRegex.Matches(row);
    MatchCollection dontMatch = dontRegex.Matches(row);
    List<int> doMatchIndex = doMatch.Select(x => x.Index).ToList();
    List<int> dontMatchIndex = dontMatch.Select(x => x.Index).ToList();
    int[] mergeMatchIndcies = doMatchIndex.Concat(dontMatchIndex).OrderBy(x => x).ToArray();
    bool isEnabled = true; // mul instructions are enabled at the beginning
    var nextIndex = 0;

    foreach (Match match in mulMatches)
    {
        var matchIndex = match.Index;
        while (nextIndex < mergeMatchIndcies.Length && matchIndex > mergeMatchIndcies[nextIndex])
        {
            bool isDo = doMatchIndex.Contains(mergeMatchIndcies[nextIndex]);
            isEnabled = isDo;
            nextIndex++;
        }
        if (isEnabled)
        {
            string[] numbers = match.Value.Substring(4, match.Value.Length - 5).Split(',');
            int num1 = int.Parse(numbers[0]);
            int num2 = int.Parse(numbers[1]);
            digits.Add(num1);
            digits.Add(num2);
        }
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
        position += 2;
    }
    return i;
}

var mulInstructions = FoundMul(input);
int total = MultiMul(mulInstructions);

Console.WriteLine($"TOTAL: {total}");
