using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.WebDriver.Elements;

public class CustomElement : BaseCustomElement
{
    public IWebElement WebDriverElement;
    public IJavaScriptExecutor CurrentJsExecutor;
    public IWebDriver CurrentDriver;
    protected string nameOfElement;
    protected Logger logger; 
    
    public CustomElement(By locator, string nameOfElement, IWebDriver driver)
    {
        logger = LogManager.GetCurrentClassLogger();
        CurrentDriver = driver;
        CurrentJsExecutor = (IJavaScriptExecutor)CurrentDriver;
        WebDriverElement = CurrentDriver.FindElement(locator);
        this.nameOfElement = nameOfElement;
    }

    public override void ContextClick() => new Actions(CurrentDriver)
        .ContextClick(WebDriverElement)
        .Perform();
    
    public override IWebElement GetWebDriverElement() => WebDriverElement;

    public void Click()
    {
        WebDriverElement.Click();
        logger.Info($"Click on {nameOfElement}");
    }

    public void SendKeys(string keys)
    {
        WebDriverElement.SendKeys(keys);
        logger.Info($"Send text to {nameOfElement}");
    }
}