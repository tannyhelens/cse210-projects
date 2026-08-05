public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine($"Level: {_score / 500 + 1}");

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type would you like to create? ");

        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times must it be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus
                )
            );
        }

        Console.WriteLine("Goal created!");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}"
            );
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals.");
            return;
        }

        Console.WriteLine("\nYour goals:");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int number = int.Parse(Console.ReadLine()) - 1;

        if (number < 0 || number >= _goals.Count)
        {
            Console.WriteLine("Invalid goal.");
            return;
        }

        int oldLevel = _score / 500 + 1;
        int earnedPoints = _goals[number].RecordEvent();

        _score += earnedPoints;

        Console.WriteLine(
            $"Congratulations! You earned {earnedPoints} points!"
        );

        int newLevel = _score / 500 + 1;

        if (newLevel > oldLevel)
        {
            Console.WriteLine($"Level up! You reached level {newLevel}!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("\nWhat is the filename? ");
        string filename = Console.ReadLine();

        using StreamWriter file = new StreamWriter(filename);

        file.WriteLine(_score);

        foreach (Goal goal in _goals)
        {
            file.WriteLine(goal.GetStringRepresentation());
        }

        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        Console.Write("\nWhat is the filename? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] typeParts = lines[i].Split(':', 2);
            string type = typeParts[0];
            string[] data = typeParts[1].Split('|');

            if (type == "SimpleGoal")
            {
                _goals.Add(
                    new SimpleGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        bool.Parse(data[3])
                    )
                );
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(
                    new EternalGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2])
                    )
                );
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(
                    new ChecklistGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        int.Parse(data[3]),
                        int.Parse(data[4]),
                        int.Parse(data[5])
                    )
                );
            }
        }

        Console.WriteLine("Goals loaded!");
    }
}