using OpenQA.Selenium;

namespace Businesslogic.ColorSchema.Colors;

public class Brown : ColorSchema
{
    public Brown(IWebElement element, IWebDriver driver) : base(element, driver)
    {
        ExpectedColor = "rgba(41, 27, 24, 1)";
    }
}