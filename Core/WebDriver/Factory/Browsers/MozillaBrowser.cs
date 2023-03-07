using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Core.WebDriver.Factory.Browsers;

public class MozillaBrowser : BrowserType
{
    protected override IWebDriver InitDriver()
    {
        var service = FirefoxDriverService.CreateDefaultService();
        var option = new FirefoxOptions();
        _driver = new FirefoxDriver(service, option);
        return _driver;
    }
}