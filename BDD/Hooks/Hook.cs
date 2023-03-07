using Core.WebDriver;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace BDD.Hooks;

[Binding]
public class Hooks
{
    [BeforeScenario]
    public static void Init()
    {
        Browser.Init(TestContext.CurrentContext.Test.Name);
    }

    [AfterScenario]
    public static void CleanUp()
    {
        Browser.CleanAfterTest(TestContext.CurrentContext.Test.Name);
    }
}