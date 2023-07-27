using PostCommentSession.Domain.Entities;
using PostCommentSession.Domain.Entities.PostAggregate;

namespace PostCommentSession.Domain.Repository;

public interface IPostRepository
{
    Task<Post?> GetById(Guid id);
    void Insert(Post post, CancellationToken cancellationToken);
   
}