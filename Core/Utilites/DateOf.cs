using System.Reflection;

namespace Core;

public static class Date
{
    public static string DateForScreenShot =>
        $"{DateTime.Now.DayOfWeek} " +
        $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} " +
        $"{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Millisecond}";
}