using System.Collections.Concurrent;
using Core.Enums;
using Core.WebDriver.Factory;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.WebDriver;

public static partial class Browser
{
    public static readonly ConcurrentDictionary<string, IWebDriver> Drivers = new();
   
    public static void Init(string name)
    {
        Drivers.TryAdd(name, DriverFactory.GetDriver(BrowserNames.Chrome, 10));
    }

    public static IWebDriver GetDriver(string name)
    {
        Drivers.TryGetValue(name, out var driver);
        Console.WriteLine($"{name}: {driver.GetHashCode()} thread: {Thread.CurrentThread.Name}");
        return driver;
    }

    public static void CleanAfterTest(string name)
    {
        GetDriver(name).Quit();
    }
}