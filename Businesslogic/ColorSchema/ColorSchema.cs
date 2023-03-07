using OpenQA.Selenium;

namespace Businesslogic.ColorSchema;

public class ColorSchema : BaseColorSchema
{
    protected string ExpectedColor;
    private readonly IWebElement _element;

    protected ColorSchema(IWebElement element, IWebDriver driver) : base(driver)
    {
        _element = element;
    }

    public override bool ValidateColor() => ExpectedColor == GetColor();

    public override string GetColor()
    {
        return _element.GetCssValue("backgroundColor");
    }
}