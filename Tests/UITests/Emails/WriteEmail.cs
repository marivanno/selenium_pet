using Core.BaseTests;
using Core.BusinessObjects;
using Core.WebDriver;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using HomePage = Businesslogic.Pages.HomePage;
using PersonalAreaPage = Businesslogic.Pages.PersonalAreaPage;

namespace Tests.UITests.Emails;

[TestFixture]
public class WriteAndSaveEmailInDraftFolderTest : BaseUITest
{
    private PersonalAreaPage _personalAreaPage;
    private HomePage _homePage;
    private User _user;
    private Email _email;
    private IWebDriver _driver;

    [SetUp]
    public void SetupTest()
    {
        Browser.Init(TestContext.CurrentContext.Test.Name);
        _email = DataFactory.Email;
        _user = DataFactory.ValidUser;
        _driver = Browser.GetDriver(TestContext.CurrentContext.Test.Name);
        _homePage = new HomePage(_driver);
        _personalAreaPage = new PersonalAreaPage(_driver);
        _homePage.Open();
        _homePage.SignIn(_user);
        _personalAreaPage.AcceptPrivacyRuleButton.Click();
    }

    [Test]
    [Ignore("something wrong")]
    public void SignedInToPersonalAccount()
    {
        var expectedUniqElementIntoPersonalAreaPage = _personalAreaPage.InputFolderButton;
        expectedUniqElementIntoPersonalAreaPage.Displayed().Should().BeTrue();
    }
    
    [Test]
    [Ignore("something wrong")]
    public void EmailSavedIntoDraftFolder()
    {
        _personalAreaPage.WindowWithOfferToMakeStartPageMailRuButtonClose.Click();
        _personalAreaPage.WriteEmail(_email.emailAddress, _email.subject, _email.body);
        _personalAreaPage.SaveNewEmailButton.Click();
        _personalAreaPage.CloseNewEmailButton.Click();
        _personalAreaPage.DraftFolderButton.JsClick();
        var expectedElementEmailInDraftFolder =
            _personalAreaPage.ElementEmailByUniqEmailAddress(_email.emailAddress);
        expectedElementEmailInDraftFolder.Displayed.Should().BeTrue();
        _personalAreaPage.ElementEmailLetterByUniqSubject(_email.body).Click();
        var expectedDataFromOpenEmailInDraftFolder = new List<bool>
        {
            _personalAreaPage.EmailEmailAddressByUniqId(_email.emailAddress).Displayed,
            _personalAreaPage.ElementEmailSubjectByUniqId(_email.subject).Displayed,
            _personalAreaPage.ElementEmailBodyByUniqId(_email.body).Displayed,
        };
        expectedDataFromOpenEmailInDraftFolder.Any(element => element).Should().BeTrue();
    }
    
    [Test]
    [Ignore("something wrong")]
    public void ScrolledUpByButton()
    {
        _personalAreaPage.DraftFolderButton.JsClick();
        _personalAreaPage.FirstEmailFromCurrentFolder.MoveMouseToElement();
        _personalAreaPage.ScrollToLastEmail();
        var expectedScrollUpButton = _personalAreaPage.ScrollUpButton;
        expectedScrollUpButton.Displayed().Should().BeTrue();
    }
}