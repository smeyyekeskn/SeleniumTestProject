using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class Tests
    {


        private RemoteWebDriver driver;

        [SetUp]
        public void Setup()
        {
            string driverDirectory = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory))), "Driver");
            driver = new ChromeDriver(driverDirectory);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.n11.com");
        }

        [TearDown]
        public void Close()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }

        [Test]

        public void TestSiteTitle()
        {
            var title = driver.Title;

            Assert.IsTrue(title == "n11.com - Al��veri�in U�urlu Adresi");
        }

        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl("http://www.n11.com/giris-yap");
            Assert.IsTrue(driver.Title == "Giri� Yap - n11.com");

            driver.FindElementById("email").SendKeys("******@*****.com");
            driver.FindElementById("password").SendKeys("***********");
            driver.FindElementById("loginButton").Click();

            var text = driver.FindElementByCssSelector(".menuLink.user").Text;
            Assert.IsTrue(text=="*********");
        }
    }
}
