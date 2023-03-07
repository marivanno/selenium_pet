using NLog;
using OpenQA.Selenium;
using Browser = Core.WebDriver.Browser;

namespace Businesslogic.Pages;

public class BasePage
{
    protected IWebDriver CurrentDriver;
    protected IJavaScriptExecutor CurrentJsExecutor;
    protected static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public BasePage(IWebDriver driver)
    {
        CurrentDriver = driver;
    }

    protected void SwitchToDefaultPage()
    {
        CurrentDriver.SwitchTo().DefaultContent();
    }
    public bool CheckTextOnCurrentPage(String text) => CurrentDriver.PageSource.Contains(text);
    public virtual void Open()
    {
        CurrentDriver.Navigate().GoToUrl("https://mail.ru");
        CurrentDriver.Manage().Window.Maximize();
    }
}