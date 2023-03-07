using OpenQA.Selenium;

namespace Core.WebDriver.Elements;

public class InputElement: CustomElement
{
    public InputElement(By locator, string nameOfElement, IWebDriver driver) : base(locator, nameOfElement, driver)
    {
    }
}