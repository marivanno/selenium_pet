using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.WebDriver;

public partial class Browser
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public static void DragAndDrop(IWebElement dragElement, IWebElement dropElement, string name)
    {
        new Actions(GetDriver(name))
            .DragAndDrop(dragElement, dropElement)
            .Perform();
        logger.Info("Move element by mouse(DragAndDrop)");
    }
}