using OpenQA.Selenium;
using Browser = Core.WebDriver.Browser;

namespace Businesslogic.Pages;

public partial class SettingsPage : BasePage
{
    public SettingsPage(IWebDriver driver) : base(driver)
    {
    }
    public IWebElement ColorBrownButton => CurrentDriver.FindElement(ColorBrownButtonLocator);
    public IWebElement ColorGreenButton => CurrentDriver.FindElement(ColorGreenButtonLocator);
    public IWebElement ColorBlueButton => CurrentDriver.FindElement(ColorBlueButtonLocator);
    public IWebElement ColorRedButton => CurrentDriver.FindElement(ColorRedButtonLocator);
}