using Core.WebDriver.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Browser = Core.WebDriver.Browser;

namespace Businesslogic.Pages;

public partial class PersonalAreaPage : BasePage
{
    public PersonalAreaPage(IWebDriver driver) : base(driver)
    {
    }
    private ButtonElement NewEmailButton => new(NewEmailButtonLocator, nameof(NewEmailButton), CurrentDriver);
    private InputElement EmailInput => new(EmailAddressInputLocator, nameof(EmailInput), CurrentDriver);
    private InputElement SubjectInput => new(SubjectInputLocator, nameof(SubjectInput), CurrentDriver);
    private InputElement BodyOfEmailInput => new(BodyOfEmailInputLocator, nameof(BodyOfEmailInput), CurrentDriver);

    public CustomElement WindowWithOfferToMakeStartPageMailRuButtonClose =>
        new (CloseButtonLocator, nameof(CustomElement), CurrentDriver);

    public FolderElement InputFolderButton => new(InputFolderButtonLocator, nameof(InputFolderButton), CurrentDriver);
    public FolderElement SentFolderButton => new(SentFolderButtonLocator, nameof(SentFolderButton), CurrentDriver);
    public FolderElement DraftFolderButton => new(DraftFolderButtonLocator, nameof(DraftFolderButton), CurrentDriver);
    public ButtonElement SaveNewEmailButton => new(SaveEmailButtonLocator, nameof(SaveNewEmailButton), CurrentDriver);
    public ButtonElement CloseNewEmailButton => new(CloseEmailButtonLocator, nameof(CloseNewEmailButton), CurrentDriver);

    public IWebElement ElementEmailSubjectByUniqId(String subject) =>
        CurrentDriver.FindElement(ElementEmailSubjectByUniqIdLocator(subject));

    public IWebElement ElementEmailBodyByUniqId(String bodyOfEmail) =>
        CurrentDriver.FindElement(ElementEmailBodyByUniqIdLocator(bodyOfEmail));

    public IWebElement EmailEmailAddressByUniqId(String emailAddress) =>
        CurrentDriver.FindElement(EmailEmailAddressByUniqIdLocator(emailAddress));

    public IWebElement ElementEmailByUniqEmailAddress(String emailAddress) =>
        CurrentDriver.FindElement(ElementEmailByUniqEmailAddressLocator(emailAddress));

    public ButtonElement SendEmailButton => new(SendEmailButtonLocator, nameof(SendEmailButton), CurrentDriver);

    public ButtonElement PopUpCloseButton =>
        new(PopUpCloseButtonLocator, nameof(PopUpCloseButton), CurrentDriver);

    private ButtonElement NewFolderButton => new(NewFolderLocator, nameof(NewFolderButton), CurrentDriver);

    private InputElement NewFolderNameInput => new(NewFolderNameInputLocator, nameof(NewFolderNameInput), CurrentDriver);

    private ButtonElement AddNewFolderButton =>
        new(AddNewFolderButtonLocator, nameof(AddNewFolderButton), CurrentDriver);

    private ButtonElement MoveToTheFolderButton =>
        new(MoveToTheFolderButtonLocator, nameof(MoveToTheFolderButton), CurrentDriver);

    private ButtonElement FolderByNameButton(String name) =>
        new(FolderByNameButtonLocator(name), $"{nameof(FolderByNameButton)} - name", CurrentDriver);

    private ButtonElement RemoveFolderButton =>
        new (RemoveFolderButtonLocator, nameof(RemoveFolderButton), CurrentDriver);

    private ButtonElement PopUpRemoveFolderButton =>
        new(PopUpRemoveFolderButtonLocator, nameof(PopUpRemoveFolderButton), CurrentDriver);

    public FolderElement FolderByName(String name) => new(FolderByNameLocator(name),$"{nameof(FolderByName)} - name", CurrentDriver);

    public EmailElement ElementEmailLetterByUniqSubject(String subject) =>
        new(ElementEmailLetterByUniqSubjectLocator(subject), $"{nameof(ElementEmailLetterByUniqSubject)} - subject", CurrentDriver);

    public ButtonElement AcceptPrivacyRuleButton => new(PrivacyRoleButtonLocator, nameof(AcceptPrivacyRuleButton), CurrentDriver);
    public ButtonElement ScrollUpButton => new(ScrollUpButtonLocator,nameof(ScrollUpButton), CurrentDriver);
    public EmailElement FirstEmailFromCurrentFolder => new(FirstEmailLocator, nameof(FirstEmailFromCurrentFolder), CurrentDriver);
    public EmailElement CheckBoxOfEmailByUniqSubject(String subject) => 
        new(CheckboxOfEmailLocator(subject), nameof(CheckBoxOfEmailByUniqSubject), CurrentDriver);
    public ButtonElement SettingsButton => new(SettingsButtonLocator, nameof(SettingsButton), CurrentDriver);
    public IWebElement Header => CurrentDriver.FindElement(HeaderLocator);
    public void RemoveFolderByName(String name)
    {
        var folderImportant = FolderByName(name);
        folderImportant.ContextClick();
        RemoveFolderButton.Click();
        PopUpRemoveFolderButton.Click();
    }
    
    public void WriteEmail(String email, String subject, String bodyOfEmail)
    {
        NewEmailButton.Click();
        EmailInput.SendKeys(email);
        SubjectInput.SendKeys(subject);
        BodyOfEmailInput.SendKeys(bodyOfEmail);
    }

    public void CreateNewFolderWithName(String name)
    {
        NewFolderButton.Click();
        NewFolderNameInput.SendKeys(name);
        AddNewFolderButton.Click();
    }

    public void MoveEmailToFolder(String subject, String folderName)
    {
        var emailForMoving = ElementEmailLetterByUniqSubject(subject);
        emailForMoving.ContextClick();
        MoveToTheFolderButton.Click();
        FolderByNameButton(folderName).Click();
    }
    
    public void KeyDownDelete()
    {
        new Actions(CurrentDriver).KeyDown(Keys.Delete).Perform();
    }

    public void ScrollToLastEmail()
    {
        CurrentJsExecutor
            .ExecuteScript(
                "document.querySelector('.ReactVirtualized__Grid__innerScrollContainer')" +
                ".lastElementChild.scrollIntoView({block: 'start'})");
        logger.Info("Scroll to last element into folder");
    }
}