using OpenQA.Selenium;

namespace Businesslogic.ColorSchema.Colors;

public class Blue : ColorSchema
{
    public Blue(IWebElement element, IWebDriver driver) : base(element, driver)
    {
        ExpectedColor = "rgba(67, 76, 152, 1)";
    }
}