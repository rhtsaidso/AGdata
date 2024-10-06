using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace UITests.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver; // WebDriver instance to interact with the browser
        private readonly WebDriverWait _wait; // Wait object for managing explicit waits

        // Constructor to initialize the HomePage with the WebDriver
        public HomePage(IWebDriver driver)
        {
            _driver = driver; // Assign the provided WebDriver to the private field
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Set an explicit wait time of 10 seconds
        }

        // Method to navigate to the "Solutions" menu
        public void NavigateToSolutionsMenu()
        {
            // Hover over the "Solutions" menu to reveal the submenu
            var solutionsMenu = _wait.Until(driver => driver.FindElement(By.XPath("//a[text()='Solutions']")));
            Actions actions = new Actions(_driver); // Create an Actions object to perform complex actions
            actions.MoveToElement(solutionsMenu).Perform(); // Perform the hover action
        }

        // Method to select the "Market Intelligence" submenu option
        public void SelectMarketIntelligenceSubMenu()
        {
            // Wait for the "Market Intelligence" option to be visible after hovering
            var marketIntelligenceOption = _wait.Until(driver => driver.FindElement(By.XPath("//a[text()='Market Intelligence']")));
            marketIntelligenceOption.Click(); // Click the submenu option
        }

        // Method to get the headings from the "Ways You Benefit" section
        public List<string> GetWaysYouBenefitHeadings()
        {
            // Locate the "Ways You Benefit" section
            var sectionElement = _wait.Until(driver => driver.FindElement(By.XPath("//*[@id='post-796']/div/div/section[3]/div")));

            // Scroll to the "Ways You Benefit" section to ensure it is in view
            var jsExecutor = (IJavaScriptExecutor)_driver; // Create a JavaScript executor
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", sectionElement); // Scroll to the section

            // Wait for the headings in the "Ways You Benefit" section to be visible
            var headingsElements = _wait.Until(driver => driver.FindElements(By.XPath("//div[@class='text']")));

            // Extract the text from each heading and return as a list
            var headingTexts = new List<string>(); // Create a list to store the heading texts
            foreach (var heading in headingsElements)
            {
                headingTexts.Add(heading.Text); // Add each heading text to the list
            }

            return headingTexts; // Return the list of heading texts
        }

        // Method to click the "Let's Get Started" button
        public void ClickLetsGetStartedButton()
        {
            // Wait for the "Let's Get Started" button to be visible and click it
            var getStartedButton = _wait.Until(driver => driver.FindElement(By.XPath("//*[@id='prefooter']/a")));
            getStartedButton.Click(); // Click the button
        }

        // Method to check if the Contact page is displayed
        public bool IsContactPageDisplayed()
        {
            // Wait for the Contact page to be displayed (check for an element unique to the Contact page)
            var contactHeader = _wait.Until(driver => driver.FindElement(By.XPath("//h4[text()='Contact']")));
            return contactHeader.Displayed; // Return true if the header is displayed, false otherwise
        }
    }
}
