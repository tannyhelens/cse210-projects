using System;

// Creativity:
// The reflecting activity does not repeat questions until every question
// has been shown at least once during the session.
// The program also validates menu choices and activity durations.

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a number from 1 to 4.");
                Console.WriteLine();
                continue;
            }

            if (choice == 1)
            {
                BreathingActivity breathingActivity =
                    new BreathingActivity();

                breathingActivity.Run();
            }
            else if (choice == 2)
            {
                ReflectingActivity reflectingActivity =
                    new ReflectingActivity();

                reflectingActivity.Run();
            }
            else if (choice == 3)
            {
                ListingActivity listingActivity =
                    new ListingActivity();

                listingActivity.Run();
            }
            else if (choice == 4)
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for using the Mindfulness Program.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please select a number from 1 to 4.");
                Console.WriteLine();
            }
        }
    }
}