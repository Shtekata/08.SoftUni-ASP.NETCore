using ForumSystem.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Xunit;

namespace ForumSystem.Services.Tests
{
    public class SeleniumHomePageTests
    {
        private RemoteWebDriver browser;
        private SeleniumServerFactory<Startup> serverFactory;

        public SeleniumHomePageTests()
        {
            this.serverFactory = new SeleniumServerFactory<Startup>();
            serverFactory.CreateClient();
            var options = new ChromeOptions();
            options.AddArguments("--headless", "--no-sandbox", "--ignore-certificate-errors");
            this.browser = new RemoteWebDriver(options);
        }

        [Fact]
        public void HomePageShouldHaveH1Tag()
        {
            this.browser.Navigate().GoToUrl(serverFactory.RootUri + "/Home/Index");
            //Assert.Contains("Welcome to", this.browser.FindElementByCssSelector("h1").Text);
            var headerSelector = By.TagName("h1");
            Assert.Equal("Welcome to ForumSystem!", browser.FindElement(headerSelector).Text);
            Assert.StartsWith("Welcome", browser.Title);
        }
    }
}
