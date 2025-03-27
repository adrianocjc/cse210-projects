using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public TimeSpan Duration { get; set; }
    public int Views { get; set; }
    public DateTime UploadDate { get; set; }
    public string Description { get; set; }

    public void Play()
    {
        Console.WriteLine($"Playing video: {Title}");
    }

    public void Pause()
    {
        Console.WriteLine($"Pausing video: {Title}");
    }

    public void Like()
    {
        Console.WriteLine($"Liked video: {Title}");
    }

    public void Share()
    {
        Console.WriteLine($"Sharing video: {Title}");
    }
}

class Category
{
    public string CategoryName { get; set; }
    public List<Video> Videos { get; set; } = new List<Video>();

    public void AddVideo(Video video)
    {
        Videos.Add(video);
        Console.WriteLine($"Added video: {video.Title} to category: {CategoryName}");
    }

    public void RemoveVideo(Video video)
    {
        Videos.Remove(video);
        Console.WriteLine($"Removed video: {video.Title} from category: {CategoryName}");
    }

    public void ListVideos()
    {
        Console.WriteLine($"Videos in category: {CategoryName}");
        foreach (var video in Videos)
        {
            Console.WriteLine($"- {video.Title}");
        }
    }
}

class Playlist
{
    public string PlaylistName { get; set; }
    public List<Video> VideoList { get; set; } = new List<Video>();

    public void AddVideo(Video video)
    {
        VideoList.Add(video);
        Console.WriteLine($"Added video: {video.Title} to playlist: {PlaylistName}");
    }

    public void RemoveVideo(Video video)
    {
        VideoList.Remove(video);
        Console.WriteLine($"Removed video: {video.Title} from playlist: {PlaylistName}");
    }

    public void PlayAll()
    {
        Console.WriteLine($"Playing all videos in playlist: {PlaylistName}");
        foreach (var video in VideoList)
        {
            video.Play();
        }
    }
}

class User
{
    public string Username { get; set; }
    public List<Playlist> SavedPlaylists { get; set; } = new List<Playlist>();
    public List<Video> WatchHistory { get; set; } = new List<Video>();

    public void CreatePlaylist(string name)
    {
        SavedPlaylists.Add(new Playlist { PlaylistName = name });
        Console.WriteLine($"Created playlist: {name}");
    }

    public void SaveVideo(Video video)
    {
        WatchHistory.Add(video);
        Console.WriteLine($"Saved video: {video.Title} to watch history");
    }

    public void ViewHistory()
    {
        Console.WriteLine($"Watch history for user: {Username}");
        foreach (var video in WatchHistory)
        {
            Console.WriteLine($"- {video.Title}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var video1 = new Video
        {
            Title = "Introduction to C#",
            Duration = TimeSpan.FromMinutes(10),
            Views = 1000,
            UploadDate = DateTime.Now,
            Description = "Learn the basics of C#."
        };

        var video2 = new Video
        {
            Title = "Advanced C# Techniques",
            Duration = TimeSpan.FromMinutes(20),
            Views = 500,
            UploadDate = DateTime.Now,
            Description = "Explore advanced concepts in C#."
        };

        var category = new Category { CategoryName = "Programming Tutorials" };
        category.AddVideo(video1);
        category.AddVideo(video2);
        category.ListVideos();

        var playlist = new Playlist { PlaylistName = "C# Learning" };
        playlist.AddVideo(video1);
        playlist.AddVideo(video2);
        playlist.PlayAll();

        var user = new User { Username = "Adriano" };
        user.CreatePlaylist("Favorites");
        user.SaveVideo(video1);
        user.ViewHistory();
    }
}