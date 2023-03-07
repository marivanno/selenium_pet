using Core.WebDriver;
using OpenQA.Selenium;

namespace Businesslogic.Pages;

public partial class PersonalAreaPage
{
    private By NewEmailButtonLocator => By.ClassName("compose-button__wrapper");
    private By EmailAddressInputLocator => By.XPath("//div[@class='head_container--3W05z']//input");
    private By SubjectInputLocator => By.XPath("//div[@class='subject__container--HWnat']//input");
    private By BodyOfEmailInputLocator => By.CssSelector("div[contenteditable='true']");
    private By CloseButtonLocator => By.ClassName("ph-project-promo-close-icon__container");
    private By InputFolderButtonLocator => By.XPath("//div[text()='Входящие']");
    private By SentFolderButtonLocator => By.XPath("//div[text()='Отправленные']");
    private By DraftFolderButtonLocator => By.XPath("//div[text()='Черновики']");
    private By SaveEmailButtonLocator => By.CssSelector("button[data-test-id='save']");
    private By CloseEmailButtonLocator => By.XPath("//button[@title='Закрыть']");
    private By ElementEmailSubjectByUniqIdLocator(String subject) => By.XPath($"//input[@value='{subject}']");
    private By EmailEmailAddressByUniqIdLocator(String emailAddress) => By.XPath($"//span[text()='{emailAddress}']");

    private By ElementEmailBodyByUniqIdLocator(String bodyOfEmail) =>
        By.XPath($"//div[contains(text(), '{bodyOfEmail}')]");

    private By ElementEmailByUniqEmailAddressLocator(String emailAddress) =>
        By.CssSelector($"span[title='{emailAddress}']");
    private By SendEmailButtonLocator => By.CssSelector("button[data-test-id='send']");
    private By PopUpCloseButtonLocator => By.CssSelector("span[title='Закрыть']");
    private By NewFolderLocator => By.XPath("//div[text()='Новая папка']");
    private By NewFolderNameInputLocator => By.XPath("//input[@data-test-id='name']");
    private By AddNewFolderButtonLocator => By.XPath("//span[text()='Добавить папку']");

    private By FolderByNameLocator(String name) =>
        By.XPath($"//div[@class='nav__folder-name__txt' and text()='{name}']");

    private By MoveToTheFolderButtonLocator =>
        By.XPath("//span[@class='list-item__text' and text()='Переместить в папку']");
    private By FolderByNameButtonLocator(String name) => By.XPath($"//div[@title='{name}']");
    private By RemoveFolderButtonLocator => By.CssSelector("[data-qa-id='delete']");
    private By PopUpRemoveFolderButtonLocator => By.XPath("//div[@class='button2__txt' and text()='Удалить']");
    private By ElementEmailLetterByUniqSubjectLocator(String subject) => By.XPath($"//span[text()='{subject}']");
    private By PrivacyRoleButtonLocator => By.Id("cmpbntyestxt");
    private By ScrollUpButtonLocator => By.XPath("//span[@title='Наверх']");
    private By FirstEmailLocator => By.CssSelector("div[class='llc__container']");

    private By CheckboxOfEmailLocator(String subject) =>
        By.XPath($"//span[text()='{subject}']//ancestor::a//span[@class='ll-av__checkbox']");

    private By SettingsButtonLocator => By.ClassName("js-promo-id_settings");
    private By HeaderLocator => By.CssSelector("#app-canvas .portal-menu");

    public override void Open()
    {
        CurrentDriver.Navigate().GoToUrl("https://e.mail.ru/messages/");
    }
}