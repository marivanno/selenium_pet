using Core.BaseTests;
using Core.BusinessObjects;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Browser = Core.WebDriver.Browser;
using HomePage = Businesslogic.Pages.HomePage;
using PersonalAreaPage = Businesslogic.Pages.PersonalAreaPage;

namespace Tests.UITests.Emails;
[TestFixture]
public class MoveEmailToFolder : BaseUITest
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
        _user = DataFactory.ValidUser;
        _email = DataFactory.Email;
        _driver = Browser.GetDriver(TestContext.CurrentContext.Test.Name);
        _homePage = new HomePage(_driver);
        _personalAreaPage = new PersonalAreaPage(_driver);
        _homePage.Open();
        _homePage.SignIn(_user);
        _personalAreaPage.WindowWithOfferToMakeStartPageMailRuButtonClose.Click();
        _personalAreaPage.CreateNewFolderWithName("Important");
        _personalAreaPage.WriteEmail(_email.emailAddress, _email.subject, _email.body);
        _personalAreaPage.SaveNewEmailButton.Click();
        _personalAreaPage.CloseNewEmailButton.Click();
        _personalAreaPage.DraftFolderButton.Click();
    }

    [Test]
    [Ignore("something wrong")]
    public void EmailMovedToImportantFolderByContextClick()
    {
        logger.Info($"Verify that we can move email to folder by context click");
        _personalAreaPage.MoveEmailToFolder(_email.subject, "Important");
        _personalAreaPage.FolderByName("Important").Click();
        var expectedEmailFromFolderImportant = _personalAreaPage.ElementEmailLetterByUniqSubject(_email.subject);
        expectedEmailFromFolderImportant.GetWebDriverElement().Displayed.Should().BeTrue();
    }
    
    [Test]
    [Ignore("something wrong")]
    public void EmailMovedToImportantFolderByMouse()
    {
        logger.Info($"Verify that we can move email to folder by mouse");
        var folderImportant = _personalAreaPage.FolderByName("Important")
            .GetWebDriverElement();
        var email = _personalAreaPage.ElementEmailLetterByUniqSubject(_email.subject)
            .GetWebDriverElement();
        Browser.DragAndDrop(email, folderImportant, TestContext.CurrentContext.Test.Name);
        _personalAreaPage.FolderByName("Important").JsClick();
        var expectedEmailFromFolderImportant = _personalAreaPage.ElementEmailLetterByUniqSubject(_email.subject);
        expectedEmailFromFolderImportant.Displayed().Should().BeTrue();
    }

    [Test]
    public void EmailMovedToTrashFolderByKeyDelete()
    {
        _personalAreaPage.CheckBoxOfEmailByUniqSubject(_email.subject).MoveAndClickOnCheckbox();
        _personalAreaPage.KeyDownDelete();
        _personalAreaPage.ScrollToLastEmail();
        _personalAreaPage.AcceptPrivacyRuleButton.Click();
        _personalAreaPage.ScrollUpButton.Click();
        _personalAreaPage.FolderByName("Корзина").JsClick();
        var expectedEmailFromTrashFolder = _personalAreaPage.ElementEmailLetterByUniqSubject(_email.subject);
        expectedEmailFromTrashFolder.Displayed().Should().BeTrue();
    }
    
    [Test]
    public void CreatedNewFolder()
    {
        var expectedFolderInPersonalAria = _personalAreaPage.FolderByName("Important");
        expectedFolderInPersonalAria.GetWebDriverElement().Displayed.Should().BeTrue();
    }

    [TearDown]
    public void RemoveFolderImportant()
    {
        if (_personalAreaPage.CheckTextOnCurrentPage("Important"))
        {
            _personalAreaPage.RemoveFolderByName("Important");
        }
    }
}