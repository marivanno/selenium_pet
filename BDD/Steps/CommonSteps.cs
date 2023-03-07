using Businesslogic.ColorSchema.Colors;
using Businesslogic.Pages;
using Businesslogic.Pages.Factory;
using Core.BusinessObjects;
using Core.Enums;
using Core.WebDriver;
using FluentAssertions;
using NUnit.Framework;

namespace BDD;

[Binding]
public class CommonSteps
{
    private PersonalAreaPage _personalAreaPage;
    private HomePage _homePage;
    private SettingsPage _settingsPage;
    private User _user;
    private Email _email;

    [Given(@"I am on the '(.*)' page")]
    public void GoToPage(string pageName)
    {
        var page = (PageNames)Enum.Parse(typeof(PageNames), pageName, true);
        PageFactory.GetPage(page).Open();
    }

    [When(@"Login with '(.*)' from Pre-condition")]
    public void Login(string user)
    {
        _homePage = new HomePage(Browser.GetDriver(TestContext.CurrentContext.Test.Name));
        switch (user)
        {
            case "valid user":
            {
                _homePage.SignIn(DataFactory.ValidUser);
                _personalAreaPage = new PersonalAreaPage(Browser.GetDriver(TestContext.CurrentContext.Test.Name));
            } break;
            case "invalid user":
            {
                _homePage.SignIn(DataFactory.InvalidUser);
                _personalAreaPage = new PersonalAreaPage(Browser.GetDriver(TestContext.CurrentContext.Test.Name));
            } break;
        }
    }

    [When(@"I Accept privacy rule")]
    public void AcceptPrivacyRule()
    {
        _personalAreaPage.AcceptPrivacyRuleButton.Click();
    }

    [Given(@"I am on the settings page")]
    public void ClickOnSettingsButton()
    {
        _personalAreaPage.SettingsButton.Click();
    }

    [When(@"I choose (.*)")]
    public void ChooseColor(string color)
    {
        _settingsPage = new SettingsPage(Browser.GetDriver(TestContext.CurrentContext.Test.Name));
        switch (color)
        {
            case "Red": _settingsPage.ColorRedButton.Click(); 
                break;
            case "Green": _settingsPage.ColorGreenButton.Click();
                break;
            case  "Brown": _settingsPage.ColorBrownButton.Click();
                break;
            case "Blue": _settingsPage.ColorBlueButton.Click();
                break;
        }
    }

    [Then(@"Colors of my personal area has changed to the right (.*)")]
    public void ColorSchemaSwitchedTheRightColor(string color)
    {
        switch (color)
        {
            case "Red":
            {
                var redColorSchema = new Red(_personalAreaPage.Header, Browser.GetDriver(TestContext.CurrentContext.Test.Name));
                redColorSchema.ValidateColor().Should().BeTrue();
            }
                break;
            case "Green":
            {
                var greenColorSchema = new Green(_personalAreaPage.Header, Browser.GetDriver(TestContext.CurrentContext.Test.Name));
                greenColorSchema.ValidateColor().Should().BeTrue();
            }
                break;
            case "Brown":
            {
                var brownColorSchema = new Brown(_personalAreaPage.Header, Browser.GetDriver(TestContext.CurrentContext.Test.Name));
                brownColorSchema.ValidateColor().Should().BeTrue();
            }
                break;
            case "Blue":
            {
                var blueColorSchema = new Blue(_personalAreaPage.Header, Browser.GetDriver(TestContext.CurrentContext.Test.Name));
                blueColorSchema.ValidateColor().Should().BeTrue();
            }
                break;
        }
    }

    [When(@"I close window to make mail\.ru default page")]
    public void CloseWindowToMakeMailRuDefaultPage()
    {
        _personalAreaPage.WindowWithOfferToMakeStartPageMailRuButtonClose.Click();
    }

    [When(@"I write email with uniq email, subject and body")]
    public void WriteEmail()
    {
        _email = DataFactory.Email;
        _personalAreaPage.WriteEmail(_email.emailAddress, _email.subject, _email.body);
    }

    [When(@"I click send email button")]
    public void ClickSendEmailButton()
    {
        _personalAreaPage.SendEmailButton.Click();
    }

    [When(@"I close Pup up window")]
    public void ClosePupUpWindow()
    {
        _personalAreaPage.PopUpCloseButton.Click();
    }

    [Given(@"I am in personal area page")]
    public void UpdatePage()
    {
        _personalAreaPage.Open();
    }

    [When(@"I click to sent folder button")]
    public void ClickToSentFolderButton()
    {
        _personalAreaPage.DraftFolderButton.Click();
    }

    [Then(@"Draft folder contains expected email")]
    public void IsEmailInSentFolder()
    {
        var isExpectedInDraftFolder = _personalAreaPage.CheckTextOnCurrentPage(_email.emailAddress);
        isExpectedInDraftFolder.Should().BeFalse();
    }

    [Then(@"Pop up window is closed")]
    public void PopUpWindowIsClosed()
    {
        _personalAreaPage.PopUpCloseButton.Displayed().Should().Be(false);
    }
}