using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace AdventOfCode;

public class Day05 : BaseDay
{
    private readonly string[] _input;

    public Day05()
    {
        var data = File.ReadAllText(InputFilePath);
        _input = data.Split("\n\n");
    }

    public override ValueTask<string> Solve_1() => Part1(_input);

    public override ValueTask<string> Solve_2() => Part2(_input);


    public ValueTask<string> Part1(string[] input)
    {
        var seedNumbers = input[0].Split(":")[1].Trim().Split(" ").Select(x => long.Parse(x));
        var tempLocation = new List<long>();

        for (int i = 1; i < input.Length; i++)
        {
            switch (input[i])
            {
                case { } s when s.StartsWith("seed-"):
                    tempLocation = MapRanges(s, seedNumbers);
                    break;
                case { } s when s.StartsWith("soil-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("fertilizer-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("water-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("light-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("temperature-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("humidity-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                default:
                    continue;
            }
        }

        var lowest = tempLocation.Min();
        return ValueTask.FromResult($"{lowest}");
    }

    //seed-to-soil map:
    //50 98 2  -> 98, 99 -> 50 , 51 
    //52 50 48
    List<long> MapRanges(string inputData, IEnumerable<long> seedNumbers)
    {
        //soilLocation, seedNumber
        Dictionary<long, long> newLocations = new();
        var soilMap = inputData.Split("\n");
        long source = 0;
        long destination = 0;
        long range = 0;

        var enumerable = seedNumbers as long[] ?? seedNumbers.ToArray();
        for (var i = 1; i < soilMap.Length; i++)
        {
            var row = soilMap[i].Split(" ");
            source = long.Parse(row[1]);
            destination = long.Parse(row[0]);
            range = long.Parse(row[2]);

            foreach (var seed in enumerable)
            {
                if (seed < source || seed >= source + range) continue;
                var newDest = seed - source + destination;
                newLocations.Add(newDest, seed);
            }
        }

        var leftovers = enumerable.Where(x => !newLocations.Values.Contains(x));

        foreach (var seed in leftovers)
        {
            newLocations.Add(seed, seed);
        }

        return newLocations.Keys.ToList();
    }


    public ValueTask<string> Part2(string[] input)
    {
        var seedNumbers = input[0].Split(":")[1].Trim().Split(" ").Select(x => long.Parse(x)).ToArray();
        //startPoint, seedRange
        Dictionary<long, long> seedRanges = new();
        for (int i = 0; i < seedNumbers.Length; i += 2)
        {
            seedRanges.Add(seedNumbers[i], seedNumbers[i + 1]);
        }

        var smallestStart = seedRanges.Keys.Min();
        var smallestStartRange = seedRanges[smallestStart];

        var tempLocation = new List<long>();
        tempLocation.Add(smallestStart);

        for (int i = 1; i < input.Length; i++)
        {
            switch (input[i])
            {
                case { } s when s.StartsWith("seed-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("soil-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("fertilizer-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("water-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("light-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("temperature-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                case { } s when s.StartsWith("humidity-"):
                    tempLocation = MapRanges(s, tempLocation);
                    break;
                default:
                    continue;
            }
        }

        var lowest = tempLocation.Min();
        return ValueTask.FromResult($"{lowest}");
    }
}