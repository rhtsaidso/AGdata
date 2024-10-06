using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace UITests.PageObjects
{
    public class MarketIntelligencePage
    {
        private readonly IWebDriver _driver; // WebDriver instance to interact with the browser

        // Constructor to initialize the MarketIntelligencePage with the WebDriver
        public MarketIntelligencePage(IWebDriver driver)
        {
            _driver = driver; // Assign the provided WebDriver to the private field
        }

        // Method to get the headings from the "Ways You Benefit" section
        public List<string> GetWaysYouBenefitHeadings()
        {
            // Find all the heading elements (h3) within the "Ways You Benefit" section
            var headings = _driver.FindElements(By.CssSelector("div.ways-you-benefit h3")) // Locate h3 elements inside the specified div
                                  .Select(h => h.Text) // Select the text of each heading
                                  .ToList(); // Convert the result to a list
            return headings; // Return the list of heading texts
        }

        // Method to click the "Let's Get Started" button
        public void ClickLetsGetStartedButton()
        {
            // Locate the "Let's Get Started" button by its link text and click it
            var letsGetStartedButton = _driver.FindElement(By.LinkText("Let’s Get Started"));
            letsGetStartedButton.Click(); // Click the button
        }
    }
}
