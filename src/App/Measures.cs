using System.Diagnostics;
using System.Reflection;
using MethodTimer;

namespace App;

public static class Measures
{
    public static void Warmup()
    {
        _ = Algorithms.FindPrimeNumbers();
    }

    public static void UsingStopWatch()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        _ = Algorithms.FindPrimeNumbers();
        stopWatch.Stop();
        Console.WriteLine($"[{nameof(UsingStopWatch)}] Execution time = {stopWatch.Elapsed} ms");
    }

    public static void UsingEfficientStopWatch()
    {
        var startTime = Stopwatch.GetTimestamp();
        _ = Algorithms.FindPrimeNumbers();
        var elapsedTime = Stopwatch.GetElapsedTime(startTime);
        Console.WriteLine($"[{nameof(UsingEfficientStopWatch)}] Execution time = {elapsedTime} ms");
    }

    [Time(nameof(UsingMethodTimerFody))]
    public static void UsingMethodTimerFody()
    {
        _ = Algorithms.FindPrimeNumbers();
    }

    private static class MethodTimeLogger
    {
        public static void Log(MethodBase methodBase, TimeSpan elapsedTime, string message)
        {
            Console.WriteLine($"[{message}] Execution time = {elapsedTime} ms");
        }
    }
}
