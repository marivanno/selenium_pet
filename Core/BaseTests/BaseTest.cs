using NLog;
using NUnit.Framework;

namespace Core.BaseTests;

public abstract class BaseTest
{
    protected static readonly Logger logger = LogManager.GetCurrentClassLogger();
    [SetUp]
    public abstract void InitTest();

    [TearDown]
    public abstract void CleanTest();
}