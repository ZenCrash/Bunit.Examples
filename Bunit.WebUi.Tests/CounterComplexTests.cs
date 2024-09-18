using Bunit.Examples.WebUi.Components.Pages;
using Bunit;
using Xunit;

namespace Bunit.WebUi.Tests
{
  public class UnitTest1 : TestContext
  {
    [Fact]
    public void CounterStartsAtZero()
    {
      // Arrange
      var cut = RenderComponent<ComplexCounter>();

      // Act - Find elements by their ID using CSS selector
      var counter1 = cut.Find("#id1");  // Selects the element with id="id1"
      var counter2 = cut.Find("#id2");  // Selects the element with id="id2"
      var counter3 = cut.Find("#id3");  // Selects the element with id="id3"

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
      var counter1 = cut.Find("#id1");  // currentCount (1x)
      var counter2 = cut.Find("#id2");  // currentCount2 (2x)
      var counter3 = cut.Find("#id3");  // currentCount3 (4x)

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
      var counter1 = cut.Find("#id1");  // currentCount
      var counter2 = cut.Find("#id2");  // currentCount2 (2x)
      var counter3 = cut.Find("#id3");  // currentCount3 (4x)

      Assert.Equal("Current 1x*count: 3", counter1.TextContent);  // 1x*count
      Assert.Equal("Current 2x*count: 6", counter2.TextContent);  // 2x*count
      Assert.Equal("Current 4x*count: 12", counter3.TextContent); // 4x*count
    }
  }
}