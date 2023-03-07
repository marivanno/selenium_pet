using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
namespace Core.WebDriver.Factory.Browsers;

public class RemoteMozillaBrowser : BrowserType
{
    protected override IWebDriver InitDriver()
    {
        var option = new ChromeOptions();
        _driver = new RemoteWebDriver(new Uri("http://localhost:4444"), option.ToCapabilities());
        return _driver;
    }
}