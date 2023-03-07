using OpenQA.Selenium;

namespace Core.WebDriver.Elements;

public class FolderElement : CustomElement
{
    public FolderElement(By locator, string nameOfElement, IWebDriver driver) : base(locator, nameOfElement, driver)
    {
    }

    public void JsClick()
    {
        CurrentJsExecutor.ExecuteScript("arguments[0].click();", WebDriverElement);
        logger.Info($"Click on --{nameOfElement}-- button");
    }
}