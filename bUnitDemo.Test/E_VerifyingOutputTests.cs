namespace bUnitDemo.Test
{
    using bUnitDemo.Shared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class E_VerifyingOutputTests : TestContext
    {
        [Fact]
        public void VerifyMarkup()
        {
            var cut = RenderComponent<SimpleCounter>();

            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
        }

        [Fact]
        public void VerifyPropertyValues()
        {
            var cut = RenderComponent<CounterWithInteractions>();

            cut.Find("button").Click();

            Assert.True(cut.Instance.GetCounter() == 1);
        }

        [Fact]
        public void VerifyInnerComponents()
        {
            var cut = RenderComponent<ToDoList>(parameter => parameter.Add(p => p.Tasks, new[] { "Task 1", "Task 2" }) );

            var tasks = cut.FindComponents<Task>();

            Assert.Equal(2, tasks.Count);
        }
    }
}