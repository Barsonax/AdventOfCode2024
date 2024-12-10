namespace AdventOfCode2024;

public class Day4
{
    private static string _allText;
    
    [Test]
    public void ParseInput()
    {
        _allText = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day4Input"));

    }
    
    [Test]
    [DependsOn(nameof(ParseInput))]
    public void Problem1()
    {
        
    }

    [Test]
    [DependsOn(nameof(ParseInput))]
    public void Problem2()
    {

    }
}