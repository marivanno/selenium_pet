using OpenQA.Selenium;

namespace Businesslogic.Pages;

public partial class SettingsPage
{
    private By ColorBrownButtonLocator => By.XPath("//div[@data-test-id='themes-item-t4001']");
    private By ColorGreenButtonLocator => By.XPath("//div[@data-test-id='themes-item-t4008']");
    private By ColorBlueButtonLocator => By.XPath("//div[@data-test-id='themes-item-t4005']");
    private By ColorRedButtonLocator => By.XPath("//div[@data-test-id='themes-item-t4007']");
}