using System;
using System.Diagnostics;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description) { }

    protected override void PerformActivity()
    {
        // Alternate "Breathe in..." and "Breathe out..." with countdowns until time is up
        var sw = Stopwatch.StartNew();
        bool inhale = true;

        while (sw.Elapsed.TotalSeconds < DurationSeconds)
        {
            int phaseSeconds = 4; // several seconds per instruction
            int remaining = (int)Math.Ceiling(DurationSeconds - sw.Elapsed.TotalSeconds);
            if (remaining <= 1) break; // avoid very short flashes at the end

            Console.WriteLine(inhale ? "Breathe in..." : "Breathe out...");
            // show a small progress bar during countdown (creativity)
            ShowCountdown(Math.Min(phaseSeconds, remaining), withBar: true);
            Console.WriteLine();
            inhale = !inhale;
        }
    }
}
