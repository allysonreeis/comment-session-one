using PostCommentSession.Domain.Entities;
using PostCommentSession.Domain.Entities.PostAggregate;
using PostCommentSession.Domain.Repository;

namespace PostComment.Infrastructure.Repositories.PostRepository;

public class PostRepository : IPostRepository
{
    public Task<IList<Post>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Insert(Post post, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Post post)
    {
        throw new NotImplementedException();
    }
}