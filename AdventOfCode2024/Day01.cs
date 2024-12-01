using AoCHelper;

namespace AdventOfCode2024;

public class Day01 : BaseDay
{
    private readonly string[] _input;

    public Day01()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => SolveFirstPart(_input);

    public override ValueTask<string> Solve_2() => SolveSecondPart(_input);


    public ValueTask<string> SolveFirstPart(string[] input)
    {
        List<int> left = new();
        List<int> right = new();
        for (var index = 0; index < input.Length; index++)
        {
            var line = input[index];
            var split = line.Split("   ");
            left.Add(int.Parse(split[0]));
            right.Add(int.Parse(split[1]));
        }

        left.Sort();
        right.Sort();
        
        var total = 0;
        
        for (var i = 0; i < left.Count; i++)
        {
            total += Math.Abs(left[i] - right[i]);
        }
        
        return ValueTask.FromResult($"{total}");
    }

    public ValueTask<string> SolveSecondPart(string[] input)
    {
        List<int> left = new();
        List<int> right = new();
        for (var index = 0; index < input.Length; index++)
        {
            var line = input[index];
            var split = line.Split("   ");
            left.Add(int.Parse(split[0]));
            right.Add(int.Parse(split[1]));
        }
        
        var counts = FindCount(right);
        var total = 0;
        
        for (var i = 0; i < left.Count; i++)
        {
            var key = left[i];
            if (counts.ContainsKey(key) && counts[key] > 0)
            {
                //9 + 4 + 0 + 0 + 9 + 9
                var amount =  key * counts[key];
                total += amount;
            }
        }
        
        return ValueTask.FromResult($"{total}");
    }

    private Dictionary<int, int> FindCount(IEnumerable<int> right)
    {
        var dict = new Dictionary<int, int>();
        foreach (var i in right)
        {
            if (dict.ContainsKey(i))
            {
                dict[i]++;
            }
            else
            {
                dict.Add(i , 1);
            }
        }

        return dict;
        
        
        
        
        
    }
}