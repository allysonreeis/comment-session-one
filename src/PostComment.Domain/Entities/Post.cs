namespace PostCommentSession.Domain.Entities;

public class Post
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Author { get; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public IList<string> Images { get; set; }

    private Post(string author, string title, string content)
    {
        Author = author;
        Title = title;
        Content = content;
        Images = new List<string>();
    }

    public static Post Create(string author, string title, string content)
    {
        
        return new Post(author, title, content);
    }
    
        
}