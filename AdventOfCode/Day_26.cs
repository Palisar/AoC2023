namespace AdventOfCode;

public class Day_26 : BaseDay
{
    private readonly string[] _input;

    public Day_26()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => Part1(_input);

    public override ValueTask<string> Solve_2() => Part2(_input);


    public ValueTask<string> Part1(string[] input)
    {
        return ValueTask.FromResult("");
    }
    
    public ValueTask<string> Part2(string[] input)
    {
        return ValueTask.FromResult("");
    }
}