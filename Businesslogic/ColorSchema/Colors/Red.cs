using OpenQA.Selenium;

namespace Businesslogic.ColorSchema.Colors;

public class Red : ColorSchema
{
    public Red(IWebElement element, IWebDriver driver) : base(element, driver)
    {
        ExpectedColor = "rgba(183, 48, 38, 1)";
    }
}