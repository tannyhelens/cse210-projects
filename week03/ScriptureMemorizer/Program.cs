/*
Creativity and exceeding requirements:

The program stores multiple scriptures and chooses one randomly each
time it starts. It also hides only words that are still visible, so it
does not waste a turn selecting words that were already hidden.
*/

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding"
            ),

            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son"
            ),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me"
            )
        };

        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        string userInput = "";

        while (userInput.ToLower() != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine(
                "Press Enter to continue or type 'quit' to finish:"
            );

            userInput = Console.ReadLine() ?? "";

            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}