namespace PostComment.Application.UseCases.PostUseCase.CreatePost;

public record CreatePostInput(
    string Author,
    string Title,
    string Content
);