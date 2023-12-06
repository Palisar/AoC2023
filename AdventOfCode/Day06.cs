namespace AdventOfCode;

public class Day06 : BaseDay
{
    private readonly string[] _input;

    public Day06()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => Part1(_input);

    public override ValueTask<string> Solve_2() => Part2(_input);
/*
Time:      7  15   30
Distance:  9  40  200
 */

    public ValueTask<string> Part1(string[] input)
    {
        HoldTheButton(input);
        return ValueTask.FromResult("");
    }

    public string HoldTheButton(string[] input)
    {
        var times = input[0].Split(":")[1].Trim().Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray();
        var distances = input[1].Split(":")[1].Trim().Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray();
        var index = 0;
        for (int i = 0; i < times.Length; i++)
        {
            var raceTime = times[i];
            var raceDistance = distances[i];
            
            
        }


        return "0";
    }

    public ValueTask<string> Part2(string[] input)
    {
        return ValueTask.FromResult("");
    }
}