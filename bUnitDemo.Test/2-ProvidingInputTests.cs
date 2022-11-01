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
    public class ProvidingInputTests : TestContext
    {
        [Fact]
        public void PassingClassicParameter()
        {
            int counterStart = 1;

            //(for cascading parameters the syntax is the same)
            var cut = RenderComponent<Counter>(parameters => parameters.Add(p => p.CounterStart, counterStart));

            cut.Find("p").MarkupMatches($"<p>Current count: {counterStart}</p>");
        }

        [Fact]
        public void PassingTwoWayBindingParameter()
        {
            int counterStart = 1;

            var cut = RenderComponent<Counter>(parameters => parameters.Bind(p => p.CounterStart, counterStart, newValue => counterStart = newValue));
        }

        [Fact]
        public void PassingEventHandler()
        {
            int secondaryCount = 0;

            Action<int> updateSecondaryCountHandler = (int currentCount) => { secondaryCount = currentCount; };

            var cut = RenderComponent<Counter>(parameters => parameters.Add(p => p.CounterIncremented, updateSecondaryCountHandler));
        }

        [Fact]
        public void InjectServices()
        {
            var logService = new LogService();

            Services.AddSingleton<ILogService>(logService);

            //in this components logservice has been injected
            var cut = RenderComponent<Counter>();
        }
    }
}