namespace AdventOfCode2024;

public class Day2
{
    private static int[][] _parsedInput;
    
    [Test]
    public void ParseInput()
    {
        var input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day2Input"));

        _parsedInput = input.Select(x => x.Split(' ').Select(int.Parse).ToArray()).ToArray();
    }
    
    public enum RedNosedReportType
    {
        Unknown,
        Increasing,
        Decreasing,
        Unsafe
    }
    
    [Test]
    [DependsOn(nameof(ParseInput))]
    public void Problem1()
    {
        var safeReports = 0;
        foreach (var t in _parsedInput)
        {
            if (IsSafe(t))
            {
                safeReports++;
            }
        }
        Console.WriteLine(safeReports);
    }



    [Test]
    [DependsOn(nameof(ParseInput))]
    public void Problem2()
    {
        var safeReports = 0;
        foreach (var t in _parsedInput)
        {
            var alternatives = GenerateAlternatives(t).ToArray();
            if (alternatives.Any(IsSafe))
            {
                safeReports++;
            }
        }
        Console.WriteLine(safeReports);
    }

    private static IEnumerable<int[]> GenerateAlternatives(int[] t)
    {
        yield return t;

        for (int i = 0; i < t.Length; i++)
        {
            yield return t.Where((x, y) => y != i).ToArray();
        }
    }
    
    private static bool IsSafe(int[] t)
    {
        var previousType = RedNosedReportType.Unknown;
        for (int j = 0; j < t.Length - 1; j++)
        {
            var type = (t[j] - t[j + 1]) switch
            {
                0 or > 3 or < -3 => RedNosedReportType.Unsafe,
                > 0 => previousType == RedNosedReportType.Decreasing ? RedNosedReportType.Unsafe : RedNosedReportType.Increasing,
                < 0 => previousType == RedNosedReportType.Increasing ? RedNosedReportType.Unsafe : RedNosedReportType.Decreasing,
            };

            previousType = type;
                
            if (type == RedNosedReportType.Unsafe)
            {
                break;
            }
        }

        return previousType != RedNosedReportType.Unsafe;
    }
}