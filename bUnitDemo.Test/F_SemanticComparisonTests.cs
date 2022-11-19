namespace bUnitDemo.Test
{
    using AngleSharp.Css.Dom;
    using AngleSharp.Dom;
    using bUnitDemo.Shared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class F_SemanticComparisonTests : TestContext
    {
        [Fact]
        public void IgnoreAnElement()
        {
            var cut = RenderComponent<ComponentWithHtmlContent>();

            //<h1 class="heading-1">Hello world</h1>
            //diff:ignore attribute to ignore an element, all its attributes and its child nodes
            cut.Find("h1").MarkupMatches(@"<h1 class=""heading-1"" diff:ignore></h1>");
        }

        [Fact]
        public void IgnoreAnAttribute()
        {
            var cut = RenderComponent<ComponentWithHtmlContent>();

            //<h1 class="heading-1">Hello world</h1>
            //ignore only that attribute
            cut.Find("h1").MarkupMatches(@"<h1 class:ignore>Hello world</h1>");
        }

        [Fact]
        public void IgnoreChildren()
        {
            var cut = RenderComponent<ComponentWithHtmlContent>();

            //<h3>Hello world<span>!</span></h3>
            //ignore attribute children
            cut.Find("h3").MarkupMatches(@"<h3 diff:ignoreChildren>Hello world</h3>");
        }

        [Fact]
        public void ConfigureWhitespaceHandling()
        {
            var cut = RenderComponent<ComponentWithHtmlContent>();

            //<h2> Hello world </h2>
            //trim all text nodes
            cut.Find("h2").MarkupMatches(@"<h2 diff:normalize>Hello world</h2>");
        }

        [Fact]
        public void PerformCaseInsensitiveComparison()
        {
            var cut = RenderComponent<ComponentWithHtmlContent>();

            //<h2> Hello world </h2>
            //case insensitive
            cut.Find("h2").MarkupMatches(@"<h2 diff:ignorecase>HeLlO wOrLd</h2>");
        }
    }
}