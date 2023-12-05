using System.Net.Http.Headers;

namespace AdventOfCode;

public class Day04 : BaseDay
{
    private readonly string[] _input;
    private int gamesProcessed = 0;
    
    public Day04()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => Part1(_input);

    public override ValueTask<string> Solve_2() => Part2(_input);


    public ValueTask<string> Part1(string[] input)
    {
        var winningScore = 0;

        foreach (var game in input)
        {
            var splitLine = game.Split(":");
            var gameNumber = splitLine[0];
            var scoreCard = splitLine[1].Split("|");
            var winningNumbers = (from number in scoreCard[0].Split(" ")
                where !string.IsNullOrWhiteSpace(number)
                select int.Parse(number.Trim())).ToList();
            var preSplit = scoreCard[1].Trim().Split(" ");
            var yourNumberSheet = (from number in preSplit
                where !string.IsNullOrWhiteSpace(number)
                select int.Parse(number.Trim())).ToList();


            winningScore += TotalWinningNumbers(winningNumbers, yourNumberSheet);
        }

        return ValueTask.FromResult($"{winningScore}");
    }

    public int TotalWinningNumbers(IEnumerable<int> winningNumbers, IEnumerable<int> yourNumbers)
    {
        var score = 0;
        var isFirstFound = false;

        foreach (var number in winningNumbers)
        {
            //if (string.IsNullOrWhiteSpace(number))continue;
            if (yourNumbers.Contains(number))
            {
                score = isFirstFound ? score * 2 : 1;
                isFirstFound = true;
            }
        }

        return score;
    }


    public ValueTask<string> Part2(string[] input)
    {
        List<GameCard> WonCards = new();
        for (var index = 0; index < input.Length; index++)
        {
            var game = CreateGame(input[index]);
            var cardsWon = ProcessGame(game.First(), game.Last());
            if(cardsWon > 0)
                ProcessWinners(AddWinningCards(index, cardsWon, input), input);
        }
        
        return ValueTask.FromResult($"{gamesProcessed}");
    }

    public IEnumerable<IEnumerable<int>> CreateGame(string game)
    {
        List<IEnumerable<int>> Games = new();
        
        var splitLine = game.Split(":");
        var scoreCard = splitLine[1].Split("|");
        var winningNumbers = (from number in scoreCard[0].Split(" ")
            where !string.IsNullOrWhiteSpace(number)
            select int.Parse(number.Trim())).ToList();
        var preSplit = scoreCard[1].Trim().Split(" ");
        var yourNumberSheet = (from number in preSplit
            where !string.IsNullOrWhiteSpace(number)
            select int.Parse(number.Trim())).ToList();
        
        Games.Add(winningNumbers);
        Games.Add(yourNumberSheet);

        return Games;
    }
    public int ProcessGame(IEnumerable<int> winningNumbers, IEnumerable<int> yourNumbers)
    {
        gamesProcessed++;
        return winningNumbers.Count(number => yourNumbers.Contains(number));
    }

    public void ProcessWinners(List<GameCard> winners, string[] input)
    {
        List<GameCard> WonCards = new();
        if (winners.Count < 1) 
            return;

        for (int i = 0; i < winners.Count; i++)
        {
            var game = CreateGame(winners[i].Game);
            var cardsWon = ProcessGame(game.First(), game.Last());
            if(cardsWon > 0)
                ProcessWinners(AddWinningCards(winners[i].GameNumber -1, cardsWon, input), input);
            
        }
    }

    public List<GameCard> AddWinningCards(int currentIndex, int amountToAdd, string[] inputArray)
    {
        List<GameCard> Cards = new();
        for (int i = 1; i <= amountToAdd; i++)
        {
            Cards.Add(new GameCard(currentIndex + 1 + i, inputArray[currentIndex + i]));
        }

        return Cards;
    }
}

public record GameCard(int GameNumber, string Game);