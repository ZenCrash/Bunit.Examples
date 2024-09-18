using Bunit;
using Bunit.Examples.WebUi.Components.Pages;
using Xunit;

namespace Bunit.WebUi.Tests
{
  public class CounterComplexTests : TestContext
  {
    [Fact]
    public void CounterStartsAtZero()
    {
      // Arrange
      var cut = RenderComponent<ComplexCounter>();

      //if a components uses depdency injection aka @inject.
      //we can also inject that into our render fragment with bunit.
      //Services.AddSingleton<PersonRepository>(
      //  new PersonRepository())

      // Act - Find elements by their ID using CSS selector
      //Alternative ways to search

      //counter1 - Searches through nested statement, via every id
      var counter1 = cut.Find("div#div1 div#div2 p#p1x");  //id="p1x"

      //counter2 - Searches through nested statement, via every id, seperated into seperate arguments
      var counter2 = cut.Find(string.Join(" ", new[] { "div#div1", "div#div2", "p#p2x" })); //id="p2x"

      //counter3 - Searches for spesefic type "p" and id "#<id>" (will return erro if other components has that id)
      var counter3 = cut.Find("p#p3x");  //id="p3x"

      //counter4 - Searches for spesefic type "p" and id "#<id>" (will return erro if other components has that id)
      var counter4 = cut.Find("#p4x");  //id="p4x"

      // Assert - All counters should start at 0
      Assert.Equal("Current 1x*count: 0", counter1.TextContent);
      Assert.Equal("Current 2x*count: 0", counter2.TextContent);
      Assert.Equal("Current 4x*count: 0", counter3.TextContent);
      Assert.Equal("Current 8x*count: 0", counter4.TextContent);
    }

    [Fact]
    public void ClickingButtonIncrementsCounters()
    {
      // Arrange
      var cut = RenderComponent<ComplexCounter>();

      // Act - Find and click the button
      cut.Find("button").Click();

      // Assert - Check that all counters update correctly
      var counter1 = cut.Find("div#div1 div#div2 p#p1x"); 
      var counter2 = cut.Find("div#div1 div#div2 p#p2x");
      var counter3 = cut.Find("div#div1 div#div2 p#p3x");
      var counter4 = cut.Find("div#div1 div#div2 p#p4x");

      Assert.Equal("Current 1x*count: 1", counter1.TextContent); // 1x*count
      Assert.Equal("Current 2x*count: 2", counter2.TextContent); // 2x*count
      Assert.Equal("Current 4x*count: 4", counter3.TextContent); // 4x*count
      Assert.Equal("Current 8x*count: 8", counter4.TextContent); // 8x*count
    }

    [Fact]
    public void ClickingButtonMultipleTimesIncrementsCountersCorrectly()
    {
      // Arrange
      var cut = RenderComponent<ComplexCounter>();

      // Act - Click the button multiple times
      cut.Find("button").Click();
      cut.Find("button").Click();
      cut.Find("button").Click();

      // Assert - Check that all counters update after 3 clicks
      var counter1 = cut.Find("div#div1 div#div2 p#p1x");
      var counter2 = cut.Find("div#div1 div#div2 p#p2x");
      var counter3 = cut.Find("div#div1 div#div2 p#p3x");
      var counter4 = cut.Find("div#div1 div#div2 p#p4x");

      Assert.Equal("Current 1x*count: 3", counter1.TextContent);  //Count*3*1 = 3
      Assert.Equal("Current 2x*count: 6", counter2.TextContent);  //Count*3*2 = 6
      Assert.Equal("Current 4x*count: 12", counter3.TextContent); //Count*3*4 = 12
      Assert.Equal("Current 8x*count: 24", counter4.TextContent); //Count*3*8 = 24
    }
  }
}