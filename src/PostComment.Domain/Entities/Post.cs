using PostCommentSession.Domain.Exceptions;

namespace PostCommentSession.Domain.Entities;

public class Post
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Author { get; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public IList<string> Images { get; private set; }
    public DateTime CreatedAt { get; }

    private Post(string author, string title, string content)
    {
        Author = author;
        Title = title;
        Content = content;
        Images = new List<string>();
        CreatedAt = DateTime.UtcNow;
    }

    // Keep the Entity state consistent and avoid problems like breaking clients that use this object 
    public static Post Create(string author, string title, string content)
    {
        var post = new Post(author, title, content);
        post.Validate();
        return post;
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Title) || string.IsNullOrWhiteSpace(Title))
        {
            throw new EntityValidationException($"{nameof(Title)} should not be null or empty");
        }
    }
        
}