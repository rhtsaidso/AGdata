using OpenQA.Selenium;

namespace UITests.PageObjects
{
    public class ContactPage
    {
        private readonly IWebDriver _driver; // WebDriver instance to interact with the browser

        // Constructor to initialize the ContactPage with the WebDriver
        public ContactPage(IWebDriver driver)
        {
            _driver = driver; // Assign the provided WebDriver to the private field
        }

        // Method to check if the Contact page is loaded
        public bool IsContactPageLoaded()
        {
            // Find the header element on the page using a CSS selector for the <h1> tag
            var contactHeader = _driver.FindElement(By.CssSelector("h1"));
            
            // Check if the text of the header contains "Contact"
            return contactHeader.Text.Contains("Contact");
        }
    }
}
