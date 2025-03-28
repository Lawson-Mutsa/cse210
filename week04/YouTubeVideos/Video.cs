using System;
using System.Collections.Generic;

class Video
{
    
    private string title;
    private string author;
    private int length; // Length in seconds
    private List<Comment> comments;

    
    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        comments = new List<Comment>();
    }

    
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    
    public int GetCommentCount()
    {
        return comments.Count;
    }

    
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine("-----------------------------------");
    }
}
