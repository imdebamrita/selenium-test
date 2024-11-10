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
    public class ContactUsTests
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
        public void ValidateHeaderMenus()
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

        [Test]
        [Category("ValidateContactPage")]
        public void ValidateContactPage()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.innovination.com");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("(//div[contains(@class, 'header_area_container')]//li[contains(@id, 'menu-item')]//span[contains(text(), 'Contact Us')])[1]")).Click();
                Thread.Sleep(5000);

                string jsonFilePath = @"..\..\..\data.json";
                // var jsonString = File.ReadAllText(@"..\..\..\data.json");
                string jsonContent = File.ReadAllText(jsonFilePath);

                IWebElement sideElement = driver.FindElement(By.XPath("(//div[contains(@id, 'main-content')]//div[contains(@class, 'vc')]//div[contains(@class, 'wpb')])[1]"));

                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonContent);
                foreach (ContactFormField contactFormField in rootObject.ContactFormFields)
                {
                    IWebElement formElement = driver.FindElement(By.XPath($"(//form//div[contains(@class, 'zcwf_row')]//label[contains(text(), '{contactFormField.Name}')])"));
                    Actions action = new Actions(driver);
                    action.MoveToElement(formElement).Perform();
                }

                IWebElement captcha = driver.FindElement(By.XPath("(//div[contains(@id, 'main-content')]//div[contains(@class, 'zcwf_row')]//div[contains(@class, 'g-recaptcha')])"));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [AttributeUsage(AttributeTargets.Method, Inherited = false)]
        public class TestContactPageAttribute : Attribute
        {
            public string Name { get; }

            public TestContactPageAttribute(string name)
            {
                Name = name;
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
