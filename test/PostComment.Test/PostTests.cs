using Moq;
using PostComment.Infrastructure.Repositories;
using PostComment.Infrastructure.Repositories.PostRepository;
using PostCommentSession.Domain.Entities;

namespace PostComment.Test;

public class PostTests
{
    // Test name pattern T1_T2_T3
    // T1: SUT - System under test - logical component we're testing
    // T2: Scenario - what we're testing
    // T3: Expect outcome - what we expect the logical component to do
    [Fact]
    public void Post_CreateAPost_ShouldInstantiateAPost()
    {
        // Arrange
        var author = "Messi";
        var title = "The Laws of Physics";
        var content = "Text/Content of the post...";

        // Act
        var post = Post.Create(author, title, content);

        // Assert
        Assert.NotNull(post);
        Assert.NotEqual(default(Guid), post.Id);
        Assert.NotEqual(default(DateTime), post.CreatedAt);
        Assert.Equal(author, post.Author);
        Assert.Equal(title, post.Title);
        Assert.Equal(content, post.Content);
    }

    [Fact]
    public async Task Post_CreateAPostRepository_ShouldCreateAPostUsingRepository()
    {
        var postMock = new Mock<IPostRepository>();

        var author = "Messi";
        var title = "The Laws of Physics";
        var content = "Text/Content of the post...";

        // Deveria ser uma DTO?
        var postRequest = Post.Create(author, title, content);
        postMock.Setup(p => p.GetById(postRequest.Id)).ReturnsAsync(postRequest);
        
        var repository = postMock.Object;
        await repository.Create(postRequest);
        
        var postResponse = await repository.GetById(postRequest.Id);
        
        Assert.Equal(postRequest, postResponse);
    }
}