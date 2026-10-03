using System;
using System.Collections.Generic;

// Video 1
Video video1 = new Video(
    "How to Make Homemade Pizza",
    "Cooking with Sarah",
    420
);

video1.AddComment(new Comment("Maria", "This looks delicious!"));
video1.AddComment(new Comment("John", "I am going to try this recipe."));
video1.AddComment(new Comment("Emma", "Thanks for sharing!"));


// Video 2
Video video2 = new Video(
    "Learn C# in 10 Minutes",
    "Code Academy",
    600
);

video2.AddComment(new Comment("David", "This was very helpful."));
video2.AddComment(new Comment("Sofia", "I finally understand classes!"));
video2.AddComment(new Comment("Lucas", "Great explanation."));

// Video 3
Video video3 = new Video(
    "Best Hiking Trails",
    "Outdoor Adventures",
    900
);

video3.AddComment(new Comment("Ana", "The scenery is beautiful."));
video3.AddComment(new Comment("Michael", "I want to visit this place."));
video3.AddComment(new Comment("Laura", "Thanks for the recommendations!"));

// Put all videos into a list
List<Video> videos = new List<Video>();

videos.Add(video1);
videos.Add(video2);
videos.Add(video3);

// Display all videos and comments
foreach (Video video in videos)
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine($"Title: {video.GetTitle()}");
    Console.WriteLine($"Author: {video.GetAuthor()}");
    Console.WriteLine($"Length: {video.GetLength()} seconds");
    Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
    Console.WriteLine("Comments:");

    foreach (Comment comment in video.GetComments())
    {
        Console.WriteLine($"- {comment.GetDisplayText()}");
    }

    Console.WriteLine();
}