using bUnitDemo.Shared;
using bUnitDemo.Shared.Interfaces;
using bUnitDemo.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bUnitDemo.Test
{
    public class InteractionTests : TestContext
    {
        [Fact]
        public void InvokeComponentMethods()
        {
            var cut = RenderComponent<Counter>(parameters => parameters.Add(p => p.CounterStart, 10));

            cut.Instance.ResetCounter();
        }

        [Fact]
        public void InvokeComponentEventHandler()
        {
            int secondaryCount = 0;

            Action<int> updateSecondaryCountHandler = (int currentCount) => { secondaryCount = currentCount; };

            var cut = RenderComponent<Counter>(parameters => parameters.Add(p => p.CounterIncremented, updateSecondaryCountHandler));

            cut.Instance.CounterIncremented.InvokeAsync(1);
        }

        [Fact]
        public void InvokeButtonClick()
        {
            var cut = RenderComponent<Counter>();

            cut.Find("button").Click();

            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
        }
    }
}