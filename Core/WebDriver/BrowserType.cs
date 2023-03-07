using OpenQA.Selenium;

namespace Core.WebDriver;

public abstract class BrowserType
{
    public IWebDriver driver;
    protected BrowserType()
    {
        driver = InitDriver();
    }
    protected IWebDriver _driver;
    protected abstract IWebDriver InitDriver();
}