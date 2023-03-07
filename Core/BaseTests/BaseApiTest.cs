using NUnit.Framework;

namespace Core.BaseTests;

public class BaseApiTest : BaseTest
{
    public override void InitTest()
    {
        logger.Info($"Test {TextEditor.ParseNameOfTestFromContext(TestContext.CurrentContext.Test.FullName)} has started");
        logger.Info($"Request to server has sent");
    }

    [TearDown]
    public override void CleanTest()
    {
        if (TestContext.CurrentContext.Result.FailCount > 0)
        {
            logger.Error($"{TestContext.CurrentContext.Result.Message}\n");
        }
        else
        {
            logger.Info($"Test {TextEditor.ParseNameOfTestFromContext(TestContext.CurrentContext.Test.FullName)} passed\n");
        }
    }
}