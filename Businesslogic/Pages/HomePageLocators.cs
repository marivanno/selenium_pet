using OpenQA.Selenium;

namespace Businesslogic.Pages;

public partial class HomePage
{
    private By SignInButtonLocator => By.XPath("//button[contains(text(), 'Войти')]");
    private By UserNameInputLocator  => By.CssSelector("input[name='username']");
    private By PasswordInputLocator  => By.CssSelector("input[name='password']");
    private By SubmitButtonLocator  => By.CssSelector("button[data-test-id='submit-button']");
    private By NextButtonLocator  => By.CssSelector("button[data-test-id='next-button']");
    private By PopUpNewEmailLocator => By.ClassName("ag-popup__frame__layout__iframe");
}