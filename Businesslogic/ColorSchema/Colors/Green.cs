using OpenQA.Selenium;

namespace Businesslogic.ColorSchema.Colors;

public class Green : ColorSchema
{
    public Green(IWebElement element, IWebDriver driver) : base(element, driver)
    {
        ExpectedColor = "rgba(39, 102, 42, 1)";
    }
}