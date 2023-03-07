using System.Collections.ObjectModel;
using System.Drawing;
using Core.Interfaces;
using OpenQA.Selenium;

namespace Core.WebDriver.Elements;

public abstract class BaseCustomElement : ICustomsElement
{
    public abstract IWebElement GetWebDriverElement();
    public abstract void ContextClick();

    public void Click()
    {
        GetWebDriverElement().Click();
    }

    public bool Displayed()
    {
        return GetWebDriverElement().Displayed;
    }
}