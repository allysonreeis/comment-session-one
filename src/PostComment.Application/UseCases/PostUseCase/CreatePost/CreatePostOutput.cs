namespace PostComment.Application.UseCases.PostUseCase.CreatePost;

public record CreatePostOutput(
    Guid Id,
    string Author,
    string Title,
    string Content,
    DateTime CreatedAt);