using PostComment.Application.Interfaces;
using PostCommentSession.Domain.Entities.PostAggregate;
using PostCommentSession.Domain.Repository;

namespace PostComment.Application.UseCases.PostUseCase.CreatePost;

public class CreatePostUseCase
{
    private readonly IPostRepository _postRepository;
    private readonly IUnitOfWork _uow;


    public CreatePostUseCase(IPostRepository postRepository, IUnitOfWork uow)
    {
        _postRepository = postRepository;
        _uow = uow;
    }

    public async Task<CreatePostOutput> Handle(CreatePostInput createPostInput, CancellationToken cancellationToken)
    {
        var post = Post.Create(createPostInput.Author, createPostInput.Title, createPostInput.Content);
        
        await _postRepository.Insert(post, cancellationToken);
        await _uow.Commit(cancellationToken);
        
        return new CreatePostOutput(post.Id, post.Author, post.Title, post.Content, post.CreatedAt);
    }
}