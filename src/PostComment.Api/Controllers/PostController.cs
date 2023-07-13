using Microsoft.AspNetCore.Mvc;
using PostComment.Infrastructure.Repositories;

namespace PostComment.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class PostController : ControllerBase
{
    private static readonly string[] posts = new[] {
        "Api", ".Net", "Node.JS", "React"
    };

    [HttpGet("/")]
    public string[] GetPosts()
    {
        return posts;
    }
}