using System;
using System.Collections.Generic;

// Comment Class
class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video Class
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public TimeSpan Length { get; set; }
    private List<Comment> Comments { get; set; } = new List<Comment>();

    public Video(string title, string author, TimeSpan length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length}");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");

        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create Video Objects
        var video1 = new Video("Introduction to C#", "Adriano", TimeSpan.FromMinutes(10));
        var video2 = new Video("Advanced C# Techniques", "Adriano", TimeSpan.FromMinutes(20));
        var video3 = new Video("C# Design Patterns", "Adriano", TimeSpan.FromMinutes(15));

        // Add Comments to Video 1
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Learned a lot!"));

        // Add Comments to Video 2
        video2.AddComment(new Comment("Alice", "Amazing content!"));
        video2.AddComment(new Comment("Daisy", "Loved the explanation."));
        video2.AddComment(new Comment("Eve", "Looking forward to more!"));

        // Add Comments to Video 3
        video3.AddComment(new Comment("Frank", "Awesome examples."));
        video3.AddComment(new Comment("Grace", "Best explanation I've seen!"));
        video3.AddComment(new Comment("Helen", "Perfect for beginners."));

        // Store Videos in a List
        var videos = new List<Video> { video1, video2, video3 };

        // Display Details for Each Video
        foreach (var video in videos)
        {
            video.DisplayDetails();
            Console.WriteLine();
        }
    }
}