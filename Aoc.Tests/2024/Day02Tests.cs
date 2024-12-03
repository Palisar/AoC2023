using AdventOfCode2024;
using FluentAssertions;


namespace Aoc.Tests._2024;

public class Day02Tests
{
    Day02 sut = new();

    string input = @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";

    [Fact]
    public async Task Solve01Test01()
    {
        var result = await sut.SolveFirstPart(input.Split('\n'));
        result.Should().BeEquivalentTo("2");
    }


    [Fact]
    public async Task Solve02Test01()
    {
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("4");
    }


    [Theory]
    [InlineData(new[] { 7, 6, 4, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 7, 8, 9 }, false)]//
    [InlineData(new[] { 9, 7, 6, 2, 1 }, false)]
    [InlineData(new[] { 1, 3, 2, 4, 5 }, false)]
    [InlineData(new[] { 8, 6, 4, 4, 1 }, false)]
    [InlineData(new[] { 1, 3, 6, 7, 9 }, true)]
    [InlineData(new[] { 6, 6, 6, 8, 6 }, false)]
    [InlineData(new[] { 45, 47, 48, 50, 51, 52, 54, 51 }, false)]
    public async Task IsRowSafeTest(int[] row, bool expected)
    {
        var result = sut.IsRowSafe(row);
        result.Should().Be(expected);
    }
    
    
    [Theory]
    [InlineData(new[] { 7, 6, 4, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 7, 8, 9 }, false)]
    [InlineData(new[] { 9, 7, 6, 2, 1 }, false)]
    [InlineData(new[] { 1, 3, 2, 4, 5 }, true)]
    [InlineData(new[] { 8, 6, 4, 4, 1 }, true)]
    [InlineData(new[] { 1, 3, 6, 7, 9 }, true)]
    [InlineData(new[] { 6, 6, 6, 8, 6 }, false)]
    [InlineData(new[] { 1, 2, 3, 4, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 1, 1 }, false)]
    [InlineData(new[] { 1, 1, 2 ,3, 1 }, false)]
    [InlineData(new[] { 1, 1, 1, 1}, false)]
    [InlineData(new[] { 45, 47, 48, 50, 51, 52, 54, 51 }, true)]
    [InlineData(new[] { 13, 13, 10, 7, 3 }, false)]
    [InlineData(new[] {  3, 2, 1, 3}, true)]
    [InlineData(new[] {  1, 2, 3, 1}, true)]
    [InlineData(new[] {  1, 2, 1, 3}, true)]
    [InlineData(new[] {  1, 1, 2, 3}, true)]
    [InlineData(new[] {  48, 46, 47 ,49, 51, 54, 56}, true)]
    [InlineData(new[] {  1, 1, 2, 3, 4, 5}, true)]
    [InlineData(new[] {  1, 2, 3, 4, 5, 5}, true)]
    [InlineData(new[] {  5, 1, 2, 3, 4, 5}, true)]
    [InlineData(new[] {  1, 4, 3, 2, 1}, true)]
    [InlineData(new[] {  1, 6, 7, 8, 9}, true)]
    [InlineData(new[] {  1, 2, 3, 4, 3}, true)]
    [InlineData(new[] {  9, 8, 7, 6, 7}, true)]
    [InlineData(new[] { 7, 10, 8 ,10, 11}, true)]
    [InlineData(new[] {  29, 28, 27, 25, 26, 25, 22, 20}, true)]
    public async Task IsRowSafeTestDampener(int[] row, bool expected)
    {
        var result = sut.IsRowSafeDampened(row.ToList());
        result.Should().Be(expected);
    }
}