using OpenQA.Selenium; // Import the Selenium WebDriver library
using OpenQA.Selenium.Chrome; // Import the Chrome WebDriver
using System; // Import the System namespace for basic functionalities
using Xunit; // Import the xUnit testing framework

namespace UITests
{
    public class MarketIntelligenceTests : IDisposable // Class for Market Intelligence tests that implements IDisposable
    {
        private readonly IWebDriver _driver; // Private field to hold the WebDriver instance

        // Constructor to initialize the MarketIntelligenceTests
        public MarketIntelligenceTests()
        {
            _driver = new ChromeDriver(); // Instantiate a new ChromeDriver for browser automation
        }

        [Fact] // Attribute indicating this is a test method
        public void TestMarketIntelligenceFlow()
        {
            // Arrange
            var homePage = new PageObjects.HomePage(_driver); // Create an instance of the HomePage class
            _driver.Navigate().GoToUrl("https://www.agdata.com/"); // Navigate to the AgData website

            // Act
            homePage.NavigateToSolutionsMenu(); // Hover over the Solutions menu
            homePage.SelectMarketIntelligenceSubMenu(); // Click on the Market Intelligence submenu

            // Get the headings from the "Ways You Benefit" section
            var headings = homePage.GetWaysYouBenefitHeadings(); // Retrieve the headings

            // Assert that the headings are not empty
            Assert.NotEmpty(headings); // Assert that the list of headings is not empty

            // Optionally, log the headings to verify they are as expected
            foreach (var heading in headings)
            {
                Console.WriteLine(heading); // Print each heading to the console
            }

            // Click the "Let's Get Started" button
            homePage.ClickLetsGetStartedButton(); // Click the button to navigate to the Contact page

            // Validate that the Contact page is displayed
            var isContactPageDisplayed = homePage.IsContactPageDisplayed(); // Check if the Contact page is displayed
            Assert.True(isContactPageDisplayed, "Contact page should be displayed after clicking 'Let's Get Started'"); // Assert the condition
        }

        // IDisposable implementation to clean up resources
        public void Dispose()
        {
            _driver.Quit(); // Close the browser and dispose of the WebDriver
        }
    }
}
