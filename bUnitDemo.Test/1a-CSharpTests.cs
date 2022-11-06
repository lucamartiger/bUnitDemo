using bUnitDemo.Shared;

namespace bUnitDemo.Test
{
    public class CSharpTests : TestContext //context inheritance (very useful)
    {
        [Fact]
        public void CounterStartsAtZero()
        {
            var cut = RenderComponent<Counter>(); //cut means "Component Under Test"

            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
        }
    }
}