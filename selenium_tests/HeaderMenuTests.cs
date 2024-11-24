using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace InnovinationTest
{
    [TestFixture]
    public class HeaderMenuTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            // baseURL = "https://www.blazedemo.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            // Assert.AreEqual(string.Empty, verificationErrors.ToString());
        }

        [Test]
        public void ValidateInnovinationLogo()
        {
            // Label: Test
            // ERROR: Caught exception [ERROR: Unsupported command [resizeWindow | 1536,713 | ]]
            try
            {

                driver.Navigate().GoToUrl("https://www.innovination.com/");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement headerLogo = driver.FindElement(By.XPath("(//div[contains(@class, 'header_area_container')]//img[contains(@src, 'logo-header')])[1]"));

                Boolean isLogoDisplayed = headerLogo.Displayed;
                if (isLogoDisplayed)
                {
                    Console.WriteLine("Logo is displayed");
                }
                else
                {
                    Console.WriteLine("Logo is not displayed");
                }
                // Assert.That(headerLogo, Is.EqualTo(true), $"Expected {true}");
                // Assert.That(true, Is.Equals(headerLogo));
                // Assert.AreEqual(true, headerLogo.Displayed);
                // validateElements(headerLogo);
                Actions action = new Actions(driver);
                IWebElement element = driver.FindElement(By.XPath("(//div[contains(@class, 'header_area_container')]//li[contains(@id, 'menu-item')]//span[contains(text(), 'Services')])[1]"));
                // var elements = wait.Until(element..ElementIsVisible(By.Id(elementId)));
                action.MoveToElement(element).Perform();
                driver.FindElement(By.XPath("//*[text() = \"Website Development\"]")).Click();
                // Assert.Equals()
                //(//div[contains(@class, 'header_area_container')]//li[contains(@id, 'menu-item')]//span[contains(text(), 'Services')])[1]
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Test]
        public void ValidateTopHeaderMenus()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.innovination.com/");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement emailElement = driver.FindElement(By.XPath("//div[contains(@class, 'header_area_container')]//div[contains(@class, 'wrapper')]//a[contains(@href, 'info@innovination.com')]"));
                IWebElement phoneElement = driver.FindElement(By.XPath("//div[contains(@class, 'header_area_container')]//div[contains(@class, 'wrapper')]//a[contains(@href, '9903842429')]"));
                IWebElement partnerWithUsElement = driver.FindElement(By.XPath("//div[contains(@class, 'header_area_container')]//div[contains(@class, 'wrapper')]//a[contains(@href, 'https://vendors.innovination.com/vendor-registration')]"));
                IWebElement facebookElement = driver.FindElement(By.XPath("//div[contains(@class, 'header_area_container')]//div[contains(@class, 'wrapper')]//a[contains(@href, 'facebook.com')]"));
                IWebElement linkedInElement = driver.FindElement(By.XPath("//div[contains(@class, 'header_area_container')]//div[contains(@class, 'wrapper')]//a[contains(@href, 'linkedin.com')]"));
                IWebElement instagramElement = driver.FindElement(By.XPath("//div[contains(@class, 'header_area_container')]//div[contains(@class, 'wrapper')]//a[contains(@href, 'instagram.com')]"));
                IWebElement indiaElement = driver.FindElement(By.XPath("//div[contains(@class, 'header_area_container')]//div[contains(@class, 'wrapper')]//img[contains(@src, 'india-map')]"));
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [Test]
        public void ValidateSecondaryHeaderIsSticky()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.innovination.com/");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,1000)");
                // Thread.Sleep(2000);

                IWebElement emailElement = driver.FindElement(By.XPath("(//div[contains(@class, 'header_area_container')]//nav[contains(@class, 'primary-nav')])[1]"));
                // Thread.Sleep(2000);

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [Test]
        public void ValidateSecondaryHeaderMenus()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.innovination.com/");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                string jsonFilePath = @"..\..\..\data.json";
                // var jsonString = File.ReadAllText(@"..\..\..\data.json");
                string jsonContent = File.ReadAllText(jsonFilePath);

                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonContent);
                foreach (NavItem navItem in rootObject.NavItems)
                {
                    IWebElement element = driver.FindElement(By.XPath($"(//div[contains(@class, 'header_area_container')]//li[contains(@id, 'menu-item')]//span[contains(text(), '{navItem.Name}')])[1]"));
                    Actions action = new Actions(driver);
                    action.MoveToElement(element).Perform();
                    Thread.Sleep(500);
                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }


        public class RootObject
        {
            public List<NavItem> NavItems { get; set; }
            public List<ContactFormField> ContactFormFields { get; set; }
        }
        public class NavItem
        {
            public string Name { get; set; }
        }

        public class ContactFormField
        {
            public string Name { get; set; }
        }

    }
}


// top header
// secondary header
// footer
// make the file structure correct