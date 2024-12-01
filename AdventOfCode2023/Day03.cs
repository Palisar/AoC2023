using System.Text;
using System.Text.RegularExpressions;
using Spectre.Console;

namespace AdventOfCode;

public class Day03 : BaseDay
{
    private readonly string[] _input;
    private List<Point> previouslyFound = new();
    public Regex regex = new Regex("[-'!+@;#=$%^&*(),?\\\":{}|\\/<>]");

    public Day03()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => Part1(_input);

    public override ValueTask<string> Solve_2() => Part2(_input);


    public ValueTask<string> Part1(string[] input)
    {
        var total = 0;
        for (int y = 0; y < input.Length; y++)
        {
            var matches = regex.Matches(input[y]);
            switch (matches.Count)
            {
                case <= 0:
                    continue;
                case 1:
                {
                    var startIndex = new Point(matches.First().Index, y);
                    total += FindAdjacentNumbers(startIndex, input);
                    break;
                }
                default:
                {
                    foreach (var match in matches.ToArray())
                    {
                        var startIndex = new Point(match.Index, y);
                        total += FindAdjacentNumbers(startIndex, input);
                    }

                    break;
                }
            }
        }

        return ValueTask.FromResult($"{total}");
    }


    public int FindAdjacentNumbers(Point startIndex, string[] searchArray)
    {
        var total = 0;
        var tempfound = 0;
        bool triggerTop = false;
        bool triggerEnd = false;

        for (int y = startIndex.yPos - 1; y <= startIndex.yPos + 1; y++)
        {
            if (startIndex.yPos == 0 && !triggerTop)
            {
                y++;
                triggerTop = true;
            }

            if (startIndex.yPos == searchArray.Length && !triggerEnd)
            {
                y--;
                triggerEnd = true;
            }

            for (int x = startIndex.xPos - 1; x <= startIndex.xPos + 1; x++)
            {
                if (x == searchArray[y].Length) break;
                if (startIndex.xPos == 0)
                    x++;
                if (startIndex.xPos == searchArray[y].Length)
                    x--;
                if (int.TryParse($"{searchArray[y][x]}", out var result))
                {
                    result = ExtractNumber(searchArray[y], x, y);
                    if (tempfound == 0)
                        tempfound = result;
                    else if (tempfound == result && searchArray[y][x - 1] != '.' &&
                             !regex.Match($"{searchArray[y][x - 1]}").Success)
                        break;

                    total += result;
                }
            }

            tempfound = 0;
        }

        return total;
    }

    public int ExtractNumber(string row, int foundIndex, int rowIndex)
    {
        var entryPoint = new Point(foundIndex, rowIndex);
        if (!previouslyFound.Any(x => x.xPos == entryPoint.xPos && x.yPos == entryPoint.yPos))
            previouslyFound.Add(new Point(foundIndex, rowIndex));
        else
            return 0;

        StringBuilder output = new();
        output.Append(row[foundIndex]);

        var startPoint = foundIndex--;
        while (foundIndex >= 0)
        {
            if (row[foundIndex] == '.' || regex.Match($"{row[foundIndex]}").Success)
                break;

            previouslyFound.Add(new Point(foundIndex, rowIndex));
            output.Insert(0, row[foundIndex]);
            foundIndex--;
        }

        foundIndex = startPoint;
        foundIndex++;

        while (foundIndex < row.Length)
        {
            if (row[foundIndex] == '.' || regex.Match($"{row[foundIndex]}").Success)
                break;

            previouslyFound.Add(new Point(foundIndex, rowIndex));
            output.Append(row[foundIndex]);
            foundIndex++;
        }

        return int.Parse(output.ToString());
    }

    public ValueTask<string> Part2(string[] input)
    {
        previouslyFound = new();
        var total = 0;

        var gearRegex = new Regex("[*]");
        for (int y = 0; y < input.Length; y++)
        {
            if (!input[y].Contains('*')) continue;

            var matches = gearRegex.Matches(input[y]);
            switch (matches.Count)
            {
                case 1:
                {
                    var startIndex = new Point(matches.First().Index, y);
                    total += FindExactly2AdjacentFromGear(startIndex, input);
                    break;
                }
                default:
                {
                    foreach (var match in matches.ToArray())
                    {
                        var startIndex = new Point(match.Index, y);
                        total += FindExactly2AdjacentFromGear(startIndex, input);
                    }

                    break;
                }
            }
        }

        return ValueTask.FromResult($"{total}");
    }

    public int FindExactly2AdjacentFromGear(Point startIndex, string[] searchArray)
    {
        
        var tempfound = 0;
        bool triggerTop = false;
        bool triggerEnd = false;
        List<int> extractedNumbers = new();

        for (int y = startIndex.yPos - 1; y <= startIndex.yPos + 1; y++)
        {
            if (startIndex.yPos == 0 && !triggerTop)
            {
                y++;
                triggerTop = true;
            }

            if (startIndex.yPos == searchArray.Length && !triggerEnd)
            {
                y--;
                triggerEnd = true;
            }

            for (int x = startIndex.xPos - 1; x <= startIndex.xPos + 1; x++)
            {
                if (x == searchArray[y].Length) break;
                if (startIndex.xPos == 0)
                    x++;
                if (startIndex.xPos == searchArray[y].Length)
                    x--;
                if (int.TryParse($"{searchArray[y][x]}", out var result))
                {
                    result = ExtractNumber(searchArray[y], x, y);
                    if (tempfound == 0)
                        tempfound = result;
                    else if (tempfound == result && searchArray[y][x - 1] != '.' &&
                             !regex.Match($"{searchArray[y][x - 1]}").Success)
                        break;

                    if (result != 0)
                        extractedNumbers.Add(result);
                }
            }

            tempfound = 0;
        }

        if (extractedNumbers.Count == 2)
            return extractedNumbers[0] * extractedNumbers[1];

        return 0;
    }
}

public record struct Point(int xPos, int yPos);