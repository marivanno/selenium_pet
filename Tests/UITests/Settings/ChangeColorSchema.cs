using Businesslogic.ColorSchema.Colors;
using Core.BaseTests;
using Core.BusinessObjects;
using Core.WebDriver;
using FluentAssertions;
using NLog;
using NUnit.Framework;
using HomePage = Businesslogic.Pages.HomePage;
using PersonalAreaPage = Businesslogic.Pages.PersonalAreaPage;
using SettingsPage = Businesslogic.Pages.SettingsPage;

namespace Tests.UITests.Settings;

public class ChangeColorSchema : BaseUITest
{
    private PersonalAreaPage _personalAreaPage;
    private HomePage _homePage;
    private SettingsPage _settingsPage;
    private User _user;

    [SetUp]
    public void SetupTest()
    {
        logger.Info("Test switch color schima started");
        _user = DataFactory.ValidUser;
        _homePage = new HomePage(Browser.GetDriver(TestContext.CurrentContext.Test.Name));
        _homePage.Open();
        _homePage.SignIn(_user);
        _personalAreaPage = new PersonalAreaPage(Browser.GetDriver(TestContext.CurrentContext.Test.Name));
        _personalAreaPage.AcceptPrivacyRuleButton.Click();
        _personalAreaPage.SettingsButton.Click();
        _settingsPage = new SettingsPage(Browser.GetDriver(TestContext.CurrentContext.Test.Name));
    }

    [Test]
    public void ColorSchemaSwitchedToBrown()
    {
        _settingsPage.ColorBrownButton.Click();
        var brownColorSchema = new Brown(_personalAreaPage.Header, Browser.GetDriver(TestContext.CurrentContext.Test.Name));
        brownColorSchema.ValidateColor().Should().BeTrue();
    }
    
    [Test]
    public void ColorSchemaSwitchedToGreen()
    {
        _settingsPage.ColorGreenButton.Click();
        var greenColorSchema = new Green(_personalAreaPage.Header, Browser.GetDriver(TestContext.CurrentContext.Test.Name));
        greenColorSchema.ValidateColor().Should().BeTrue();
    }
    
    [Test]
    public void ColorSchemaSwitchedToBlue()
    {
        _settingsPage.ColorBlueButton.Click();
        var blueColorSchema = new Blue(_personalAreaPage.Header, Browser.GetDriver(TestContext.CurrentContext.Test.Name));
        blueColorSchema.ValidateColor().Should().BeTrue();
    }
    
    [Test]
    public void ColorSchemaSwitchedToRed()
    {
        _settingsPage.ColorRedButton.Click();
        var redColorSchema = new Red(_personalAreaPage.Header, Browser.GetDriver(TestContext.CurrentContext.Test.Name));
        redColorSchema.ValidateColor().Should().BeTrue();
    }
}