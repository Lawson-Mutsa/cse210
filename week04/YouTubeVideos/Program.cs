using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("C# Tutorial", "CodeAcademy", 600);
        Video video2 = new Video("OOP in C#", "Tech Explained", 750);
        Video video3 = new Video("Abstraction in Programming", "Dev Simplified", 480);

        // Add comments with likes
        video1.AddComment(new Comment("Alice", "Great tutorial!", 15));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!", 8));
        video1.AddComment(new Comment("Charlie", "Well explained!", 12));

        video2.AddComment(new Comment("David", "OOP is finally making sense!", 22));
        video2.AddComment(new Comment("Eve", "I was confused before, but now I get it!", 18));
        video2.AddComment(new Comment("Frank", "Solid explanation!", 10));

        video3.AddComment(new Comment("Grace", "Abstraction is so cool!", 25));
        video3.AddComment(new Comment("Hannah", "Great examples!", 9));
        video3.AddComment(new Comment("Isaac", "Best video on this topic!", 14));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display all videos and comments
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
