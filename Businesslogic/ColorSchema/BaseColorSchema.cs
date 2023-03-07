using Businesslogic.Pages;
using OpenQA.Selenium;

namespace Businesslogic.ColorSchema;

public abstract class BaseColorSchema : BasePage
{
    public BaseColorSchema(IWebDriver driver) : base(driver)
    {
    }
    public abstract bool ValidateColor();
    public abstract string GetColor();
}