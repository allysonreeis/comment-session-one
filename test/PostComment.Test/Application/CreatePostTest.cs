using Moq;
// using PostComment.Application.Interfaces;
using PostComment.Application.UseCases.PostUseCase.CreatePost;
using PostCommentSession.Domain.Entities.PostAggregate;
using PostCommentSession.Domain.Repository;

namespace PostComment.Test.Application;

public class CreatePostTest
{
    [Fact]
    public async void Post_CreatePostUseCase_ShouldCreateAPostUseCase()
    {
        var postRepositoryMock = new Mock<IPostRepository>();
        // var unitOfWorkMock = new Mock<IUnitOfWork>();

        var useCase = new CreatePostUseCase(postRepositoryMock.Object);

        var input = new CreatePostInput("Isaac Newton", "The Physics Beaty", "...");
        
        var output = await useCase.Handle(input, CancellationToken.None);
        
        postRepositoryMock.Verify(repository => 
                repository.Insert(
                It.IsAny<Post>(), 
                It.IsAny<CancellationToken>()), 
            Times.Once);
        
        // unitOfWorkMock.Verify(uow => uow.Commit(It.IsAny<CancellationToken>()), 
            // Times.Once);
        
        Assert.NotNull(output);
        Assert.Equal(input.Author, output.Author);
        Assert.Equal(input.Title, output.Title);
        Assert.Equal(input.Content, output.Content);
        Assert.True(output.Id != Guid.Empty);
        Assert.True(output.CreatedAt != default(DateTime));
    }
}