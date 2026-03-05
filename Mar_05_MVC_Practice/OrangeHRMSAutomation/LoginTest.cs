//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace OrangeHRMSAutomation
//{
//    public class LoginTest
//    {
//        private IWebDriver? driver;

//        [SetUp]
//        public void StartBrowser()
//        {
//            driver = new ChromeDriver(@"E:\Selenium\chromedriver-win64");
//            driver.Manage().Window.Maximize();

//            //TEST_1
//            //driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");


//            //TEST_2
//            //driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");


//            //TEST_3 for Leetcode
//            driver.Navigate().GoToUrl("https://leetcode.com/accounts/login");

//            Thread.Sleep(3000); // wait for page load
//        }


//        //Code of TEST_1
//        [Test]
//        public void LoginToOrangeHRMS()
//        {
//            driver!.FindElement(By.Name("username")).SendKeys("Admin");
//            driver.FindElement(By.Name("password")).SendKeys("admin123");
//            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

//            Thread.Sleep(300000);

//            Assert.That(driver.Url.Contains("dashboard"));
//        }
//        //Code of TEST_2

//        //public void LoginToHerokuApp()
//        //{
//        //    // Open website
//        //    driver!.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

//        //    // Enter username
//        //    driver.FindElement(By.Id("username")).SendKeys("tomsmith");

//        //    // Enter password
//        //    driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");

//        //    // Click login
//        //    driver.TIindElement(By.CssSelector("button[type='submit']")).Click();

//        //    Thread.Sleep(3000);

//        //    // Verify success message
//        //    string message = driver.FindElement(By.Id("flash")).Text;

//        //    Assert.That(message.Contains("You logged into a secure area"));
//        //}

//        //Code of TEST_3 for Leetcode
//        [Test]
//        public void LoginToLeetCode()
//        {
//            // Open LeetCode login page
//            driver!.Navigate().GoToUrl("https://leetcode.com/accounts/login");

//            Thread.Sleep(4000);

//            // Enter Email / Username
//            driver.FindElement(By.Id("id_login")).SendKeys("mukesh704swami@gmail.com");

//            // Enter Password
//            driver.FindElement(By.Id("id_password")).SendKeys("Leetcode@0612");

//            // Click Sign In button
//            driver.FindElement(By.Id("signin_btn")).Click();

//            Thread.Sleep(5000);

//            // Verify login by checking URL
//            Assert.That(driver.Url.Contains("leetcode"));
//        }


//        [Test]


//        [TearDown]
//        public void EndTest()
//        {
//            driver?.Quit();
//            driver?.Dispose();
//        }
//    }
//}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumLeetCodeTest
{
    public class LeetCodeLoginTest
    {
        private IWebDriver? driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"E:\Selenium\chromedriver-win64");
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://leetcode.com/accounts/login");

            Thread.Sleep(4000); // wait for page load
        }

        [Test]
        public void LoginToLeetCode()
        {
            // Enter Email / Username
            driver!.FindElement(By.Id("id_login")).SendKeys("mukesh704swami@gmail.com");

            // Enter Password
            driver.FindElement(By.Id("id_password")).SendKeys("Leetcode@0612");

            // Click Sign In
            driver.FindElement(By.Id("signin_btn")).Click();

            Thread.Sleep(500000);

            // Verify page loaded
            Assert.That(driver.Url.Contains("leetcode"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}