using System.Diagnostics;

public static class Extensions {
    public static void Restart(this Stopwatch stopwatch) {
        stopwatch.Reset();
        stopwatch.Start();
    }
}