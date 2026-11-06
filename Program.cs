using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CloudQATask1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Make the URL configurable (passed via command line args)
            string targetUrl = args.Length > 0 ? args[0] : "https://app.cloudqa.io/home/AutomationPracticeForm";

            var options = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            try
            {
                driver.Navigate().GoToUrl(targetUrl);
                Console.WriteLine($"Navigated to: {targetUrl}");

                // 2. First Name (Text Box)
                // Find the label containing "First Name", then find the input below or near it.
                var firstNameLabel = driver.FindElement(By.XPath("//*[contains(text(), 'First Name')]"));
                var firstNameInput = driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Below(firstNameLabel));
                firstNameInput.SendKeys("Yash");
                Console.WriteLine("Filled First Name.");

                // 3. Gender (Radio Button)
                // Find the label "Male", then find the radio input near/left of it.
                var genderLabel = driver.FindElement(By.XPath("//*[normalize-space()='Male']"));
                var genderRadio = driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Near(genderLabel));
                genderRadio.Click();
                Console.WriteLine("Selected Gender.");

                // 4. State (Dropdown)
                // Find the label "State", then find the select element near it.
                var stateLabel = driver.FindElement(By.XPath("//*[contains(text(), 'State')]"));
                var stateSelect = driver.FindElement(RelativeBy.WithLocator(By.TagName("select")).Near(stateLabel));
                stateSelect.SendKeys("Rajasthan"); // Typing directly into standard selects works in Selenium
                Console.WriteLine("Selected State.");

                Thread.Sleep(3000); // Pause for visual confirmation during your video recording
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test Failed: {ex.Message}");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}