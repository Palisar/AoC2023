using System.Diagnostics.CodeAnalysis;
using AdventOfCode;
using FluentAssertions;

namespace Aoc.Tests;

public class Day07Tests
{
    Day07 _sut = new Day07();

    //#region Part1

    [Fact]
    public async Task Day07_Solve_1_Test1()
    {
        //destination range start -- source range start  -- range length
        // seed number    -           
        var data = """
                   32T3K 765
                   T55J5 684
                   KK677 28
                   KTJJT 220
                   QQQJA 483
                   """;

        var input = data.Split("\n");

        var result = await _sut.Part1(input);

        result.Should().Be("6440");
    }

    [Fact]
    public async Task Day07_Solve_1_ShowMeWhatYouGot()
    {
        //destination range start -- source range start  -- range length
        // seed number    -           
        var data = "QQQJA";
       

        var result = _sut.ShowMeWhatYouGot(data);

        result.Should().Be(4);
    }

    [Fact]
    public async Task Day07_Solve_1_Test2()
    {
        //destination range start -- source range start  -- range length
        // seed number    -           
        var data = """
                   Time:      30
                   Distance:  200
                   """;

        var input = data.Split("\n");

        var result = await _sut.Part1(input);

        result.Should().Be("9");
    }
}