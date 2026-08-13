class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running(
            new DateTime(2026, 8, 12),
            30,
            3.0
        );

        Cycling cycling = new Cycling(
            new DateTime(2026, 8, 12),
            45,
            12.0
        );

        Swimming swimming = new Swimming(
            new DateTime(2026, 8, 12),
            30,
            20
        );

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}