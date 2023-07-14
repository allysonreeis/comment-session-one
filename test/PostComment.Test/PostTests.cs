using Moq;
using PostComment.Infrastructure.Repositories;
using PostComment.Infrastructure.Repositories.PostRepository;
using PostComment.Test.Common;
using PostCommentSession.Domain.Entities;
using PostCommentSession.Domain.Entities.PostAggregate;
using PostCommentSession.Domain.Exceptions;
using PostCommentSession.Domain.Repository;

namespace PostComment.Test;

[Collection(nameof(PostTestFixture))]
public class PostTests
{
    private readonly PostTestFixture _postTestFixture;

    public PostTests(PostTestFixture postTestFixture) => _postTestFixture = postTestFixture;

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
        await repository.Insert(postRequest, CancellationToken.None);
        
        var postResponse = await repository.GetById(postRequest.Id);
        
        Assert.Equal(postRequest, postResponse);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    public void Post_CreateAPost_ShouldThrowErrorWhenTitleIsNullOrEmpty(string? title)
    {
        //Arrange
        // Action action = ()=>Post.Create("Neymar", title, "Some contente here...");
        void action() => Post.Create("Neymar", title, "Some contente here...");
        
        //Act
        var exception = Assert.Throws<EntityValidationException>(action);
        
        //Assert
        Assert.Equal("Title should not be null or empty", exception.Message);
    }
}