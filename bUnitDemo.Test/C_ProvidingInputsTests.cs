namespace bUnitDemo.Test
{
    using bUnitDemo.Shared;
    using bUnitDemo.Shared.Interfaces;
    using bUnitDemo.Shared.Services;
    using NuGet.Frameworks;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class C_ProvidingInputsTests : TestContext
    {
        [Fact]
        public void PassingClassicParameter()
        {
            int counterStart = 1;

            var cut = RenderComponent<CounterWithInputs>(parameters => parameters.Add(p => p.CounterStart, counterStart));

            cut.Find("p").MarkupMatches($"<p>Current count: {counterStart}</p>");
        }

        [Fact]
        public void PassingTwoWayBindingParameter()
        {
            int counterStart = 1;

            var cut = RenderComponent<CounterWithInputs>(parameters => parameters.Bind(p => p.TwoWayBindingCounterStart, counterStart, newValue => counterStart = newValue));

            cut.Find("p").MarkupMatches($"<p>Current count: {counterStart}</p>");
        }

        [Fact]
        public void PassingCascadingParameter() //same syntax of classic parameters
        {
            int counterStart = 1;

            var cut = RenderComponent<CounterWithInputs>(parameters => parameters.Add(p => p.CascadingCounterStart, counterStart));

            cut.Find("p").MarkupMatches($"<p>Current count: {counterStart}</p>");
        }

        [Fact]
        public void PassingEventHandler()
        {
            int secondaryCount = 0;

            Action<int> updateSecondaryCountHandler = (int currentCount) => { secondaryCount = currentCount; };

            var cut = RenderComponent<CounterWithInputs>(parameters => parameters.Add(p => p.CounterIncremented, updateSecondaryCountHandler));
            cut.Find("button").Click();

            Assert.True(secondaryCount == 1);
        }

        [Fact]
        public void PassingRenderFragment()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<CounterWithInputs>(parameters => parameters.AddChildContent("<h3>Hello World</h3>"));

            cut.Find("h3").MarkupMatches("<h3>Hello World</h3>");
        }

        [Fact]
        public void InjectServices()
        {
            var logService = new LogService();

            Services.AddSingleton<ILogService>(logService);

            //in this components logservice has been injected
            var cut = RenderComponent<CounterWithInjection>();

            Assert.NotNull(cut.Instance.GetLogService());
        }
    }
}