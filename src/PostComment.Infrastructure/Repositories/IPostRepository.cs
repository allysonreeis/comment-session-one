using PostCommentSession.Domain.Entities;

namespace PostComment.Infrastructure.Repositories;

public interface IPostRepository
{
    Task<IList<Post>> Get();
    Task<Post?> GetById(Guid id);
    Task Create(Post post);
    Task Delete(Guid id);
    Task Update(Post post);
}