using System;
using System.Collections.Generic;

/// <summary>
/// W04 Assignment - YouTube Video Program
/// Demonstrates abstraction: each class manages its own data and behavior.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Create a few sample videos
        Video video1 = new Video("How to Bake Bread", "CookingWithAmy", 480);
        video1.AddComment(new Comment("John", "Great recipe! I’ll try this today."));
        video1.AddComment(new Comment("Laura", "Looks delicious!"));
        video1.AddComment(new Comment("David", "I love the step-by-step guide."));

        Video video2 = new Video("Travel Vlog: Japan", "WanderWorld", 600);
        video2.AddComment(new Comment("Mia", "Japan is on my bucket list!"));
        video2.AddComment(new Comment("Leo", "Amazing editing."));
        video2.AddComment(new Comment("Sara", "Beautiful temples and food!"));

        Video video3 = new Video("C# Tutorial for Beginners", "TechWithTom", 900);
        video3.AddComment(new Comment("Alice", "Super helpful explanation!"));
        video3.AddComment(new Comment("Carlos", "Finally understood classes!"));
        video3.AddComment(new Comment("Nina", "Could you make one about interfaces?"));

        // Put videos into a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(new string('-', 50));
        }
    }
}
