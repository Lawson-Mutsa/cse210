using System;

class Comment
{
    
    private string name;
    private string text;
    private int likes; // Added "likes" feature for creativity

    
    public Comment(string name, string text, int likes = 0)
    {
        this.name = name;
        this.text = text;
        this.likes = likes;
    }

    
    public void DisplayComment()
    {
        Console.WriteLine($"- {name}: \"{text}\" ({likes} likes)");
    }
}
