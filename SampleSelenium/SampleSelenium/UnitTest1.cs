using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace SampleSelenium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // 2. Go to the "Google" homepage
            driver.Navigate().GoToUrl("http://www.gmail.com");
        }
    }
}
