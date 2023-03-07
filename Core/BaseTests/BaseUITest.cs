using Core.WebDriver;
using NUnit.Framework;

namespace Core.BaseTests;

public class BaseUITest : BaseTest
{
    [SetUp]
    public override void InitTest()
    {
        logger.Info($"Test {TextEditor.ParseNameOfTestFromContext(TestContext.CurrentContext.Test.FullName)} has started");
    }

    [TearDown]
    public override void CleanTest()
    {
        if (TestContext.CurrentContext.Result.FailCount > 0)
        {
            
            /*Screenshoter.TakeScreenshot(Environment.CurrentDirectory, TestContext.CurrentContext.Test.Name);
            logger.Error($"{TestContext.CurrentContext.Result.Message}\n");*/
        }
        else
        {
            logger.Info($"Test {TextEditor.ParseNameOfTestFromContext(TestContext.CurrentContext.Test.FullName)} passed\n");
        }
        Browser.CleanAfterTest(TestContext.CurrentContext.Test.Name);
    }
}