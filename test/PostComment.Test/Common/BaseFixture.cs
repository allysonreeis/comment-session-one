using Bogus;

namespace PostComment.Test.Common;

public abstract class BaseFixture
{
    protected Faker Faker { get; set; }

    protected BaseFixture()
    {
        Faker = new Faker("pt_br");
    }
}