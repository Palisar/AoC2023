using AoCHelper;

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
      return ValueTask.FromResult("0");
    }


    public ValueTask<string> SolveSecondPart(string[] input)
    {
        return ValueTask.FromResult("0");
    }
}