using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace ContactFormApp_AutomationTests
{
    public class ContactFormTests
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CheckGoogle()
        {
            //var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            //driver.Quit();
            Assert.Pass();
        }
        
        [Test]
        public void OpenContactPage()
        {
            //var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5100/Home/Contact");
            var title = driver.Title;
            Assert.That(title, Is.EqualTo("Contact"));
            //driver.Quit();
        }
        
        [Test]
        public void ContactPageSubmission()
        {
            //var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5100/Home/Contact");

            //Locate and manipulate elements
            var NameTextBox = driver.FindElement(By.Id("Name"));
            NameTextBox.SendKeys("Khaleelullah Hussaini Syed");

            var EmailTextBox = driver.FindElement(By.Id("Email"));
            EmailTextBox.SendKeys("techiesyed@outlook.com");

            var MessageTextBox = driver.FindElement(By.Id("Message"));
            MessageTextBox.SendKeys("Hello Selenium");

            NameTextBox.Submit();

            var title = driver.Title;

            Assert.That(title, Is.EqualTo("Contact Success"));

            var H1Text = driver.FindElement(By.TagName("h1"));

            Assert.That(H1Text.Text, Is.EqualTo("Thank you for contacting us. Our team will reach out to you on techiesyed@outlook.com"));

            //driver.Quit();
        }
    }
}
