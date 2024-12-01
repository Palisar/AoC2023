using AdventOfCode;
using FluentAssertions;

namespace Aoc.Tests._2023;

public class Day02Tests
{
    Day02 _sut = new Day02();

    [Fact]
    public async Task Day02_Solve_1()
    {
        var data = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);


        result.Should().Be("8");
    }

    [Fact]
    public async Task Day02_Solve_2()
    {
        string[] input;
        input = new[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"};
        var result = await _sut.Part2(input);
        result.Should().Be("48");
    }
}