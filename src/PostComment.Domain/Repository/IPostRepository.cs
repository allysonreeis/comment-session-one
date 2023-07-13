using PostCommentSession.Domain.Entities;
using PostCommentSession.Domain.Entities.PostAggregate;

namespace PostCommentSession.Domain.Repository;

public interface IPostRepository
{
    Task<IList<Post>> Get();
    Task<Post?> GetById(Guid id);
    Task Insert(Post post, CancellationToken cancellationToken);
    Task Delete(Guid id);
    Task Update(Post post);
}