using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;


namespace InnovinationTest.Steps
{
    [Binding]
    public class FooterStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver;

        public FooterStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            _driver = new ChromeDriver(options);
            _scenarioContext["driver"] = _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }

        [Given(@"I validate the footer")]
        public void GivenIValidateTheFooter()
        {
            try
            {
                if (_driver == null)
                {
                    throw new InvalidOperationException("WebDriver is not initialized");
                }
                _driver.Navigate().GoToUrl("https://www.innovination.com/");
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

                IWebElement footerElement = _driver.FindElement(By.XPath("//div[contains(@class, 'footer_top-area')]//div[contains(@class, 'row-footer')]//div[contains(@class, 'vc_row')]"));
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to validate footer: {ex.Message}", ex);
            }

        }


        // public class RootObject
        // {
        //     public List<NavItem> NavItems { get; set; }
        //     public List<ContactFormField> ContactFormFields { get; set; }
        // }
        // public class NavItem
        // {
        //     public string Name { get; set; }
        // }

        // public class ContactFormField
        // {
        //     public string Name { get; set; }
        // }

    }
}


// top header
// secondary header
// footer
// make the file structure correct