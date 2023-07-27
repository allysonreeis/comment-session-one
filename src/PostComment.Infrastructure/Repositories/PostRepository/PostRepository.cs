using PostCommentSession.Domain.Entities;
using PostCommentSession.Domain.Entities.PostAggregate;
using PostCommentSession.Domain.Repository;

namespace PostComment.Infrastructure.Repositories.PostRepository;

public class PostRepository : IPostRepository
{
    private IList<Object> lista = new List<object>();
    public Task<IList<Post>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Insert(Post post, CancellationToken cancellationToken)
    {
        lista.Add(post);
    }
    
}