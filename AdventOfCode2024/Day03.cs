using System.Text.RegularExpressions;
using AoCHelper;

namespace AdventOfCode2024;

public class Day03 : BaseDay
{
    private readonly string _input;

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => SolveFirstPart(_input);

    public override ValueTask<string> Solve_2() => SolveSecondPart(_input);

    public ValueTask<string> SolveFirstPart(string input)
    {
        var regex = new Regex(@"mul\((\d+),(\d+)\)");
        var total = 0;
        //match all occurences of mul(a,b)
        var matches = regex.Matches(input);
        foreach (Match match in matches)
        {
            total += DoMul(match.Value);
        }

        return ValueTask.FromResult($"{total}");
    }

    public ValueTask<string> SolveSecondPart(string input)
    {
        var total = 0;
        var mulRegex = new Regex(@"mul\((\d+),(\d+)\)");
        var doRegex = new Regex(@"do\(\)");
        //regex to match don't(a,b)
        var dontRegex = new Regex(@"don't\(\)");

        var mulMatches = mulRegex.EnumerateMatches(input, 0);
        var doMatches = doRegex.EnumerateMatches(input, 0);
        var dontMatches = dontRegex.EnumerateMatches(input, 0);

        dontMatches.MoveNext();
        var currentDo = doMatches.Current;
        var currentDont = dontMatches.Current;

        foreach (var match in mulMatches)
        {
            var mulIndex = match.Index;
            
            if (currentDo.Index < mulIndex && currentDont.Index > mulIndex)
            {
                var inputString = input.Substring(match.Index, match.Length);
                total += DoMul(inputString);
            }
            else
            {
                if(currentDo.Index == 0)
                {
                    doMatches.MoveNext();
                    currentDo = doMatches.Current;
                }
                if (mulIndex > currentDont.Index && mulIndex < currentDo.Index)
                {
                    doMatches.MoveNext();
                    currentDo = doMatches.Current;
                    continue;
                }
                if(mulIndex > currentDo.Index)
                {
                    dontMatches.MoveNext();
                    currentDont = dontMatches.Current;
                }
            }
        }

        return ValueTask.FromResult($"{total}");
    }

    private int DoMul(string input)
    {
        var regex = new Regex(@"mul\((\d+),(\d+)\)");
        var matches = regex.Matches(input).First();
        var a = int.Parse(matches.Groups[1].Value);
        var b = int.Parse(matches.Groups[2].Value);

        return a * b;
    }
    
    private bool IsActive(Match match, Match currentDo, Match currentDont)
    {
        var mulIndex = match.Index;
        return currentDo.Index < mulIndex && currentDont.Index > mulIndex;
    }
    
}