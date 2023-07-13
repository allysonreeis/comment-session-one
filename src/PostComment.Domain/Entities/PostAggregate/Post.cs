using PostCommentSession.Domain.Exceptions;
using PostCommentSession.Domain.SeedWork;

namespace PostCommentSession.Domain.Entities.PostAggregate;

public class Post : AggregateRoot
{
    public string Author { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    // public IList<string> Images { get; private set; }
    public DateTime CreatedAt { get; }

    private Post(string author, string title, string content)
    {
        Author = author;
        Title = title;
        Content = content;
        // Images = new List<string>();
        CreatedAt = DateTime.UtcNow;
    }

    // Keep the Entity state consistent and avoid problems like breaking clients that use this object 
    public static Post Create(string author, string title, string content)
    {
        var post = new Post(author, title, content);
        post.Validate();
        return post;
    }

    public void Update(string author, string title, string content, IList<string> images)
    {
        Author = author;
        Title = title;
        Content = content;
        // Images = images; // atention to this
        
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Title) || string.IsNullOrWhiteSpace(Title))
        {
            throw new EntityValidationException($"{nameof(Title)} should not be null or empty");
        }
    }
        
}