using System.Runtime.CompilerServices;
using AdventOfCode.Helpers;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string[] _input;
    private readonly string[] _inputLines;

    public Day01()
    {
        _input = File.ReadAllLines(InputFilePath);
        _inputLines = _input;
    }

    public override ValueTask<string> Solve_1() => SolveFirstPart(_inputLines);

    public override ValueTask<string> Solve_2() => SolveSecondPart(_inputLines);


    public ValueTask<string> SolveFirstPart(string[] input)
    {
        var total = 0;
        var first = "";
        var last = "";
        foreach (var line in input)
        {
            foreach (var value in line)
            {
                if (int.TryParse($"{value}", out int found))
                {
                    first = $"{found}";
                    break;
                }
            }

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (int.TryParse($"{line[i]}", out int found))
                {
                    last = $"{found}";
                    break;
                }
            }

            total += int.Parse($"{first}{last}");
            last = "";
            first = "";
        }

        return ValueTask.FromResult($"{total}");
    }


    public ValueTask<string> SolveSecondPart(string[] input)
    {
        var valid = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        Dictionary<int, string> indexes = new();

        var total = 0;
        var first = "";
        var last = "";
        bool wasAdded = false;
        foreach (var inputLine in input)
        {
            var line = inputLine.ToLower();
            
            
            foreach (var value in valid.Keys)
            {
                if (line.Contains(value))
                {
                    var allOccurrences = line.AllIndexesOf(value);
                    if (allOccurrences.Count() <= 1)
                    {
                        var index = line.IndexOf(value);
                        var dictValue = $"{valid[value]}";
                        indexes.Add(index, dictValue);
                    }
                    else
                    {
                        var minIndex = allOccurrences.Min();
                        var maxIndex = allOccurrences.Max();
                        var dictValue = $"{valid[value]}";


                        if (!indexes.Any() || minIndex < indexes.Keys.Min())
                        {
                            if (indexes.Count() > 1)
                                indexes.Remove(indexes.Keys.Min());

                            indexes.Add(minIndex, dictValue);
                            wasAdded = true;
                        }

                        if (!indexes.Any() || maxIndex > indexes.Keys.Max())
                        {
                            if (indexes.Any() && !wasAdded && indexes.Count() > 1)
                                indexes.Remove(indexes.Keys.Max());
                            indexes.Add(maxIndex, dictValue);
                        }

                        wasAdded = false;
                    }
                }
            }
            
            for (var i = 0; i < line.Length; i++)
            {
                if (int.TryParse($"{line[i]}", out var found))
                {
                    indexes.Add(i, $"{found}");
                }
            }

            first = indexes.OrderBy(x => x.Key).First().Value;
            last = indexes.OrderBy(x => x.Key).Last().Value;
            Console.WriteLine($"{line}  : {first}{last}");
            total += int.Parse($"{first}{last}");
            indexes = new();
        }

        return ValueTask.FromResult($"{total}");
    }
}