using System.Diagnostics.CodeAnalysis;
using AdventOfCode;
using FluentAssertions;

namespace Aoc.Tests;

public class Day05Tests
{
    Day05 _sut = new Day05();

    //#region Part1
    [Fact]
    public async Task Day05_Solve_1_Test1()
    {//destination range start -- source range start  -- range length
        // seed number    -           
        var data = """
                   seeds: 79 14 55 13
                   
                   seed-to-soil map:
                   50 98 2
                   52 50 48
                   
                   soil-to-fertilizer map:
                   0 15 37
                   37 52 2
                   39 0 15
                   
                   fertilizer-to-water map:
                   49 53 8
                   0 11 42
                   42 0 7
                   57 7 4
                   
                   water-to-light map:
                   88 18 7
                   18 25 70
                   
                   light-to-temperature map:
                   45 77 23
                   81 45 19
                   68 64 13
                   
                   temperature-to-humidity map:
                   0 69 1
                   1 0 69
                   
                   humidity-to-location map:
                   60 56 37
                   56 93 4
                   """;

        var input = data.Split("\n\n");

        var result = await _sut.Part1(input);

        result.Should().Be("35");
    }

    [Fact]
    public async Task Day05_Solve_1_Test2()
    {
        var data = """
                   seeds: 51

                   seed-to-soil map:
                   98 50 2
                   """;

        var input = data.Split("\n\n");

        var result = await _sut.Part1(input);

        result.Should().Be("99");
    }
    
    [Fact]
    public async Task Day05_Solve_1_Test3()
    {//destination range start -- source range start  -- range length
        // seed number    -// seed - source gives the distance then add this number to the destination           
        var data = """
                   seeds: 79
                   
                   seed-to-soil map:
                   0 0 0
                   0 0 0

                   water-to-light map:
                   88 18 7
                   18 25 70
                   """;

        var input = data.Split("\n\n");

        var result = await _sut.Part1(input);

        result.Should().Be("72");
    }
    
    [Fact]
    public async Task Day05_Solve_2_Test1()
    {//destination range start -- source range start  -- range length
        // seed number    -// seed - source gives the distance then add this number to the destination           
        var data = """
                   seeds: 79 14 55 13

                   seed-to-soil map:
                   50 98 2
                   52 50 48

                   soil-to-fertilizer map:
                   0 15 37
                   37 52 2
                   39 0 15

                   fertilizer-to-water map:
                   49 53 8
                   0 11 42
                   42 0 7
                   57 7 4

                   water-to-light map:
                   88 18 7
                   18 25 70

                   light-to-temperature map:
                   45 77 23
                   81 45 19
                   68 64 13

                   temperature-to-humidity map:
                   0 69 1
                   1 0 69

                   humidity-to-location map:
                   60 56 37
                   56 93 4
                   """;

        var input = data.Split("\n\n");

        var result = await _sut.Part2(input);

        result.Should().Be("46");
    }
  
}