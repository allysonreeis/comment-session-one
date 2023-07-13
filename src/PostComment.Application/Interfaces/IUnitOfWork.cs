namespace PostComment.Application.Interfaces;

public interface IUnitOfWork
{
    public Task Commit(CancellationToken cancellationToken);
}