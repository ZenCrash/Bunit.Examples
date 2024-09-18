using Bunit;
using Bunit.Examples.WebUi.Components.Pages;
using Xunit;

namespace Bunit.WebUi.Tests
{
  public class UnitTest1 : TestContext
  {
    //if a components uses depdency injection aka @inject.
    //we can also inject that into our render fragment with bunit.
    //Services.AddSingleton<PersonRepository>(
    //  new PersonRepository())

    [Fact]
    public void CounterStartsAtZero()
    {
      // Arrange
      var cut = RenderComponent<ComplexCounter>();

      // Act - Find elements by their ID using CSS selector
      var counter1 = cut.Find("div#div1 div#div2 p#p1x");  // Selects the element with id="p1x"
      var counter2 = cut.Find("div#div1 div#div2 p#p2x");  // Selects the element with id="p2x"
      var counter3 = cut.Find("div#div1 div#div2 p#p3x");  // Selects the element with id="p4x"

      // Assert - All counters should start at 0
      Assert.Equal("Current 1x*count: 0", counter1.TextContent);
      Assert.Equal("Current 2x*count: 0", counter2.TextContent);
      Assert.Equal("Current 4x*count: 0", counter3.TextContent);
    }

    [Fact]
    public void ClickingButtonIncrementsCounters()
    {
      // Arrange
      var cut = RenderComponent<ComplexCounter>();

      // Act - Find and click the button
      cut.Find("button").Click();

      // Assert - Check that all counters update correctly
      var counter1 = cut.Find("div#div1 div#div2 p#p1x");  // currentCount (1x)
      var counter2 = cut.Find("div#div1 div#div2 p#p2x");  // currentCount2 (2x)
      var counter3 = cut.Find("div#div1 div#div2 p#p3x");  // currentCount3 (4x)

      Assert.Equal("Current 1x*count: 1", counter1.TextContent);  // 1x*count
      Assert.Equal("Current 2x*count: 2", counter2.TextContent);  // 2x*count
      Assert.Equal("Current 4x*count: 4", counter3.TextContent);  // 4x*count
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
      var counter1 = cut.Find("div#div1 div#div2 p#p1x");  // currentCount
      var counter2 = cut.Find("div#div1 div#div2 p#p2x");  // currentCount2 (2x)
      var counter3 = cut.Find("div#div1 div#div2 p#p3x");  // currentCount3 (4x)

      Assert.Equal("Current 1x*count: 3", counter1.TextContent);  // 1x*count
      Assert.Equal("Current 2x*count: 6", counter2.TextContent);  // 2x*count
      Assert.Equal("Current 4x*count: 12", counter3.TextContent); // 4x*count
    }
  }
}