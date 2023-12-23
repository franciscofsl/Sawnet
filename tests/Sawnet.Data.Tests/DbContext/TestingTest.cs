namespace Sawnet.Data.Tests.DbContext;

public class TestingTest : IClassFixture<TestingDbFixture>
{
    private readonly TestingDbFixture _fixture;

    public TestingTest(TestingDbFixture fixture)
    {
        _fixture = fixture;
    }

    protected TService GetRequiredService<TService>()
    {
        return _fixture.GetRequiredService<TService>();
    }
}