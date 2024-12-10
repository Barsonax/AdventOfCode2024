using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public partial class Day3
{
    [GeneratedRegex("mul\\(([0-9]*),([0-9]*)\\)")]
    private static partial Regex IsMul();
    
    private static (string instruction, int left, int right, int pos)[] _mulInstructions;
    private static string _allText;
    
    [Test]
    public void ParseInput()
    {
        _allText = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day3Input"));
        _mulInstructions = IsMul()
            .Matches(_allText)
            .Select(x => (instruction: x.Groups[0].Value, left: int.Parse(x.Groups[1].Value), right: int.Parse(x.Groups[2].Value), position: x.Index))
            .ToArray();


    }
    
    [Test]
    [DependsOn(nameof(ParseInput))]
    public void Problem1()
    {
        Console.WriteLine(_mulInstructions.Aggregate(0, (i, tuple) => tuple.left * tuple.right + i));
    }

    [Test]
    [DependsOn(nameof(ParseInput))]
    public void Problem2()
    {
        Console.WriteLine(_mulInstructions
            .Where(IsEnabled)
            .Aggregate(0, (i, tuple) => tuple.left * tuple.right + i));
    }

    private bool IsEnabled((string instruction, int left, int right, int pos) tuple)
    {
        var substring = _allText.AsSpan()[.. tuple.pos];
        
        var dontIndex = substring.LastIndexOf("don't()");
        var doIndex = substring.LastIndexOf("do()");

        if (dontIndex == -1) return true;
        if (doIndex > dontIndex) return true;
        return false;
    }
}