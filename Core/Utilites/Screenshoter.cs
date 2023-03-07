using Core.WebDriver;
using OpenQA.Selenium;

namespace Core;

public static class Screenshoter
{
    public static void TakeScreenshot(string path, string name)
    {
        var Screener = (ITakesScreenshot)Browser.GetDriver(name);
        var screenshot = Screener.GetScreenshot();
        screenshot.SaveAsFile($"{path}/Fail_{Date.DateForScreenShot}.png",
            ScreenshotImageFormat.Png);
    }
}