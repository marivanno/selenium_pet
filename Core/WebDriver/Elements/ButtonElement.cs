using OpenQA.Selenium;

namespace Core.WebDriver.Elements;

public class ButtonElement : CustomElement
{
    public ButtonElement(By locator, string nameOfElement, IWebDriver driver) : base(locator, nameOfElement, driver)
    {
    }
}