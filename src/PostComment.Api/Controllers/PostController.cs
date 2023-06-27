using Microsoft.AspNetCore.Mvc;
using PostComment.Infrastructure.Repositories;

namespace PostComment.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class PostController : ControllerBase
{
    private readonly IPostRepository _postRepository;
    
    private static readonly string[] posts = new[] {
        "Api", ".Net", "Node.JS", "React"
    };

    public PostController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpGet("/")]
    public string[] GetPosts()
    {
        return posts;
    }
}