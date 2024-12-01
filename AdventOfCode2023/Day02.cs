namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string[] _input;

    public Day02()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => Part1(_input);

    public override ValueTask<string> Solve_2() => Part2(_input);

    public ValueTask<string> Part1(string[] input)
    {
        Dictionary<string, int> MaxAllowed = new()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 },
        };

        var total = 0;
        
        foreach (var line in input)
        {
            var over = false;
            var masterGame = line.Split(":");
            var gameNumber = int.Parse(masterGame[0].Split(" ")[1]);

            var miniGames = masterGame[1].Split(";");
            foreach (var round in miniGames)
            {
                var cubes = round.Split(",");
                foreach (var handful in cubes)
                {
                    var color = handful.Trim().Split(" ")[1].ToLower();
                    var amount = int.Parse(handful.Trim().Split(" ")[0].ToLower());

                    if (amount > MaxAllowed[color])
                        over = true;
                }
            }

            if (!over) total += gameNumber;
            
        }

        return ValueTask.FromResult($"{total}");
    }
    
    public ValueTask<string> Part2(string[] input)
    {
        var total = 0;
        
        foreach (var line in input)
        {
            Dictionary<string, int> minimumNeeded = new();
            var masterGame = line.Split(":");

            var miniGames = masterGame[1].Split(";");
            foreach (var round in miniGames)
            {
                var cubes = round.Split(",");
                foreach (var handful in cubes)
                {
                    var color = handful.Trim().Split(" ")[1].ToLower();
                    var amount = int.Parse(handful.Trim().Split(" ")[0].ToLower());

                    if (minimumNeeded.ContainsKey(color))
                    {
                        if(minimumNeeded[color] < amount)
                            minimumNeeded[color] = amount;
                    }
                    else
                    {
                        minimumNeeded.Add(color, amount);
                    }
                }
            }

            var temp = minimumNeeded.Values.Aggregate(1, (current, value) => current * value);

            total += temp;

        }

        return ValueTask.FromResult($"{total}");
    }
}