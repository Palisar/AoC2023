using AdventOfCode2024;
using FluentAssertions;


namespace Aoc.Tests._2024;

public class Day03Tests
{
    Day03 sut = new();

    private string input =  @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
    private string inputB = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    [Fact]
    public async Task Solve01Test01()
    {
        var result = await sut.SolveFirstPart(input);
        result.Should().BeEquivalentTo("161");
    }

    [Fact]
    public async Task Solve02Test01()
    {
        var result = await sut.SolveSecondPart(inputB);
        result.Should().BeEquivalentTo("48");
    }
}