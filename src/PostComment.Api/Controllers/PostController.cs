using Microsoft.AspNetCore.Mvc;
using PostComment.Application.UseCases.PostUseCase.CreatePost;
using PostComment.Infrastructure.Repositories;
using PostCommentSession.Domain.Repository;

namespace PostComment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostRepository _repository;

    private static readonly string[] posts = new[] {
        "Api", ".Net", "Node.JS", "React"
    };

    public PostController(IPostRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("create")]
    public async Task<CreatePostOutput> CreateAPosts([FromBody] CreatePostInput createPostInput)
    {
        var useCase = new CreatePostUseCase(_repository);

        var output = await useCase.Handle(createPostInput, CancellationToken.None);
        
        return output;
    }

    [HttpGet]
    public Object GetPost()
    {
        return new { nome= "allyson" };
    }
}