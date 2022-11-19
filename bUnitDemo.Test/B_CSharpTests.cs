namespace bUnitDemo.Test
{
    using bUnitDemo.Shared;

    public class B_CSharpTests : TestContext //context inheritance (very useful)
    {
        [Fact]
        public void CounterStartsAtZero()
        {
            var cut = RenderComponent<SimpleCounter>();

            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
        }
    }
}