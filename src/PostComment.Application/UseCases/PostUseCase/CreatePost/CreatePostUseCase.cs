using MediatR;
using PostCommentSession.Domain.Entities.PostAggregate;
using PostCommentSession.Domain.Repository;

namespace PostComment.Application.UseCases.PostUseCase.CreatePost;

public class CreatePostUseCase : IRequestHandler<CreatePostInput, CreatePostOutput>
{
    private readonly IPostRepository _postRepository;


    public CreatePostUseCase(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<CreatePostOutput> Handle(CreatePostInput createPostInput, CancellationToken cancellationToken)
    {
        var post = Post.Create(createPostInput.Author, createPostInput.Title, createPostInput.Content);
        
         _postRepository.Insert(post, cancellationToken);

         return new CreatePostOutput(post.Id, post.Author, post.Title, post.Content, post.CreatedAt);
    }
}