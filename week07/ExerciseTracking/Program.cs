using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2026, 10, 15), 30, 5.0),
            new Cycling(new DateTime(2026, 10, 16), 45, 20.0),
            new Swimming(new DateTime(2026, 10, 17), 30, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
