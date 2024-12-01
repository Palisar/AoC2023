using AdventOfCode;
using FluentAssertions;

namespace Aoc.Tests._2023;

public class Day03Tests
{
    Day03 _sut = new Day03();

    #region Part1
    [Fact]
    public async Task Day03_Solve_1_Test1()
    {
        var data = """
                   467..114..
                   ...*......
                   ..35..633.
                   ......#...
                   617*......
                   .....+.58.
                   ..592.....
                   ......755.
                   ...$.*....
                   .664.598..
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);

        result.Should().Be("4361");
    }
    
    [Fact]
    public async Task Day03_Solve_1_Test2()
    {
        var data = """
                   .....
                   *67..
                   ...*.
                   .....
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);

        result.Should().Be("67");
    }

    [Fact]
    public async Task Day03_Solve_1_Test3()
    {
        var data = """
                   467..114..
                   ...*......
                   ..35..633.
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);

        result.Should().Be("502");
    }
    [Fact]
    public async Task Day03_Solve_1_Test4()
    {
        var data = """
                   ...
                   111
                   1*1
                   1*1
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);

        result.Should().Be("115");
    }
    [Fact]
    public async Task Day03_Solve_1_Test5()
    {
        var data = """
                   ...
                   *11
                   1*1
                   1*1
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);

        result.Should().Be("15");
    }
    
    [Fact]
    public async Task Day03_Solve_1_Test6()
    {
        var data = """
                   ...
                   1*1
                   1*1
                   1*1
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);

        result.Should().Be("6");
    }
     [Fact]
    public async Task Day03_Solve_1_Test7()
    {
        var data = """
                   ...
                   **1
                   **1
                   **1
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);

        result.Should().Be("3");
    }
       [Fact]
    public async Task Day03_Solve_1_Test8()
    {
        var data = """
                   ...
                   1*.
                   1*.
                   1*.
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);

        result.Should().Be("3");
    }
       [Fact]
    public async Task Day03_Solve_1_Test9()
    {
        var data = """
                   ..1
                   11*
                   .*.
                   .*.
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part1(input);

        result.Should().Be("12");
    }
    #endregion
    
    #region Part2 
    [Fact]
    public async Task Day03_Solve_2_Test1()
    {
        var data = """
                   467..114..
                   ...*......
                   ..35..633.
                   ......#...
                   617*......
                   .....+.58.
                   ..592.....
                   ......755.
                   ...$.*....
                   .664.598..
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("467835");
    }
  [Fact]
    public async Task Day03_Solve_2_Test2()
    {
        var data = """
                   111
                   2*.
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("222");
    }
  [Fact]
    public async Task Day03_Solve_2_Test3()
    {
        var data = """
                   111
                   2*.
                   1..
                   """;


        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("0");
    }
    
     [Fact]
    public async Task Day03_Solve_2_Test4()
    {
        var data = """
                   .....
                   *67..
                   ...*.
                   .....
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("0");
    }

    [Fact]
    public async Task Day03_Solve_2_Test5()
    {
        var data = """
                   467..114..
                   ...*......
                   ..35..633.
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("16345");
    }
    [Fact]
    public async Task Day03_Solve_2_Test6()
    {
        var data = """
                   ...
                   111
                   1*1
                   1*1
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("0");
    }
    [Fact]
    public async Task Day03_Solve_2_Test7()
    {
        var data = """
                   ...
                   *11
                   1*1
                   1*1
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("0");
    }
    
    [Fact]
    public async Task Day03_Solve_2_Test8()
    {
        var data = """
                   ...
                   1*1
                   1*1
                   1*1
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("0");
    }
     [Fact]
    public async Task Day03_Solve_2_Test9()
    {
        var data = """
                   ...
                   **1
                   **1
                   **1
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("0");
    }
       [Fact]
    public async Task Day03_Solve_2_Test10()
    {
        var data = """
                   ...
                   2*.
                   2*.
                   2*.
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("4");
    }
       [Fact]
    public async Task Day03_Solve_2_Test11()
    {
        var data = """
                   ..1
                   11*
                   .*.
                   .*.
                   ...
                   """;

        var input = data.Split("\r\n");

        var result = await _sut.Part2(input);

        result.Should().Be("11");
    }

    #endregion
    
    #region HelperTests

    [Theory]
    [InlineData("......?322./441.", 7, 322)]
    [InlineData("..1", 2, 1)]
    [InlineData("1.1", 0, 1)]
    [InlineData(".1@", 1, 1)]
    public void ExtractNumbersTests(string row, int startIndex, int expected)
    {
        var result = _sut.ExtractNumber(row, startIndex , 0);

        result.Should().Be(expected);
    }

    [Fact]
    public void FindAdjacentNumbersTests()
    {
        var data = """
                   467..114..
                   ...*......
                   ..35..633.
                   """;

        var startIndex = new Point(3, 1);
        var input = data.Split("\r\n");
        var result = _sut.FindAdjacentNumbers(startIndex, input);
        result.Should().Be(502);
    }

    [Fact]
    public void FindAdjacentNumbersTests2()
    {
        var data = """
                   467..114..
                   ...*......
                   ..3.5..633
                   """;

        var startIndex = new Point(3, 1);
        var input = data.Split("\r\n");
        var result = _sut.FindAdjacentNumbers(startIndex, input);
        result.Should().Be(475);
    }

    [Fact]
    public void FindAdjacentNumbersTests3()
    {
        var data = """
                   467..114..
                   ...*......
                   ..3.3..633
                   """;

        var startIndex = new Point(3, 1);
        var input = data.Split("\r\n");
        var result = _sut.FindAdjacentNumbers(startIndex, input);
        result.Should().Be(473);
    }

    [Fact]
    public void FindAdjacentNumbersTests4()
    {
        var data = """
                   467..114..
                   ..3*3.....
                   .......633
                   """;

        var startIndex = new Point(3, 1);
        var input = data.Split("\r\n");
        var result = _sut.FindAdjacentNumbers(startIndex, input);
        result.Should().Be(473);
    }

    [Fact]
    public void FindAdjacentNumbersTests5()
    {
        var data = """
                   467*.114..
                   ...3......
                   ..3.3...633
                   """;

        var startIndex = new Point(3, 0);
        var input = data.Split("\r\n");
        var result = _sut.FindAdjacentNumbers(startIndex, input);
        result.Should().Be(470);
    }
    
    #endregion
}