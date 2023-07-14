using PostComment.Test.Common;
using PostCommentSession.Domain.Entities;
using PostCommentSession.Domain.Entities.PostAggregate;

namespace PostComment.Test;

public class PostTestFixture : BaseFixture
{
    public PostTestFixture() : base()
    {
    }
    
    public Post GetValidPost() =>  Post.Create(Faker.Name.FirstName( ),Faker.Lorem.Sentence(5), Faker.Lorem.Paragraphs()); 
}

[CollectionDefinition(nameof(PostTestFixture))]
public class PostTestFixtureCollection : ICollectionFixture<PostTestFixture>
{
}