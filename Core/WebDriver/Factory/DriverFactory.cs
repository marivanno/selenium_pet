using Core.Enums;
using Core.WebDriver.Factory.Browsers;
using OpenQA.Selenium;

namespace Core.WebDriver.Factory;

public static class DriverFactory
{
    private static IWebDriver _driver;
    public static IWebDriver GetDriver(BrowserNames name, int timeOut)
    {
        _driver = name switch
        {
            BrowserNames.Chrome => new ChromeBrowser().driver,
            BrowserNames.FireFox => new MozillaBrowser().driver,
            BrowserNames.RemoteFirefox => new RemoteMozillaBrowser().driver,
            BrowserNames.RemoteChrome => new RemoteChromeBrowser().driver,
            _ => _driver
        };
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
        return _driver;
    }
}