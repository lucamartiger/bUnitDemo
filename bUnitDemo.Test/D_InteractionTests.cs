namespace bUnitDemo.Test
{
    using bUnitDemo.Shared;
    using System;

    public class D_InteractionTests : TestContext
    {
        [Fact]
        public void InvokeComponentMethods()
        {
            int counterStart = 10;

            var cut = RenderComponent<CounterWithInteractions>(parameters => parameters.Add(p => p.CounterStart, counterStart));

            cut.Instance.ResetCounter();

            Assert.True(cut.Instance.GetCounter() == 0);
        }

        [Fact]
        public void InvokeComponentEventHandler()
        {
            int secondaryCount = 0;

            Action<int> updateSecondaryCountHandler = (int currentCount) => { secondaryCount = currentCount; };

            var cut = RenderComponent<CounterWithInteractions>(parameters => parameters.Add(p => p.CounterIncremented, updateSecondaryCountHandler));

            cut.Instance.CounterIncremented.InvokeAsync(1);

            Assert.True(secondaryCount == 1);
        }

        //(1) all other interaction types
        [Fact]
        public void InvokeButtonClick()
        {
            var cut = RenderComponent<CounterWithInteractions>();

            cut.Find("button").Click();

            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
        }
    }
}