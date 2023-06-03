using PostCommentSession.Domain.Entities;

namespace PostComment.Test;

public class PostTests
{
    // Test name pattern T1_T2_T3
    // T1: SUT - System under test - logical component we're testing
    // T2: Scenario - what we're testing
    // T3: Expect outcome - what we expect the logical component to do
    [Fact]
    public void Post_CreateAPost_ShouldCreateAPost()
    {
        // Arrange
        var author = "Messi";
        var title = "The Laws of Physics";
        var content = "Text/Content of the post...";

        // Act
        var post = Post.Create(author, title, content);
        
        // Assert
        Assert.Equal(author, post.Author);
        Assert.Equal(title, post.Title);
        Assert.Equal(content, post.Content);
    }
}