using Core;
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
public class SendEmailTests : BaseUITest
{
    private User _user;
    private Email _email;
    private IWebDriver _driver;
    private HomePage _homePage;
    private PersonalAreaPage _personalAreaPage;

    [SetUp]
    public void SetupTest()
    {
        Browser.Init(TestContext.CurrentContext.Test.Name);
        _driver = Browser.GetDriver(TestContext.CurrentContext.Test.Name);
        _homePage = new HomePage(_driver);
        _personalAreaPage = new PersonalAreaPage(_driver);
        _email = DataFactory.Email;
        _user = DataFactory.ValidUser;
        _homePage.Open();
        _homePage.SignIn(_user);
        _personalAreaPage.WriteEmail(_email.emailAddress, _email.subject, _email.body);
        _personalAreaPage.SendEmailButton.Click();
        _personalAreaPage.PopUpCloseButton.Click();
    }

    [Test]
    public void EmailDisappearedInDraftFolder()
    {
        var driver = Browser.GetDriver(TestContext.CurrentContext.Test.Name);
        var personalAreaPage = new PersonalAreaPage(driver);
        personalAreaPage.DraftFolderButton.JsClick();
        var isExpectedInDraftFolder = personalAreaPage.CheckTextOnCurrentPage(_email.emailAddress);
        isExpectedInDraftFolder.Should().BeFalse();
    }

    [Test]
    public void EmailIsInSentFolder()
    {
        var driver = Browser.GetDriver(TestContext.CurrentContext.Test.Name);
        var personalAreaPage = new PersonalAreaPage(driver);
        personalAreaPage.SentFolderButton.JsClick();
        var expectedEmailFromSentFolder = personalAreaPage.ElementEmailByUniqEmailAddress(_email.emailAddress);
        expectedEmailFromSentFolder.Displayed.Should().BeTrue();
    }
}