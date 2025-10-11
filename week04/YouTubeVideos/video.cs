using System;
using System.Collections.Generic;

/// <summary>
/// Represents a YouTube video with title, author, length, and a list of comments.
/// </summary>
class Video
{
    // Private fields
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments;

    // Public properties (abstraction: controlled access)
    public string Title { get { return _title; } }
    public string Author { get { return _author; } }
    public int Length { get { return _length; } }

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // Add a comment to the list
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Return number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Return all comments
    public List<Comment> GetComments()
    {
        return _comments;
    }
}
