using Core.BusinessObjects;
using Core.WebDriver.Elements;
using NLog;
using OpenQA.Selenium;
using Browser = Core.WebDriver.Browser;

namespace Businesslogic.Pages;

public partial class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver)
    {
    }
    private ButtonElement SignInButton => new(SignInButtonLocator, nameof(SignInButton), CurrentDriver);
    private InputElement UserNameInput => new(UserNameInputLocator, nameof(UserNameInput), CurrentDriver);
    private InputElement PasswordInput => new(PasswordInputLocator, nameof(PasswordInput), CurrentDriver);
    private ButtonElement SubmitButton => new(SubmitButtonLocator, nameof(SubmitButton), CurrentDriver);
    private ButtonElement NextButton => new(NextButtonLocator, nameof(NextButton), CurrentDriver);
    
    public void SignIn(User user)
    {
        SignInButton.Click();
        SwitchToIframeWithLoginAndPassword();
        UserNameInput.SendKeys(user.UserName);
        NextButton.Click();
        PasswordInput.SendKeys(user.Password);
        SubmitButton.Click();
        SwitchToDefaultPage();
    }

    private void SwitchToIframeWithLoginAndPassword()
    {
        var frame = CurrentDriver.FindElement(PopUpNewEmailLocator);
        CurrentDriver.SwitchTo().Frame(frame);
    }
}