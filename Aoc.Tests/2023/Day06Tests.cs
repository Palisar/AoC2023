using AdventOfCode;
using FluentAssertions;

namespace Aoc.Tests._2023;

public class Day06Tests
{
    Day06 _sut = new Day06();

    //#region Part1
    [Fact]
    public async Task Day06_Solve_1_Test1()
    {
        //destination range start -- source range start  -- range length
        // seed number    -           
        var data = """
                   Time:      7  15   30
                   Distance:  9  40  200
                   """;

        var input = data.Split("\n");

        var result = await _sut.Part1(input);

        result.Should().Be("288");
    }
    
    [Fact]
    public async Task Day06_Solve_1_Test2()
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
    
    [Fact]
    public async Task Day06_Solve_2_Test1()
    {
        //destination range start -- source range start  -- range length
        // seed number    -           
        var data = """
                   Time:      7  15   30
                   Distance:  9  40  200
                   """;

        var input = data.Split("\n");

        var result = await _sut.Part2(input);

        result.Should().Be("71503");
    }    
    
    
}