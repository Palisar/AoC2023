using AoCHelper;

namespace AdventOfCode2024;

public class Day02 : BaseDay
{
    private readonly string[] _input;

    public Day02()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => SolveFirstPart(_input);

    public override ValueTask<string> Solve_2() => SolveSecondPart(_input);


    public ValueTask<string> SolveFirstPart(string[] input)
    {
        var safeCount = 0;
        foreach (var row in input)
        {
            var parsed = row.Split(" ").Select(int.Parse);
            if (IsRowSafe(parsed.ToArray()))
                safeCount++;
        }

        return ValueTask.FromResult(safeCount.ToString());
    }

    public ValueTask<string> SolveSecondPart(string[] input)
    {
        var safeCount = 0;
        foreach (var row in input)
        {
            var parsed = row.Split(" ").Select(int.Parse);
            if (IsRowSafeDampened(parsed.ToList()))
                safeCount++;
        }

        return ValueTask.FromResult(safeCount.ToString());
    }

    public bool IsRowSafe(int[] row)
    {
        var increasing = row[0] < row[^1];
        for (var i = 1; i < row.Length - 1; i++)
        {
            switch (increasing)
            {
                case true when row[i - 1] > row[i] || row[i] > row[i + 1]:
                case false when row[i - 1] < row[i] || row[i] < row[i + 1]:
                    return false;
            }

            //difference of 3 or more
            var prediff = Math.Abs(row[i] - row[i - 1]);
            var postdiff = Math.Abs(row[i + 1] - row[i]);

            if (prediff > 3 || postdiff > 3)
                return false;

            //difference of 1
            if (
                prediff < 1 ||
                postdiff < 1)
                return false;
        }

        return true;
    }

    public bool IsRowSafeDampened(List<int> row)
    {
        bool? increasing = IsListIncreasing(row);
        if (increasing == null)
            return false;

        bool dampener = false;
        for (var i = 0; i < row.Count - 1; i++)
        {
            switch (increasing)
            {
                case true when i == 0:
                    if (increasing == true && row[i] > row[i + 1])
                    {
                        if (dampener) return false;
                        row.RemoveAt(i - 1);
                        i = 0;
                        dampener = true;
                    }

                    continue;


                case true when row[i - 1] > row[i]:
                    if (dampener) return false;
                    row.RemoveAt(i - 1);
                    i = 0;
                    dampener = true;
                    continue;

                case true when row[i] > row[i + 1]:
                    if (dampener) return false;
                    row.RemoveAt(i + 1);
                    i = 0;
                    dampener = true;
                    continue;

                case false when row[i - 1] < row[i]:
                    if (dampener) return false;
                    row.RemoveAt(i);
                    i = 0;
                    dampener = true;
                    continue;

                case false when row[i] < row[i + 1]:
                    if (dampener) return false;
                    row.RemoveAt(i + 1);
                    i = 0;
                    dampener = true;
                    continue;
            }

            //difference of 3 or more
            int? prediff = i == 0 ? null : Math.Abs(row[i] - row[i - 1]);
            var postdiff = Math.Abs(row[i + 1] - row[i]);

            if (postdiff > 3)
            {
                if (dampener)
                    return false;

                dampener = true;
                row.RemoveAt(i + 1);
                i = 0;
                continue;
            }

            if (postdiff < 1)
            {
                if (dampener)
                    return false;

                dampener = true;
                row.RemoveAt(i + 1);
                i = 0;
            }

            if(prediff is null) continue;
            
            if (prediff > 3)
            {
                if (dampener)
                    return false;

                dampener = true;
                row.RemoveAt(i);
                i = 0;
                continue;
            }

            if (prediff < 1)
            {
                if (dampener)
                    return false;

                dampener = true;
                row.RemoveAt(i);
                i = 0;
            }
        }

        return true;
    }

    private bool? IsListIncreasing(List<int> row)
    {
        List<int> increasing = new();
        List<int> decreasing = new();

        for (var i = 0; i < row.Count - 1; i++)
        {
            if (row[i] == row[i + 1])
                continue;
            if (row[i] < row[i + 1])
                increasing.Add(row[i]);
            else
                decreasing.Add(row[i]);
        }

        if (increasing.Count == decreasing.Count)
            return null;

        return increasing.Count > decreasing.Count;
    }

    public void CheckYourNeighbours(int index, List<int> row)
    {
    }
}