using System.Reflection.PortableExecutable;
using AdventOfCode;
using FluentAssertions;

namespace Aoc.Tests._2023;

public class Day01Tests
{
    Day01 sut = new Day01();
    
    [Fact]
    public async Task Solve01Test()
    {
         
        var input = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";
        
        var result = await sut.SolveFirstPart(input.Split('\n'));
        result.Should().BeEquivalentTo("142");
    }
    
    [Fact]
    public async Task Solve02Test()
    {
         
        var input =
            "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("281");
        
    }
    
    [Fact]
    public async Task Solve02Test2()
    {
        var input =
            "mktwonecvqsxhqrjfninethreethreedkllgfxrxrffzvdbqdj2c3";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("23");
    }
    [Fact]
    public async Task Solve02Test3()
    {
        var input =
            "5sjnnfivefourzxxfpfivenine7five";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("55");
    }
    [Fact]
    public async Task Solve02Test4()
    {
        var input =
            "oneonevstpxxrjpnine7six";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("16");
    }
    [Fact]
    public async Task Solve02Test5()
    {
        var input =
            "eightwo2";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("82");
    }
    
    [Fact]
    public async Task Solve02Test6()
    {
        var input =
            "eight3nineight";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("88");
    }
    [Fact]
    public async Task Solve02Test7()
    {
        var input =
            "twone3";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("23");
    }
    [Fact]
    public async Task Solve02Test8()
    {
        var input =
            "3sevenine";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("39");
    }
    [Fact]
    public async Task Solve02Test9()
    {
        var input =
            "3442323145";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("35");
    }
    [Fact]
    public async Task Solve02Test10()
    {
        var input =
            "oneightwo";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("12");
    }
    [Fact]
    public async Task Solve02Test11()
    {
        var input =
            "51591twosix4dhsxvgghxq";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("54");
    }
    [Fact]
    public async Task Solve02Test12()
    {
        var input =
            "3two3eightjszbfourkxbh5twonepr";
        
        var result = await sut.SolveSecondPart(input.Split('\n'));
        result.Should().BeEquivalentTo("31");
    }
    
    
}