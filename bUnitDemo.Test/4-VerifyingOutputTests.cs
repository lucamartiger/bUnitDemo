//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace bUnitDemo.Test
//{
//    public class VerifyingOutputTests
//    {
//        [Fact]
//        public void VerifyCommandResulTest()
//        {
//            var cut = RenderComponent<Counter>();

//            cut.Find("button").Click();

//            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
//        }

//        [Fact]
//        public void VerifyPropertyValuesTest()
//        {
//            var cut = RenderComponent<Counter>();

//            cut.Find("button").Click();

//            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
//        }
//    }
//}