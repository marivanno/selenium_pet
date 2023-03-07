using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.WebDriver.Elements;

public class EmailElement : CustomElement
{
    public EmailElement(By locator, string nameOfElement, IWebDriver driver) : base(locator, nameOfElement, driver)
    {
    }

    public void MoveAndClickOnCheckbox()
    {
        new Actions(CurrentDriver)
            .MoveToElement(WebDriverElement)
            .Click()
            .Perform();
    }

    public void MoveMouseToElement()
    {
        new Actions(CurrentDriver)
            .MoveToElement(WebDriverElement);
    }
}