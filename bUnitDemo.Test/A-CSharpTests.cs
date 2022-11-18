﻿using bUnitDemo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bUnitDemo.Test
{
    public class A_CSharpTests : TestContext //context inheritance (very useful)
    {
        [Fact]
        public void CounterStartsAtZero()
        {
            var cut = RenderComponent<SimpleCounter>(); //cut means "Component Under Test"

            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
        }
    }
}
