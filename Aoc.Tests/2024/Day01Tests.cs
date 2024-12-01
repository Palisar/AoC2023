using AdventOfCode2024;
using FluentAssertions;


namespace Aoc.Tests._2024;

public class Day01Tests
{
    Day01 sut = new();
    string input = @"3   4
4   3
2   5
1   3
3   9
3   3";
    
    [Fact]
    public async Task Solve01Test01()
    {
        var result = await sut.SolveFirstPart(input.Split('\n'));
        result.Should().BeEquivalentTo("11");
    }
    
    
    [Fact]
    public async Task Solve02Test01()
    {
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("31");
    }
}