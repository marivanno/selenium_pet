using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Core.WebDriver.Factory.Browsers;

public class RemoteChromeBrowser : BrowserType
{
    protected override IWebDriver InitDriver()
    {
        var option = new FirefoxOptions();
        _driver = new RemoteWebDriver(new Uri("http://localhost:4444"), option.ToCapabilities());
        return _driver;
    }
}