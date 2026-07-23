using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learn C#", "John", 600);

        video1.AddComment(new Comment("Maria", "Great video!"));
        video1.AddComment(new Comment("Pedro", "Very helpful."));
        video1.AddComment(new Comment("Lucas", "Thanks for sharing!"));

        Video video2 = new Video("Cooking Pasta", "Anna", 420);

        video2.AddComment(new Comment("James", "Looks delicious!"));
        video2.AddComment(new Comment("Emily", "I'll try this recipe."));
        video2.AddComment(new Comment("Chris", "Amazing!"));

        Video video3 = new Video("Travel in Japan", "David", 900);

        video3.AddComment(new Comment("Sophia", "Beautiful places!"));
        video3.AddComment(new Comment("Michael", "I want to visit."));
        video3.AddComment(new Comment("Emma", "Fantastic video!"));

        video1.DisplayVideo();
        video2.DisplayVideo();
        video3.DisplayVideo();
    }
}