using Bunit.Examples.WebUi.Components.Pages;

namespace Bunit.WebUi.Tests
{
  public class CounterTests : TestContext
  {
    [Fact]
    public void CounterStartsAtZero()
    {
      // Arrange
      // by using RenderComponent from bunit, we can define a render fragment "cut" in this case
      var cut = RenderComponent<Counter>();

      // Act - Find the paragraph with the current count and verify it starts at 0
      var paragraph = cut.Find("p[role='status']");

      // Assert
      Assert.Equal("Current count: 0", paragraph.TextContent);
    }

    [Fact]
    public void ClickingButtonIncrementsCounter()
    {
      // Arrange
      var cut = RenderComponent<Counter>();

      // Act - Find and click the button
      cut.Find("button").Click();

      // Assert - Verify the count increments to 1
      var paragraph = cut.Find("p[role='status']");
      Assert.Equal("Current count: 1", paragraph.TextContent);
    }

    [Fact]
    public void ClickingButtonMultipleTimesIncrementsCounterCorrectly()
    {
      // Arrange
      var cut = RenderComponent<Counter>();

      // Act - Click the button multiple times
      cut.Find("button").Click();
      cut.Find("button").Click();
      cut.Find("button").Click();

      // Assert - Verify the count increments to 3
      var paragraph = cut.Find("p[role='status']");
      Assert.Equal("Current count: 3", paragraph.TextContent);
    }
  }
}