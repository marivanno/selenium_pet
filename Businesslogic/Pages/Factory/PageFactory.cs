using Core.Enums;
using Core.WebDriver;
using NUnit.Framework;

namespace Businesslogic.Pages.Factory;

public static class PageFactory
{
    private static BasePage _page;
    public static BasePage GetPage(PageNames name)
    {
        _page = name switch
        {
            PageNames.home => new HomePage(Browser.GetDriver(TestContext.CurrentContext.Test.Name)),
            PageNames.PersonalArea => new PersonalAreaPage(Browser.GetDriver(TestContext.CurrentContext.Test.Name)),
            _ => _page
        };
        return _page;
    }
}