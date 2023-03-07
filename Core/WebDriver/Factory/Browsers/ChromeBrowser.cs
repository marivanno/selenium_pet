using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.WebDriver.Factory.Browsers;

public class ChromeBrowser : BrowserType
{
    protected override IWebDriver InitDriver()
    {
        var service = ChromeDriverService.CreateDefaultService();
        var option = new ChromeOptions();
        /*option.AddArguments("headless");*/
        _driver = new ChromeDriver(service, option);
        return _driver;
    }
}