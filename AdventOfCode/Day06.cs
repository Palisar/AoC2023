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
        var winning = HoldTheButton(input);
        return ValueTask.FromResult($"{winning}");
    }

    public string HoldTheButton(string[] input)
    {
        var times = input[0].Split(":")[1].Trim().Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray();
        var distances = input[1].Split(":")[1].Trim().Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray();
        var wins = 0;
        var winningTotals = new List<int>();

        for (var i = 0; i < times.Length; i++)
        {
            var raceTime = int.Parse(times[i]);
            var raceDistance = int.Parse(distances[i]);

            for (var speed = 0; speed < raceTime; speed++)
            {
                //v * T = d
                var didIMakeIt = 0;
                var timeLeftToMove = raceTime - speed;
                // if distance travel divided by the distance per millisecond
                //var totalDistanceTravelled = speed * timeLeftToMove;

                for (int j = 1; j <= timeLeftToMove; j++)
                {
                    didIMakeIt += speed;
                }

                if (didIMakeIt > raceDistance)
                    wins++;

                //var willIMakeIt = speed - raceTime;
                //if (distanceTravelled >= raceDistance)
            }

            winningTotals.Add(wins);
            wins = 0;
        }

        var marginOfError = 1;
        foreach (var value in winningTotals)
        {
            marginOfError *= value;
        }

// each time I return the count of each race and then at the top I can multiple all the total counts togeteher to get the margin of error 
        return $"{marginOfError}";
    }

    // public int GetSpeed(int timePast)
    // {
    //     
    // }

    public ValueTask<string> Part2(string[] input)
    {
        var winning = HoldTheButtonAgain(input);
        return ValueTask.FromResult($"{winning}");
    }

    public string HoldTheButtonAgain(string[] input)
    {
        var times = input[0].Split(":")[1].Trim().Replace(" ", "");
        var distances = input[1].Split(":")[1].Trim().Replace(" ", "");
        long wins = 0;

        var raceTime = long.Parse(times);
        var raceDistance = long.Parse(distances);

        for (long speed = 0; speed < raceTime; speed++)
        {
            if (speed == 71516)
            {
                //Do nothing
            }
            //v * T = d
            long didIMakeIt = 0;
            long timeLeftToMove = raceTime - speed;
            // if distance travel divided by the distance per millisecond
            //var totalDistanceTravelled = speed * timeLeftToMove;


            didIMakeIt = timeLeftToMove * speed;
            

            if (didIMakeIt > raceDistance)
                wins++;
        }

        return $"{wins}";
    }
}