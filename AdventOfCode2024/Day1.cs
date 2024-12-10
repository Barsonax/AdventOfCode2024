namespace AdventOfCode2024;

public class Day1
{
    private static int[] _leftList;
    private static int[] _rightList;
    
    [Test]
    public void ParseInput()
    {
        var input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day1Input"));
        var parsedInput = input
            .Select(x => x.Split(' ')
                .Where(y => !string.IsNullOrEmpty(y))
                .Select(int.Parse)
                .ToArray()).ToArray();

        _leftList = parsedInput.Select(x => x[0])
            .Order()
            .ToArray();
        _rightList = parsedInput.Select(x => x[1])
            .Order()
            .ToArray();
    }
    
    [Test]
    [DependsOn(nameof(ParseInput))]
    public void Problem1()
    {
       var distance = _leftList
           .Zip(_rightList)
           .Aggregate(0, (i, tuple) => Math.Abs(tuple.First - tuple.Second) + i);
       Console.WriteLine(distance);
    }

    [Test]
    [DependsOn(nameof(ParseInput))]
    public void Problem2()
    {
        var similarityScore = _leftList.Aggregate(0, (i, x) => x * _rightList.Count(y => y == x) + i);
        Console.WriteLine(similarityScore);
    }
}