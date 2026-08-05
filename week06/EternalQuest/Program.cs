/*
Creativity and exceeding requirements:

This program includes a level system. The player begins at level 1
and reaches a new level for every 500 points earned. When the player's
score crosses a new level, the program displays a special level-up
message.

The program also validates menu selections, positive number inputs,
goal selections, missing files, and invalid file data.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}