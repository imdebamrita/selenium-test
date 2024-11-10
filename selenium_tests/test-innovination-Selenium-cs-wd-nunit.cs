using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class TestInnovination
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
        public void InnovinationTest()
        {
            // Label: Test
            // ERROR: Caught exception [ERROR: Unsupported command [resizeWindow | 1536,713 | ]]
            driver.Navigate().GoToUrl("https://www.innovination.com/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement headerLogo = driver.FindElement(By.XPath("(//div[contains(@class, 'header_area_container')]//img[contains(@src, 'logo-header')])[1]"));

            Assert.That(headerLogo, Is.EqualTo(true), $"Expected {true}");
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

        public void validateElements(IWebElement headerLogo)
        {
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
