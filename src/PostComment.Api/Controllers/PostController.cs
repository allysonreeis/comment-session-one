using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostComment.Application.UseCases.PostUseCase.CreatePost;

namespace PostCommentSession.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{

    [HttpPost]
    [Route("create")]
    public async Task<CreatePostOutput> CreateAPosts([FromServices] IMediator mediator,[FromBody] CreatePostInput createPostInput)
    {
        var output = await mediator.Send(createPostInput);
        
        return output;
    }

    [HttpGet]
    public Object GetPost()
    {
        return new { nome= "allyson" };
    }
}