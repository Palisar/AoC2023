using System.Collections;
using System.Security.AccessControl;

namespace AdventOfCode;

public class Day07 : BaseDay
{
    private readonly string[] _input;

    private readonly Dictionary<char, int> Cards = new()
    {
        { '2', 0 },
        { '3', 1 },
        { '4', 2 },
        { '5', 3 },
        { '6', 4 },
        { '7', 5 },
        { '8', 6 },
        { '9', 7 },
        { 'T', 8 },
        { 'J', 9 },
        { 'Q', 10 },
        { 'K', 11 },
        { 'A', 12 },
    };

    public Day07()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => Part1(_input);

    public override ValueTask<string> Solve_2() => Part2(_input);

    public record struct Hand(string Cards, int Bet);

    public ValueTask<string> Part1(string[] input)
    {
        Dictionary<Hand, int> Hands = new();

        foreach (var player in input)
        {
            var playerSplit = player.Split(" ");
            var playerHand = playerSplit[0];
            var playerBet = int.Parse(playerSplit[1]);
            var thisHand = new Hand(playerHand, playerBet);
            Hands.Add(thisHand, ShowMeWhatYouGot(playerHand));
        }

        var ordered = Hands.OrderBy(c => c.Value).ToDictionary();
        CheckForTies(ordered);


        return ValueTask.FromResult("");
    }

    public void CheckForTies(Dictionary<Hand, int> hands)
    {
        Tuple<Hand, int> temp;
        Queue<Dictionary<Hand, int>> queue = new();
        bool firstRun = true;
        foreach (var player in hands)
        {
            if (firstRun)
            {
                temp = new Tuple<Hand, int>(player.Key, player.Value);
                firstRun = false;
                continue;
            }
//TODO : START HERE
            if (player.Value == temp.Item2)
        }
    }


    public ValueTask<string> Part2(string[] input)
    {
        return ValueTask.FromResult("");
    }
    /*
     * hand strength
     * 5oaK  = 7
     * 4oaK = 6
     * fullH = 5
     * 3oaK = 4
     * 2Pair = 3
     * 1Pair = 2
     * HighCard = 1
     */

    public int ShowMeWhatYouGot(string player)
    {
        Func<string, int>[] waysToWin = new[]
        {
            FiveOfAKind,
            FourOfAKind,
            FullHouse,
            ThreeOfAKind,
            TwoPair,
            OnePair,
            HighCard
        };
        var handStrength = 0;
        foreach (var tryHand in waysToWin)
        {
            handStrength = tryHand(player);
            if (handStrength > 0)
                return handStrength;
        }

        return handStrength;
    }

    public char GetHighCard(string hand)
    {
        var highCard = ' ';
        foreach (var card in hand)
        {
            if (Cards[card] > highCard)
                highCard = card;
        }

        return highCard;
    }

    /*
     * hand strength
     * 5oaK  = 7
     * 4oaK = 6
     * fullH = 5
     * 3oaK = 4
     * 2Pair = 3
     * 1Pair = 2
     * HighCard = 1
     */
    public int FiveOfAKind(string hand)
    {
        var value = hand[0];
        for (int i = 1; i < hand.Length; i++)
        {
            if (hand[i] != value) return 0;
        }

        return 7;
    }

    public int FourOfAKind(string hand)
    {
        Dictionary<char, int> occurence = new();
        foreach (var card in hand)
        {
            if (occurence.ContainsKey(card)) occurence[card]++;
            else occurence.Add(card, 1);
        }

        if (occurence.Count() == 2)
        {
            var fourOf = occurence.First(x => x.Value == 4);
            if (fourOf.Value == 4)
                return 6;
        }

        return 0;
    }

    public int FullHouse(string hand)
    {
        Dictionary<char, int> occurence = new();
        foreach (var card in hand)
        {
            if (occurence.ContainsKey(card)) occurence[card]++;
            else occurence.Add(card, 1);
        }

        if (occurence.Count() == 2)
        {
            var threeOf = occurence.First(x => x.Value == 3);
            var twoOf = occurence.First(x => x.Value == 2);
            if (threeOf.Value == 3 && twoOf.Value == 2)
                return 5;
        }

        return 0;
    }

    public int ThreeOfAKind(string hand)
    {
        Dictionary<char, int> occurence = new();
        foreach (var card in hand)
        {
            if (occurence.ContainsKey(card)) occurence[card]++;
            else occurence.Add(card, 1);
        }

        if (occurence.Count() == 3)
        {
            var threeOf = occurence.FirstOrDefault(x => x.Value == 3);
            if (threeOf.Value == 3)
                return 4;
        }

        return 0;
    }

    public int TwoPair(string hand)
    {
        Dictionary<char, int> occurence = new();
        foreach (var card in hand)
        {
            if (occurence.ContainsKey(card)) occurence[card]++;
            else occurence.Add(card, 1);
        }

        if (occurence.Count() == 3)
        {
            var pairs = occurence.Where(x => x.Value == 2);
            if (pairs.Count() == 2)
                return 3;
        }

        return 0;
    }

    public int OnePair(string hand)
    {
        Dictionary<char, int> occurence = new();
        foreach (var card in hand)
        {
            if (occurence.ContainsKey(card)) occurence[card]++;
            else occurence.Add(card, 1);
        }

        if (occurence.Count() == 4)
        {
            var pair = occurence.FirstOrDefault(x => x.Value == 2);
            if (pair.Value == 2)
                return 2;
        }

        return 0;
    }

    public int HighCard(string hand)
    {
        Dictionary<char, int> occurence = new();
        foreach (var card in hand)
        {
            if (occurence.ContainsKey(card)) occurence[card]++;
            else occurence.Add(card, 1);
        }

        if (occurence.Count() == 5)
        {
            return 1;
        }

        return 0;
    }
}