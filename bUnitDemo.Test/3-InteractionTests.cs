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
        public void InvokeButtonClick()
        {
            var cut = RenderComponent<Counter>();

            cut.Find("button").Click();

            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
        }
    }
}